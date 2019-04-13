using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PcapDotNet.Core;
using PcapDotNet.Packets.IpV4;
using PcapDotNet.Packets.Transport;
using PcapDotNet.Packets;
using PcapDotNet.Packets.Http;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using System.Data.SQLite;
using System.Data.Sql;
using System.Data;
namespace Safety_Net
{
    public class Proxy
    {
        List<DataLog> listLog;
        public void doProxy()
        {
            IList<LivePacketDevice> allDevices = LivePacketDevice.AllLocalMachine;

            if (allDevices.Count == 0)
            {
                Console.WriteLine("No interfaces found! Make sure WinPcap is installed.");
                return;
            }

            // Print the list
            for (int i = 0; i != allDevices.Count; ++i)
            {
                LivePacketDevice device = allDevices[i];
                Console.Write((i + 1) + ". " + device.Name);
                if (device.Description != null)
                    Console.WriteLine(" (" + device.Description + ")");
                else
                    Console.WriteLine(" (No description available)");
            }

            int deviceIndex = 1;
            do
            {
                Console.WriteLine("Enter the interface number (1-" + allDevices.Count + "):");
                string deviceIndexString = Console.ReadLine();
                
            } while (deviceIndex == 0);

            // Take the selected adapter
            PacketDevice selectedDevice = allDevices[deviceIndex - 1];

            // Open the device
            using (PacketCommunicator communicator =
                selectedDevice.Open(65536,                                  // portion of the packet to capture
                                                                            // 65536 guarantees that the whole packet will be captured on all the link layers
                                    PacketDeviceOpenAttributes.Promiscuous, // promiscuous mode
                                    1000))                                  // read timeout
            {
                // Check the link layer. We support only Ethernet for simplicity.
                if (communicator.DataLink.Kind != DataLinkKind.Ethernet)
                {
                    Console.WriteLine("This program works only on Ethernet networks.");
                    return;
                }
                using (BerkeleyPacketFilter filter = communicator.CreateFilter("ip and tcp and dst port 80"))
                {
                    // Set the filter
                    communicator.SetFilter(filter);
                }

                Console.WriteLine("Listening on " + selectedDevice.Description + "...");

                // start the capture
                communicator.ReceivePackets(0,PacketHandler);
                
            }

        }
    
        private void PacketHandler(Packet packet)
        {
            DataLog dLog = new DataLog();

            if (packet == null) { return; }
            if (packet.Ethernet == null) { return; }
            if (packet.Ethernet.IpV4 == null) { return; }
            if (packet.Ethernet.IpV4.Tcp == null) { return; }
            if (packet.Ethernet.IpV4.Tcp.Http == null) { return; }
            try
            {
                HttpDatagram http = packet.Ethernet.IpV4.Tcp.Http;

                if (http.IsRequest && http.IsValid)
                {
                   
                    String msg = http.Decode(Encoding.UTF8).Split('\n')[0];
                    if (msg.StartsWith("GET") || msg.StartsWith("POST "))
                    {
                        string header = http.Header.ToString();
                        string version = http.Version.ToString();
                        string dest = packet.Ethernet.IpV4.Destination.ToString();
                        IPAddress ipAddress = IPAddress.Parse(dest);
                        string hostAddress = Dns.GetHostEntry(ipAddress).HostName;
                        string data = "";
                        
                        if (http.Body.Length > 0)
                        {
                            for (int i = 0; i != http.Body.Length; ++i)
                            {
                                string hex = (http.Body[i]).ToString("X2");
                                data += HexStringToString(hex);
                                
                            }
                        }
                        //string method = 
                        Console.WriteLine(version);
                        Console.WriteLine(header);
                        Console.WriteLine(data);
                        Console.WriteLine(hostAddress);
                        dLog.Timestamp = packet.Timestamp.ToString("yyyy-MM-dd hh:mm:ss.fff");
                        dLog.hostName = hostAddress;
                        dLog.Data = data;
                        dLog.header = header;
                        
                        addToDatabase(dLog);
                    }
                }
            }
            catch (Exception e)
            {

            }
            finally
            {

            }
        }

    
        private  void DispatcherHandler(Packet packet)
        {
            Console.WriteLine(packet.Timestamp.ToString("yyyy-MM-dd hh:mm:ss.fff") + " length:" + packet.Length);

            // Print the packet
            const int LineLength = 64;
            string message = "";
            for (int i = 0; i != packet.Length; ++i)
            {
                string hex = (packet[i]).ToString("X2");
                message += HexStringToString(hex);
               Console.Write((packet[i]).ToString("X2"));
                if ((i + 1) % LineLength == 0)
                  Console.WriteLine();
            }

            Console.WriteLine("message: "+message);
            Console.WriteLine();
            
        }
        private  string HexStringToString(string hexString)
        {
            return string.Join("", System.Text.RegularExpressions.Regex.Split(hexString, "(?<=\\G..)(?!$)").Select(x => (char)Convert.ToByte(x, 16)));
        }

        private void addToDatabase(DataLog dlog)
        {
            string query = "INSERT INTO dataLog (TimeStamp, HostName, Header, Data) VALUES (@TimeStamp,@HostName, @Header, @Data)";
            //string query = "CREATE TABLE Users(Timestamp text NOT NULL, HostName text NOT NULL,Header text NOT NULL, Data text  NOT NULL);";
            using (SQLiteConnection conn = new SQLiteConnection("data source = Safety-Netdb.db"))
            {
                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {

                    cmd.Parameters.Add("@TimeStamp", DbType.String).Value = dlog.Timestamp;
                    cmd.Parameters.Add("@HostName", DbType.String).Value = dlog.hostName;
                    cmd.Parameters.Add("@Header", DbType.String).Value = dlog.header;
                    cmd.Parameters.Add("@Data", DbType.String).Value = dlog.Data;
                    
                    try
                    {
                        conn.Open();
                        int rows = cmd.ExecuteNonQuery();
                    }
                    catch (SQLiteException)
                    {

                    }
                    finally
                    {
                        conn.Close();

                    }


                }
            }
        }
        private void checkIfTableExists()
        {
            bool exists;
            const string sqlStatement = @"SELECT COUNT(*) FROM my_table";
            
            using(SQLiteConnection conn = new SQLiteConnection("data source = Safety-Netdb.db"))
            { 
                using (SQLiteCommand cmd = new SQLiteCommand(sqlStatement, conn))
                {
                    try
                    {
                        conn.Open();
                        cmd.ExecuteScalar();
                        exists = true;
                    }
                    catch
                    {
                        exists = false;
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
            }
            if(exists == false)
            {
                CreateTable();
            }
        }
        private void CreateTable()
        {
            string query = "CREATE TABLE dataLog(Timestamp text NOT NULL, HostName text NOT NULL,Header text NOT NULL, Data text  NOT NULL);";
            using (SQLiteConnection conn = new SQLiteConnection("data source = Safety-Netdb.db"))
            {
                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    try
                    {
                        conn.Open();
                        int rows = cmd.ExecuteNonQuery();
                    }
                    catch (SQLiteException)
                    {

                    }
                    finally
                    {
                        conn.Close();

                    }


                }
            }
        }

    }
}
