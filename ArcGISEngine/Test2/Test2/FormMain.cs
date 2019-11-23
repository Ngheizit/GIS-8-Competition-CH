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

namespace Test2
{
    public partial class FormMain : Form
    {
        private IMapControl2 m_pMapC2;
        private IMapDocument m_pMapDoc;

        public FormMain()
        {
            InitializeComponent();
            m_pMapC2 = axMapControl_Main.GetOcx() as IMapControl2;
            m_pMapDoc = new MapDocumentClass();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            AeUtils.SetMapControl(m_pMapC2);
            AeUtils.SetMapDocument(m_pMapDoc);
            AeUtils.SetPageLayoutCtl(axPageLayoutControl_Main);
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
            AeUtils.SaveMxd();
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

        private void button1_Click(object sender, EventArgs e)
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
            if(axMapControl_HawkEye.Visible)
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
                
            }
        }

    }
}
