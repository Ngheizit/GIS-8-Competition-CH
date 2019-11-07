namespace Temp_1107_6_B
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
            this.axToolbarControl_main = new ESRI.ArcGIS.Controls.AxToolbarControl();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_AddViewers = new System.Windows.Forms.Button();
            this.btn_OpenMxd = new System.Windows.Forms.Button();
            this.btn_visibility = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.axPageLayoutControl_main = new ESRI.ArcGIS.Controls.AxPageLayoutControl();
            this.btn_ExportMap = new System.Windows.Forms.Button();
            this.axToolbarControl1 = new ESRI.ArcGIS.Controls.AxToolbarControl();
            ((System.ComponentModel.ISupportInitialize)(this.axLicenseControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axMapControl_main)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axTOCControl_main)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axToolbarControl_main)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axPageLayoutControl_main)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axToolbarControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // axLicenseControl1
            // 
            this.axLicenseControl1.Enabled = true;
            this.axLicenseControl1.Location = new System.Drawing.Point(232, 152);
            this.axLicenseControl1.Name = "axLicenseControl1";
            this.axLicenseControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axLicenseControl1.OcxState")));
            this.axLicenseControl1.Size = new System.Drawing.Size(32, 32);
            this.axLicenseControl1.TabIndex = 0;
            // 
            // axMapControl_main
            // 
            this.axMapControl_main.Location = new System.Drawing.Point(0, 0);
            this.axMapControl_main.Name = "axMapControl_main";
            this.axMapControl_main.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axMapControl_main.OcxState")));
            this.axMapControl_main.Size = new System.Drawing.Size(669, 400);
            this.axMapControl_main.TabIndex = 1;
            this.axMapControl_main.OnMouseDown += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnMouseDownEventHandler(this.axMapControl_main_OnMouseDown);
            // 
            // axTOCControl_main
            // 
            this.axTOCControl_main.Location = new System.Drawing.Point(698, 12);
            this.axTOCControl_main.Name = "axTOCControl_main";
            this.axTOCControl_main.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axTOCControl_main.OcxState")));
            this.axTOCControl_main.Size = new System.Drawing.Size(219, 516);
            this.axTOCControl_main.TabIndex = 2;
            // 
            // axToolbarControl_main
            // 
            this.axToolbarControl_main.Location = new System.Drawing.Point(12, 65);
            this.axToolbarControl_main.Name = "axToolbarControl_main";
            this.axToolbarControl_main.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axToolbarControl_main.OcxState")));
            this.axToolbarControl_main.Size = new System.Drawing.Size(304, 28);
            this.axToolbarControl_main.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_ExportMap);
            this.groupBox1.Controls.Add(this.btn_visibility);
            this.groupBox1.Controls.Add(this.btn_AddViewers);
            this.groupBox1.Controls.Add(this.btn_OpenMxd);
            this.groupBox1.Location = new System.Drawing.Point(12, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(680, 54);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "功能区";
            // 
            // btn_AddViewers
            // 
            this.btn_AddViewers.Location = new System.Drawing.Point(123, 21);
            this.btn_AddViewers.Name = "btn_AddViewers";
            this.btn_AddViewers.Size = new System.Drawing.Size(129, 23);
            this.btn_AddViewers.TabIndex = 1;
            this.btn_AddViewers.Text = "2. 添加观看预设点";
            this.btn_AddViewers.UseVisualStyleBackColor = true;
            this.btn_AddViewers.Click += new System.EventHandler(this.btn_AddViewer_Click);
            // 
            // btn_OpenMxd
            // 
            this.btn_OpenMxd.Location = new System.Drawing.Point(7, 21);
            this.btn_OpenMxd.Name = "btn_OpenMxd";
            this.btn_OpenMxd.Size = new System.Drawing.Size(109, 23);
            this.btn_OpenMxd.TabIndex = 0;
            this.btn_OpenMxd.Text = "1. 打开地图文档";
            this.btn_OpenMxd.UseVisualStyleBackColor = true;
            this.btn_OpenMxd.Click += new System.EventHandler(this.btn_OpenMxd_Click);
            // 
            // btn_visibility
            // 
            this.btn_visibility.Location = new System.Drawing.Point(259, 21);
            this.btn_visibility.Name = "btn_visibility";
            this.btn_visibility.Size = new System.Drawing.Size(183, 23);
            this.btn_visibility.TabIndex = 2;
            this.btn_visibility.Text = "3. 分析观看预设点的可见范围";
            this.btn_visibility.UseVisualStyleBackColor = true;
            this.btn_visibility.Click += new System.EventHandler(this.btn_visibility_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 99);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(680, 429);
            this.tabControl1.TabIndex = 5;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.axMapControl_main);
            this.tabPage1.Location = new System.Drawing.Point(4, 4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(672, 403);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "数据视图";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.axPageLayoutControl_main);
            this.tabPage2.Location = new System.Drawing.Point(4, 4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(672, 403);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "布局视图";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // axPageLayoutControl_main
            // 
            this.axPageLayoutControl_main.Location = new System.Drawing.Point(0, 0);
            this.axPageLayoutControl_main.Name = "axPageLayoutControl_main";
            this.axPageLayoutControl_main.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axPageLayoutControl_main.OcxState")));
            this.axPageLayoutControl_main.Size = new System.Drawing.Size(669, 400);
            this.axPageLayoutControl_main.TabIndex = 0;
            // 
            // btn_ExportMap
            // 
            this.btn_ExportMap.Location = new System.Drawing.Point(449, 21);
            this.btn_ExportMap.Name = "btn_ExportMap";
            this.btn_ExportMap.Size = new System.Drawing.Size(86, 23);
            this.btn_ExportMap.TabIndex = 3;
            this.btn_ExportMap.Text = "4. 导出地图";
            this.btn_ExportMap.UseVisualStyleBackColor = true;
            this.btn_ExportMap.Click += new System.EventHandler(this.btn_ExportMap_Click);
            // 
            // axToolbarControl1
            // 
            this.axToolbarControl1.Location = new System.Drawing.Point(323, 65);
            this.axToolbarControl1.Name = "axToolbarControl1";
            this.axToolbarControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axToolbarControl1.OcxState")));
            this.axToolbarControl1.Size = new System.Drawing.Size(369, 28);
            this.axToolbarControl1.TabIndex = 6;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(929, 534);
            this.Controls.Add(this.axToolbarControl1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.axToolbarControl_main);
            this.Controls.Add(this.axTOCControl_main);
            this.Controls.Add(this.axLicenseControl1);
            this.Name = "FormMain";
            this.Text = "主窗体";
            ((System.ComponentModel.ISupportInitialize)(this.axLicenseControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axMapControl_main)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axTOCControl_main)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axToolbarControl_main)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.axPageLayoutControl_main)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axToolbarControl1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ESRI.ArcGIS.Controls.AxLicenseControl axLicenseControl1;
        private ESRI.ArcGIS.Controls.AxMapControl axMapControl_main;
        private ESRI.ArcGIS.Controls.AxTOCControl axTOCControl_main;
        private ESRI.ArcGIS.Controls.AxToolbarControl axToolbarControl_main;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_OpenMxd;
        private System.Windows.Forms.Button btn_AddViewers;
        private System.Windows.Forms.Button btn_visibility;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private ESRI.ArcGIS.Controls.AxPageLayoutControl axPageLayoutControl_main;
        private System.Windows.Forms.Button btn_ExportMap;
        private ESRI.ArcGIS.Controls.AxToolbarControl axToolbarControl1;
    }
}

