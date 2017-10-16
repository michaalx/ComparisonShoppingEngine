using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSE
{
    public partial class logFrm : Form
    {
        public logFrm()
        {
            InitializeComponent();
        }

        private void RegisterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            regFrm frm2 = new regFrm();
            frm2.Show();
        }

        private void SignIn_Click(object sender, EventArgs e)
        {//comment if you want fast testing without login
            /*var email = logEmBox.Text;
            var password = logPwBox.Text;
            var csv = new CSV();
            
            if (csv.ParsingRegistration(email,password))
            {//This has to be uncommented (inside if)*/
                this.Hide();
                Form1 frm = new Form1();
                frm.Show();
           /* }//
            else
            {
                ifError2.Text = "Email or password is invalid";
            }*/
        }
    }
}