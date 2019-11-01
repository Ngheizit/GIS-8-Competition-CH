namespace Temp_1101_4_A
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_getHeight = new System.Windows.Forms.Button();
            this.axToolbarControl_map = new ESRI.ArcGIS.Controls.AxToolbarControl();
            this.axTOCControl_map = new ESRI.ArcGIS.Controls.AxTOCControl();
            this.axSceneControl_main = new ESRI.ArcGIS.Controls.AxSceneControl();
            this.axToolbarControl_scene = new ESRI.ArcGIS.Controls.AxToolbarControl();
            this.btn_showBuilding3D = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.axLicenseControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axMapControl_main)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axToolbarControl_map)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axTOCControl_map)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axSceneControl_main)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axToolbarControl_scene)).BeginInit();
            this.SuspendLayout();
            // 
            // axLicenseControl1
            // 
            this.axLicenseControl1.Enabled = true;
            this.axLicenseControl1.Location = new System.Drawing.Point(490, 393);
            this.axLicenseControl1.Name = "axLicenseControl1";
            this.axLicenseControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axLicenseControl1.OcxState")));
            this.axLicenseControl1.Size = new System.Drawing.Size(32, 32);
            this.axLicenseControl1.TabIndex = 0;
            // 
            // axMapControl_main
            // 
            this.axMapControl_main.Location = new System.Drawing.Point(12, 107);
            this.axMapControl_main.Name = "axMapControl_main";
            this.axMapControl_main.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axMapControl_main.OcxState")));
            this.axMapControl_main.Size = new System.Drawing.Size(472, 417);
            this.axMapControl_main.TabIndex = 1;
            this.axMapControl_main.OnMouseDown += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnMouseDownEventHandler(this.axMapControl_main_OnMouseDown);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_showBuilding3D);
            this.groupBox1.Controls.Add(this.btn_getHeight);
            this.groupBox1.Location = new System.Drawing.Point(12, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1175, 64);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "工具栏";
            // 
            // btn_getHeight
            // 
            this.btn_getHeight.Location = new System.Drawing.Point(11, 24);
            this.btn_getHeight.Name = "btn_getHeight";
            this.btn_getHeight.Size = new System.Drawing.Size(75, 23);
            this.btn_getHeight.TabIndex = 0;
            this.btn_getHeight.Text = "计算楼高";
            this.btn_getHeight.UseVisualStyleBackColor = true;
            this.btn_getHeight.Click += new System.EventHandler(this.btn_getHeight_Click);
            // 
            // axToolbarControl_map
            // 
            this.axToolbarControl_map.Location = new System.Drawing.Point(12, 73);
            this.axToolbarControl_map.Name = "axToolbarControl_map";
            this.axToolbarControl_map.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axToolbarControl_map.OcxState")));
            this.axToolbarControl_map.Size = new System.Drawing.Size(677, 28);
            this.axToolbarControl_map.TabIndex = 3;
            // 
            // axTOCControl_map
            // 
            this.axTOCControl_map.Location = new System.Drawing.Point(490, 107);
            this.axTOCControl_map.Name = "axTOCControl_map";
            this.axTOCControl_map.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axTOCControl_map.OcxState")));
            this.axTOCControl_map.Size = new System.Drawing.Size(199, 417);
            this.axTOCControl_map.TabIndex = 4;
            this.axTOCControl_map.OnMouseDown += new ESRI.ArcGIS.Controls.ITOCControlEvents_Ax_OnMouseDownEventHandler(this.axTOCControl_map_OnMouseDown);
            // 
            // axSceneControl_main
            // 
            this.axSceneControl_main.Location = new System.Drawing.Point(695, 107);
            this.axSceneControl_main.Name = "axSceneControl_main";
            this.axSceneControl_main.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axSceneControl_main.OcxState")));
            this.axSceneControl_main.Size = new System.Drawing.Size(492, 417);
            this.axSceneControl_main.TabIndex = 5;
            // 
            // axToolbarControl_scene
            // 
            this.axToolbarControl_scene.Location = new System.Drawing.Point(695, 73);
            this.axToolbarControl_scene.Name = "axToolbarControl_scene";
            this.axToolbarControl_scene.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axToolbarControl_scene.OcxState")));
            this.axToolbarControl_scene.Size = new System.Drawing.Size(492, 28);
            this.axToolbarControl_scene.TabIndex = 3;
            // 
            // btn_showBuilding3D
            // 
            this.btn_showBuilding3D.Location = new System.Drawing.Point(93, 23);
            this.btn_showBuilding3D.Name = "btn_showBuilding3D";
            this.btn_showBuilding3D.Size = new System.Drawing.Size(92, 23);
            this.btn_showBuilding3D.TabIndex = 1;
            this.btn_showBuilding3D.Text = "建筑三维显示";
            this.btn_showBuilding3D.UseVisualStyleBackColor = true;
            this.btn_showBuilding3D.Click += new System.EventHandler(this.btn_showBuilding3D_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1199, 536);
            this.Controls.Add(this.axSceneControl_main);
            this.Controls.Add(this.axTOCControl_map);
            this.Controls.Add(this.axToolbarControl_scene);
            this.Controls.Add(this.axToolbarControl_map);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.axMapControl_main);
            this.Controls.Add(this.axLicenseControl1);
            this.Name = "FormMain";
            this.Text = "主窗体";
            this.Load += new System.EventHandler(this.FormMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.axLicenseControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axMapControl_main)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.axToolbarControl_map)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axTOCControl_map)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axSceneControl_main)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axToolbarControl_scene)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ESRI.ArcGIS.Controls.AxLicenseControl axLicenseControl1;
        private ESRI.ArcGIS.Controls.AxMapControl axMapControl_main;
        private System.Windows.Forms.GroupBox groupBox1;
        private ESRI.ArcGIS.Controls.AxToolbarControl axToolbarControl_map;
        private ESRI.ArcGIS.Controls.AxTOCControl axTOCControl_map;
        private ESRI.ArcGIS.Controls.AxSceneControl axSceneControl_main;
        private ESRI.ArcGIS.Controls.AxToolbarControl axToolbarControl_scene;
        private System.Windows.Forms.Button btn_getHeight;
        private System.Windows.Forms.Button btn_showBuilding3D;
    }
}

