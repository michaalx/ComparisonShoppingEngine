namespace CSE.FrontEnd
{
    partial class GetDataForm
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
            this.comparePricesButton = new System.Windows.Forms.Button();
            this.goBackButton = new System.Windows.Forms.Button();
            this.popularProductsButton = new System.Windows.Forms.Button();
            this.staticsticsButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Californian FB", 14.25F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(47, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(141, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "Getting data area";
            // 
            // comparePricesButton
            // 
            this.comparePricesButton.Font = new System.Drawing.Font("Modern No. 20", 20.25F);
            this.comparePricesButton.Location = new System.Drawing.Point(33, 72);
            this.comparePricesButton.Name = "comparePricesButton";
            this.comparePricesButton.Size = new System.Drawing.Size(220, 91);
            this.comparePricesButton.TabIndex = 1;
            this.comparePricesButton.Text = "Compare product prices";
            this.comparePricesButton.UseVisualStyleBackColor = true;
            this.comparePricesButton.Click += new System.EventHandler(this.CompareProductPrices_Click);
            // 
            // goBackButton
            // 
            this.goBackButton.Font = new System.Drawing.Font("Modern No. 20", 20.25F);
            this.goBackButton.Location = new System.Drawing.Point(33, 368);
            this.goBackButton.Name = "goBackButton";
            this.goBackButton.Size = new System.Drawing.Size(220, 91);
            this.goBackButton.TabIndex = 1;
            this.goBackButton.Text = "Go back";
            this.goBackButton.UseVisualStyleBackColor = true;
            this.goBackButton.Click += new System.EventHandler(this.GoBack_Click);
            // 
            // popularProductsButton
            // 
            this.popularProductsButton.Font = new System.Drawing.Font("Modern No. 20", 20.25F);
            this.popularProductsButton.Location = new System.Drawing.Point(33, 169);
            this.popularProductsButton.Name = "popularProductsButton";
            this.popularProductsButton.Size = new System.Drawing.Size(220, 91);
            this.popularProductsButton.TabIndex = 1;
            this.popularProductsButton.Text = "Popular products";
            this.popularProductsButton.UseVisualStyleBackColor = true;
            this.popularProductsButton.Click += new System.EventHandler(this.PopularButton_OnClick);
            // 
            // staticsticsButton
            // 
            this.staticsticsButton.Font = new System.Drawing.Font("Modern No. 20", 20.25F);
            this.staticsticsButton.Location = new System.Drawing.Point(33, 266);
            this.staticsticsButton.Name = "staticsticsButton";
            this.staticsticsButton.Size = new System.Drawing.Size(220, 91);
            this.staticsticsButton.TabIndex = 1;
            this.staticsticsButton.Text = "Statistics";
            this.staticsticsButton.UseVisualStyleBackColor = true;
            this.staticsticsButton.Click += new System.EventHandler(this.StatisticsButton_OnClick);
            // 
            // GetDataForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 481);
            this.Controls.Add(this.goBackButton);
            this.Controls.Add(this.staticsticsButton);
            this.Controls.Add(this.popularProductsButton);
            this.Controls.Add(this.comparePricesButton);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GetDataForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GetDataForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button comparePricesButton;
        private System.Windows.Forms.Button goBackButton;
        private System.Windows.Forms.Button popularProductsButton;
        private System.Windows.Forms.Button staticsticsButton;
    }
}