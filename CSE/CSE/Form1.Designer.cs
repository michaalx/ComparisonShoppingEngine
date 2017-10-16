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
            this.comboBox = new System.Windows.Forms.ComboBox();
            this.ifError = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.insertReceiptToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chooseItemsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.removeButton = new System.Windows.Forms.Button();
            this.cheapestStore = new System.Windows.Forms.Label();
            this.CheapestStoreButton = new System.Windows.Forms.Button();
            this.addButton = new System.Windows.Forms.Button();
            this.listViewCart = new System.Windows.Forms.ListView();
            this.listViewItems = new System.Windows.Forms.ListView();
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.insertReceiptToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.chooseItemsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.menuStrip2.SuspendLayout();
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
            this.panel1.Controls.Add(this.comboBox);
            this.panel1.Controls.Add(this.ifError);
            this.panel1.Controls.Add(this.uplButton);
            this.panel1.Controls.Add(this.pathBox);
            this.panel1.Controls.Add(this.brwsButton);
            this.panel1.Controls.Add(this.menuStrip1);
            this.panel1.Location = new System.Drawing.Point(-2, 3);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(485, 373);
            this.panel1.TabIndex = 4;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // comboBox
            // 
            this.comboBox.FormattingEnabled = true;
            this.comboBox.Items.AddRange(new object[] {
            "Maxima",
            "IKI",
            "Rimi",
            "Norfa",
            "Lidl"});
            this.comboBox.Location = new System.Drawing.Point(121, 84);
            this.comboBox.Margin = new System.Windows.Forms.Padding(2);
            this.comboBox.Name = "comboBox";
            this.comboBox.Size = new System.Drawing.Size(176, 21);
            this.comboBox.TabIndex = 5;
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
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.insertReceiptToolStripMenuItem,
            this.chooseItemsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(485, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // insertReceiptToolStripMenuItem
            // 
            this.insertReceiptToolStripMenuItem.Name = "insertReceiptToolStripMenuItem";
            this.insertReceiptToolStripMenuItem.Size = new System.Drawing.Size(90, 20);
            this.insertReceiptToolStripMenuItem.Text = "Insert Receipt";
            // 
            // chooseItemsToolStripMenuItem
            // 
            this.chooseItemsToolStripMenuItem.Name = "chooseItemsToolStripMenuItem";
            this.chooseItemsToolStripMenuItem.Size = new System.Drawing.Size(91, 20);
            this.chooseItemsToolStripMenuItem.Text = "Choose Items";
            this.chooseItemsToolStripMenuItem.Click += new System.EventHandler(this.chooseItemsToolStripMenuItem_Click);
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
            // panel3
            // 
            this.panel3.Controls.Add(this.removeButton);
            this.panel3.Controls.Add(this.cheapestStore);
            this.panel3.Controls.Add(this.CheapestStoreButton);
            this.panel3.Controls.Add(this.addButton);
            this.panel3.Controls.Add(this.listViewCart);
            this.panel3.Controls.Add(this.listViewItems);
            this.panel3.Controls.Add(this.menuStrip2);
            this.panel3.Location = new System.Drawing.Point(0, 5);
            this.panel3.Margin = new System.Windows.Forms.Padding(2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(478, 367);
            this.panel3.TabIndex = 6;
            this.panel3.Visible = false;
            // 
            // removeButton
            // 
            this.removeButton.Location = new System.Drawing.Point(178, 118);
            this.removeButton.Margin = new System.Windows.Forms.Padding(2);
            this.removeButton.Name = "removeButton";
            this.removeButton.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.removeButton.Size = new System.Drawing.Size(106, 69);
            this.removeButton.TabIndex = 6;
            this.removeButton.Text = "Remove";
            this.removeButton.UseVisualStyleBackColor = true;
            this.removeButton.Click += new System.EventHandler(this.removeButton_Click);
            // 
            // cheapestStore
            // 
            this.cheapestStore.AutoSize = true;
            this.cheapestStore.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.cheapestStore.Location = new System.Drawing.Point(113, 300);
            this.cheapestStore.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.cheapestStore.Name = "cheapestStore";
            this.cheapestStore.Size = new System.Drawing.Size(0, 25);
            this.cheapestStore.TabIndex = 5;
            // 
            // CheapestStoreButton
            // 
            this.CheapestStoreButton.Location = new System.Drawing.Point(178, 192);
            this.CheapestStoreButton.Margin = new System.Windows.Forms.Padding(2);
            this.CheapestStoreButton.Name = "CheapestStoreButton";
            this.CheapestStoreButton.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.CheapestStoreButton.Size = new System.Drawing.Size(106, 64);
            this.CheapestStoreButton.TabIndex = 4;
            this.CheapestStoreButton.Text = "Show Cheapest Store";
            this.CheapestStoreButton.UseVisualStyleBackColor = true;
            this.CheapestStoreButton.Click += new System.EventHandler(this.CheapestStoreButton_Click);
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(178, 43);
            this.addButton.Margin = new System.Windows.Forms.Padding(2);
            this.addButton.Name = "addButton";
            this.addButton.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.addButton.Size = new System.Drawing.Size(106, 70);
            this.addButton.TabIndex = 3;
            this.addButton.Text = "ADD";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // listViewCart
            // 
            this.listViewCart.Location = new System.Drawing.Point(290, 43);
            this.listViewCart.Margin = new System.Windows.Forms.Padding(2);
            this.listViewCart.Name = "listViewCart";
            this.listViewCart.Size = new System.Drawing.Size(150, 214);
            this.listViewCart.TabIndex = 2;
            this.listViewCart.UseCompatibleStateImageBehavior = false;
            this.listViewCart.View = System.Windows.Forms.View.List;
            // 
            // listViewItems
            // 
            this.listViewItems.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.listViewItems.Location = new System.Drawing.Point(31, 43);
            this.listViewItems.Margin = new System.Windows.Forms.Padding(2);
            this.listViewItems.Name = "listViewItems";
            this.listViewItems.Size = new System.Drawing.Size(144, 214);
            this.listViewItems.TabIndex = 1;
            this.listViewItems.UseCompatibleStateImageBehavior = false;
            this.listViewItems.View = System.Windows.Forms.View.List;
            // 
            // menuStrip2
            // 
            this.menuStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.insertReceiptToolStripMenuItem1,
            this.chooseItemsToolStripMenuItem1});
            this.menuStrip2.Location = new System.Drawing.Point(0, 0);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip2.Size = new System.Drawing.Size(478, 24);
            this.menuStrip2.TabIndex = 0;
            this.menuStrip2.Text = "menuStrip2";
            // 
            // insertReceiptToolStripMenuItem1
            // 
            this.insertReceiptToolStripMenuItem1.Name = "insertReceiptToolStripMenuItem1";
            this.insertReceiptToolStripMenuItem1.Size = new System.Drawing.Size(90, 20);
            this.insertReceiptToolStripMenuItem1.Text = "Insert Receipt";
            this.insertReceiptToolStripMenuItem1.Click += new System.EventHandler(this.insertReceiptToolStripMenuItem1_Click);
            // 
            // chooseItemsToolStripMenuItem1
            // 
            this.chooseItemsToolStripMenuItem1.Name = "chooseItemsToolStripMenuItem1";
            this.chooseItemsToolStripMenuItem1.Size = new System.Drawing.Size(91, 20);
            this.chooseItemsToolStripMenuItem1.Text = "Choose Items";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(483, 377);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2);
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
        private System.Windows.Forms.ComboBox comboBox;
        private System.Windows.Forms.ListView listViewItems;
        private System.Windows.Forms.ListView listViewCart;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button CheapestStoreButton;
        private System.Windows.Forms.Label cheapestStore;
        private System.Windows.Forms.Button removeButton;
    }
}

