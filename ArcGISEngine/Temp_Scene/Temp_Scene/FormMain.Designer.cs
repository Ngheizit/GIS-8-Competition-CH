namespace Temp_Scene
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
            this.axTOCControl_main = new ESRI.ArcGIS.Controls.AxTOCControl();
            this.axSceneControl_main = new ESRI.ArcGIS.Controls.AxSceneControl();
            this.axToolbarControl_map = new ESRI.ArcGIS.Controls.AxToolbarControl();
            this.axToolbarControl_scene = new ESRI.ArcGIS.Controls.AxToolbarControl();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.axLicenseControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axMapControl_main)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axTOCControl_main)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axSceneControl_main)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axToolbarControl_map)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axToolbarControl_scene)).BeginInit();
            this.SuspendLayout();
            // 
            // axLicenseControl1
            // 
            this.axLicenseControl1.Enabled = true;
            this.axLicenseControl1.Location = new System.Drawing.Point(338, 222);
            this.axLicenseControl1.Name = "axLicenseControl1";
            this.axLicenseControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axLicenseControl1.OcxState")));
            this.axLicenseControl1.Size = new System.Drawing.Size(32, 32);
            this.axLicenseControl1.TabIndex = 0;
            // 
            // axMapControl_main
            // 
            this.axMapControl_main.Location = new System.Drawing.Point(12, 129);
            this.axMapControl_main.Name = "axMapControl_main";
            this.axMapControl_main.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axMapControl_main.OcxState")));
            this.axMapControl_main.Size = new System.Drawing.Size(419, 406);
            this.axMapControl_main.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1086, 77);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "功能区";
            // 
            // axTOCControl_main
            // 
            this.axTOCControl_main.Location = new System.Drawing.Point(437, 128);
            this.axTOCControl_main.Name = "axTOCControl_main";
            this.axTOCControl_main.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axTOCControl_main.OcxState")));
            this.axTOCControl_main.Size = new System.Drawing.Size(238, 406);
            this.axTOCControl_main.TabIndex = 3;
            // 
            // axSceneControl_main
            // 
            this.axSceneControl_main.Location = new System.Drawing.Point(681, 129);
            this.axSceneControl_main.Name = "axSceneControl_main";
            this.axSceneControl_main.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axSceneControl_main.OcxState")));
            this.axSceneControl_main.Size = new System.Drawing.Size(419, 406);
            this.axSceneControl_main.TabIndex = 4;
            // 
            // axToolbarControl_map
            // 
            this.axToolbarControl_map.Location = new System.Drawing.Point(12, 96);
            this.axToolbarControl_map.Name = "axToolbarControl_map";
            this.axToolbarControl_map.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axToolbarControl_map.OcxState")));
            this.axToolbarControl_map.Size = new System.Drawing.Size(537, 28);
            this.axToolbarControl_map.TabIndex = 5;
            // 
            // axToolbarControl_scene
            // 
            this.axToolbarControl_scene.Location = new System.Drawing.Point(555, 96);
            this.axToolbarControl_scene.Name = "axToolbarControl_scene";
            this.axToolbarControl_scene.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axToolbarControl_scene.OcxState")));
            this.axToolbarControl_scene.Size = new System.Drawing.Size(543, 28);
            this.axToolbarControl_scene.TabIndex = 6;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(7, 21);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(85, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "洼地处理";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1110, 547);
            this.Controls.Add(this.axToolbarControl_scene);
            this.Controls.Add(this.axToolbarControl_map);
            this.Controls.Add(this.axSceneControl_main);
            this.Controls.Add(this.axTOCControl_main);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.axMapControl_main);
            this.Controls.Add(this.axLicenseControl1);
            this.Name = "FormMain";
            this.Text = "主窗体";
            this.Load += new System.EventHandler(this.FormMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.axLicenseControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axMapControl_main)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.axTOCControl_main)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axSceneControl_main)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axToolbarControl_map)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axToolbarControl_scene)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ESRI.ArcGIS.Controls.AxLicenseControl axLicenseControl1;
        private ESRI.ArcGIS.Controls.AxMapControl axMapControl_main;
        private System.Windows.Forms.GroupBox groupBox1;
        private ESRI.ArcGIS.Controls.AxTOCControl axTOCControl_main;
        private ESRI.ArcGIS.Controls.AxSceneControl axSceneControl_main;
        private ESRI.ArcGIS.Controls.AxToolbarControl axToolbarControl_map;
        private ESRI.ArcGIS.Controls.AxToolbarControl axToolbarControl_scene;
        private System.Windows.Forms.Button button1;

    }
}

