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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.insertReceiptToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chooseItemsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.insertReceiptToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.chooseItemsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.menuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // brwsButton
            // 
            this.brwsButton.Location = new System.Drawing.Point(403, 192);
            this.brwsButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.brwsButton.Name = "brwsButton";
            this.brwsButton.Size = new System.Drawing.Size(147, 28);
            this.brwsButton.TabIndex = 0;
            this.brwsButton.Text = "Browse..";
            this.brwsButton.UseVisualStyleBackColor = true;
            this.brwsButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // pathBox
            // 
            this.pathBox.Location = new System.Drawing.Point(159, 193);
            this.pathBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pathBox.Name = "pathBox";
            this.pathBox.Size = new System.Drawing.Size(236, 22);
            this.pathBox.TabIndex = 1;
            // 
            // uplButton
            // 
            this.uplButton.Location = new System.Drawing.Point(212, 246);
            this.uplButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.uplButton.Name = "uplButton";
            this.uplButton.Size = new System.Drawing.Size(160, 33);
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
            this.panel1.Controls.Add(this.comboBox1);
            this.panel1.Controls.Add(this.ifError);
            this.panel1.Controls.Add(this.uplButton);
            this.panel1.Controls.Add(this.pathBox);
            this.panel1.Controls.Add(this.brwsButton);
            this.panel1.Controls.Add(this.menuStrip1);
            this.panel1.Location = new System.Drawing.Point(-3, 4);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(647, 459);
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
            this.ifError.Location = new System.Drawing.Point(251, 158);
            this.ifError.Name = "ifError";
            this.ifError.Size = new System.Drawing.Size(0, 17);
            this.ifError.TabIndex = 3;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.insertReceiptToolStripMenuItem,
            this.chooseItemsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(647, 28);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // insertReceiptToolStripMenuItem
            // 
            this.insertReceiptToolStripMenuItem.Name = "insertReceiptToolStripMenuItem";
            this.insertReceiptToolStripMenuItem.Size = new System.Drawing.Size(111, 24);
            this.insertReceiptToolStripMenuItem.Text = "Insert Receipt";
            // 
            // chooseItemsToolStripMenuItem
            // 
            this.chooseItemsToolStripMenuItem.Name = "chooseItemsToolStripMenuItem";
            this.chooseItemsToolStripMenuItem.Size = new System.Drawing.Size(110, 24);
            this.chooseItemsToolStripMenuItem.Text = "Choose Items";
            this.chooseItemsToolStripMenuItem.Click += new System.EventHandler(this.chooseItemsToolStripMenuItem_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.button3);
            this.panel2.Controls.Add(this.textBox2);
            this.panel2.Location = new System.Drawing.Point(7, 4);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(629, 452);
            this.panel2.TabIndex = 5;
            this.panel2.Visible = false;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(469, 14);
            this.button3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(140, 43);
            this.button3.TabIndex = 1;
            this.button3.Text = "Browse Again";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(5, 14);
            this.textBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(444, 431);
            this.textBox2.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.menuStrip2);
            this.panel3.Location = new System.Drawing.Point(8, 6);
            this.panel3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(629, 452);
            this.panel3.TabIndex = 6;
            this.panel3.Visible = false;
            // 
            // menuStrip2
            // 
            this.menuStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.insertReceiptToolStripMenuItem1,
            this.chooseItemsToolStripMenuItem1});
            this.menuStrip2.Location = new System.Drawing.Point(0, 0);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Size = new System.Drawing.Size(629, 28);
            this.menuStrip2.TabIndex = 0;
            this.menuStrip2.Text = "menuStrip2";
            // 
            // insertReceiptToolStripMenuItem1
            // 
            this.insertReceiptToolStripMenuItem1.Name = "insertReceiptToolStripMenuItem1";
            this.insertReceiptToolStripMenuItem1.Size = new System.Drawing.Size(111, 24);
            this.insertReceiptToolStripMenuItem1.Text = "Insert Receipt";
            this.insertReceiptToolStripMenuItem1.Click += new System.EventHandler(this.insertReceiptToolStripMenuItem1_Click);
            // 
            // chooseItemsToolStripMenuItem1
            // 
            this.chooseItemsToolStripMenuItem1.Name = "chooseItemsToolStripMenuItem1";
            this.chooseItemsToolStripMenuItem1.Size = new System.Drawing.Size(110, 24);
            this.chooseItemsToolStripMenuItem1.Text = "Choose Items";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Maxima",
            "IKI",
            "Rimi",
            "Norfa",
            "Lidl"});
            this.comboBox1.Location = new System.Drawing.Point(161, 104);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(233, 24);
            this.comboBox1.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(644, 464);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_Closing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.Form_Resize);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
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
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem insertReceiptToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem chooseItemsToolStripMenuItem;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.ToolStripMenuItem insertReceiptToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem chooseItemsToolStripMenuItem1;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}

