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
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.Geodatabase;

namespace Temp_1119_6_B
{
    public partial class FormMain : Form
    {

        private IMapControl2 m_pMapC2;
        private IMapDocument m_pMapDoc;
        private bool _isShowInfo = false;

        public FormMain()
        {
            InitializeComponent();
            this.m_pMapC2 = axMapControl1.GetOcx() as IMapControl2;
            this.m_pMapDoc = new MapDocumentClass();
        }
        private void FormMain_Load(object sender, EventArgs e)
        {
            AeUtils.SetMapControl(m_pMapC2);
            AeUtils.SetMapDocument(m_pMapDoc);
        }



        private void btn_LoadMxd_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofg = new OpenFileDialog() { 
                Title = "选择打开地图文档",
                Filter = "地图文档 (*.mxd)|*.mxd",
                InitialDirectory = Application.StartupPath + @"\data"
            };
            if (ofg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            { 
                string mxdPath = ofg.FileName;
                AeUtils.LoadMxd(mxdPath);
                if (mxdPath != Application.StartupPath + @"\data\Map.mxd")
                {
                    MessageBox.Show("当前地图文档非系统分析需要的地图文档", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btn_save_Click(object sender, EventArgs e)
        {

            try
            {
                m_pMapDoc.Save();
                MessageBox.Show(String.Format("地图文档【{0}】已保存", m_pMapDoc.DocumentFilename));
            }
            catch
            {
                MessageBox.Show("当前系统未加载地图文档", "警告", MessageBoxButtons.OK ,MessageBoxIcon.Error);
            }
        }

        private void btn_BuildingInfo_Click(object sender, EventArgs e)
        {
            _isShowInfo = !_isShowInfo;
            if (_isShowInfo)
            {
                btn_BuildingInfo.Text = "查看建筑信息\n（状态：开启）";
                (AeUtils.GetLayerByName("Plan") as IFeatureLayer).Selectable = false;
                (AeUtils.GetLayerByName("Plan") as IFeatureLayer).Selectable = false;
            }
            else
            {
                btn_BuildingInfo.Text = "查看建筑信息\n（状态：关闭）";
                (AeUtils.GetLayerByName("Plan") as IFeatureLayer).Selectable = true;
                (AeUtils.GetLayerByName("Road") as IFeatureLayer).Selectable = true;
            }
        }

        private void axMapControl1_OnMouseDown(object sender, IMapControlEvents2_OnMouseDownEvent e)
        {
            if (e.button == 4)
            {
                AeUtils.Pan();
            }
            else if (e.button == 1 && _isShowInfo)
            {
                IPoint pPoint = new PointClass() { 
                    X = e.mapX, Y = e.mapY
                };
                m_pMapC2.Map.SelectByShape(pPoint, null, true);
                m_pMapC2.Refresh(esriViewDrawPhase.esriViewGeoSelection, null, null);
                IEnumFeature pEnumFeature = m_pMapC2.Map.FeatureSelection as IEnumFeature;
                IFeature pFeature = pEnumFeature.Next();
                if (pFeature == null)
                    return;
                int FID = (int)pFeature.get_Value(0);

                new FormInfo(AeUtils.GetLayerByName("Building") as IFeatureLayer, FID).Show();
            }
        }

        private void btn_roadAna_Click(object sender, EventArgs e)
        {

        }




    }
}
