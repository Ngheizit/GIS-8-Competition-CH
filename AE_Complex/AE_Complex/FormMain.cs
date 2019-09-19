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
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Display;

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

            #region 设置Toolbar和TOOC以及（鹰眼）MapControl控件初始隐藏状态
            axTOCControl_Main.Visible = false;
            axToolbarControl_Main.Visible = false;
            axMapControl_EagleEye.Visible = false;
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


        #region Tocc和Toolbar以及（鹰眼）MapControl控件开关按钮事件
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
            if ((Button)sender == btn_eagleEye)
            {
                if (axMapControl_EagleEye.Visible)
                {
                    axMapControl_EagleEye.Visible = false;
                    btn_eagleEye.Text = "E";
                }
                else
                {
                    axMapControl_EagleEye.Visible = true;
                    btn_eagleEye.Text = "↑";
                }
                return;
            }
        } 
        #endregion

        #region MapControl控件鼠标鼠标点击事件

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

        #region 视图同步 - 鹰眼
        #region 0. 鹰眼相关变量定义
        private bool bCanDrag; // 鹰眼地图上的矩形框可移动的标志
        private IPoint pMoveRectPoint; // 记录在移动鹰眼地图上的矩形框时鼠标的位置
        private IEnvelope pEnv; // 记录数据视图的Extent
        #endregion
        #region 1. 鹰眼数据与数据视图的数据一致，且鹰眼视图中地图始终显示为全图
        private void axMapControl_Main_OnMapReplaced(object sender, IMapControlEvents2_OnMapReplacedEvent e)
        {
            if (axMapControl_EagleEye.LayerCount > 0)
            {
                axMapControl_EagleEye.ClearLayers();
            }
            // 设置鹰眼和主图的坐标系统一致
            axMapControl_EagleEye.SpatialReference = axMapControl_Main.SpatialReference;
            for (int i = 0; i < axMapControl_Main.LayerCount; i++)
            { 
                // 使鹰眼视图与数据视图的图层上下顺序保持一致
                ILayer pLayer = axMapControl_Main.get_Layer(i);
                if (pLayer is IGroupLayer || pLayer is ICompositeLayer)
                {
                    ICompositeLayer pCompositeLayer = (ICompositeLayer)pLayer;
                    for (int j = pCompositeLayer.Count - 1; j >= 0; j--)
                    {
                        ILayer pSubLayer = pCompositeLayer.get_Layer(i);
                        IFeatureLayer pFeatureLayer = pSubLayer as IFeatureLayer;
                        if (pFeatureLayer != null)
                        {
                            if (pFeatureLayer.FeatureClass.ShapeType != esriGeometryType.esriGeometryPoint && pFeatureLayer.FeatureClass.ShapeType != esriGeometryType.esriGeometryMultipoint)
                            {
                                axMapControl_EagleEye.AddLayer(pLayer);
                            }
                        }
                    }
                }
                else
                {
                    IFeatureLayer pFeatureLayer = pLayer as IFeatureLayer;
                    if (pFeatureLayer != null)
                    {
                        if (pFeatureLayer.FeatureClass.ShapeType != esriGeometryType.esriGeometryPoint && pFeatureLayer.FeatureClass.ShapeType != esriGeometryType.esriGeometryMultipoint)
                        {
                            axMapControl_EagleEye.AddLayer(pLayer);
                        }
                    }
                }
            }
            // 设置鹰眼地图全图显示
            axMapControl_EagleEye.Extent = axMapControl_Main.FullExtent;
            pEnv = axMapControl_Main.Extent as IEnvelope;
            DrawRectangle(pEnv);
            axMapControl_EagleEye.ActiveView.Refresh();
        }
        // 在鹰眼地图上面画矩形框
        private void DrawRectangle(IEnvelope pEnvelope)
        { 
            // 在绘制前，清除鹰眼中之前绘制的矩形框
            IGraphicsContainer pGraphicsContainer = axMapControl_EagleEye.Map as IGraphicsContainer;
            IActiveView pActiveView = pGraphicsContainer as IActiveView;
            pGraphicsContainer.DeleteAllElements();
            // 得到当前视图范围
            IRectangleElement pRectangleElement = new RectangleElementClass();
            IElement pElement = pRectangleElement as IElement;
            pElement.Geometry = pEnvelope;
            // 设置矩形框（实质为中间透明度面）
            IRgbColor pColor = new RgbColorClass();
            pColor.Red = 255; pColor.Green = 0; pColor.Blue = 0;
            pColor.Transparency = 255;
            ILineSymbol pOutline = new SimpleLineSymbolClass();
            pOutline.Width = 2;
            pOutline.Color = pColor;
            IFillSymbol pFullSymbol = new SimpleFillSymbolClass();
            pColor.Transparency = 0;
            pFullSymbol.Color = pColor;
            pFullSymbol.Outline = pOutline;
            // 向鹰眼中添加矩形框
            IFillShapeElement pFillShapeElement = pElement as IFillShapeElement;
            pFillShapeElement.Symbol = pFullSymbol;
            pGraphicsContainer.AddElement((IElement)pFillShapeElement, 0);
            // 刷新
            pActiveView.PartialRefresh(esriViewDrawPhase.esriViewGraphics, null, null);
        }
        #endregion
        #endregion

    }
}
