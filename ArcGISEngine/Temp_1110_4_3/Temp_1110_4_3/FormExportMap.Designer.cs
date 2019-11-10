namespace Temp_1110_4_3
{
    partial class FormExportMap
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormExportMap));
            this.axPageLayoutControl_main = new ESRI.ArcGIS.Controls.AxPageLayoutControl();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_symbology = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.axPageLayoutControl_main)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // axPageLayoutControl_main
            // 
            this.axPageLayoutControl_main.Location = new System.Drawing.Point(12, 59);
            this.axPageLayoutControl_main.Name = "axPageLayoutControl_main";
            this.axPageLayoutControl_main.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axPageLayoutControl_main.OcxState")));
            this.axPageLayoutControl_main.Size = new System.Drawing.Size(396, 493);
            this.axPageLayoutControl_main.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_symbology);
            this.groupBox1.Location = new System.Drawing.Point(12, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(396, 50);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "功能区";
            // 
            // btn_symbology
            // 
            this.btn_symbology.Location = new System.Drawing.Point(6, 20);
            this.btn_symbology.Name = "btn_symbology";
            this.btn_symbology.Size = new System.Drawing.Size(83, 23);
            this.btn_symbology.TabIndex = 0;
            this.btn_symbology.Text = "符号化图层";
            this.btn_symbology.UseVisualStyleBackColor = true;
            this.btn_symbology.Click += new System.EventHandler(this.btn_symbology_Click);
            // 
            // FormExportMap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(420, 564);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.axPageLayoutControl_main);
            this.Name = "FormExportMap";
            this.Text = "FormExportMap";
            ((System.ComponentModel.ISupportInitialize)(this.axPageLayoutControl_main)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ESRI.ArcGIS.Controls.AxPageLayoutControl axPageLayoutControl_main;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_symbology;
    }
}