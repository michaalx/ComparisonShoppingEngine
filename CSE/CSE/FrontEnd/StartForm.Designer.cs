namespace CSE.FrontEnd
{
    partial class StartForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.getDataButton = new System.Windows.Forms.Button();
            this.uploadDataButton = new System.Windows.Forms.Button();
            this.exitButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Californian FB", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(22, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(242, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "Comparison Shopping Engine";
            // 
            // getDataButton
            // 
            this.getDataButton.Font = new System.Drawing.Font("Modern No. 20", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.getDataButton.Location = new System.Drawing.Point(22, 69);
            this.getDataButton.Name = "getDataButton";
            this.getDataButton.Size = new System.Drawing.Size(241, 88);
            this.getDataButton.TabIndex = 1;
            this.getDataButton.Text = "Get data";
            this.getDataButton.UseVisualStyleBackColor = true;
            this.getDataButton.Click += new System.EventHandler(this.GetDataButton_Click);
            // 
            // uploadDataButton
            // 
            this.uploadDataButton.Font = new System.Drawing.Font("Modern No. 20", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uploadDataButton.Location = new System.Drawing.Point(22, 177);
            this.uploadDataButton.Name = "uploadDataButton";
            this.uploadDataButton.Size = new System.Drawing.Size(241, 91);
            this.uploadDataButton.TabIndex = 1;
            this.uploadDataButton.Text = "Upload data";
            this.uploadDataButton.UseVisualStyleBackColor = true;
            this.uploadDataButton.Click += new System.EventHandler(this.UploadDataButton_Click);
            // 
            // exitButton
            // 
            this.exitButton.Font = new System.Drawing.Font("Modern No. 20", 20.25F);
            this.exitButton.Location = new System.Drawing.Point(22, 283);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(241, 102);
            this.exitButton.TabIndex = 2;
            this.exitButton.Text = "Exit";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.ExitButton_OnClick);
            // 
            // StartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 450);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.uploadDataButton);
            this.Controls.Add(this.getDataButton);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "StartForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Welcome";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.StartForm_Closing);
            this.Load += new System.EventHandler(this.StartForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button getDataButton;
        private System.Windows.Forms.Button uploadDataButton;
        private System.Windows.Forms.Button exitButton;
    }
}