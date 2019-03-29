using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Safety_Net
{
    public partial class FrmStartUp : Form
    {
        private FrmLogIn frmLog;
        private FrmRegister frmReg;
        public FrmStartUp()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            groupBox1.BackColor = Color.Cyan;
           
           
        }

        private void btnSignIn_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmLog = new FrmLogIn();
            frmLog.Closed += (s, args) => this.Close();
            frmLog.Show();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            frmReg = new FrmRegister();
            frmReg.ShowDialog();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
