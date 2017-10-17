namespace CSE.GraphFeature
{
    partial class ChooseGraph2
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
            this.listViewGraph = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.showButton = new System.Windows.Forms.Button();
            this.notSelected = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // listViewGraph
            // 
            this.listViewGraph.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.listViewGraph.Location = new System.Drawing.Point(12, 12);
            this.listViewGraph.Name = "listViewGraph";
            this.listViewGraph.Size = new System.Drawing.Size(219, 340);
            this.listViewGraph.TabIndex = 2;
            this.listViewGraph.UseCompatibleStateImageBehavior = false;
            this.listViewGraph.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Products";
            this.columnHeader1.Width = 176;
            // 
            // showButton
            // 
            this.showButton.Location = new System.Drawing.Point(12, 358);
            this.showButton.Name = "showButton";
            this.showButton.Size = new System.Drawing.Size(219, 66);
            this.showButton.TabIndex = 3;
            this.showButton.Text = "Show";
            this.showButton.UseVisualStyleBackColor = true;
            this.showButton.Click += new System.EventHandler(this.showButton_Click);
            // 
            // notSelected
            // 
            this.notSelected.AutoSize = true;
            this.notSelected.Location = new System.Drawing.Point(32, 438);
            this.notSelected.Name = "notSelected";
            this.notSelected.Size = new System.Drawing.Size(0, 17);
            this.notSelected.TabIndex = 4;
            // 
            // ChooseGraph2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(249, 474);
            this.Controls.Add(this.notSelected);
            this.Controls.Add(this.showButton);
            this.Controls.Add(this.listViewGraph);
            this.Name = "ChooseGraph2";
            this.Text = "ChooseGraph2";
            this.Load += new System.EventHandler(this.ChooseGraph2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listViewGraph;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.Button showButton;
        private System.Windows.Forms.Label notSelected;
    }
}