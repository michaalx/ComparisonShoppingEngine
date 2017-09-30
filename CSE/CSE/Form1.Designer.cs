namespace CSE
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        //test comments
        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			this.brwsButton = new System.Windows.Forms.Button();
			this.pathBox = new System.Windows.Forms.TextBox();
			this.uplButton = new System.Windows.Forms.Button();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.panel1 = new System.Windows.Forms.Panel();
			this.ifError = new System.Windows.Forms.Label();
			this.panel2 = new System.Windows.Forms.Panel();
			this.button3 = new System.Windows.Forms.Button();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// brwsButton
			// 
			this.brwsButton.Location = new System.Drawing.Point(302, 156);
			this.brwsButton.Margin = new System.Windows.Forms.Padding(2);
			this.brwsButton.Name = "brwsButton";
			this.brwsButton.Size = new System.Drawing.Size(110, 23);
			this.brwsButton.TabIndex = 0;
			this.brwsButton.Text = "Browse..";
			this.brwsButton.UseVisualStyleBackColor = true;
			this.brwsButton.Click += new System.EventHandler(this.button1_Click);
			// 
			// pathBox
			// 
			this.pathBox.Location = new System.Drawing.Point(119, 157);
			this.pathBox.Margin = new System.Windows.Forms.Padding(2);
			this.pathBox.Name = "pathBox";
			this.pathBox.Size = new System.Drawing.Size(178, 20);
			this.pathBox.TabIndex = 1;
			// 
			// uplButton
			// 
			this.uplButton.Location = new System.Drawing.Point(159, 200);
			this.uplButton.Margin = new System.Windows.Forms.Padding(2);
			this.uplButton.Name = "uplButton";
			this.uplButton.Size = new System.Drawing.Size(120, 27);
			this.uplButton.TabIndex = 2;
			this.uplButton.Text = "Upload";
			this.uplButton.UseVisualStyleBackColor = true;
			this.uplButton.Click += new System.EventHandler(this.button2_Click);
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.FileName = "openFileDialog1";
			this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.ifError);
			this.panel1.Controls.Add(this.uplButton);
			this.panel1.Controls.Add(this.pathBox);
			this.panel1.Controls.Add(this.brwsButton);
			this.panel1.Location = new System.Drawing.Point(-2, 3);
			this.panel1.Margin = new System.Windows.Forms.Padding(2);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(485, 373);
			this.panel1.TabIndex = 4;
			this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
			// 
			// ifError
			// 
			this.ifError.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.ifError.AutoSize = true;
			this.ifError.ForeColor = System.Drawing.Color.Red;
			this.ifError.Location = new System.Drawing.Point(188, 128);
			this.ifError.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.ifError.Name = "ifError";
			this.ifError.Size = new System.Drawing.Size(0, 13);
			this.ifError.TabIndex = 3;
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.button3);
			this.panel2.Controls.Add(this.textBox2);
			this.panel2.Location = new System.Drawing.Point(5, 3);
			this.panel2.Margin = new System.Windows.Forms.Padding(2);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(472, 367);
			this.panel2.TabIndex = 5;
			this.panel2.Visible = false;
			this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(352, 11);
			this.button3.Margin = new System.Windows.Forms.Padding(2);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(105, 35);
			this.button3.TabIndex = 1;
			this.button3.Text = "Browse Again";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(4, 11);
			this.textBox2.Margin = new System.Windows.Forms.Padding(2);
			this.textBox2.Multiline = true;
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(334, 351);
			this.textBox2.TabIndex = 0;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(483, 377);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.panel2);
			this.Margin = new System.Windows.Forms.Padding(2);
			this.Name = "Form1";
			this.Text = "Form1";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_Closing);
			this.Load += new System.EventHandler(this.Form1_Load);
			this.Resize += new System.EventHandler(this.Form_Resize);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button brwsButton;
        private System.Windows.Forms.TextBox pathBox;
        private System.Windows.Forms.Button uplButton;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label ifError;
        private System.Windows.Forms.Button button3;
    }
}

