namespace CSE.FrontEnd
{
    partial class CartForm
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
            this.listViewOfChosenProducts = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.goBackButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.removeItemButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // greetingLabel
            // 
            this.greetingLabel.AutoSize = true;
            this.greetingLabel.Font = new System.Drawing.Font("Californian FB", 14.25F, System.Drawing.FontStyle.Bold);
            this.greetingLabel.Location = new System.Drawing.Point(44, 17);
            this.greetingLabel.Name = "greetingLabel";
            this.greetingLabel.Size = new System.Drawing.Size(118, 22);
            this.greetingLabel.TabIndex = 1;
            this.greetingLabel.Text = "Shopping cart";
            // 
            // selectProductLabel
            // 
            this.selectProductLabel.AutoSize = true;
            this.selectProductLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.selectProductLabel.Location = new System.Drawing.Point(24, 48);
            this.selectProductLabel.Name = "selectProductLabel";
            this.selectProductLabel.Size = new System.Drawing.Size(138, 18);
            this.selectProductLabel.TabIndex = 2;
            this.selectProductLabel.Text = "Your selected items";
            // 
            // listViewOfChosenProducts
            // 
            this.listViewOfChosenProducts.CheckBoxes = true;
            this.listViewOfChosenProducts.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.listViewOfChosenProducts.Location = new System.Drawing.Point(12, 69);
            this.listViewOfChosenProducts.Name = "listViewOfChosenProducts";
            this.listViewOfChosenProducts.Size = new System.Drawing.Size(260, 132);
            this.listViewOfChosenProducts.TabIndex = 5;
            this.listViewOfChosenProducts.UseCompatibleStateImageBehavior = false;
            this.listViewOfChosenProducts.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Product name";
            this.columnHeader1.Width = 225;
            // 
            // goBackButton
            // 
            this.goBackButton.Font = new System.Drawing.Font("Modern No. 20", 20.25F);
            this.goBackButton.Location = new System.Drawing.Point(12, 382);
            this.goBackButton.Name = "goBackButton";
            this.goBackButton.Size = new System.Drawing.Size(260, 82);
            this.goBackButton.TabIndex = 6;
            this.goBackButton.Text = "Go back";
            this.goBackButton.UseVisualStyleBackColor = true;
            this.goBackButton.Click += new System.EventHandler(this.GoBackButton_OnClick);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Modern No. 20", 20.25F);
            this.button1.Location = new System.Drawing.Point(12, 295);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(260, 82);
            this.button1.TabIndex = 7;
            this.button1.Text = "The cheapest store";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.TheCheapestStoreButton_OnClick);
            // 
            // removeItemButton
            // 
            this.removeItemButton.Font = new System.Drawing.Font("Modern No. 20", 20.25F);
            this.removeItemButton.Location = new System.Drawing.Point(12, 207);
            this.removeItemButton.Name = "removeItemButton";
            this.removeItemButton.Size = new System.Drawing.Size(260, 82);
            this.removeItemButton.TabIndex = 7;
            this.removeItemButton.Text = "Remove item ";
            this.removeItemButton.UseVisualStyleBackColor = true;
            this.removeItemButton.Click += new System.EventHandler(this.RemoveItemButton_OnClick);
            // 
            // CartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 470);
            this.Controls.Add(this.removeItemButton);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.goBackButton);
            this.Controls.Add(this.listViewOfChosenProducts);
            this.Controls.Add(this.selectProductLabel);
            this.Controls.Add(this.greetingLabel);
            this.Name = "CartForm";
            this.Load += new System.EventHandler(this.CartForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label greetingLabel;
        private System.Windows.Forms.Label selectProductLabel;
        private System.Windows.Forms.ListView listViewOfChosenProducts;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.Button goBackButton;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button removeItemButton;
    }
}