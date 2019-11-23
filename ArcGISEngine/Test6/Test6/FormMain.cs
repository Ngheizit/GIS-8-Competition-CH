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
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Geometry;

namespace Test6
{
    public partial class FormMain : Form
    {
        private IMapControl2 m_pMapC2;
        private IMapDocument m_pMapDoc;
        private ToolbarMenu m_pToolbarMenu;

        public FormMain()
        {
            InitializeComponent();
            m_pMapC2 = axMapControl_Main.GetOcx() as IMapControl2;
            m_pMapDoc = new MapDocumentClass();
            m_pToolbarMenu = new ToolbarMenu(); ;
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            AeUtils.SetMapControl(m_pMapC2);
            AeUtils.SetMapDocument(m_pMapDoc);
            AeUtils.SetAxPageLayoutControl(axPageLayoutControl_Main);

            m_pToolbarMenu.AddItem(new OpenAttributeTable());
            m_pToolbarMenu.SetHook(m_pMapC2);
        }

        private void 打开地图文档ToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void 保存地图文档ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AeUtils.Save();
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void axMapControl_Main_OnMouseDown(object sender, IMapControlEvents2_OnMouseDownEvent e)
        {
            if (e.button == 4)
            {
                AeUtils.Pan();
            }
        }

        private void btn_HawkEye_Click(object sender, EventArgs e)
        {
            bool isShowing = (axMapControl_HawkEye.Visible = !axMapControl_HawkEye.Visible);
            if (isShowing)
            {
                btn_HawkEye.Text = "↗";
                AeUtils.AddLayersToHawkEye(axMapControl_HawkEye);
                AeUtils.DrawExtent(m_pMapC2.Extent, axMapControl_HawkEye);
            }
            else
            {
                btn_HawkEye.Text = "↙";
            }
        }

        private void axMapControl_Main_OnExtentUpdated(object sender, IMapControlEvents2_OnExtentUpdatedEvent e)
        {
            if (axMapControl_HawkEye.Visible)
                AeUtils.DrawExtent(e.newEnvelope as IEnvelope, axMapControl_HawkEye);
        }

        private void axMapControl_HawkEye_OnMouseDown(object sender, IMapControlEvents2_OnMouseDownEvent e)
        {
            if (e.button == 1)
            {
                m_pMapC2.CenterAt(new PointClass() { 
                    X = e.mapX, Y = e.mapY
                });
            }
        }

        private void axMapControl_HawkEye_OnMouseMove(object sender, IMapControlEvents2_OnMouseMoveEvent e)
        {
            if (e.button == 1)
            {
                m_pMapC2.CenterAt(new PointClass()
                {
                    X = e.mapX,
                    Y = e.mapY
                });
            }
            if (e.button == 2)
            {
                IEnvelope pEnv = axMapControl_HawkEye.TrackRectangle();
                m_pMapC2.Extent = pEnv;
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
            {
                axTOCControl_Main.SetBuddyControl(axMapControl_Main);
                axToolbarControl_DataView.SetBuddyControl(axMapControl_Main);
                axToolbarControl_LayoutView.SetBuddyControl(axMapControl_Main);
            }
            else
            {
                axTOCControl_Main.SetBuddyControl(axMapControl_HawkEye);
                axToolbarControl_DataView.SetBuddyControl(axMapControl_HawkEye);
                axToolbarControl_LayoutView.SetBuddyControl(axMapControl_HawkEye);
            }
        }

        private void axMapControl_Main_OnAfterScreenDraw(object sender, IMapControlEvents2_OnAfterScreenDrawEvent e)
        {
            AeUtils.CopyMap();
        }

        private void axMapControl_Main_OnMouseMove(object sender, IMapControlEvents2_OnMouseMoveEvent e)
        {
            tbx_Loc.Text = String.Format("{0} {1} {2}", e.mapX.ToString(".###"), e.mapY.ToString(".###"), m_pMapC2.MapUnits.ToString().Substring(4));
        }

        private void axPageLayoutControl_Main_OnMouseMove(object sender, IPageLayoutControlEvents_OnMouseMoveEvent e)
        {
            tbx_Loc.Text = String.Format("{0} {1} {2}", e.pageX.ToString(".###"), e.pageY.ToString(".###"), axPageLayoutControl_Main.Page.Units.ToString().Substring(4));

        }

        private void axTOCControl_Main_OnMouseDown(object sender, ITOCControlEvents_OnMouseDownEvent e)
        {
            esriTOCControlItem item = new esriTOCControlItem();
            IBasicMap map = new MapClass();
            ILayer layer = new FeatureLayerClass();
            object unk = new object();
            object data = new object();
            axTOCControl_Main.HitTest(e.x, e.y, ref item, ref map, ref layer, ref unk, ref data);
            if (e.button == 2 && item == esriTOCControlItem.esriTOCControlItemLayer)
            {
                (m_pMapC2 as IMapControl4).CustomProperty = layer;
                m_pToolbarMenu.PopupMenu(e.x, e.y, axTOCControl_Main.hWnd);
            }
        }
    }
}
