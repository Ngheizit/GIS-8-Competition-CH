namespace Temp_1119_6_B
{
    partial class FormMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.axLicenseControl1 = new ESRI.ArcGIS.Controls.AxLicenseControl();
            this.axMapControl1 = new ESRI.ArcGIS.Controls.AxMapControl();
            this.axTOCControl1 = new ESRI.ArcGIS.Controls.AxTOCControl();
            this.axToolbarControl1 = new ESRI.ArcGIS.Controls.AxToolbarControl();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_LoadMxd = new System.Windows.Forms.Button();
            this.btn_BuildingInfo = new System.Windows.Forms.Button();
            this.btn_roadAna = new System.Windows.Forms.Button();
            this.btn_save = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.axLicenseControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axMapControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axTOCControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axToolbarControl1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // axLicenseControl1
            // 
            this.axLicenseControl1.Enabled = true;
            this.axLicenseControl1.Location = new System.Drawing.Point(379, 379);
            this.axLicenseControl1.Name = "axLicenseControl1";
            this.axLicenseControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axLicenseControl1.OcxState")));
            this.axLicenseControl1.Size = new System.Drawing.Size(32, 32);
            this.axLicenseControl1.TabIndex = 0;
            // 
            // axMapControl1
            // 
            this.axMapControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.axMapControl1.Location = new System.Drawing.Point(12, 93);
            this.axMapControl1.Name = "axMapControl1";
            this.axMapControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axMapControl1.OcxState")));
            this.axMapControl1.Size = new System.Drawing.Size(543, 415);
            this.axMapControl1.TabIndex = 1;
            this.axMapControl1.OnMouseDown += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnMouseDownEventHandler(this.axMapControl1_OnMouseDown);
            // 
            // axTOCControl1
            // 
            this.axTOCControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.axTOCControl1.Location = new System.Drawing.Point(561, 46);
            this.axTOCControl1.Name = "axTOCControl1";
            this.axTOCControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axTOCControl1.OcxState")));
            this.axTOCControl1.Size = new System.Drawing.Size(223, 462);
            this.axTOCControl1.TabIndex = 2;
            // 
            // axToolbarControl1
            // 
            this.axToolbarControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.axToolbarControl1.Location = new System.Drawing.Point(561, 12);
            this.axToolbarControl1.Name = "axToolbarControl1";
            this.axToolbarControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axToolbarControl1.OcxState")));
            this.axToolbarControl1.Size = new System.Drawing.Size(223, 28);
            this.axToolbarControl1.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.btn_save);
            this.groupBox1.Controls.Add(this.btn_roadAna);
            this.groupBox1.Controls.Add(this.btn_BuildingInfo);
            this.groupBox1.Controls.Add(this.btn_LoadMxd);
            this.groupBox1.Location = new System.Drawing.Point(12, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(543, 79);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "功能区";
            // 
            // btn_LoadMxd
            // 
            this.btn_LoadMxd.Location = new System.Drawing.Point(16, 26);
            this.btn_LoadMxd.Name = "btn_LoadMxd";
            this.btn_LoadMxd.Size = new System.Drawing.Size(120, 34);
            this.btn_LoadMxd.TabIndex = 0;
            this.btn_LoadMxd.Text = "打开地图文档\r\n（导入学校信息）";
            this.btn_LoadMxd.UseVisualStyleBackColor = true;
            this.btn_LoadMxd.Click += new System.EventHandler(this.btn_LoadMxd_Click);
            // 
            // btn_BuildingInfo
            // 
            this.btn_BuildingInfo.Location = new System.Drawing.Point(157, 26);
            this.btn_BuildingInfo.Name = "btn_BuildingInfo";
            this.btn_BuildingInfo.Size = new System.Drawing.Size(109, 34);
            this.btn_BuildingInfo.TabIndex = 1;
            this.btn_BuildingInfo.Text = "查看建筑信息\r\n（状态：关闭）";
            this.btn_BuildingInfo.UseVisualStyleBackColor = true;
            this.btn_BuildingInfo.Click += new System.EventHandler(this.btn_BuildingInfo_Click);
            // 
            // btn_roadAna
            // 
            this.btn_roadAna.Location = new System.Drawing.Point(287, 26);
            this.btn_roadAna.Name = "btn_roadAna";
            this.btn_roadAna.Size = new System.Drawing.Size(111, 34);
            this.btn_roadAna.TabIndex = 2;
            this.btn_roadAna.Text = "新生报到\r\n最短路径规划";
            this.btn_roadAna.UseVisualStyleBackColor = true;
            this.btn_roadAna.Click += new System.EventHandler(this.btn_roadAna_Click);
            // 
            // btn_save
            // 
            this.btn_save.Location = new System.Drawing.Point(419, 26);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(111, 34);
            this.btn_save.TabIndex = 2;
            this.btn_save.Text = "保存地图文档";
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(796, 519);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.axToolbarControl1);
            this.Controls.Add(this.axTOCControl1);
            this.Controls.Add(this.axMapControl1);
            this.Controls.Add(this.axLicenseControl1);
            this.Name = "FormMain";
            this.Text = "数字校园新生路径规划系统";
            this.Load += new System.EventHandler(this.FormMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.axLicenseControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axMapControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axTOCControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axToolbarControl1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ESRI.ArcGIS.Controls.AxLicenseControl axLicenseControl1;
        private ESRI.ArcGIS.Controls.AxMapControl axMapControl1;
        private ESRI.ArcGIS.Controls.AxTOCControl axTOCControl1;
        private ESRI.ArcGIS.Controls.AxToolbarControl axToolbarControl1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_LoadMxd;
        private System.Windows.Forms.Button btn_BuildingInfo;
        private System.Windows.Forms.Button btn_roadAna;
        private System.Windows.Forms.Button btn_save;
    }
}

