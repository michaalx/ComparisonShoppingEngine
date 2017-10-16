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
            this.goBackButton = new System.Windows.Forms.Button();
            this.listViewOfAllProducts = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.addToCartButton = new System.Windows.Forms.Button();
            this.showCartButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // greetingLabel
            // 
            this.greetingLabel.AutoSize = true;
            this.greetingLabel.Font = new System.Drawing.Font("Californian FB", 14.25F, System.Drawing.FontStyle.Bold);
            this.greetingLabel.Location = new System.Drawing.Point(33, 17);
            this.greetingLabel.Name = "greetingLabel";
            this.greetingLabel.Size = new System.Drawing.Size(197, 22);
            this.greetingLabel.TabIndex = 0;
            this.greetingLabel.Text = "Compare product prices";
            // 
            // selectProductLabel
            // 
            this.selectProductLabel.AutoSize = true;
            this.selectProductLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.selectProductLabel.Location = new System.Drawing.Point(22, 50);
            this.selectProductLabel.Name = "selectProductLabel";
            this.selectProductLabel.Size = new System.Drawing.Size(115, 18);
            this.selectProductLabel.TabIndex = 1;
            this.selectProductLabel.Text = "Select a product";
            // 
            // goBackButton
            // 
            this.goBackButton.Font = new System.Drawing.Font("Modern No. 20", 20.25F);
            this.goBackButton.Location = new System.Drawing.Point(12, 385);
            this.goBackButton.Name = "goBackButton";
            this.goBackButton.Size = new System.Drawing.Size(260, 82);
            this.goBackButton.TabIndex = 3;
            this.goBackButton.Text = "Go back";
            this.goBackButton.UseVisualStyleBackColor = true;
            this.goBackButton.Click += new System.EventHandler(this.GoBackButton_Click);
            // 
            // listViewOfAllProducts
            // 
            this.listViewOfAllProducts.CheckBoxes = true;
            this.listViewOfAllProducts.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.listViewOfAllProducts.Location = new System.Drawing.Point(12, 71);
            this.listViewOfAllProducts.Name = "listViewOfAllProducts";
            this.listViewOfAllProducts.Size = new System.Drawing.Size(260, 208);
            this.listViewOfAllProducts.TabIndex = 4;
            this.listViewOfAllProducts.UseCompatibleStateImageBehavior = false;
            this.listViewOfAllProducts.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Product name";
            this.columnHeader1.Width = 225;
            // 
            // addToCartButton
            // 
            this.addToCartButton.Font = new System.Drawing.Font("Modern No. 20", 20.25F);
            this.addToCartButton.Location = new System.Drawing.Point(12, 299);
            this.addToCartButton.Name = "addToCartButton";
            this.addToCartButton.Size = new System.Drawing.Size(125, 80);
            this.addToCartButton.TabIndex = 5;
            this.addToCartButton.Text = "Add to cart";
            this.addToCartButton.UseVisualStyleBackColor = true;
            this.addToCartButton.Click += new System.EventHandler(this.AddToCartButton_OnClick);
            // 
            // showCartButton
            // 
            this.showCartButton.Font = new System.Drawing.Font("Modern No. 20", 20.25F);
            this.showCartButton.Location = new System.Drawing.Point(143, 299);
            this.showCartButton.Name = "showCartButton";
            this.showCartButton.Size = new System.Drawing.Size(129, 80);
            this.showCartButton.TabIndex = 5;
            this.showCartButton.Text = "Show cart";
            this.showCartButton.UseVisualStyleBackColor = true;
            this.showCartButton.Click += new System.EventHandler(this.ShowCartButton_OnClick);
            // 
            // CompareProductPricesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 470);
            this.Controls.Add(this.showCartButton);
            this.Controls.Add(this.addToCartButton);
            this.Controls.Add(this.listViewOfAllProducts);
            this.Controls.Add(this.goBackButton);
            this.Controls.Add(this.selectProductLabel);
            this.Controls.Add(this.greetingLabel);
            this.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "CompareProductPricesForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CompareProductPricesForm_FormClosing);
            this.Load += new System.EventHandler(this.CompareProductPricesForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label greetingLabel;
        private System.Windows.Forms.Label selectProductLabel;
        private System.Windows.Forms.Button goBackButton;
        private System.Windows.Forms.ListView listViewOfAllProducts;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.Button addToCartButton;
        private System.Windows.Forms.Button showCartButton;
    }
}