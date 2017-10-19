using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CSE.BackEnd;

namespace CSE.FrontEnd
{
    public partial class InsertReceiptForm : Form
    {
        private string _file;
        public InsertReceiptForm()
        {
            InitializeComponent();
        }

        private void InsertReceiptForm_Load(object sender, EventArgs e)
        {

        }

        private void InsertReceiptForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Environment.Exit(1);
        }

        private void BrowseButton_OnClick(object sender, EventArgs e)
        {
            DialogResult dialogResult = openFileDialog.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                _file = openFileDialog.FileName;
                try
                {
                    string fullPath = Path.GetFullPath(_file);
                    pathBox.Text = fullPath;
                }
                catch (ArgumentException) { }
                catch (IOException) { }
            }   else if (openFileDialog.FileName == "")
            {
                FormsToolkit.DisplayMessageBox("File is not chosen.");
            }
        }

        private void UploadImageButton_OnClick(object sender, EventArgs e)
        {
            try
            {
               ProcessReceipt processReceipt = new ProcessReceipt(_file);
                //Uncomment as soon as method is implemented.
                processReceipt.ManipulateData();
            }
            catch (IOException) { }
            catch (ArgumentException) { }
            catch (Tesseract.TesseractException) { }
        }

        private void GoBackButton_OnClick(object sender, EventArgs e)
        {
            Hide();
            StartForm startForm = new StartForm();
            startForm.Show();
        }
    }
}
