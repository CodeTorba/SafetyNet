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
    public partial class FrmLogIn : Form
    {
        public FrmLogIn()
        {
            InitializeComponent();
            
        }

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            FrmTwoWayVerification twoway = new FrmTwoWayVerification();
            FrmMain main = new FrmMain();
            Boolean test = true;
            if (tbUserName.Text =="" || tbPassword.Text == "")
            {
                label4.Visible = true;
                label4.Text = "*** Please Enter Username and Password ";
                label4.BackColor = Color.Red;
                return;
            }
            else
            {
                label4.Visible = false;
                //TODO: Connect Database
                string query = "SELECT * FROM Users WHERE UserName = '" + tbUserName.Text +"' AND Password = '" + tbPassword.Text + "';";
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
                                    User.FirstName = reader["FirstName"].ToString();
                                    User.LastName = reader["LastName"].ToString();
                                    User.PhoneNumber = reader["PhoneNumber"].ToString();
                                    User.UserName = reader["UserName"].ToString();
                                    User.Password = reader["Password"].ToString();
                                }

                                if (test == false)
                                {
                                    this.Hide();
                                    twoway.Closed += (s, args) => this.Close();
                                    twoway.Show();
                                }
                                else
                                {
                                    this.Hide();
                                    main.Closed += (s, args) => this.Close();
                                    main.Show();
                                    
                                }

                            }
                            else
                            {
                                label4.Visible = true;
                                label4.Text = "*** Incorrect Username and Password ";
                                label4.BackColor = Color.Red;
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
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void FrmLogIn_Load(object sender, EventArgs e)
        {
            label4.Visible = false;
        }
    }
}
