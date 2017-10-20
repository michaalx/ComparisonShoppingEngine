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
    public partial class SignUpForm : Form
    {
        public SignUpForm()
        {
            InitializeComponent();
        }

        private void SignUpButton_Click(object sender, EventArgs e)
        {
            var name = nameBox.Text;
            var lastName = lastNameBox.Text;
            var email = emailBox.Text;
            var password = passwordBox.Text;
            var confirmPassword = confirmPasswordBox.Text;
            Email userEmail = new Email();
            if (password != confirmPassword)
            {
                var error = "Passwords do not match.";
                FormsToolkit.DisplayMessageBox(error);
            }
            else if (!userEmail.IsValid(email))
            {
                var error = "Email address is not valid.";
                FormsToolkit.DisplayMessageBox(error);

            }
            else
            {
                var csv = new CSV();
                var check = csv.ParsingRegistration(email);
                if (check)
                {
                    var error = "User with this email already exists.";
                    FormsToolkit.DisplayMessageBox(error);
                }
                else
                {
                    /*
                     Create new user if all fields are valid
                     and display log in form.
                     */
                    var user = new User(name, lastName, email, password);
                    csv.WriteToFileRegistration(user);
                    Hide();
                    LogInForm loginForm = new LogInForm();
                    loginForm.Show();
                }
            }

            
        }

        private void GoBackButton_Click(object sender, EventArgs e)
        {
            Hide();
            UploadDataForm goBack = new UploadDataForm();
            goBack.Show();
        }

        private void SignUpForm_Closing(object sender, FormClosingEventArgs e)
        {
            System.Environment.Exit(1);
        }
    }
}
