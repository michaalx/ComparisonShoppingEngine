namespace CSE
{
    partial class regFrm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.regNmBox = new System.Windows.Forms.TextBox();
            this.regLastBox = new System.Windows.Forms.TextBox();
            this.regEmBox = new System.Windows.Forms.TextBox();
            this.regPwBox = new System.Windows.Forms.TextBox();
            this.regConfBox = new System.Windows.Forms.TextBox();
            this.SignUp = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.loginToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.registerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ifError2 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(96, 256);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(121, 17);
            this.label6.TabIndex = 11;
            this.label6.Text = "Confirm Password";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(148, 219);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 17);
            this.label5.TabIndex = 10;
            this.label5.Text = "Password";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(175, 182);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 17);
            this.label4.TabIndex = 9;
            this.label4.Text = "Email";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(141, 143);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 17);
            this.label2.TabIndex = 7;
            this.label2.Text = "Last Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(172, 106);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 17);
            this.label1.TabIndex = 6;
            this.label1.Text = "Name";
            // 
            // regNmBox
            // 
            this.regNmBox.Location = new System.Drawing.Point(241, 106);
            this.regNmBox.Name = "regNmBox";
            this.regNmBox.Size = new System.Drawing.Size(180, 22);
            this.regNmBox.TabIndex = 12;
            // 
            // regLastBox
            // 
            this.regLastBox.Location = new System.Drawing.Point(241, 143);
            this.regLastBox.Name = "regLastBox";
            this.regLastBox.Size = new System.Drawing.Size(180, 22);
            this.regLastBox.TabIndex = 13;
            // 
            // regEmBox
            // 
            this.regEmBox.Location = new System.Drawing.Point(241, 182);
            this.regEmBox.Name = "regEmBox";
            this.regEmBox.Size = new System.Drawing.Size(180, 22);
            this.regEmBox.TabIndex = 15;
            // 
            // regPwBox
            // 
            this.regPwBox.Location = new System.Drawing.Point(241, 219);
            this.regPwBox.Name = "regPwBox";
            this.regPwBox.Size = new System.Drawing.Size(180, 22);
            this.regPwBox.TabIndex = 16;
            // 
            // regConfBox
            // 
            this.regConfBox.Location = new System.Drawing.Point(241, 256);
            this.regConfBox.Name = "regConfBox";
            this.regConfBox.Size = new System.Drawing.Size(180, 22);
            this.regConfBox.TabIndex = 17;
            // 
            // SignUp
            // 
            this.SignUp.Location = new System.Drawing.Point(241, 299);
            this.SignUp.Name = "SignUp";
            this.SignUp.Size = new System.Drawing.Size(95, 30);
            this.SignUp.TabIndex = 18;
            this.SignUp.Text = "SignUp";
            this.SignUp.UseVisualStyleBackColor = true;
            this.SignUp.Click += new System.EventHandler(this.SignUp_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loginToolStripMenuItem,
            this.registerToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(644, 28);
            this.menuStrip1.TabIndex = 19;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // loginToolStripMenuItem
            // 
            this.loginToolStripMenuItem.Name = "loginToolStripMenuItem";
            this.loginToolStripMenuItem.Size = new System.Drawing.Size(58, 24);
            this.loginToolStripMenuItem.Text = "Login";
            this.loginToolStripMenuItem.Click += new System.EventHandler(this.loginToolStripMenuItem_Click);
            // 
            // registerToolStripMenuItem
            // 
            this.registerToolStripMenuItem.Name = "registerToolStripMenuItem";
            this.registerToolStripMenuItem.Size = new System.Drawing.Size(75, 24);
            this.registerToolStripMenuItem.Text = "Register";
            // 
            // ifError2
            // 
            this.ifError2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ifError2.AutoSize = true;
            this.ifError2.ForeColor = System.Drawing.Color.Red;
            this.ifError2.Location = new System.Drawing.Point(279, 77);
            this.ifError2.Name = "ifError2";
            this.ifError2.Size = new System.Drawing.Size(0, 17);
            this.ifError2.TabIndex = 20;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(644, 464);
            this.Controls.Add(this.ifError2);
            this.Controls.Add(this.SignUp);
            this.Controls.Add(this.regConfBox);
            this.Controls.Add(this.regPwBox);
            this.Controls.Add(this.regEmBox);
            this.Controls.Add(this.regLastBox);
            this.Controls.Add(this.regNmBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form2";
            this.Text = "Form2";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox regNmBox;
        private System.Windows.Forms.TextBox regLastBox;
        private System.Windows.Forms.TextBox regEmBox;
        private System.Windows.Forms.TextBox regPwBox;
        private System.Windows.Forms.TextBox regConfBox;
        private System.Windows.Forms.Button SignUp;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem loginToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem registerToolStripMenuItem;
        private System.Windows.Forms.Label ifError2;
    }
}