using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

#region ArcGIS Engine 引用库

using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.SystemUI;

#endregion

namespace AE_Complex
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private IMapControl2 m_pMapC2;

        #region 窗体加载时触发事件
        private void FormMain_Load(object sender, EventArgs e)
        {
            m_pMapC2 = axMapControl_Main.Object as IMapControl2;

            #region 设置Toolbar和TOOC控件初始隐藏状态
            axTOCControl_Main.Visible = false;
            axToolbarControl_Main.Visible = false;
            #endregion

            #region Toolbar工具加载
            //axToolbarControl_Main.AddItem(new CommandTool.OpenMxd(), -1, -1, false, 0, esriCommandStyles.esriCommandStyleTextOnly);
            axToolbarControl_Main.AddItem(new ControlsOpenDocCommandClass(), -1, -1, false, 0, esriCommandStyles.esriCommandStyleIconOnly);
            axToolbarControl_Main.AddItem(new CommandTool.Save(), -1, -1, false, 0, esriCommandStyles.esriCommandStyleTextOnly);
            //axToolbarControl_Main.AddItem(new CommandTool.SaveAs(), -1, -1, false, 0, esriCommandStyles.esriCommandStyleTextOnly);
            axToolbarControl_Main.AddItem(new ControlsSaveAsDocCommandClass(), -1, -1, false, 0, esriCommandStyles.esriCommandStyleIconOnly);


            #endregion

        } 
        #endregion


        #region Tocc和Toolbar控件开关按钮事件
        private void Buttons_OpenOrClose_Click(object sender, EventArgs e)
        {
            if ((Button)sender == btn_tooc)
            {
                if (axTOCControl_Main.Visible)
                {
                    axTOCControl_Main.Visible = false;
                    btn_tooc.Text = "L";
                }
                else
                {
                    axTOCControl_Main.Visible = true;
                    btn_tooc.Text = "↓";
                }
                return;
            }
            if ((Button)sender == btn_toolbar)
            {
                if (axToolbarControl_Main.Visible)
                {
                    axToolbarControl_Main.Visible = false;
                    btn_toolbar.Text = "T";
                }
                else
                {
                    axToolbarControl_Main.Visible = true;
                    btn_toolbar.Text = "→";
                }
                return;
            }
        } 
        #endregion

        #region MapControl

        private void axMapControl_Main_OnMouseDown(object sender, IMapControlEvents2_OnMouseDownEvent e)
        {
            #region 地图移动（滑轮键）
            if (e.button == 4)
            {
                this.m_pMapC2.MousePointer = esriControlsMousePointer.esriPointerPan;
                this.m_pMapC2.Pan();
                this.m_pMapC2.MousePointer = esriControlsMousePointer.esriPointerArrow;
            }
            #endregion
        } 
        #endregion



    }
}
