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
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Geoprocessor;

namespace Temp_1101_4_A
{
    public partial class FormMain : Form
    {
        private string DEBUG_DIR = System.IO.Path.GetDirectoryName(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName) + "\\Data\\";
        private IMapControl2 m_pMapC2;
        private IMapDocument m_pMapDoc;
        private ISceneControl m_pSceneCtl;
        private ToolbarMenu m_pToolbarMenu;

        private IFeatureLayer GetFeatureLayerByName(string layername)
        {
            for (int i = 0; i < m_pMapC2.LayerCount; i++)
            {
                if (m_pMapC2.get_Layer(i).Name == layername)
                    return m_pMapC2.get_Layer(i) as IFeatureLayer;
            }
            return null;
        }

        public FormMain()
        {
            InitializeComponent();
            m_pMapC2 = axMapControl_main.Object as IMapControl2;
            m_pMapDoc = new MapDocumentClass();
            m_pSceneCtl = axSceneControl_main.Object as ISceneControl;
            m_pToolbarMenu = new ToolbarMenu();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            m_pToolbarMenu.AddItem(new OpenAttributeTable());
            m_pToolbarMenu.SetHook(m_pMapC2);
        }

        private void axMapControl_main_OnMouseDown(object sender, IMapControlEvents2_OnMouseDownEvent e)
        {
            #region // 地图中键实现地图漫游（Pan）
            if (e.button == 4)
            {
                m_pMapC2.MousePointer = esriControlsMousePointer.esriPointerPanning;
                m_pMapC2.Pan();
                m_pMapC2.MousePointer = esriControlsMousePointer.esriPointerArrow;
            }
            #endregion
        }

        private void axTOCControl_map_OnMouseDown(object sender, ITOCControlEvents_OnMouseDownEvent e)
        {
            IBasicMap map = new MapClass();
            ILayer layer = new FeatureLayerClass();
            esriTOCControlItem item = new esriTOCControlItem();
            object other = new object(), 
                   index = new object();
            axTOCControl_map.HitTest(e.x, e.y, ref item, ref map, ref layer, ref other, ref index);
            if (e.button == 2 && item == esriTOCControlItem.esriTOCControlItemLayer)
            {
                (m_pMapC2 as IMapControl4).CustomProperty = layer;
                m_pToolbarMenu.PopupMenu(e.x, e.y, axTOCControl_map.hWnd);
            }
        }



        private void btn_getHeight_Click(object sender, EventArgs e)
        {
            IFeatureLayer pFeatureLayer = GetFeatureLayerByName("Building");

            Geoprocessor gp = new Geoprocessor() { 
                OverwriteOutput = true
            };
            ESRI.ArcGIS.DataManagementTools.CalculateField pCalculateField = new ESRI.ArcGIS.DataManagementTools.CalculateField() {
                in_table = pFeatureLayer as ITable,
                field = "Height",
                expression = "[Floor] * 3",
                
            };
            gp.Execute(pCalculateField, null);
            new FormAttriTable(pFeatureLayer).Show();
        }

        private void btn_showBuilding3D_Click(object sender, EventArgs e)
        {
            m_pSceneCtl.Scene.AddLayer(GetFeatureLayerByName("Building3D"));
            IFeatureLayer pFeatureLayer = m_pSceneCtl.Scene.Layer[0] as IFeatureLayer;
            IExtrude pExtrude = new GeometryEnvironmentClass() as IExtrude;

            IFeatureCursor pFeatureCursor = pFeatureLayer.FeatureClass.Search(null, false);
            IFeature pFeature = pFeatureCursor.NextFeature();
            while (pFeature != null)
            {
                pExtrude.ExtrudeFromTo(0, (double)pFeature.get_Value(3), pFeature.Shape);

                pFeature = pFeatureCursor.NextFeature();
            }
            pFea

            //m_pSceneCtl.SceneGraph.RefreshViewers();
        }
    }
}
