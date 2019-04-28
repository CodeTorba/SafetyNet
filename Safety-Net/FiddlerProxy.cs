using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fiddler;
using System.Windows.Forms;

namespace Safety_Net
{
    public class FiddlerProxy
    {
        public FrmMain main;
        public FiddlerProxy(FrmMain m)
        {
            main = m;
        }
        public void Start()
        {
           // FiddlerCoreStartupFlags flags = FiddlerCoreStartupFlags.DecryptSSL & FiddlerCoreStartupFlags.CaptureFTP & FiddlerCoreStartupFlags.ChainToUpstreamGateway & FiddlerCoreStartupFlags.MonitorAllConnections;
            FiddlerApplication.AfterSessionComplete += FiddlerApplication_AfterSessionComplete;
            FiddlerApplication.Startup(8888, true, true, true);
        }
        public void Stop()
        {
            FiddlerApplication.AfterSessionComplete -= FiddlerApplication_AfterSessionComplete;
            if (FiddlerApplication.IsStarted())
                FiddlerApplication.Shutdown();
        }
        public bool InstallCertificate()
        {
            if (!CertMaker.rootCertExists())
            {
                if (!CertMaker.createRootCert())
                    return false;

                if (!CertMaker.trustRootCert())
                    return false;
            }
            
            var cert = FiddlerApplication.Prefs.GetStringPref("fiddler.certmaker.bc.cert", null);
            var key = FiddlerApplication.Prefs.GetStringPref("fiddler.certmaker.bc.key", null);
            CertMaker.trustRootCert();
            FiddlerApplication.Log.OnLogString += delegate (object sender, LogEventArgs e)
            {
                Console.WriteLine("Log {0}", e.LogString);
                
            };
            return true;
        }
        public  bool UninstallCertificate()
        {
            if (CertMaker.rootCertExists())
            {
                if (!CertMaker.removeFiddlerGeneratedCerts(true))
                    return false;
            }
            return true;
        }

        private  void FiddlerApplication_AfterSessionComplete(Session sess)
        {

            // Ignore HTTPS connect requests
            if (sess.RequestMethod == "CONNECT")
                return;


            if (sess == null || sess.oRequest == null || sess.oRequest.headers == null)
                return;

            string headers = sess.oRequest.headers.ToString();
            var reqBody = sess.GetRequestBodyAsString();

            // if you wanted to capture the response
            //string respHeaders = session.oResponse.headers.ToString();
            //var respBody = session.GetResponseBodyAsString();

            // replace the HTTP line to inject full URL
            string firstLine = sess.RequestMethod + " " + sess.fullUrl + " " + sess.oRequest.headers.HTTPVersion;
            int at = headers.IndexOf("\r\n");
            if (at < 0)
                return;
            headers = firstLine + "\r\n" + headers.Substring(at + 1);

            string output = headers + "\r\n" +
                            (!string.IsNullOrEmpty(reqBody) ? reqBody + "\r\n" : string.Empty) + "\r\n\r\n";
            DataLog dlog = new DataLog();
            dlog.header = headers;
            dlog.Data = reqBody;
            dlog.hostName = sess.hostname;
            dlog.Timestamp = sess.Timers.FiddlerGotRequestHeaders.ToLongTimeString();
            foreach(PI x in main.allPis)
            {
                if(reqBody.Contains(x.getVarInfo()))
                {
                    IntPtr gridHandle = main.Handle;
                    main.dataGridView1.Invoke(new Action(delegate ()
                    {
                        main.dataGridView1.Rows.Add(dlog.Timestamp, x.getVarName(), dlog.hostName, dlog.Data);
                    }));
                    //main.setDataGridView(dlog.Timestamp, x.getVarName(), dlog.hostName, dlog.Data);
                }
            }

            Console.WriteLine(output);
        }
    }


}