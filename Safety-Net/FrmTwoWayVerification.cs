using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TextmagicRest;
using TextmagicRest.Model;
namespace Safety_Net
{
  
    public partial class FrmTwoWayVerification : Form
    {
        public string userName;
        
        public static string phoneNumber;
        public static Random random = new Random();
        public static int verificationint= random.Next(100000,999999) ;
        public string verificationCode = verificationint.ToString();
        public FrmTwoWayVerification(string username)
        {
            userName = username;
            InitializeComponent();
           
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        public void SendText(string PhoneNumber)
        {
            var client = new Client("vincenttorba"," 0zGE5cKVvHEoPENrkHl1EifO4eQUhR");
            var link = client.SendMessage("Your Verification Code is: "+ verificationCode, PhoneNumber);
            if (link.Success)
            {
                Console.WriteLine("Message ID {0} has been successfully sent", link.Id);
            }
            else
            {
                Console.WriteLine("Message was not sent due to following exception: {0}", link.ClientException.Message);
             }
        }
    
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if(tbVerify.Text == verificationCode)
            {
                FrmMain mainForm = new FrmMain(userName);
                this.Hide();
                mainForm.Closed += (s, args) => this.Close();
                mainForm.Show();
            }
            else
            {
                label2.BackColor = Color.Red;
                label2.Visible = true;
                label2.Text = "Incorrect verification code";
            }
           
        }

        private void FrmTwoWayVerification_Load(object sender, EventArgs e)
        {
            label2.Visible = false;
            phoneNumber = User.PhoneNumber;
            phoneNumber.Replace("-", "");
            SendText("1"+ phoneNumber);
        }

        private void label1_Click_1(object sender, EventArgs e)
        {
            // UI Improvements
        }
    }
}
