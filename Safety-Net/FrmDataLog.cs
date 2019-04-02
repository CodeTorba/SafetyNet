using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
namespace Safety_Net
{
    public partial class FrmDataLog : Form
    {
        public FrmDataLog()
        {
            InitializeComponent();
        }
        private void DatabaseConnection()
        {
            List<DataLog> lstData = new List<DataLog>();

            string query = "SELECT * FROM dataLog;";
            using (SQLiteConnection conn = new SQLiteConnection("data source = Safety-Netdb.db"))
            {
                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    try
                    {
                        conn.Open();
                        SQLiteDataReader reader = cmd.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                DataLog datalog = new DataLog();
                                datalog.hostName= reader["HostName"].ToString();
                                datalog.Data = reader["Data"].ToString();
                                datalog.header = reader["Header"].ToString();
                                datalog.Timestamp = reader["TimeStamp"].ToString();
                                lstData.Add(datalog);
                                dataGridView1.Rows.Add(datalog.Timestamp, datalog.hostName, datalog.header, datalog.Data);
                            }
                          
                        }
                     
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
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void FrmDataLog_Load(object sender, EventArgs e)
        {
            DatabaseConnection();
        }
    }
}

