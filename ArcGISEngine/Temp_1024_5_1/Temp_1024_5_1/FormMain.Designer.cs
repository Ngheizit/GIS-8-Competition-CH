namespace Temp_1024_5_1
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
            this.btn_Identify = new System.Windows.Forms.Button();
            this.rtbx_info = new System.Windows.Forms.RichTextBox();
            this.btn_clearselect = new System.Windows.Forms.Button();
            this.listBox_pts = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_select = new System.Windows.Forms.Button();
            this.btn_link = new System.Windows.Forms.Button();
            this.btn_anno = new System.Windows.Forms.Button();
            this.btn_symbol = new System.Windows.Forms.Button();
            this.btn_outlyr = new System.Windows.Forms.Button();
            this.btn_addpt = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.axLicenseControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axMapControl_main)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axTOCControl_main)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // axLicenseControl1
            // 
            this.axLicenseControl1.Enabled = true;
            this.axLicenseControl1.Location = new System.Drawing.Point(507, 360);
            this.axLicenseControl1.Name = "axLicenseControl1";
            this.axLicenseControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axLicenseControl1.OcxState")));
            this.axLicenseControl1.Size = new System.Drawing.Size(32, 32);
            this.axLicenseControl1.TabIndex = 0;
            // 
            // axMapControl_main
            // 
            this.axMapControl_main.Location = new System.Drawing.Point(173, 0);
            this.axMapControl_main.Name = "axMapControl_main";
            this.axMapControl_main.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axMapControl_main.OcxState")));
            this.axMapControl_main.Size = new System.Drawing.Size(472, 496);
            this.axMapControl_main.TabIndex = 1;
            // 
            // axTOCControl_main
            // 
            this.axTOCControl_main.Location = new System.Drawing.Point(644, 0);
            this.axTOCControl_main.Name = "axTOCControl_main";
            this.axTOCControl_main.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axTOCControl_main.OcxState")));
            this.axTOCControl_main.Size = new System.Drawing.Size(201, 301);
            this.axTOCControl_main.TabIndex = 2;
            // 
            // btn_Identify
            // 
            this.btn_Identify.Location = new System.Drawing.Point(529, 41);
            this.btn_Identify.Name = "btn_Identify";
            this.btn_Identify.Size = new System.Drawing.Size(109, 23);
            this.btn_Identify.TabIndex = 3;
            this.btn_Identify.Text = "查询监测站点";
            this.btn_Identify.UseVisualStyleBackColor = true;
            // 
            // rtbx_info
            // 
            this.rtbx_info.BackColor = System.Drawing.Color.White;
            this.rtbx_info.Location = new System.Drawing.Point(644, 300);
            this.rtbx_info.Name = "rtbx_info";
            this.rtbx_info.ReadOnly = true;
            this.rtbx_info.Size = new System.Drawing.Size(201, 196);
            this.rtbx_info.TabIndex = 4;
            this.rtbx_info.Text = "监测站点信息：";
            // 
            // btn_clearselect
            // 
            this.btn_clearselect.Location = new System.Drawing.Point(529, 12);
            this.btn_clearselect.Name = "btn_clearselect";
            this.btn_clearselect.Size = new System.Drawing.Size(109, 23);
            this.btn_clearselect.TabIndex = 5;
            this.btn_clearselect.Text = "清空选择集";
            this.btn_clearselect.UseVisualStyleBackColor = true;
            // 
            // listBox_pts
            // 
            this.listBox_pts.FormattingEnabled = true;
            this.listBox_pts.ItemHeight = 12;
            this.listBox_pts.Location = new System.Drawing.Point(12, 20);
            this.listBox_pts.Name = "listBox_pts";
            this.listBox_pts.Size = new System.Drawing.Size(155, 460);
            this.listBox_pts.TabIndex = 6;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.listBox_pts);
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(177, 496);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "监测站点";
            // 
            // btn_select
            // 
            this.btn_select.Location = new System.Drawing.Point(529, 71);
            this.btn_select.Name = "btn_select";
            this.btn_select.Size = new System.Drawing.Size(109, 23);
            this.btn_select.TabIndex = 8;
            this.btn_select.Text = "绘制多边形选择";
            this.btn_select.UseVisualStyleBackColor = true;
            // 
            // btn_link
            // 
            this.btn_link.Location = new System.Drawing.Point(529, 101);
            this.btn_link.Name = "btn_link";
            this.btn_link.Size = new System.Drawing.Size(109, 23);
            this.btn_link.TabIndex = 9;
            this.btn_link.Text = "链接监测站点信息";
            this.btn_link.UseVisualStyleBackColor = true;
            // 
            // btn_anno
            // 
            this.btn_anno.Location = new System.Drawing.Point(529, 131);
            this.btn_anno.Name = "btn_anno";
            this.btn_anno.Size = new System.Drawing.Size(109, 23);
            this.btn_anno.TabIndex = 10;
            this.btn_anno.Text = "显示区县数据";
            this.btn_anno.UseVisualStyleBackColor = true;
            // 
            // btn_symbol
            // 
            this.btn_symbol.Location = new System.Drawing.Point(529, 161);
            this.btn_symbol.Name = "btn_symbol";
            this.btn_symbol.Size = new System.Drawing.Size(109, 23);
            this.btn_symbol.TabIndex = 11;
            this.btn_symbol.Text = "可视化北京区县";
            this.btn_symbol.UseVisualStyleBackColor = true;
            // 
            // btn_outlyr
            // 
            this.btn_outlyr.Location = new System.Drawing.Point(529, 191);
            this.btn_outlyr.Name = "btn_outlyr";
            this.btn_outlyr.Size = new System.Drawing.Size(109, 23);
            this.btn_outlyr.TabIndex = 12;
            this.btn_outlyr.Text = "导出北京区县图层";
            this.btn_outlyr.UseVisualStyleBackColor = true;
            // 
            // btn_addpt
            // 
            this.btn_addpt.Location = new System.Drawing.Point(529, 221);
            this.btn_addpt.Name = "btn_addpt";
            this.btn_addpt.Size = new System.Drawing.Size(109, 23);
            this.btn_addpt.TabIndex = 13;
            this.btn_addpt.Text = "添加新监测站点";
            this.btn_addpt.UseVisualStyleBackColor = true;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(845, 496);
            this.Controls.Add(this.btn_addpt);
            this.Controls.Add(this.btn_outlyr);
            this.Controls.Add(this.btn_symbol);
            this.Controls.Add(this.btn_anno);
            this.Controls.Add(this.btn_link);
            this.Controls.Add(this.btn_select);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btn_clearselect);
            this.Controls.Add(this.rtbx_info);
            this.Controls.Add(this.btn_Identify);
            this.Controls.Add(this.axTOCControl_main);
            this.Controls.Add(this.axMapControl_main);
            this.Controls.Add(this.axLicenseControl1);
            this.Name = "FormMain";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.FormMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.axLicenseControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axMapControl_main)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axTOCControl_main)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ESRI.ArcGIS.Controls.AxLicenseControl axLicenseControl1;
        private ESRI.ArcGIS.Controls.AxMapControl axMapControl_main;
        private ESRI.ArcGIS.Controls.AxTOCControl axTOCControl_main;
        private System.Windows.Forms.Button btn_Identify;
        private System.Windows.Forms.RichTextBox rtbx_info;
        private System.Windows.Forms.Button btn_clearselect;
        private System.Windows.Forms.ListBox listBox_pts;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_select;
        private System.Windows.Forms.Button btn_link;
        private System.Windows.Forms.Button btn_anno;
        private System.Windows.Forms.Button btn_symbol;
        private System.Windows.Forms.Button btn_outlyr;
        private System.Windows.Forms.Button btn_addpt;
    }
}

