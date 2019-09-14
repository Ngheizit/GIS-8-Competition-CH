namespace AE_Complex
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
            this.axMapControl_Main = new ESRI.ArcGIS.Controls.AxMapControl();
            this.axToolbarControl_Main = new ESRI.ArcGIS.Controls.AxToolbarControl();
            this.axTOCControl_Main = new ESRI.ArcGIS.Controls.AxTOCControl();
            this.btn_tooc = new System.Windows.Forms.Button();
            this.btn_toolbar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.axLicenseControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axMapControl_Main)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axToolbarControl_Main)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axTOCControl_Main)).BeginInit();
            this.SuspendLayout();
            // 
            // axLicenseControl1
            // 
            this.axLicenseControl1.Enabled = true;
            this.axLicenseControl1.Location = new System.Drawing.Point(53, 99);
            this.axLicenseControl1.Name = "axLicenseControl1";
            this.axLicenseControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axLicenseControl1.OcxState")));
            this.axLicenseControl1.Size = new System.Drawing.Size(32, 32);
            this.axLicenseControl1.TabIndex = 0;
            // 
            // axMapControl_Main
            // 
            this.axMapControl_Main.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.axMapControl_Main.Location = new System.Drawing.Point(0, 0);
            this.axMapControl_Main.Name = "axMapControl_Main";
            this.axMapControl_Main.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axMapControl_Main.OcxState")));
            this.axMapControl_Main.Size = new System.Drawing.Size(1401, 762);
            this.axMapControl_Main.TabIndex = 1;
            this.axMapControl_Main.OnMouseDown += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnMouseDownEventHandler(this.axMapControl_Main_OnMouseDown);
            // 
            // axToolbarControl_Main
            // 
            this.axToolbarControl_Main.Location = new System.Drawing.Point(81, 12);
            this.axToolbarControl_Main.Name = "axToolbarControl_Main";
            this.axToolbarControl_Main.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axToolbarControl_Main.OcxState")));
            this.axToolbarControl_Main.Size = new System.Drawing.Size(279, 28);
            this.axToolbarControl_Main.TabIndex = 2;
            // 
            // axTOCControl_Main
            // 
            this.axTOCControl_Main.Location = new System.Drawing.Point(13, 47);
            this.axTOCControl_Main.Name = "axTOCControl_Main";
            this.axTOCControl_Main.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axTOCControl_Main.OcxState")));
            this.axTOCControl_Main.Size = new System.Drawing.Size(347, 203);
            this.axTOCControl_Main.TabIndex = 3;
            // 
            // btn_tooc
            // 
            this.btn_tooc.Location = new System.Drawing.Point(13, 12);
            this.btn_tooc.Name = "btn_tooc";
            this.btn_tooc.Size = new System.Drawing.Size(28, 28);
            this.btn_tooc.TabIndex = 4;
            this.btn_tooc.Text = "L";
            this.btn_tooc.UseVisualStyleBackColor = true;
            this.btn_tooc.Click += new System.EventHandler(this.Buttons_OpenOrClose_Click);
            // 
            // btn_toolbar
            // 
            this.btn_toolbar.Location = new System.Drawing.Point(47, 12);
            this.btn_toolbar.Name = "btn_toolbar";
            this.btn_toolbar.Size = new System.Drawing.Size(28, 28);
            this.btn_toolbar.TabIndex = 4;
            this.btn_toolbar.Text = "T";
            this.btn_toolbar.UseVisualStyleBackColor = true;
            this.btn_toolbar.Click += new System.EventHandler(this.Buttons_OpenOrClose_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1401, 762);
            this.Controls.Add(this.btn_toolbar);
            this.Controls.Add(this.btn_tooc);
            this.Controls.Add(this.axTOCControl_Main);
            this.Controls.Add(this.axToolbarControl_Main);
            this.Controls.Add(this.axMapControl_Main);
            this.Controls.Add(this.axLicenseControl1);
            this.Name = "FormMain";
            this.Text = "FormMain";
            this.Load += new System.EventHandler(this.FormMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.axLicenseControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axMapControl_Main)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axToolbarControl_Main)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axTOCControl_Main)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ESRI.ArcGIS.Controls.AxLicenseControl axLicenseControl1;
        private ESRI.ArcGIS.Controls.AxMapControl axMapControl_Main;
        private ESRI.ArcGIS.Controls.AxToolbarControl axToolbarControl_Main;
        private ESRI.ArcGIS.Controls.AxTOCControl axTOCControl_Main;
        private System.Windows.Forms.Button btn_tooc;
        private System.Windows.Forms.Button btn_toolbar;
    }
}

