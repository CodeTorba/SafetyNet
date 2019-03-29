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

            string query = "SELECT * FROM tbl_Logs;";
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
                                datalog.LogNumber = (int) reader["LogNumber"];
                                datalog.IPAddress = reader["IPAddress"].ToString();
                                datalog.Data = reader["Data"].ToString();
                                datalog.Timestamp = reader["TimeStamp"].ToString();
                                lstData.Add(datalog);
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
    }
}

