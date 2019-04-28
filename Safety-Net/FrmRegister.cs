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
using System.Text.RegularExpressions;
namespace Safety_Net
{
    public partial class FrmRegister : Form
    {

       Regex numbersOnly= new Regex(@"^\d{3}\-\d{3}-\d{4}$");
       
    public FrmRegister()
        {
            InitializeComponent();
        }

        private void FrmRegister_Load(object sender, EventArgs e)
        {
            label7.Visible = false;
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if(tbFName.Text == "" || tbLName.Text == "" || tbPhoneNum.Text == "" ||  tbUName.Text == "" || tbPwd.Text =="" || tbConfirmPwd.Text =="")
            {
                label7.Visible = true;
                label7.Text = "All Fields must be filled";
                label7.BackColor = Color.Red;
            }
            else if( !numbersOnly.IsMatch(tbPhoneNum.Text))
            {

                label7.Visible = true;
                label7.Text = "Phone Number must contain only numbers";
                label7.BackColor = Color.Red;
            }
            else
            {
                label7.Visible = false;
                if (tbPwd.Text != tbConfirmPwd.Text)
                {
                    label7.Visible = true;
                    label7.BackColor = Color.Red;
                    label7.Text = "Confirm password and password are different";
                }
                else
                {
                    //string testquery = "IF OBJECT_ID('dbo.Users', 'U') IS NOT NULL \n CREATE TABLE Users(FirstName text NOT NULL, LastName text NOT NULL,PhoneNumber text NOT NULL, UserName text  NOT NULL, Password text NOT NULL);"
                    string query = "INSERT INTO Users (FirstName, LastName, PhoneNumber, UserName, Password) VALUES (@First,@Last, @PhoneNum, @uName, @Password)";
                    //string query = "CREATE TABLE Users(FirstName text NOT NULL, LastName text NOT NULL,PhoneNumber text NOT NULL, UserName text  NOT NULL, Password text NOT NULL);";
                    using (SQLiteConnection conn = new SQLiteConnection("data source = Safety-Netdb.db"))
                    {
                        using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                        {
                        }
                        using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                        {

                            cmd.Parameters.Add("@First", DbType.String).Value = tbFName.Text;
                            cmd.Parameters.Add("@Last", DbType.String).Value = tbLName.Text;
                            cmd.Parameters.Add("@PhoneNum", DbType.String).Value = tbPhoneNum.Text;
                            cmd.Parameters.Add("@uName", DbType.String).Value = tbUName.Text;
                            cmd.Parameters.Add("@Password", DbType.String).Value = tbPwd.Text;
                            try
                            {
                                conn.Open();
                                int rows = cmd.ExecuteNonQuery();
                                label7.Visible = true;
                                label7.BackColor = Color.Green;
                                label7.Text = "Registration Complete";
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

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
