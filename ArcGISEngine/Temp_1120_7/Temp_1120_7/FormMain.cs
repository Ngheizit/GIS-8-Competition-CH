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
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Geometry;

namespace Temp_1120_7
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
        }

        private void btn_OpenMxd_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofg = new OpenFileDialog() { 
                Title = "选择地图文档",
                Filter = "地图文档 (*.mxd)|*.mxd",
                InitialDirectory = Application.StartupPath + @"\Data"
            };
            if(ofg.ShowDialog() == DialogResult.OK)
            {
                string mxdPath = ofg.FileName;
                AeUtils.LoadMxd(mxdPath);
                if (mxdPath != Application.StartupPath + @"\Data\Map.mxd")
                {
                    MessageBox.Show("当前地图文档与该系统所需文档不匹配", "提醒", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btn_Eye_Click(object sender, EventArgs e)
        {
            bool isShowing = (axMapControl_Eye.Visible = !axMapControl_Eye.Visible);
            if (isShowing)
            {
                btn_Eye.Text = "↗";
                AddLayersToEye();
                AeUtils.DrawExtent(m_pMapC2.Extent, axMapControl_Eye.Object as IMapControl2);
            }
            else
            {
                btn_Eye.Text = "↙";
            }
        }
        private void AddLayersToEye()
        {
            IMap pMap = m_pMapC2.Map;
            for (int i = pMap.LayerCount - 1; i >= 0; i--)
            {
                axMapControl_Eye.AddLayer(m_pMapC2.get_Layer(i));
            }
        }

        private void axMapControl_Main_OnMouseDown(object sender, IMapControlEvents2_OnMouseDownEvent e)
        {
            if (e.button == 4)
            {
                AeUtils.Pan();
            }
        }

        private void axMapControl_Main_OnMouseMove(object sender, IMapControlEvents2_OnMouseMoveEvent e)
        {
            tbx_Location.Text = String.Format("{0} {1} {2}", e.mapX.ToString(".###"), e.mapY.ToString(".###"), m_pMapC2.MapUnits.ToString().Substring(4));
        }

        private void axMapControl_Main_OnExtentUpdated(object sender, IMapControlEvents2_OnExtentUpdatedEvent e)
        {
            AeUtils.DrawExtent(e.newEnvelope as IEnvelope, axMapControl_Eye.Object as IMapControl2);
        }

        private void btn_Info_Click(object sender, EventArgs e)
        {
            IFeatureLayer pFeatureLayer = AeUtils.GetLayerByName("A_ZD") as IFeatureLayer;
            FormInfo f_Info = new FormInfo(pFeatureLayer);
        }
    }
}
