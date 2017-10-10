namespace CSE.FrontEnd
{
    partial class CompareProductPricesForm
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
            this.selectProductLabel = new System.Windows.Forms.Label();
            this.productListBox = new System.Windows.Forms.ComboBox();
            this.goBackButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // greetingLabel
            // 
            this.greetingLabel.AutoSize = true;
            this.greetingLabel.Font = new System.Drawing.Font("Californian FB", 14.25F, System.Drawing.FontStyle.Bold);
            this.greetingLabel.Location = new System.Drawing.Point(33, 16);
            this.greetingLabel.Name = "greetingLabel";
            this.greetingLabel.Size = new System.Drawing.Size(197, 22);
            this.greetingLabel.TabIndex = 0;
            this.greetingLabel.Text = "Compare product prices";
            // 
            // selectProductLabel
            // 
            this.selectProductLabel.AutoSize = true;
            this.selectProductLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.selectProductLabel.Location = new System.Drawing.Point(9, 66);
            this.selectProductLabel.Name = "selectProductLabel";
            this.selectProductLabel.Size = new System.Drawing.Size(115, 18);
            this.selectProductLabel.TabIndex = 1;
            this.selectProductLabel.Text = "Select a product";
            // 
            // productListBox
            // 
            this.productListBox.FormattingEnabled = true;
            this.productListBox.Location = new System.Drawing.Point(18, 100);
            this.productListBox.Name = "productListBox";
            this.productListBox.Size = new System.Drawing.Size(248, 21);
            this.productListBox.TabIndex = 2;
            // 
            // goBackButton
            // 
            this.goBackButton.Font = new System.Drawing.Font("Modern No. 20", 20.25F);
            this.goBackButton.Location = new System.Drawing.Point(19, 353);
            this.goBackButton.Name = "goBackButton";
            this.goBackButton.Size = new System.Drawing.Size(246, 76);
            this.goBackButton.TabIndex = 3;
            this.goBackButton.Text = "Go back";
            this.goBackButton.UseVisualStyleBackColor = true;
            this.goBackButton.Click += new System.EventHandler(this.goBackButton_Click);
            // 
            // CompareProductPricesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 436);
            this.Controls.Add(this.goBackButton);
            this.Controls.Add(this.productListBox);
            this.Controls.Add(this.selectProductLabel);
            this.Controls.Add(this.greetingLabel);
            this.Name = "CompareProductPricesForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label greetingLabel;
        private System.Windows.Forms.Label selectProductLabel;
        public System.Windows.Forms.ComboBox productListBox;
        private System.Windows.Forms.Button goBackButton;
    }
}