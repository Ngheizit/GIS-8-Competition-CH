namespace AeDome
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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btn_save = new System.Windows.Forms.Button();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.ckbx_hawkeye = new System.Windows.Forms.CheckBox();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.rdobtn_dataView = new System.Windows.Forms.RadioButton();
            this.rdobtn_layoutView = new System.Windows.Forms.RadioButton();
            this.flowLayoutPanel4 = new System.Windows.Forms.FlowLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.ckbx_select = new System.Windows.Forms.CheckBox();
            this.cbbx_select = new System.Windows.Forms.ComboBox();
            this.listBox_selectLayers = new System.Windows.Forms.ListBox();
            this.btn_clearselect = new System.Windows.Forms.Button();
            this.axMapControl_hawkeye = new ESRI.ArcGIS.Controls.AxMapControl();
            this.axPageLayoutControl_main = new ESRI.ArcGIS.Controls.AxPageLayoutControl();
            this.btn_ExportMap = new System.Windows.Forms.Button();
            this.btn_selectBySQL = new System.Windows.Forms.Button();
            this.tbx_selectBySQL = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.axLicenseControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axMapControl_main)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axTOCControl_main)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.flowLayoutPanel3.SuspendLayout();
            this.flowLayoutPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axMapControl_hawkeye)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axPageLayoutControl_main)).BeginInit();
            this.SuspendLayout();
            // 
            // axLicenseControl1
            // 
            this.axLicenseControl1.Enabled = true;
            this.axLicenseControl1.Location = new System.Drawing.Point(295, 552);
            this.axLicenseControl1.Name = "axLicenseControl1";
            this.axLicenseControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axLicenseControl1.OcxState")));
            this.axLicenseControl1.Size = new System.Drawing.Size(32, 32);
            this.axLicenseControl1.TabIndex = 0;
            // 
            // axMapControl_main
            // 
            this.axMapControl_main.Location = new System.Drawing.Point(202, 0);
            this.axMapControl_main.Name = "axMapControl_main";
            this.axMapControl_main.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axMapControl_main.OcxState")));
            this.axMapControl_main.Size = new System.Drawing.Size(698, 584);
            this.axMapControl_main.TabIndex = 1;
            this.axMapControl_main.OnMouseDown += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnMouseDownEventHandler(this.axMapControl_main_OnMouseDown);
            this.axMapControl_main.OnAfterScreenDraw += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnAfterScreenDrawEventHandler(this.axMapControl_main_OnAfterScreenDraw);
            this.axMapControl_main.OnExtentUpdated += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnExtentUpdatedEventHandler(this.axMapControl_main_OnExtentUpdated);
            // 
            // axTOCControl_main
            // 
            this.axTOCControl_main.Location = new System.Drawing.Point(899, 0);
            this.axTOCControl_main.Name = "axTOCControl_main";
            this.axTOCControl_main.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axTOCControl_main.OcxState")));
            this.axTOCControl_main.Size = new System.Drawing.Size(258, 584);
            this.axTOCControl_main.TabIndex = 2;
            this.axTOCControl_main.OnMouseDown += new ESRI.ArcGIS.Controls.ITOCControlEvents_Ax_OnMouseDownEventHandler(this.axTOCControl_main_OnMouseDown);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.White;
            this.flowLayoutPanel1.Controls.Add(this.btn_save);
            this.flowLayoutPanel1.Controls.Add(this.flowLayoutPanel2);
            this.flowLayoutPanel1.Controls.Add(this.flowLayoutPanel3);
            this.flowLayoutPanel1.Controls.Add(this.flowLayoutPanel4);
            this.flowLayoutPanel1.Controls.Add(this.btn_ExportMap);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(1, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(201, 584);
            this.flowLayoutPanel1.TabIndex = 3;
            // 
            // btn_save
            // 
            this.btn_save.Location = new System.Drawing.Point(3, 3);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(194, 23);
            this.btn_save.TabIndex = 0;
            this.btn_save.Text = "保存地图文档";
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.Buttons_Click);
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.label1);
            this.flowLayoutPanel2.Controls.Add(this.ckbx_hawkeye);
            this.flowLayoutPanel2.Location = new System.Drawing.Point(3, 32);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(192, 19);
            this.flowLayoutPanel2.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 3);
            this.label1.Margin = new System.Windows.Forms.Padding(3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "鹰眼视图：";
            // 
            // ckbx_hawkeye
            // 
            this.ckbx_hawkeye.AutoSize = true;
            this.ckbx_hawkeye.Location = new System.Drawing.Point(74, 3);
            this.ckbx_hawkeye.Name = "ckbx_hawkeye";
            this.ckbx_hawkeye.Size = new System.Drawing.Size(15, 14);
            this.ckbx_hawkeye.TabIndex = 1;
            this.ckbx_hawkeye.UseVisualStyleBackColor = true;
            this.ckbx_hawkeye.CheckedChanged += new System.EventHandler(this.ckbx_hawkeye_CheckedChanged);
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.Controls.Add(this.rdobtn_dataView);
            this.flowLayoutPanel3.Controls.Add(this.rdobtn_layoutView);
            this.flowLayoutPanel3.Location = new System.Drawing.Point(3, 57);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(192, 22);
            this.flowLayoutPanel3.TabIndex = 4;
            // 
            // rdobtn_dataView
            // 
            this.rdobtn_dataView.AutoSize = true;
            this.rdobtn_dataView.Checked = true;
            this.rdobtn_dataView.Location = new System.Drawing.Point(3, 3);
            this.rdobtn_dataView.Name = "rdobtn_dataView";
            this.rdobtn_dataView.Size = new System.Drawing.Size(71, 16);
            this.rdobtn_dataView.TabIndex = 2;
            this.rdobtn_dataView.TabStop = true;
            this.rdobtn_dataView.Text = "数据视图";
            this.rdobtn_dataView.UseVisualStyleBackColor = true;
            this.rdobtn_dataView.CheckedChanged += new System.EventHandler(this.rdobtn_dataView2layoutView_CheckedChanged);
            // 
            // rdobtn_layoutView
            // 
            this.rdobtn_layoutView.AutoSize = true;
            this.rdobtn_layoutView.Location = new System.Drawing.Point(80, 3);
            this.rdobtn_layoutView.Name = "rdobtn_layoutView";
            this.rdobtn_layoutView.Size = new System.Drawing.Size(71, 16);
            this.rdobtn_layoutView.TabIndex = 3;
            this.rdobtn_layoutView.Text = "布局视图";
            this.rdobtn_layoutView.UseVisualStyleBackColor = true;
            this.rdobtn_layoutView.CheckedChanged += new System.EventHandler(this.rdobtn_dataView2layoutView_CheckedChanged);
            // 
            // flowLayoutPanel4
            // 
            this.flowLayoutPanel4.Controls.Add(this.label2);
            this.flowLayoutPanel4.Controls.Add(this.ckbx_select);
            this.flowLayoutPanel4.Controls.Add(this.cbbx_select);
            this.flowLayoutPanel4.Controls.Add(this.listBox_selectLayers);
            this.flowLayoutPanel4.Controls.Add(this.btn_clearselect);
            this.flowLayoutPanel4.Controls.Add(this.tbx_selectBySQL);
            this.flowLayoutPanel4.Controls.Add(this.btn_selectBySQL);
            this.flowLayoutPanel4.Location = new System.Drawing.Point(3, 85);
            this.flowLayoutPanel4.Name = "flowLayoutPanel4";
            this.flowLayoutPanel4.Size = new System.Drawing.Size(192, 161);
            this.flowLayoutPanel4.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 5);
            this.label2.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "选择";
            // 
            // ckbx_select
            // 
            this.ckbx_select.AutoSize = true;
            this.ckbx_select.Location = new System.Drawing.Point(38, 5);
            this.ckbx_select.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.ckbx_select.Name = "ckbx_select";
            this.ckbx_select.Size = new System.Drawing.Size(15, 14);
            this.ckbx_select.TabIndex = 1;
            this.ckbx_select.UseVisualStyleBackColor = true;
            // 
            // cbbx_select
            // 
            this.cbbx_select.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbx_select.FormattingEnabled = true;
            this.cbbx_select.Items.AddRange(new object[] {
            "矩形",
            "多边形"});
            this.cbbx_select.Location = new System.Drawing.Point(59, 3);
            this.cbbx_select.Name = "cbbx_select";
            this.cbbx_select.Size = new System.Drawing.Size(119, 20);
            this.cbbx_select.TabIndex = 0;
            // 
            // listBox_selectLayers
            // 
            this.listBox_selectLayers.FormattingEnabled = true;
            this.listBox_selectLayers.ItemHeight = 12;
            this.listBox_selectLayers.Location = new System.Drawing.Point(3, 29);
            this.listBox_selectLayers.Name = "listBox_selectLayers";
            this.listBox_selectLayers.Size = new System.Drawing.Size(175, 64);
            this.listBox_selectLayers.TabIndex = 3;
            this.listBox_selectLayers.SelectedIndexChanged += new System.EventHandler(this.listBox_selectLayers_SelectedIndexChanged);
            // 
            // btn_clearselect
            // 
            this.btn_clearselect.Location = new System.Drawing.Point(3, 99);
            this.btn_clearselect.Name = "btn_clearselect";
            this.btn_clearselect.Size = new System.Drawing.Size(175, 23);
            this.btn_clearselect.TabIndex = 4;
            this.btn_clearselect.Text = "清空选择集和图形元素";
            this.btn_clearselect.UseVisualStyleBackColor = true;
            this.btn_clearselect.Click += new System.EventHandler(this.btn_clearselect_Click);
            // 
            // axMapControl_hawkeye
            // 
            this.axMapControl_hawkeye.Location = new System.Drawing.Point(614, 0);
            this.axMapControl_hawkeye.Name = "axMapControl_hawkeye";
            this.axMapControl_hawkeye.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axMapControl_hawkeye.OcxState")));
            this.axMapControl_hawkeye.Size = new System.Drawing.Size(286, 163);
            this.axMapControl_hawkeye.TabIndex = 4;
            this.axMapControl_hawkeye.Visible = false;
            this.axMapControl_hawkeye.OnMouseMove += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnMouseMoveEventHandler(this.axMapControl_hawkeye_OnMouseMove);
            // 
            // axPageLayoutControl_main
            // 
            this.axPageLayoutControl_main.Location = new System.Drawing.Point(202, 0);
            this.axPageLayoutControl_main.Name = "axPageLayoutControl_main";
            this.axPageLayoutControl_main.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axPageLayoutControl_main.OcxState")));
            this.axPageLayoutControl_main.Size = new System.Drawing.Size(698, 584);
            this.axPageLayoutControl_main.TabIndex = 5;
            this.axPageLayoutControl_main.Visible = false;
            // 
            // btn_ExportMap
            // 
            this.btn_ExportMap.Location = new System.Drawing.Point(3, 252);
            this.btn_ExportMap.Name = "btn_ExportMap";
            this.btn_ExportMap.Size = new System.Drawing.Size(192, 23);
            this.btn_ExportMap.TabIndex = 6;
            this.btn_ExportMap.Text = "打印输出地图";
            this.btn_ExportMap.UseVisualStyleBackColor = true;
            this.btn_ExportMap.Click += new System.EventHandler(this.btn_ExportMap_Click);
            // 
            // btn_selectBySQL
            // 
            this.btn_selectBySQL.Location = new System.Drawing.Point(104, 128);
            this.btn_selectBySQL.Name = "btn_selectBySQL";
            this.btn_selectBySQL.Size = new System.Drawing.Size(75, 23);
            this.btn_selectBySQL.TabIndex = 7;
            this.btn_selectBySQL.Text = "SQL选择";
            this.btn_selectBySQL.UseVisualStyleBackColor = true;
            this.btn_selectBySQL.Click += new System.EventHandler(this.btn_selectBySQL_Click);
            // 
            // tbx_selectBySQL
            // 
            this.tbx_selectBySQL.Location = new System.Drawing.Point(3, 128);
            this.tbx_selectBySQL.Name = "tbx_selectBySQL";
            this.tbx_selectBySQL.Size = new System.Drawing.Size(95, 21);
            this.tbx_selectBySQL.TabIndex = 8;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1156, 583);
            this.Controls.Add(this.axPageLayoutControl_main);
            this.Controls.Add(this.axMapControl_hawkeye);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.axTOCControl_main);
            this.Controls.Add(this.axMapControl_main);
            this.Controls.Add(this.axLicenseControl1);
            this.Name = "FormMain";
            this.Text = "主窗体";
            this.Load += new System.EventHandler(this.FormMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.axLicenseControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axMapControl_main)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axTOCControl_main)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.flowLayoutPanel3.ResumeLayout(false);
            this.flowLayoutPanel3.PerformLayout();
            this.flowLayoutPanel4.ResumeLayout(false);
            this.flowLayoutPanel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axMapControl_hawkeye)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axPageLayoutControl_main)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ESRI.ArcGIS.Controls.AxLicenseControl axLicenseControl1;
        private ESRI.ArcGIS.Controls.AxMapControl axMapControl_main;
        private ESRI.ArcGIS.Controls.AxTOCControl axTOCControl_main;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox ckbx_hawkeye;
        private ESRI.ArcGIS.Controls.AxMapControl axMapControl_hawkeye;
        private System.Windows.Forms.RadioButton rdobtn_dataView;
        private System.Windows.Forms.RadioButton rdobtn_layoutView;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private ESRI.ArcGIS.Controls.AxPageLayoutControl axPageLayoutControl_main;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox ckbx_select;
        private System.Windows.Forms.ComboBox cbbx_select;
        private System.Windows.Forms.ListBox listBox_selectLayers;
        private System.Windows.Forms.Button btn_clearselect;
        private System.Windows.Forms.Button btn_ExportMap;
        private System.Windows.Forms.Button btn_selectBySQL;
        private System.Windows.Forms.TextBox tbx_selectBySQL;

    }
}

