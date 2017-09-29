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
    public partial class regFrm : Form
    {
        List<User> user_information = new List<User>();
        public regFrm()
        {
            InitializeComponent();
        }

        private void loginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            logFrm frm3 = new logFrm();
            frm3.Show();
        }

        private void SignUp_Click(object sender, EventArgs e)
        {
            var name = regNmBox.Text;
            var last_name = regLastBox.Text;
            var email = regEmBox.Text;
            var password = regPwBox.Text;
            var conf_password = regConfBox.Text;
            
            if (!(password == conf_password))
            {
                ifError2.Text = "Passwords do not match";
            }
            else
            {   //creating user object
                var user = new User(name, last_name, email, password);
                user_information.Add(user);
                //writing to csv file
                var writer = new CSV();
                writer.writeToFileRegistration(user_information);
                //showing loginform
                this.Hide();
                logFrm frm3 = new logFrm();
                frm3.Show();
            }
        }
    }
}
