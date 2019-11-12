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
            this.btn_addTitle = new System.Windows.Forms.Button();
            this.btn_addMapElementts = new System.Windows.Forms.Button();
            this.btn_symbology = new System.Windows.Forms.Button();
            this.axToolbarControl1 = new ESRI.ArcGIS.Controls.AxToolbarControl();
            this.btn_exportMap = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.axPageLayoutControl_main)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axToolbarControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // axPageLayoutControl_main
            // 
            this.axPageLayoutControl_main.Location = new System.Drawing.Point(12, 83);
            this.axPageLayoutControl_main.Name = "axPageLayoutControl_main";
            this.axPageLayoutControl_main.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axPageLayoutControl_main.OcxState")));
            this.axPageLayoutControl_main.Size = new System.Drawing.Size(396, 493);
            this.axPageLayoutControl_main.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_exportMap);
            this.groupBox1.Controls.Add(this.btn_addTitle);
            this.groupBox1.Controls.Add(this.btn_addMapElementts);
            this.groupBox1.Controls.Add(this.btn_symbology);
            this.groupBox1.Location = new System.Drawing.Point(12, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(396, 50);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "功能区";
            // 
            // btn_addTitle
            // 
            this.btn_addTitle.Location = new System.Drawing.Point(217, 21);
            this.btn_addTitle.Name = "btn_addTitle";
            this.btn_addTitle.Size = new System.Drawing.Size(75, 23);
            this.btn_addTitle.TabIndex = 2;
            this.btn_addTitle.Text = "添加标题";
            this.btn_addTitle.UseVisualStyleBackColor = true;
            this.btn_addTitle.Click += new System.EventHandler(this.btn_addTitle_Click);
            // 
            // btn_addMapElementts
            // 
            this.btn_addMapElementts.Location = new System.Drawing.Point(95, 20);
            this.btn_addMapElementts.Name = "btn_addMapElementts";
            this.btn_addMapElementts.Size = new System.Drawing.Size(115, 23);
            this.btn_addMapElementts.TabIndex = 1;
            this.btn_addMapElementts.Text = "添加地图三要素";
            this.btn_addMapElementts.UseVisualStyleBackColor = true;
            this.btn_addMapElementts.Click += new System.EventHandler(this.btn_addMapElementts_Click);
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
            // axToolbarControl1
            // 
            this.axToolbarControl1.Location = new System.Drawing.Point(12, 54);
            this.axToolbarControl1.Name = "axToolbarControl1";
            this.axToolbarControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axToolbarControl1.OcxState")));
            this.axToolbarControl1.Size = new System.Drawing.Size(396, 28);
            this.axToolbarControl1.TabIndex = 2;
            // 
            // btn_exportMap
            // 
            this.btn_exportMap.Location = new System.Drawing.Point(299, 21);
            this.btn_exportMap.Name = "btn_exportMap";
            this.btn_exportMap.Size = new System.Drawing.Size(91, 22);
            this.btn_exportMap.TabIndex = 3;
            this.btn_exportMap.Text = "输出专题图";
            this.btn_exportMap.UseVisualStyleBackColor = true;
            this.btn_exportMap.Click += new System.EventHandler(this.btn_exportMap_Click);
            // 
            // FormExportMap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(420, 588);
            this.Controls.Add(this.axToolbarControl1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.axPageLayoutControl_main);
            this.Name = "FormExportMap";
            this.Text = "输出地图对话框";
            ((System.ComponentModel.ISupportInitialize)(this.axPageLayoutControl_main)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.axToolbarControl1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ESRI.ArcGIS.Controls.AxPageLayoutControl axPageLayoutControl_main;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_symbology;
        private ESRI.ArcGIS.Controls.AxToolbarControl axToolbarControl1;
        private System.Windows.Forms.Button btn_addMapElementts;
        private System.Windows.Forms.Button btn_addTitle;
        private System.Windows.Forms.Button btn_exportMap;
    }
}