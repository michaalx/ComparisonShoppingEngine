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
    public partial class Form1 : Form
    {
        public string file { get; set; }
        public Form1()
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
            }
            Console.WriteLine(result); //<--- for debugging
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string text = File.ReadAllText(file);
                textBox2.Text = text;
                panel2.Visible = true;
                panel1.SendToBack();
            }
            catch (IOException)
            {
            }

        }
    }
}
