namespace Temp_1028_6_B
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
            this.axMapControl_main = new ESRI.ArcGIS.Controls.AxMapControl();
            this.axTOCControl_main = new ESRI.ArcGIS.Controls.AxTOCControl();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_openMxd = new System.Windows.Forms.Button();
            this.axToolbarControl_main = new ESRI.ArcGIS.Controls.AxToolbarControl();
            this.btn_viewPoint = new System.Windows.Forms.Button();
            this.btn_exportMap = new System.Windows.Forms.Button();
            this.btn_save = new System.Windows.Forms.Button();
            this.btn_visit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.axLicenseControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axMapControl_main)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axTOCControl_main)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axToolbarControl_main)).BeginInit();
            this.SuspendLayout();
            // 
            // axLicenseControl1
            // 
            this.axLicenseControl1.Enabled = true;
            this.axLicenseControl1.Location = new System.Drawing.Point(205, 231);
            this.axLicenseControl1.Name = "axLicenseControl1";
            this.axLicenseControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axLicenseControl1.OcxState")));
            this.axLicenseControl1.Size = new System.Drawing.Size(32, 32);
            this.axLicenseControl1.TabIndex = 0;
            // 
            // axMapControl_main
            // 
            this.axMapControl_main.Location = new System.Drawing.Point(12, 103);
            this.axMapControl_main.Name = "axMapControl_main";
            this.axMapControl_main.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axMapControl_main.OcxState")));
            this.axMapControl_main.Size = new System.Drawing.Size(586, 398);
            this.axMapControl_main.TabIndex = 1;
            this.axMapControl_main.OnMouseDown += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnMouseDownEventHandler(this.axMapControl_main_OnMouseDown);
            // 
            // axTOCControl_main
            // 
            this.axTOCControl_main.Location = new System.Drawing.Point(605, 69);
            this.axTOCControl_main.Name = "axTOCControl_main";
            this.axTOCControl_main.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axTOCControl_main.OcxState")));
            this.axTOCControl_main.Size = new System.Drawing.Size(198, 432);
            this.axTOCControl_main.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_visit);
            this.groupBox1.Controls.Add(this.btn_save);
            this.groupBox1.Controls.Add(this.btn_exportMap);
            this.groupBox1.Controls.Add(this.btn_viewPoint);
            this.groupBox1.Controls.Add(this.btn_openMxd);
            this.groupBox1.Location = new System.Drawing.Point(12, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(791, 58);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "功能区";
            // 
            // btn_openMxd
            // 
            this.btn_openMxd.Location = new System.Drawing.Point(6, 20);
            this.btn_openMxd.Name = "btn_openMxd";
            this.btn_openMxd.Size = new System.Drawing.Size(95, 23);
            this.btn_openMxd.TabIndex = 0;
            this.btn_openMxd.Text = "打开地图文档";
            this.btn_openMxd.UseVisualStyleBackColor = true;
            this.btn_openMxd.Click += new System.EventHandler(this.btn_openMxd_Click);
            // 
            // axToolbarControl_main
            // 
            this.axToolbarControl_main.Location = new System.Drawing.Point(18, 69);
            this.axToolbarControl_main.Name = "axToolbarControl_main";
            this.axToolbarControl_main.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axToolbarControl_main.OcxState")));
            this.axToolbarControl_main.Size = new System.Drawing.Size(580, 28);
            this.axToolbarControl_main.TabIndex = 5;
            // 
            // btn_viewPoint
            // 
            this.btn_viewPoint.Location = new System.Drawing.Point(107, 20);
            this.btn_viewPoint.Name = "btn_viewPoint";
            this.btn_viewPoint.Size = new System.Drawing.Size(118, 23);
            this.btn_viewPoint.TabIndex = 1;
            this.btn_viewPoint.Text = "添加观看预设点";
            this.btn_viewPoint.UseVisualStyleBackColor = true;
            this.btn_viewPoint.Click += new System.EventHandler(this.btn_viewPoint_Click);
            // 
            // btn_exportMap
            // 
            this.btn_exportMap.Location = new System.Drawing.Point(337, 20);
            this.btn_exportMap.Name = "btn_exportMap";
            this.btn_exportMap.Size = new System.Drawing.Size(75, 23);
            this.btn_exportMap.TabIndex = 2;
            this.btn_exportMap.Text = "导出地图";
            this.btn_exportMap.UseVisualStyleBackColor = true;
            this.btn_exportMap.Click += new System.EventHandler(this.btn_exportMap_Click);
            // 
            // btn_save
            // 
            this.btn_save.Location = new System.Drawing.Point(419, 20);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(75, 23);
            this.btn_save.TabIndex = 3;
            this.btn_save.Text = "保存地图";
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // btn_visit
            // 
            this.btn_visit.Location = new System.Drawing.Point(232, 21);
            this.btn_visit.Name = "btn_visit";
            this.btn_visit.Size = new System.Drawing.Size(99, 23);
            this.btn_visit.TabIndex = 4;
            this.btn_visit.Text = "可见性分析";
            this.btn_visit.UseVisualStyleBackColor = true;
            this.btn_visit.Click += new System.EventHandler(this.btn_visit_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(815, 513);
            this.Controls.Add(this.axToolbarControl_main);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.axTOCControl_main);
            this.Controls.Add(this.axMapControl_main);
            this.Controls.Add(this.axLicenseControl1);
            this.Name = "FormMain";
            this.Text = "主窗体";
            this.Load += new System.EventHandler(this.FormMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.axLicenseControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axMapControl_main)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axTOCControl_main)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.axToolbarControl_main)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ESRI.ArcGIS.Controls.AxLicenseControl axLicenseControl1;
        private ESRI.ArcGIS.Controls.AxMapControl axMapControl_main;
        private ESRI.ArcGIS.Controls.AxTOCControl axTOCControl_main;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_openMxd;
        private ESRI.ArcGIS.Controls.AxToolbarControl axToolbarControl_main;
        private System.Windows.Forms.Button btn_viewPoint;
        private System.Windows.Forms.Button btn_exportMap;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.Button btn_visit;

    }
}

