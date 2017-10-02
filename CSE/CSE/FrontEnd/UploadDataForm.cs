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
    public partial class UploadDataForm : Form
    {
        public UploadDataForm()
        {
            InitializeComponent();
        }

        private void LogIn_Click(object sender, EventArgs e)
        {
            Hide();
            logFrm loginForm = new logFrm();
            loginForm.Show();
        }

        private void SignUp_Click(object sender, EventArgs e)
        {
            Hide();
            regFrm registrationForm = new regFrm();
            registrationForm.Show();
        }

        private void GoBack_Click(object sender, EventArgs e)
        {
            Hide();
            StartForm startForm = new StartForm();
            startForm.Show();
        }
    }
}
