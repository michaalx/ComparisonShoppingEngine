using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSE.FrontEnd
{
    public partial class LogInForm : Form
    {
        public LogInForm()
        {
            InitializeComponent();
        }
        public void emailLabel_Click(object sender, EventArgs e)
        {

        }
        private void logInButton_Click(object sender, EventArgs e)
        {
            /*var email = emailBox.Text;
            var password = passwordBox.Text;
            var csv = new CSV();

            if (csv.ParsingRegistration(email, password))
            {*/
                this.Hide();
                Form1 frm = new Form1();
                frm.Show();
            /*}
            else
            {
                errorLabel.Text = "Email or password is incorrect.";
                //todo: hide after 5 sec .
            }*/
        }

        private void goBackButton_Click(object sender, EventArgs e)
        {
            Hide();
            UploadDataForm uploadDataForm = new UploadDataForm();
            uploadDataForm.Show();
        }
    }
}
