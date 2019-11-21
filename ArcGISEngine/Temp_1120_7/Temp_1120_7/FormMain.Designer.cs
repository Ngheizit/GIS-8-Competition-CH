namespace Temp_1120_7
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.axTOCControl1 = new ESRI.ArcGIS.Controls.AxTOCControl();
            this.tbx_Location = new System.Windows.Forms.TextBox();
            this.axToolbarControl1 = new ESRI.ArcGIS.Controls.AxToolbarControl();
            this.axMapControl_Main = new ESRI.ArcGIS.Controls.AxMapControl();
            this.btn_OpenMxd = new System.Windows.Forms.Button();
            this.btn_Eye = new System.Windows.Forms.Button();
            this.axMapControl_Eye = new ESRI.ArcGIS.Controls.AxMapControl();
            this.btn_Info = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.axLicenseControl1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axTOCControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axToolbarControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axMapControl_Main)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axMapControl_Eye)).BeginInit();
            this.SuspendLayout();
            // 
            // axLicenseControl1
            // 
            this.axLicenseControl1.Enabled = true;
            this.axLicenseControl1.Location = new System.Drawing.Point(296, 360);
            this.axLicenseControl1.Name = "axLicenseControl1";
            this.axLicenseControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axLicenseControl1.OcxState")));
            this.axLicenseControl1.Size = new System.Drawing.Size(32, 32);
            this.axLicenseControl1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.btn_Info);
            this.groupBox1.Controls.Add(this.btn_OpenMxd);
            this.groupBox1.Location = new System.Drawing.Point(6, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(923, 71);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "功能区";
            // 
            // axTOCControl1
            // 
            this.axTOCControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.axTOCControl1.Location = new System.Drawing.Point(6, 116);
            this.axTOCControl1.Name = "axTOCControl1";
            this.axTOCControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axTOCControl1.OcxState")));
            this.axTOCControl1.Size = new System.Drawing.Size(215, 373);
            this.axTOCControl1.TabIndex = 2;
            // 
            // tbx_Location
            // 
            this.tbx_Location.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tbx_Location.Location = new System.Drawing.Point(6, 495);
            this.tbx_Location.Name = "tbx_Location";
            this.tbx_Location.ReadOnly = true;
            this.tbx_Location.Size = new System.Drawing.Size(215, 21);
            this.tbx_Location.TabIndex = 3;
            // 
            // axToolbarControl1
            // 
            this.axToolbarControl1.Location = new System.Drawing.Point(6, 82);
            this.axToolbarControl1.Name = "axToolbarControl1";
            this.axToolbarControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axToolbarControl1.OcxState")));
            this.axToolbarControl1.Size = new System.Drawing.Size(215, 28);
            this.axToolbarControl1.TabIndex = 4;
            // 
            // axMapControl_Main
            // 
            this.axMapControl_Main.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.axMapControl_Main.Location = new System.Drawing.Point(227, 82);
            this.axMapControl_Main.Name = "axMapControl_Main";
            this.axMapControl_Main.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axMapControl_Main.OcxState")));
            this.axMapControl_Main.Size = new System.Drawing.Size(702, 434);
            this.axMapControl_Main.TabIndex = 5;
            this.axMapControl_Main.OnMouseDown += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnMouseDownEventHandler(this.axMapControl_Main_OnMouseDown);
            this.axMapControl_Main.OnMouseMove += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnMouseMoveEventHandler(this.axMapControl_Main_OnMouseMove);
            this.axMapControl_Main.OnExtentUpdated += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnExtentUpdatedEventHandler(this.axMapControl_Main_OnExtentUpdated);
            // 
            // btn_OpenMxd
            // 
            this.btn_OpenMxd.Location = new System.Drawing.Point(19, 27);
            this.btn_OpenMxd.Name = "btn_OpenMxd";
            this.btn_OpenMxd.Size = new System.Drawing.Size(95, 23);
            this.btn_OpenMxd.TabIndex = 0;
            this.btn_OpenMxd.Text = "打开地图文档";
            this.btn_OpenMxd.UseVisualStyleBackColor = true;
            this.btn_OpenMxd.Click += new System.EventHandler(this.btn_OpenMxd_Click);
            // 
            // btn_Eye
            // 
            this.btn_Eye.Location = new System.Drawing.Point(902, 84);
            this.btn_Eye.Name = "btn_Eye";
            this.btn_Eye.Size = new System.Drawing.Size(25, 25);
            this.btn_Eye.TabIndex = 6;
            this.btn_Eye.Text = "↙";
            this.btn_Eye.UseVisualStyleBackColor = true;
            this.btn_Eye.Click += new System.EventHandler(this.btn_Eye_Click);
            // 
            // axMapControl_Eye
            // 
            this.axMapControl_Eye.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.axMapControl_Eye.Location = new System.Drawing.Point(640, 84);
            this.axMapControl_Eye.Name = "axMapControl_Eye";
            this.axMapControl_Eye.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axMapControl_Eye.OcxState")));
            this.axMapControl_Eye.Size = new System.Drawing.Size(287, 133);
            this.axMapControl_Eye.TabIndex = 5;
            this.axMapControl_Eye.Visible = false;
            // 
            // btn_Info
            // 
            this.btn_Info.Location = new System.Drawing.Point(143, 27);
            this.btn_Info.Name = "btn_Info";
            this.btn_Info.Size = new System.Drawing.Size(95, 23);
            this.btn_Info.TabIndex = 0;
            this.btn_Info.Text = "宗地信息查询";
            this.btn_Info.UseVisualStyleBackColor = true;
            this.btn_Info.Click += new System.EventHandler(this.btn_Info_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(934, 520);
            this.Controls.Add(this.btn_Eye);
            this.Controls.Add(this.axMapControl_Eye);
            this.Controls.Add(this.axMapControl_Main);
            this.Controls.Add(this.axToolbarControl1);
            this.Controls.Add(this.tbx_Location);
            this.Controls.Add(this.axTOCControl1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.axLicenseControl1);
            this.Name = "FormMain";
            this.Text = "企业产值与宗地关系综合分析GIS系统";
            this.Load += new System.EventHandler(this.FormMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.axLicenseControl1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.axTOCControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axToolbarControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axMapControl_Main)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axMapControl_Eye)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ESRI.ArcGIS.Controls.AxLicenseControl axLicenseControl1;
        private System.Windows.Forms.GroupBox groupBox1;
        private ESRI.ArcGIS.Controls.AxTOCControl axTOCControl1;
        private System.Windows.Forms.TextBox tbx_Location;
        private ESRI.ArcGIS.Controls.AxToolbarControl axToolbarControl1;
        private ESRI.ArcGIS.Controls.AxMapControl axMapControl_Main;
        private System.Windows.Forms.Button btn_OpenMxd;
        private System.Windows.Forms.Button btn_Eye;
        private ESRI.ArcGIS.Controls.AxMapControl axMapControl_Eye;
        private System.Windows.Forms.Button btn_Info;
    }
}

