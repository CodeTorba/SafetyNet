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
using System.Data.Sql;
namespace Safety_Net
{
    public partial class FrmAddPI : Form
    {
        public FrmMain main;
        public string userName;
        public FrmAddPI(string uname, FrmMain m)
        {
            main = m; 
            userName = uname;
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {


        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            string message = "Are you sure you want to check this information";
            string title = "Private Information Check";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons);
            if (result == DialogResult.Yes)
            {
                PI privClass = new PI(tbVariableName.Text, tbPI.Text);
                //checkIfTableExists();
                addToDatabase(privClass);
                //create table
                //Add PI to addtable
                //FrmMain main = new FrmMain(userName);
                main.ckBoxes.Items.Add(privClass.getVarName());
                main.setPiToList(privClass);
                //FrmMain.ckBoxes.Items.Add(privClass);
                //FrmMain.ckBoxes.Refresh();
                //main.ckBoxes.Items.Add(privClass);
                this.Close();
            }
            else
            {
                this.Close();
            }

        }
        private void addToDatabase(PI personalInfo)
        {
            string query = "INSERT INTO PIS (UserName, VarName, VarInfo) VALUES (@user,@varname, @varinfo);";
            //string query = "CREATE TABLE PIS(UserName text NOT NULL, VarName text NOT NULL,VarInfo text NOT NULL);";
            using (SQLiteConnection conn = new SQLiteConnection("data source = Safety-Netdb.db"))
            {
                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {

                    cmd.Parameters.Add("@user", DbType.String).Value = userName;
                    cmd.Parameters.Add("@varname", DbType.String).Value = personalInfo.getVarName();
                    cmd.Parameters.Add("@varinfo", DbType.String).Value = personalInfo.getVarInfo();
                   

                   try
                    {
                        conn.Open();
                        int rows = cmd.ExecuteNonQuery();
                    }
                    catch (SQLiteException)
                    {
                        string exception = "Oh no you didn't";
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
            const string sqlStatement = @"SELECT COUNT(*) FROM PI";

            using (SQLiteConnection conn = new SQLiteConnection("data source = Safety-Netdb.db"))
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
            if (exists == false)
            {
                CreateTable();
            }
        }
        private void CreateTable()
        {
            string query = "CREATE TABLE PI(UserName text NOT NULL, VarName text NOT NULL, VarInfo text NOT NULL);";
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
