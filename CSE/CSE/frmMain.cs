using Emgu.CV;
using Emgu.CV.CvEnum;
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

namespace CSE
{
    public partial class frmMain : Form
    {
        public string file { get; set; }
        public frmMain()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Show the dialog and get result
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                file = openFileDialog1.FileName;
                try
                {
                    string fullPath = Path.GetFullPath(file);
                    textBox1.Text = fullPath;
                }
                catch (IOException)
                {
                }
            } else
            {
                textBox1.Text = "File not chosen";
            }

            Mat imgOriginal;

            try
            {
                imgOriginal = new Mat(file, /*ImreadModes loadType =*/ImreadModes.Color);
            }
            catch (Exception ex)
            {
                textBox1.Text = "unable to open image, error: " + ex.Message;
                return;
            }

            if (imgOriginal == null)
            {
                textBox1.Text = "unable to open image";
                return;
            }

            Mat imgGrayscale = new Mat(imgOriginal.Size, DepthType.Cv8U, 1);
            Mat imgBlurred = new Mat(imgOriginal.Size, DepthType.Cv8U, 1);
            Mat imgCanny = new Mat(imgOriginal.Size, DepthType.Cv8U, 1);

            CvInvoke.CvtColor(imgOriginal, imgGrayscale, ColorConversion.Bgr2Gray);

            CvInvoke.GaussianBlur(imgGrayscale, imgBlurred, new Size(5, 5), 1.5);

            CvInvoke.Canny(imgBlurred, imgCanny, 100, 200);

            ibOriginal.Image = imgOriginal;
            ibCanny.Image = imgCanny;

        }

        private void button2_Click(object sender, EventArgs e)
        {
           /* try
            {
                string text = File.ReadAllText(file);
                textBox2.Text = text;
                panel2.Visible = true;
                panel1.SendToBack();
            }
            catch (IOException)
            {
            }
            */
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
