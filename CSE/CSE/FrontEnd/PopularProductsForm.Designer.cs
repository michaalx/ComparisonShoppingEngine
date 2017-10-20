namespace CSE.FrontEnd
{
    partial class PopularProductsForm
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
            this.listViewOfPopularProducts = new System.Windows.Forms.ListView();
            this.product = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.store = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.price = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.addToCartButton = new System.Windows.Forms.Button();
            this.goBackButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listViewOfPopularProducts
            // 
            this.listViewOfPopularProducts.CheckBoxes = true;
            this.listViewOfPopularProducts.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.product,
            this.store,
            this.price});
            this.listViewOfPopularProducts.Location = new System.Drawing.Point(12, 62);
            this.listViewOfPopularProducts.Name = "listViewOfPopularProducts";
            this.listViewOfPopularProducts.Size = new System.Drawing.Size(260, 208);
            this.listViewOfPopularProducts.TabIndex = 5;
            this.listViewOfPopularProducts.UseCompatibleStateImageBehavior = false;
            this.listViewOfPopularProducts.View = System.Windows.Forms.View.Details;
            this.listViewOfPopularProducts.SelectedIndexChanged += new System.EventHandler(this.listViewOfAllProducts_SelectedIndexChanged);
            // 
            // product
            // 
            this.product.Text = "Product name";
            this.product.Width = 112;
            // 
            // store
            // 
            this.store.Text = "Store ";
            this.store.Width = 71;
            // 
            // price
            // 
            this.price.Text = "Price";
            // 
            // addToCartButton
            // 
            this.addToCartButton.Font = new System.Drawing.Font("Modern No. 20", 20.25F);
            this.addToCartButton.Location = new System.Drawing.Point(12, 276);
            this.addToCartButton.Name = "addToCartButton";
            this.addToCartButton.Size = new System.Drawing.Size(260, 86);
            this.addToCartButton.TabIndex = 6;
            this.addToCartButton.Text = "Add to cart";
            this.addToCartButton.UseVisualStyleBackColor = true;
            this.addToCartButton.Click += new System.EventHandler(this.AddToCartButton_Click);
            // 
            // goBackButton
            // 
            this.goBackButton.Font = new System.Drawing.Font("Modern No. 20", 20.25F);
            this.goBackButton.Location = new System.Drawing.Point(12, 376);
            this.goBackButton.Name = "goBackButton";
            this.goBackButton.Size = new System.Drawing.Size(260, 86);
            this.goBackButton.TabIndex = 6;
            this.goBackButton.Text = "Go back";
            this.goBackButton.UseVisualStyleBackColor = true;
            this.goBackButton.Click += new System.EventHandler(this.GoBackButton_OnClick);
            // 
            // PopularProductsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 474);
            this.Controls.Add(this.goBackButton);
            this.Controls.Add(this.addToCartButton);
            this.Controls.Add(this.listViewOfPopularProducts);
            this.Location = new System.Drawing.Point(550, 250);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PopularProductsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "PopularProductsForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PopularProductsForm_FormClosing);
            this.Load += new System.EventHandler(this.PopularProductsForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listViewOfPopularProducts;
        private System.Windows.Forms.ColumnHeader product;
        private System.Windows.Forms.ColumnHeader store;
        private System.Windows.Forms.ColumnHeader price;
        private System.Windows.Forms.Button addToCartButton;
        private System.Windows.Forms.Button goBackButton;
    }
}