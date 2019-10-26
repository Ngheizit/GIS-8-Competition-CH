namespace AeDome.Froms
{
    partial class FromAttributeTable
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
            this.listView_table = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // listView_table
            // 
            this.listView_table.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listView_table.Location = new System.Drawing.Point(0, 0);
            this.listView_table.Name = "listView_table";
            this.listView_table.Size = new System.Drawing.Size(607, 203);
            this.listView_table.TabIndex = 0;
            this.listView_table.UseCompatibleStateImageBehavior = false;
            // 
            // FromAttributeTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(607, 203);
            this.Controls.Add(this.listView_table);
            this.Name = "FromAttributeTable";
            this.Text = "FromAttributeTable";
            this.Load += new System.EventHandler(this.FromAttributeTable_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listView_table;
    }
}