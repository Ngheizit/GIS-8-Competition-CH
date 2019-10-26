using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.esriSystem;

namespace AeDome
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        #region // 类全局变量

        private String WORKDIR = System.IO.Path.GetDirectoryName(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName);
        private IMapControl2 m_pMapC2;
        private IMapDocument m_pMapDoc;
        private IGraphicsContainer m_pGraphicsLayer;
        private ToolbarMenu m_pToolbarMenu;
        #endregion

        private void FormMain_Load(object sender, EventArgs e)
        {
            InitMap();
            InitTOCControl();

            AeUtils.Symbology_UniqueValue(AeUtils.GetFeatureLayerByName(m_pMapC2.Map, "BOUA"), "COLOR", m_pMapC2, axTOCControl_main);
        }


        #region // 载入默认地图
        private void InitMap()
        {
            m_pMapC2 = axMapControl_main.Object as IMapControl2;
            m_pMapDoc = new MapDocumentClass();
            m_pGraphicsLayer = m_pMapC2.Map as IGraphicsContainer;

            string sMxdPath = String.Format(@"{0}\{1}", WORKDIR, "Map.mxd");
            if (m_pMapC2.CheckMxFile(sMxdPath))
            {
                m_pMapDoc.Open(sMxdPath); // m_pMapC2.LoadMxFile(sMxdPath);
                m_pMapC2.Map = m_pMapDoc.get_Map(0);
            }
            //m_pMapC2.AddShapeFile(WORKDIR, "BOUA.shp"); // 添加矢量数据
            //m_pMapC2.AddShapeFile(WORKDIR, "RIVER_3J.shp");
            //m_pMapC2.AddShapeFile(WORKDIR, "BOUP.shp");
        } 
        #endregion

        private void Buttons_Click(object sender, EventArgs e)
        {
            #region // 地图文档保存
            if ((Button)sender == btn_save)
            {
                m_pMapDoc.Save();
                MessageBox.Show("地图文档已保存");
            } 
            #endregion
        }

        private void axMapControl_main_OnMouseDown(object sender, IMapControlEvents2_OnMouseDownEvent e)
        {
            #region // 地图平移（漫游）
            if (e.button == 4)
            {
                m_pMapC2.MousePointer = esriControlsMousePointer.esriPointerPanning;
                m_pMapC2.Pan();
                m_pMapC2.MousePointer = esriControlsMousePointer.esriPointerArrow;
            } 
            #endregion

        }

        #region // 鹰眼功能
        private void DrawExtent(IEnvelope envelope)
        {
            (axMapControl_hawkeye.Map as IGraphicsContainer).DeleteAllElements();
            IElement pElement = new RectangleElementClass()
            {
                Geometry = envelope,
                Symbol = new SimpleFillSymbolClass()
                {
                    Color = AeUtils.GetRgbColor(0, 0, 0, 0),
                    Outline = new SimpleLineSymbolClass()
                    {
                        Color = AeUtils.GetRgbColor(255, 0, 0),
                        Width = 2
                    }
                }
            };
            (axMapControl_hawkeye.Map as IGraphicsContainer).AddElement(pElement, 0);
            axMapControl_hawkeye.Refresh(esriViewDrawPhase.esriViewGraphics, null, null);
        }
        private void ckbx_hawkeye_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbx_hawkeye.Checked)
            {
                axMapControl_hawkeye.Visible = true;
                axMapControl_hawkeye.ClearLayers();
                IMap pMap = m_pMapC2.Map;
                for (int i = pMap.LayerCount - 1; i >= 0; i--)
                {
                    axMapControl_hawkeye.AddLayer(pMap.get_Layer(i));
                }
                IEnvelope pEnvelope = axMapControl_main.Extent;
                DrawExtent(pEnvelope);
            }
            else { axMapControl_hawkeye.Visible = false; }
        }
        private void axMapControl_main_OnExtentUpdated(object sender, IMapControlEvents2_OnExtentUpdatedEvent e)
        {
            IEnvelope pEnvelope = e.newEnvelope as IEnvelope;
            DrawExtent(pEnvelope);
        }
        private void axMapControl_hawkeye_OnMouseMove(object sender, IMapControlEvents2_OnMouseMoveEvent e)
        {
            #region // 拖动
            if (e.button == 1)
            {
                m_pMapC2.CenterAt(new PointClass()
                {
                    X = e.mapX,
                    Y = e.mapY
                });
                return;
            } 
            #endregion
            #region // 画矩
            if (e.button == 2)
            {
                IEnvelope pEnvelope = axMapControl_hawkeye.TrackRectangle();
                m_pMapC2.Extent = pEnvelope;
            } 
            #endregion
        }
        #endregion

        #region // 数据视图与布局视图的同步
        private void rdobtn_dataView2layoutView_CheckedChanged(object sender, EventArgs e)
        {
            if (rdobtn_layoutView.Checked)
            {
                axPageLayoutControl_main.Visible = true;
            }
            else { axPageLayoutControl_main.Visible = false; }
        }
        private void axMapControl_main_OnAfterScreenDraw(object sender, IMapControlEvents2_OnAfterScreenDrawEvent e)
        {
            // 范围同步
            IActiveView pActiveView = axPageLayoutControl_main.ActiveView.FocusMap as IActiveView;
            pActiveView.ScreenDisplay.DisplayTransformation.VisibleBounds = m_pMapC2.Extent;
            pActiveView.Refresh();
            // 内容同步
            IObjectCopy pObjectCopy = new ObjectCopyClass();
            object copyMap = pObjectCopy.Copy(m_pMapC2.Map);
            object overwriteMap = pActiveView;
            pObjectCopy.Overwrite(copyMap, overwriteMap);
        }
        #endregion

        #region TOCControl事件
        private void InitTOCControl()
        {
            object[] cmds = new object[] { 
                new Cmds.OpenAttriTable()
            };
            m_pToolbarMenu = new ToolbarMenu();
            for (int i = 0; i < cmds.Length; i++) 
                m_pToolbarMenu.AddItem(cmds[i]); 
            m_pToolbarMenu.SetHook(m_pMapC2);
        }
        private void axTOCControl_main_OnMouseDown(object sender, ITOCControlEvents_OnMouseDownEvent e)
        {
            IBasicMap map = new MapClass();
            ILayer layer = new FeatureLayerClass();
            object index = new object();
            object other = new object();
            esriTOCControlItem item = new esriTOCControlItem();
            axTOCControl_main.HitTest(e.x, e.y, ref item, ref map, ref layer, ref other, ref index);
            if (e.button == 2 && item == esriTOCControlItem.esriTOCControlItemLayer)
            {
                (m_pMapC2 as IMapControl4).CustomProperty = layer;
                m_pToolbarMenu.PopupMenu(e.x, e.y, axTOCControl_main.hWnd);
            }
        } 
        #endregion




    }
}
