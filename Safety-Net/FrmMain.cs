using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Safety_Net
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void splitContainer2_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void splitContainer3_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnOpenDataLog_Click(object sender, EventArgs e)
        {
            FrmDataLog frmDataLog = new FrmDataLog();
            frmDataLog.ShowDialog();
        }

        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            Proxy proxy = new Proxy();
            ThreadStart threadDelegate = new ThreadStart(proxy.doProxy);
            Thread newThread = new Thread(threadDelegate);
            //proxy.doProxy();

            newThread.Start();
            
   

       
            
        }
    }
}
