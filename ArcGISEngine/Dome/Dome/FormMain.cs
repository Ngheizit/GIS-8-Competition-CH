using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.esriSystem;

namespace Dome
{
    public partial class FormMain : Form
    {
        private IMapControl2 m_pMapC2;
        private IMapDocument m_pMapDoc;
        private ToolbarMenu m_pToolbarMenu;

        public FormMain()
        {
            InitializeComponent();
            this.m_pMapC2 = axMapControl1.GetOcx() as IMapControl2;
            this.m_pMapDoc = new MapDocumentClass();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 1;
            tabControl1.SelectedIndex = 0;

            AeUtils.SetMapControl(m_pMapC2);
            AeUtils.SetMapDocument(m_pMapDoc);
            AeUtils.SetPageLayoutControl(axPageLayoutControl1);

            m_pToolbarMenu = new ToolbarMenuClass();
            m_pToolbarMenu.AddItem(new OpenAttributeTable());
            m_pToolbarMenu.SetHook(m_pMapC2);
        }

        private void btn_OpenMxd_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofg = new OpenFileDialog() { 
                Title = "选择打开地图文档",
                Filter = "地图文档 (*.mxd)|*.mxd",
                InitialDirectory = Application.StartupPath
            };
            if (ofg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string mxdPath = ofg.FileName;
                AeUtils.LoadMxd(mxdPath);
            }
        }


        private void btn_Eye_Click(object sender, EventArgs e)
        {
            axMapControl_Eye.Visible = !axMapControl_Eye.Visible;
            if (axMapControl_Eye.Visible)
            {
                AddLayersToMapEye();
                AeUtils.DrawExtent(m_pMapC2.Extent, axMapControl_Eye.Object as IMapControl2);
            }
        }
        private void AddLayersToMapEye()
        {
            IMap pMap = m_pMapC2.Map;
            for (int i = pMap.LayerCount - 1; i >= 0; i--)
            {
                axMapControl_Eye.AddLayer(pMap.get_Layer(i));
            }
        }
        private void axMapControl1_OnExtentUpdated(object sender, IMapControlEvents2_OnExtentUpdatedEvent e)
        {
            AeUtils.DrawExtent(m_pMapC2.Extent, axMapControl_Eye.Object as IMapControl2);
        }



        private void axMapControl1_OnMouseDown(object sender, IMapControlEvents2_OnMouseDownEvent e)
        {
            if (e.button == 4)
            {
                AeUtils.Pan();
            }
        }
        private void axMapControl1_OnMouseMove(object sender, IMapControlEvents2_OnMouseMoveEvent e)
        {
            tbx_Location.Text = String.Format("{0} {1} {2}", e.mapX.ToString(".###"), e.mapY.ToString(".###"), m_pMapC2.MapUnits.ToString().Substring(4));
        }
        private void axPageLayoutControl1_OnMouseMove(object sender, IPageLayoutControlEvents_OnMouseMoveEvent e)
        {
            tbx_Location.Text = String.Format("{0} {1} {2}", e.pageX.ToString(".###"), e.pageY.ToString(".###"), axPageLayoutControl1.Page.Units.ToString().Substring(4));
        }




        private void axMapControl1_OnAfterScreenDraw(object sender, IMapControlEvents2_OnAfterScreenDrawEvent e)
        {
            AeUtils.CopyMapToLayoutView();
        }
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
            {
                axToolbarControl_DataView.SetBuddyControl(axMapControl1);
                axToolbarControl_LayoutView.SetBuddyControl(axMapControl1);
            }
            else
            {
                axToolbarControl_DataView.SetBuddyControl(axPageLayoutControl1);
                axToolbarControl_LayoutView.SetBuddyControl(axPageLayoutControl1);
            }
        }



        private void axTOCControl1_OnMouseDown(object sender, ITOCControlEvents_OnMouseDownEvent e)
        {
            esriTOCControlItem item = new esriTOCControlItem();
            IBasicMap map = new MapClass();
            ILayer layer = new FeatureLayerClass();
            object unk = new object();
            object data = new object();
            axTOCControl1.HitTest(e.x, e.y, ref item, ref map, ref layer, ref unk, ref data);
            if (e.button == 2 && item == esriTOCControlItem.esriTOCControlItemLayer)
            {
                (m_pMapC2 as IMapControl4).CustomProperty = layer;
                m_pToolbarMenu.PopupMenu(e.x, e.y, axTOCControl1.hWnd);
            }
        }

        private void axMapControl_Eye_OnMouseDown(object sender, IMapControlEvents2_OnMouseDownEvent e)
        {
            if (e.button == 1)
            {
                m_pMapC2.CenterAt(new PointClass() { 
                    X = e.mapX, Y = e.mapY
                });
            }
        }

        private void axMapControl_Eye_OnMouseMove(object sender, IMapControlEvents2_OnMouseMoveEvent e)
        {
            if (e.button == 1)
            {
                m_pMapC2.CenterAt(new PointClass() {
                    X = e.mapX,
                    Y = e.mapY
                });
            }
            if (e.button == 2)
            {
                IEnvelope pEnv = axMapControl_Eye.TrackRectangle();
                m_pMapC2.Extent = pEnv;
            }
        }
    }
}
