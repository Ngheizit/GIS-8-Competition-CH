namespace Temp_1110_4_3
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
            this.btn_help = new System.Windows.Forms.Button();
            this.btn_ExportMap = new System.Windows.Forms.Button();
            this.btn_weightedOverlay = new System.Windows.Forms.Button();
            this.btn_classify = new System.Windows.Forms.Button();
            this.btn_GetWater = new System.Windows.Forms.Button();
            this.btn_AnalysisFillArr = new System.Windows.Forms.Button();
            this.btn_AddData = new System.Windows.Forms.Button();
            this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.lineShape6 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.lineShape5 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.lineShape4 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.lineShape3 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.lineShape2 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.lineShape1 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.axTOCControl_main = new ESRI.ArcGIS.Controls.AxTOCControl();
            this.axMapControl_main = new ESRI.ArcGIS.Controls.AxMapControl();
            this.axToolbarControl_main = new ESRI.ArcGIS.Controls.AxToolbarControl();
            ((System.ComponentModel.ISupportInitialize)(this.axLicenseControl1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axTOCControl_main)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axMapControl_main)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axToolbarControl_main)).BeginInit();
            this.SuspendLayout();
            // 
            // axLicenseControl1
            // 
            this.axLicenseControl1.Enabled = true;
            this.axLicenseControl1.Location = new System.Drawing.Point(358, 385);
            this.axLicenseControl1.Name = "axLicenseControl1";
            this.axLicenseControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axLicenseControl1.OcxState")));
            this.axLicenseControl1.Size = new System.Drawing.Size(32, 32);
            this.axLicenseControl1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_help);
            this.groupBox1.Controls.Add(this.btn_ExportMap);
            this.groupBox1.Controls.Add(this.btn_weightedOverlay);
            this.groupBox1.Controls.Add(this.btn_classify);
            this.groupBox1.Controls.Add(this.btn_GetWater);
            this.groupBox1.Controls.Add(this.btn_AnalysisFillArr);
            this.groupBox1.Controls.Add(this.btn_AddData);
            this.groupBox1.Controls.Add(this.shapeContainer1);
            this.groupBox1.Location = new System.Drawing.Point(11, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(764, 123);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "功能区";
            // 
            // btn_help
            // 
            this.btn_help.Location = new System.Drawing.Point(660, 12);
            this.btn_help.Name = "btn_help";
            this.btn_help.Size = new System.Drawing.Size(98, 23);
            this.btn_help.TabIndex = 7;
            this.btn_help.Text = "系统使用说明";
            this.btn_help.UseVisualStyleBackColor = true;
            this.btn_help.Click += new System.EventHandler(this.btn_help_Click);
            // 
            // btn_ExportMap
            // 
            this.btn_ExportMap.Location = new System.Drawing.Point(704, 41);
            this.btn_ExportMap.Name = "btn_ExportMap";
            this.btn_ExportMap.Size = new System.Drawing.Size(24, 43);
            this.btn_ExportMap.TabIndex = 5;
            this.btn_ExportMap.Text = "出 图";
            this.btn_ExportMap.UseVisualStyleBackColor = true;
            this.btn_ExportMap.Click += new System.EventHandler(this.btn_ExportMap_Click);
            // 
            // btn_weightedOverlay
            // 
            this.btn_weightedOverlay.Location = new System.Drawing.Point(531, 41);
            this.btn_weightedOverlay.Name = "btn_weightedOverlay";
            this.btn_weightedOverlay.Size = new System.Drawing.Size(124, 43);
            this.btn_weightedOverlay.TabIndex = 4;
            this.btn_weightedOverlay.Text = "加权叠加生成生态因子敏感度等级分布";
            this.btn_weightedOverlay.UseVisualStyleBackColor = true;
            this.btn_weightedOverlay.Click += new System.EventHandler(this.btn_weightedOverlay_Click);
            // 
            // btn_classify
            // 
            this.btn_classify.Location = new System.Drawing.Point(377, 41);
            this.btn_classify.Name = "btn_classify";
            this.btn_classify.Size = new System.Drawing.Size(97, 43);
            this.btn_classify.TabIndex = 3;
            this.btn_classify.Text = "生态因子敏感性等级分类";
            this.btn_classify.UseVisualStyleBackColor = true;
            this.btn_classify.Click += new System.EventHandler(this.btn_classify_Click);
            // 
            // btn_GetWater
            // 
            this.btn_GetWater.Location = new System.Drawing.Point(209, 65);
            this.btn_GetWater.Name = "btn_GetWater";
            this.btn_GetWater.Size = new System.Drawing.Size(116, 43);
            this.btn_GetWater.TabIndex = 2;
            this.btn_GetWater.Text = "提取植被覆盖范围内的河流数据";
            this.btn_GetWater.UseVisualStyleBackColor = true;
            this.btn_GetWater.Click += new System.EventHandler(this.btn_GetWater_Click);
            // 
            // btn_AnalysisFillArr
            // 
            this.btn_AnalysisFillArr.Location = new System.Drawing.Point(209, 16);
            this.btn_AnalysisFillArr.Name = "btn_AnalysisFillArr";
            this.btn_AnalysisFillArr.Size = new System.Drawing.Size(116, 43);
            this.btn_AnalysisFillArr.TabIndex = 1;
            this.btn_AnalysisFillArr.Text = "计算植被覆盖范围内的坡度、坡向";
            this.btn_AnalysisFillArr.UseVisualStyleBackColor = true;
            this.btn_AnalysisFillArr.Click += new System.EventHandler(this.btn_AnalysisFillArr_Click);
            // 
            // btn_AddData
            // 
            this.btn_AddData.Location = new System.Drawing.Point(25, 41);
            this.btn_AddData.Name = "btn_AddData";
            this.btn_AddData.Size = new System.Drawing.Size(119, 43);
            this.btn_AddData.TabIndex = 0;
            this.btn_AddData.Text = "添加区域高程模型和植被覆盖信息";
            this.btn_AddData.UseVisualStyleBackColor = true;
            this.btn_AddData.Click += new System.EventHandler(this.btn_AddData_Click);
            // 
            // shapeContainer1
            // 
            this.shapeContainer1.Location = new System.Drawing.Point(3, 17);
            this.shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer1.Name = "shapeContainer1";
            this.shapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.lineShape6,
            this.lineShape5,
            this.lineShape4,
            this.lineShape3,
            this.lineShape2,
            this.lineShape1});
            this.shapeContainer1.Size = new System.Drawing.Size(758, 103);
            this.shapeContainer1.TabIndex = 6;
            this.shapeContainer1.TabStop = false;
            // 
            // lineShape6
            // 
            this.lineShape6.Name = "lineShape6";
            this.lineShape6.X1 = 637;
            this.lineShape6.X2 = 711;
            this.lineShape6.Y1 = 46;
            this.lineShape6.Y2 = 46;
            // 
            // lineShape5
            // 
            this.lineShape5.Name = "lineShape5";
            this.lineShape5.X1 = 464;
            this.lineShape5.X2 = 539;
            this.lineShape5.Y1 = 47;
            this.lineShape5.Y2 = 47;
            // 
            // lineShape4
            // 
            this.lineShape4.Name = "lineShape4";
            this.lineShape4.X1 = 313;
            this.lineShape4.X2 = 376;
            this.lineShape4.Y1 = 73;
            this.lineShape4.Y2 = 40;
            // 
            // lineShape3
            // 
            this.lineShape3.Name = "lineShape3";
            this.lineShape3.X1 = 313;
            this.lineShape3.X2 = 384;
            this.lineShape3.Y1 = 18;
            this.lineShape3.Y2 = 43;
            // 
            // lineShape2
            // 
            this.lineShape2.Name = "lineShape2";
            this.lineShape2.X1 = 136;
            this.lineShape2.X2 = 220;
            this.lineShape2.Y1 = 47;
            this.lineShape2.Y2 = 73;
            // 
            // lineShape1
            // 
            this.lineShape1.Name = "lineShape1";
            this.lineShape1.X1 = 129;
            this.lineShape1.X2 = 216;
            this.lineShape1.Y1 = 49;
            this.lineShape1.Y2 = 19;
            // 
            // axTOCControl_main
            // 
            this.axTOCControl_main.Location = new System.Drawing.Point(781, 46);
            this.axTOCControl_main.Name = "axTOCControl_main";
            this.axTOCControl_main.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axTOCControl_main.OcxState")));
            this.axTOCControl_main.Size = new System.Drawing.Size(227, 498);
            this.axTOCControl_main.TabIndex = 2;
            // 
            // axMapControl_main
            // 
            this.axMapControl_main.Location = new System.Drawing.Point(11, 133);
            this.axMapControl_main.Name = "axMapControl_main";
            this.axMapControl_main.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axMapControl_main.OcxState")));
            this.axMapControl_main.Size = new System.Drawing.Size(764, 411);
            this.axMapControl_main.TabIndex = 3;
            this.axMapControl_main.OnMouseDown += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnMouseDownEventHandler(this.axMapControl_main_OnMouseDown);
            // 
            // axToolbarControl_main
            // 
            this.axToolbarControl_main.Location = new System.Drawing.Point(781, 12);
            this.axToolbarControl_main.Name = "axToolbarControl_main";
            this.axToolbarControl_main.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axToolbarControl_main.OcxState")));
            this.axToolbarControl_main.Size = new System.Drawing.Size(227, 28);
            this.axToolbarControl_main.TabIndex = 4;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1020, 556);
            this.Controls.Add(this.axToolbarControl_main);
            this.Controls.Add(this.axMapControl_main);
            this.Controls.Add(this.axTOCControl_main);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.axLicenseControl1);
            this.Name = "FormMain";
            this.Text = "生态环境敏感性分析系统";
            this.Load += new System.EventHandler(this.FormMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.axLicenseControl1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.axTOCControl_main)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axMapControl_main)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axToolbarControl_main)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ESRI.ArcGIS.Controls.AxLicenseControl axLicenseControl1;
        private System.Windows.Forms.GroupBox groupBox1;
        private ESRI.ArcGIS.Controls.AxTOCControl axTOCControl_main;
        private ESRI.ArcGIS.Controls.AxMapControl axMapControl_main;
        private ESRI.ArcGIS.Controls.AxToolbarControl axToolbarControl_main;
        private System.Windows.Forms.Button btn_AddData;
        private System.Windows.Forms.Button btn_AnalysisFillArr;
        private System.Windows.Forms.Button btn_GetWater;
        private System.Windows.Forms.Button btn_classify;
        private System.Windows.Forms.Button btn_weightedOverlay;
        private System.Windows.Forms.Button btn_ExportMap;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape6;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape5;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape4;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape3;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape2;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape1;
        private System.Windows.Forms.Button btn_help;
    }
}

