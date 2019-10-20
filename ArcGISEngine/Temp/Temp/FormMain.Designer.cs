namespace Temp
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
            this.axTOCControl_main = new ESRI.ArcGIS.Controls.AxTOCControl();
            this.axMapControl_main = new ESRI.ArcGIS.Controls.AxMapControl();
            this.axToolbarControl_main = new ESRI.ArcGIS.Controls.AxToolbarControl();
            this.btn_saveDocument = new System.Windows.Forms.Button();
            this.cmbx_draw = new System.Windows.Forms.ComboBox();
            this.ckbx_eye = new System.Windows.Forms.CheckBox();
            this.axMapControl_eye = new ESRI.ArcGIS.Controls.AxMapControl();
            ((System.ComponentModel.ISupportInitialize)(this.axLicenseControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axTOCControl_main)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axMapControl_main)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axToolbarControl_main)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axMapControl_eye)).BeginInit();
            this.SuspendLayout();
            // 
            // axLicenseControl1
            // 
            this.axLicenseControl1.Enabled = true;
            this.axLicenseControl1.Location = new System.Drawing.Point(93, 127);
            this.axLicenseControl1.Name = "axLicenseControl1";
            this.axLicenseControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axLicenseControl1.OcxState")));
            this.axLicenseControl1.Size = new System.Drawing.Size(32, 32);
            this.axLicenseControl1.TabIndex = 0;
            // 
            // axTOCControl_main
            // 
            this.axTOCControl_main.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.axTOCControl_main.Location = new System.Drawing.Point(627, 27);
            this.axTOCControl_main.Name = "axTOCControl_main";
            this.axTOCControl_main.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axTOCControl_main.OcxState")));
            this.axTOCControl_main.Size = new System.Drawing.Size(252, 488);
            this.axTOCControl_main.TabIndex = 1;
            this.axTOCControl_main.OnMouseDown += new ESRI.ArcGIS.Controls.ITOCControlEvents_Ax_OnMouseDownEventHandler(this.axTOCControl_main_OnMouseDown);
            // 
            // axMapControl_main
            // 
            this.axMapControl_main.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.axMapControl_main.Location = new System.Drawing.Point(0, 27);
            this.axMapControl_main.Name = "axMapControl_main";
            this.axMapControl_main.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axMapControl_main.OcxState")));
            this.axMapControl_main.Size = new System.Drawing.Size(628, 488);
            this.axMapControl_main.TabIndex = 2;
            this.axMapControl_main.OnMouseDown += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnMouseDownEventHandler(this.axMapControl_main_OnMouseDown);
            this.axMapControl_main.OnExtentUpdated += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnExtentUpdatedEventHandler(this.axMapControl_main_OnExtentUpdated);
            // 
            // axToolbarControl_main
            // 
            this.axToolbarControl_main.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.axToolbarControl_main.Location = new System.Drawing.Point(0, 0);
            this.axToolbarControl_main.Name = "axToolbarControl_main";
            this.axToolbarControl_main.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axToolbarControl_main.OcxState")));
            this.axToolbarControl_main.Size = new System.Drawing.Size(879, 28);
            this.axToolbarControl_main.TabIndex = 3;
            // 
            // btn_saveDocument
            // 
            this.btn_saveDocument.Location = new System.Drawing.Point(12, 480);
            this.btn_saveDocument.Name = "btn_saveDocument";
            this.btn_saveDocument.Size = new System.Drawing.Size(89, 23);
            this.btn_saveDocument.TabIndex = 4;
            this.btn_saveDocument.Text = "保存地图文档";
            this.btn_saveDocument.UseVisualStyleBackColor = true;
            this.btn_saveDocument.Click += new System.EventHandler(this.Buttons_Click);
            // 
            // cmbx_draw
            // 
            this.cmbx_draw.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbx_draw.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbx_draw.FormattingEnabled = true;
            this.cmbx_draw.Items.AddRange(new object[] {
            "非绘制状态",
            "绘制多边形",
            "绘制矩形",
            "绘制圆形",
            "绘制线"});
            this.cmbx_draw.Location = new System.Drawing.Point(500, 34);
            this.cmbx_draw.Name = "cmbx_draw";
            this.cmbx_draw.Size = new System.Drawing.Size(121, 20);
            this.cmbx_draw.TabIndex = 5;
            // 
            // ckbx_eye
            // 
            this.ckbx_eye.AutoSize = true;
            this.ckbx_eye.BackColor = System.Drawing.Color.Transparent;
            this.ckbx_eye.Location = new System.Drawing.Point(12, 34);
            this.ckbx_eye.Name = "ckbx_eye";
            this.ckbx_eye.Size = new System.Drawing.Size(48, 16);
            this.ckbx_eye.TabIndex = 6;
            this.ckbx_eye.Text = "鹰眼";
            this.ckbx_eye.UseVisualStyleBackColor = false;
            this.ckbx_eye.CheckedChanged += new System.EventHandler(this.ckbx_eye_CheckedChanged);
            // 
            // axMapControl_eye
            // 
            this.axMapControl_eye.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.axMapControl_eye.Location = new System.Drawing.Point(372, 365);
            this.axMapControl_eye.Name = "axMapControl_eye";
            this.axMapControl_eye.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axMapControl_eye.OcxState")));
            this.axMapControl_eye.Size = new System.Drawing.Size(256, 150);
            this.axMapControl_eye.TabIndex = 7;
            this.axMapControl_eye.Visible = false;
            this.axMapControl_eye.OnMouseDown += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnMouseDownEventHandler(this.axMapControl_eye_OnMouseDown);
            this.axMapControl_eye.OnMouseMove += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnMouseMoveEventHandler(this.axMapControl_eye_OnMouseMove);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(879, 515);
            this.Controls.Add(this.axMapControl_eye);
            this.Controls.Add(this.ckbx_eye);
            this.Controls.Add(this.cmbx_draw);
            this.Controls.Add(this.btn_saveDocument);
            this.Controls.Add(this.axToolbarControl_main);
            this.Controls.Add(this.axMapControl_main);
            this.Controls.Add(this.axTOCControl_main);
            this.Controls.Add(this.axLicenseControl1);
            this.Name = "FormMain";
            this.Text = "主窗体";
            this.Load += new System.EventHandler(this.FormMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.axLicenseControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axTOCControl_main)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axMapControl_main)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axToolbarControl_main)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axMapControl_eye)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ESRI.ArcGIS.Controls.AxLicenseControl axLicenseControl1;
        private ESRI.ArcGIS.Controls.AxTOCControl axTOCControl_main;
        private ESRI.ArcGIS.Controls.AxMapControl axMapControl_main;
        private ESRI.ArcGIS.Controls.AxToolbarControl axToolbarControl_main;
        private System.Windows.Forms.Button btn_saveDocument;
        private System.Windows.Forms.ComboBox cmbx_draw;
        private System.Windows.Forms.CheckBox ckbx_eye;
        private ESRI.ArcGIS.Controls.AxMapControl axMapControl_eye;
    }
}

