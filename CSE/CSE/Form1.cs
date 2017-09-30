﻿using System;
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
        List<Product> list = new List<Product>();
		private ClosestMatch ClosestMatch { get; set; }
		public string file { get; set; }
        public Form1()
        {
            InitializeComponent();
        }

		private void Form1_Closing(object sender, FormClosingEventArgs e)
		{
			System.Environment.Exit(1);
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
                    pathBox.Text = fullPath;
                    ifError.Text = "";
                }
                catch (IOException)
                {
                }
                catch(ArgumentNullException)
                {
                }
            } else if (openFileDialog1.FileName == "")
            {
                ifError.Text = "File not chosen";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var writer = new CSV();
			//writer.writeToFile(list);
			try
            {
				ClosestMatch = new ClosestMatch();
				textBox2.Text = ClosestMatch.FindMatch(TesseractOCR.ImageToText(file).Split('\n'), file);
                panel2.Visible = true;
                panel1.SendToBack();
            }
            catch (IOException)
            {
            }
            catch(ArgumentNullException)
            {
            }
            catch(ArgumentException)
            {
                ifError.Text = "Invalid file format";
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
            panel2.SendToBack();
        }

		private void Form1_Load(object sender, EventArgs e)
		{

		}

		private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form_Resize(object sender, EventArgs e)
        {
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

		private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
		{

		}

	}
}
