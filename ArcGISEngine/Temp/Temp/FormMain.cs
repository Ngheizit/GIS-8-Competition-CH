using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


// IMapControl2
using ESRI.ArcGIS.Controls;

// IMapDocument
using ESRI.ArcGIS.Carto;

// esriKeyIntercept
using ESRI.ArcGIS.SystemUI;

// IGeometry
using ESRI.ArcGIS.Geometry;

namespace Temp
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        // ********************************************************************************************
        /// <summary>
        /// 地图空间接口对象，承接axMapControl_main控件
        /// </summary>
        IMapControl2 m_pMapC2;
        /// <summary>
        /// 工作目录 （...\bin\Debug\）
        /// </summary>
        String WORKDIR = System.IO.Path.GetDirectoryName(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName);
        /// <summary>
        /// 地图文档
        /// </summary>
        IMapDocument m_pMapDoc;

        // ********************************************************************************************



        private void FormMain_Load(object sender, EventArgs e)
        {
            m_pMapC2 = axMapControl_main.Object as IMapControl2; // 初始化地图接口
            m_pMapDoc = new MapDocumentClass(); // 初始化地图文档接口

            // 默认加载MXD文档
            string sMxdPath = String.Format(@"{0}\{1}", WORKDIR, "Map.mxd");
            if (m_pMapC2.CheckMxFile(sMxdPath))
            {
                //m_pMapC2.LoadMxFile(sMxdPath);
                m_pMapDoc.Open(sMxdPath);
                m_pMapC2.Map = m_pMapDoc.get_Map(0);
            }

            // 添加矢量数据
            m_pMapC2.AddShapeFile(WORKDIR, "BOUA.shp");
            m_pMapC2.AddShapeFile(WORKDIR, "RIVER_3J.shp");
            m_pMapC2.AddShapeFile(WORKDIR, "BOUP.shp");
            m_pMapC2.Refresh();

            // 默认选择非绘制状态
            cmbx_draw.SelectedIndex = 0;

            // 关闭负责鹰眼效果的地图控件的鼠标中键滚动缩放功能
            axMapControl_eye.AutoMouseWheel = false;
        }

        #region 鼠标点击地图控件（axMapControl_main）事件
        private void axMapControl_main_OnMouseDown(object sender, IMapControlEvents2_OnMouseDownEvent e)
        {
            #region 中键点击实现地图平移（Pan）
            if (e.button == 4)
            {
                m_pMapC2.MousePointer = esriControlsMousePointer.esriPointerPanning;
                m_pMapC2.Pan();
                m_pMapC2.MousePointer = esriControlsMousePointer.esriPointerArrow;
            }
            #endregion
            #region 左键点击事件
            if (e.button == 1)
            {
                #region 绘制图形控制事件
                if (cmbx_draw.SelectedIndex != 0)
                {
                    IGeometry pGeom;
                    switch (cmbx_draw.SelectedIndex)
                    {
                        // 绘制多边形、矩形、圆形和直线
                        case 1: pGeom = m_pMapC2.TrackPolygon(); break;
                        case 2: pGeom = m_pMapC2.TrackRectangle(); break;
                        case 3: pGeom = m_pMapC2.TrackCircle(); break;
                        case 4: pGeom = m_pMapC2.TrackLine(); break;
                        default: return;
                    }
                    AeUtils.DrawMapShape(pGeom, m_pMapC2);
                    m_pMapC2.Refresh(esriViewDrawPhase.esriViewGraphics, null, null);
                }
                #endregion
            }
            #endregion
        } 
        #endregion

        #region 按钮点击事件集
        private void Buttons_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if (button == btn_saveDocument)
            {
                AeUtils.SaveDocument(m_pMapDoc);
            }
        } 
        #endregion

        #region 鹰眼开启/关闭事件
        private void ckbx_eye_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbx_eye.Checked)
            {
                axMapControl_eye.Visible = true;
                // 数据同步
                IMap pMap = m_pMapC2.Map;
                axMapControl_eye.Map.ClearLayers();
                for (int i = pMap.LayerCount - 1; i >= 0; i--)
                    axMapControl_eye.Map.AddLayer(pMap.get_Layer(i));
                IEnvelope pEnvelope = axMapControl_main.ActiveView.Extent;
                AeUtils.DrawMapShape(pEnvelope, axMapControl_eye.Object as IMapControl2);
            }
            else
                axMapControl_eye.Visible = false;
        } 
        #endregion

        #region 主地图视图范围发生变化时触发的事件
        private void axMapControl_main_OnExtentUpdated(object sender, IMapControlEvents2_OnExtentUpdatedEvent e)
        {
            #region 在鹰眼控件中更新范围示意框
            IEnvelope pEnvelope = e.newEnvelope as IEnvelope;
            AeUtils.DrawMapShape(pEnvelope, axMapControl_eye.Object as IMapControl2);
            #endregion
        } 
        #endregion


        #region 鹰眼地图控件点击/移动事件
        private void axMapControl_eye_OnMouseDown(object sender, IMapControlEvents2_OnMouseDownEvent e)
        {
            #region 左键移动范围框
            if (e.button == 1)
            {
                // 鼠标点击的地图坐标点作为主图显示范围的中心点
                IPoint pPoint = new PointClass() { X = e.mapX, Y = e.mapY };
                m_pMapC2.CenterAt(pPoint);
                
            } 
            #endregion
            #region 右键绘制范围框
            if (e.button == 2)
            {
                m_pMapC2.Extent = axMapControl_eye.TrackRectangle();
            } 
            #endregion
        }
        private void axMapControl_eye_OnMouseMove(object sender, IMapControlEvents2_OnMouseMoveEvent e)
        {   
            #region 左键移动范围框
            if (e.button == 1)
            {
                // 鼠标点击的地图坐标点作为主图显示范围的中心点
                IPoint pPoint = new PointClass();
                pPoint.PutCoords(e.mapX, e.mapY);
                m_pMapC2.CenterAt(pPoint);
                
            } 
            #endregion
        }
        #endregion


        #region 点击TOCControl控件事件
        private void axTOCControl_main_OnMouseDown(object sender, ITOCControlEvents_OnMouseDownEvent e)
        {
            IBasicMap map = new MapClass();
            ILayer layer = new FeatureLayerClass();
            object other = new object();
            object index = new object();
            esriTOCControlItem item = new esriTOCControlItem();
            axTOCControl_main.HitTest(e.x, e.y, ref item, ref map, ref layer, ref other, ref index);

        } 
        #endregion




    }
}
