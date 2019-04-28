﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Data.SQLite;
namespace Safety_Net
{
    public partial class FrmMain : Form
    {
        public string userName;
        public List<PI> allPis;
        FiddlerProxy fd;
        public FrmMain(string uname)
        {
            userName = uname;
            fd = new FiddlerProxy(this);
            InitializeComponent();
        }

        public void setPiToList(PI p)
        {
            allPis.Add(p);
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

        

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            // Proxy proxy = new Proxy();
            // ThreadStart threadDelegate = new ThreadStart(proxy.doProxy);
            //Thread newThread = new Thread(threadDelegate);
            //proxy.doProxy();

            // newThread.Start();
            allPis = grabPIFromDatabase();
            foreach (PI x in allPis)
            {
                ckBoxes.Items.Add(x.getVarName());

            }
            fd.InstallCertificate();
            fd.Start();
            fd.Stop();
            fd.UninstallCertificate();
        }
        public void setDataGridView(string time, string info, string website, string data)
        {
           this.dataGridView1.Rows.Add(time, info, website, data);
        }
        private void btnAddPrivateInfo_Click(object sender, EventArgs e)
        {
            FrmAddPI addPI = new FrmAddPI(userName, this);
            addPI.Show();
            //this.FrmMain_Load(btnAddPrivateInfo, e);
        }

        private List<PI> grabPIFromDatabase()
        {
            List<PI> allPis = new List<PI>();
            string query = "SELECT * FROM PIS WHERE UserName = '" + userName + "';";
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
                               
                                string varName = reader["VarName"].ToString();
                                string varInfo = reader["VarInfo"].ToString();
                                PI newPi = new PI(varName, varInfo);
                                allPis.Add(newPi);
                                
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
            return allPis;
        }

        private void splitContainer3_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ckBoxes_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void splitContainer2_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        private void btnDelete_Click(object sender, EventArgs e)
        {
            FrmDeletePI deletePI = new FrmDeletePI(this);
            deletePI.Show();
        }


        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {

        }
        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
           // fd.Stop();
           // fd.UninstallCertificate();
        }
    }
}
