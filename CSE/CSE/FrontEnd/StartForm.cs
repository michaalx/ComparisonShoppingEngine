using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSE.FrontEnd
{
    public partial class StartForm : Form
    {
        public StartForm()
        {
            InitializeComponent();
		}

        private void GetDataButton_Click(object sender, EventArgs e)
        {
            Hide();
            GetDataForm getDataForm = new GetDataForm();
            getDataForm.Show();
            
        }

        private void UploadDataButton_Click(object sender, EventArgs e)
        {
            Hide();
            /**
             * Invoked when file of unique product empty file.
             * */
             CSV csvTool = new CSV();
             csvTool.ResetUniqueProducts();
            /**
             * End*
             */
    
            ///Ignore Loging in and Signing up (temporarily)
            // UploadDataForm uploadDataForm = new UploadDataForm();
            //uploadDataForm.Show();
            InsertReceiptForm form = new InsertReceiptForm();
            form.Show();
        }

        private void StartForm_Closing(object sender, FormClosingEventArgs e)
        {
            System.Environment.Exit(1);
        }

        private void ExitButton_OnClick(object sender, EventArgs e)
        {
            System.Environment.Exit(1);
        }

        private void StartForm_Load(object sender, EventArgs e)
        {

        }
    }
}
