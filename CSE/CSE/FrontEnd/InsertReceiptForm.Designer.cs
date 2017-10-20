namespace CSE.FrontEnd
{
    partial class InsertReceiptForm
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
            this.greetingLabel = new System.Windows.Forms.Label();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.browseButton = new System.Windows.Forms.Button();
            this.pathBox = new System.Windows.Forms.TextBox();
            this.uploadImageButton = new System.Windows.Forms.Button();
            this.goBackButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // greetingLabel
            // 
            this.greetingLabel.AutoSize = true;
            this.greetingLabel.Font = new System.Drawing.Font("Californian FB", 14.25F, System.Drawing.FontStyle.Bold);
            this.greetingLabel.Location = new System.Drawing.Point(44, 17);
            this.greetingLabel.Name = "greetingLabel";
            this.greetingLabel.Size = new System.Drawing.Size(183, 22);
            this.greetingLabel.TabIndex = 1;
            this.greetingLabel.Text = "Insert a receipt picture";
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            // 
            // browseButton
            // 
            this.browseButton.Font = new System.Drawing.Font("Modern No. 20", 20.25F);
            this.browseButton.Location = new System.Drawing.Point(12, 110);
            this.browseButton.Name = "browseButton";
            this.browseButton.Size = new System.Drawing.Size(260, 72);
            this.browseButton.TabIndex = 2;
            this.browseButton.Text = "Browse files";
            this.browseButton.UseVisualStyleBackColor = true;
            this.browseButton.Click += new System.EventHandler(this.BrowseButton_OnClick);
            // 
            // pathBox
            // 
            this.pathBox.Location = new System.Drawing.Point(12, 84);
            this.pathBox.Name = "pathBox";
            this.pathBox.Size = new System.Drawing.Size(260, 20);
            this.pathBox.TabIndex = 3;
            // 
            // uploadImageButton
            // 
            this.uploadImageButton.Font = new System.Drawing.Font("Modern No. 20", 20.25F);
            this.uploadImageButton.Location = new System.Drawing.Point(12, 188);
            this.uploadImageButton.Name = "uploadImageButton";
            this.uploadImageButton.Size = new System.Drawing.Size(260, 72);
            this.uploadImageButton.TabIndex = 2;
            this.uploadImageButton.Text = "Upload image";
            this.uploadImageButton.UseVisualStyleBackColor = true;
            this.uploadImageButton.Click += new System.EventHandler(this.UploadImageButton_OnClick);
            // 
            // goBackButton
            // 
            this.goBackButton.Font = new System.Drawing.Font("Modern No. 20", 20.25F);
            this.goBackButton.Location = new System.Drawing.Point(12, 266);
            this.goBackButton.Name = "goBackButton";
            this.goBackButton.Size = new System.Drawing.Size(260, 72);
            this.goBackButton.TabIndex = 2;
            this.goBackButton.Text = "Go back";
            this.goBackButton.UseVisualStyleBackColor = true;
            this.goBackButton.Click += new System.EventHandler(this.GoBackButton_OnClick);
            // 
            // InsertReceiptForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 415);
            this.Controls.Add(this.pathBox);
            this.Controls.Add(this.goBackButton);
            this.Controls.Add(this.uploadImageButton);
            this.Controls.Add(this.browseButton);
            this.Controls.Add(this.greetingLabel);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "InsertReceiptForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.InsertReceiptForm_FormClosing);
            this.Load += new System.EventHandler(this.InsertReceiptForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label greetingLabel;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Button browseButton;
        private System.Windows.Forms.TextBox pathBox;
        private System.Windows.Forms.Button uploadImageButton;
        private System.Windows.Forms.Button goBackButton;
    }
}