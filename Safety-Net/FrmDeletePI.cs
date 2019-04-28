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
    public partial class FrmDeletePI : Form
    {
        public FrmMain m;
        public FrmDeletePI(FrmMain main)
        {
            m = main;
            InitializeComponent();
     
        }

        private void FrmDeletePI_Load(object sender, EventArgs e)
        {

        }
        private void removeFromDatabase(string personalInfo)
        {
            string query = "DELETE FROM PIS WHERE VarName = " + personalInfo + ";";
            //string query = "CREATE TABLE PIS(UserName text NOT NULL, VarName text NOT NULL,VarInfo text NOT NULL);";
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
                        string exception = "Oh no you didn't";
                    }
                    finally
                    {
                        conn.Close();

                    }


                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            
            removeFromDatabase(tbVarName.Text);
            m.ckBoxes.Items.Remove(tbVarName.Text);
            PI result= new PI("",""); 
            foreach (PI x in m.allPis)
            {
                if (x.getVarName() == tbVarName.Text)
                {
                    result = x;
                }
                    

            }
           if(result.getVarName() != "")
            {
                m.allPis.Remove(result);
            }
            



            this.Close();
        }
    }
}
