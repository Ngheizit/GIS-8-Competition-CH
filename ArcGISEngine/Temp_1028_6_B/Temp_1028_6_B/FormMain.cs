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
using ESRI.ArcGIS.Output;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.SystemUI;
using ESRI.ArcGIS.Geoprocessor;
using ESRI.ArcGIS.Geodatabase;

namespace Temp_1028_6_B
{
    public partial class FormMain : Form
    {
        IMapControl2 m_pMapC2;
        IMapDocument m_pMapDoc;
        private string DEBUG_DIR = System.IO.Path.GetDirectoryName(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName) + "\\Data\\";

        public FormMain()
        {
            InitializeComponent();

            m_pMapC2 = axMapControl_main.Object as IMapControl2;
            m_pMapDoc = new MapDocumentClass();
        }



        private void FormMain_Load(object sender, EventArgs e)
        {

        }

        private void axMapControl_main_OnMouseDown(object sender, IMapControlEvents2_OnMouseDownEvent e)
        {
            if (e.button == 4)
            {
                m_pMapC2.MousePointer = esriControlsMousePointer.esriPointerPanning;
                m_pMapC2.Pan();
                m_pMapC2.MousePointer = esriControlsMousePointer.esriPointerArrow;
            }
        }
        private void btn_openMxd_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofg = new OpenFileDialog()
            {
                Title = "打开地图文档",
                Filter = "地图文档 (*.mxd)|*.mxd"
            };
            if (ofg.ShowDialog() == DialogResult.OK)
            {
                string filename = ofg.FileName;
                if (m_pMapC2.CheckMxFile(filename))
                {
                    m_pMapDoc.Open(filename);
                    m_pMapC2.Map = m_pMapDoc.Map[0];
                }
            }
        }

        private void btn_viewPoint_Click(object sender, EventArgs e)
        {
            string fileName = "Viewer.shp";
            for (int i = 0; i < m_pMapC2.LayerCount; i++)
            {
                if (m_pMapC2.get_Layer(i).Name == fileName.Split('.')[0])
                {
                    MessageBox.Show("观测点已添加");
                    return;
                }
            }
            m_pMapC2.AddShapeFile(DEBUG_DIR, fileName);
        }

        private void btn_exportMap_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfg = new SaveFileDialog() { 
                Title = "导出jpg格式图片",
                Filter = "JPG图片(*.jpg)|*.jpg"
            };
            if (sfg.ShowDialog() == DialogResult.OK)
            {
                // 打印机接口
                IExporter pExporter = new JpegExporterClass() { 
                    ExportFileName = sfg.FileName,
                    Resolution = (short)m_pMapC2.ActiveView.ScreenDisplay.DisplayTransformation.Resolution
                };

                // 设置输出地图范围
                tagRECT pTagRECT = m_pMapC2.ActiveView.ScreenDisplay.DisplayTransformation.get_DeviceFrame();
                IEnvelope pEnvelope = new EnvelopeClass()
                {
                    XMin = pTagRECT.left,
                    XMax = pTagRECT.right,
                    YMin = pTagRECT.bottom,
                    YMax = pTagRECT.top
                };
                pExporter.PixelBounds = pEnvelope;

                //// 输出地图
                m_pMapC2.ActiveView.Output(pExporter.StartExporting(), pExporter.Resolution, ref pTagRECT, m_pMapC2.ActiveView.Extent, null);
                Application.DoEvents();
                pExporter.FinishExporting();
                MessageBox.Show("已将地图导出为jpg格式图片");
            }
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            m_pMapDoc.Save();
            MessageBox.Show("当前地图文档已保存");
        }

        private void btn_visit_Click(object sender, EventArgs e)
        {
            FormProgressBar bar = new FormProgressBar(13);
            bar.Show();

            IFeatureLayer pFeatureLayer_Building = GetFeatureLayerByName("Building");
            IFeatureLayer pFeatureLayer_Action = GetFeatureLayerByName("Action");
            IFeatureLayer pFeatureLayer_Viewer = GetFeatureLayerByName("Viewer");
            bar.GO();

            Geoprocessor gp = new Geoprocessor() { 
                OverwriteOutput = true,
                AddOutputsToMap = true
            };
            bar.GO();

            // 联合
            ESRI.ArcGIS.AnalysisTools.Union pUnion = new ESRI.ArcGIS.AnalysisTools.Union() {
                in_features = DEBUG_DIR + "Action.shp" + ";" + DEBUG_DIR + "Building.shp",
                out_feature_class = DEBUG_DIR + "BuildingAndAction.shp"
            };
            gp.Execute(pUnion, null);
            bar.GO();

            // 面转栅格
            ESRI.ArcGIS.ConversionTools.PolygonToRaster pPolygonToRaster = new ESRI.ArcGIS.ConversionTools.PolygonToRaster() { 
                in_features = DEBUG_DIR + "BuildingAndAction.shp",
                out_rasterdataset = DEBUG_DIR + "RsBuildingAndAction.tif",
                value_field = "height",
                cellsize = 0.000001
            };
            gp.Execute(pPolygonToRaster, null);
            bar.GO();

            // 观测点要素迭代
            IFeatureCursor pFeatureCursor = pFeatureLayer_Viewer.FeatureClass.Search(null, false);
            IFeature pFeature = pFeatureCursor.NextFeature();
            int i = 0;
            while (pFeature != null)
            {
                m_pMapC2.Map.ClearSelection();
                m_pMapC2.Refresh(esriViewDrawPhase.esriViewGeoSelection, null, null);
                m_pMapC2.Map.SelectFeature(pFeatureLayer_Viewer, pFeature);
                m_pMapC2.Refresh(esriViewDrawPhase.esriViewGeoSelection, null, null);

                // 视域分析
                ESRI.ArcGIS.SpatialAnalystTools.Viewshed pViewshed = new ESRI.ArcGIS.SpatialAnalystTools.Viewshed() {
                    in_observer_features = pFeatureLayer_Viewer,
                    in_raster = DEBUG_DIR + "RsBuildingAndAction.tif",
                    out_raster = DEBUG_DIR + "RsVisibility_" + (i).ToString() + ".tif"
                };
                gp.Execute(pViewshed, null);
                bar.GO();

                // 掩模
                ESRI.ArcGIS.SpatialAnalystTools.ExtractByMask pExtractByMask = new ESRI.ArcGIS.SpatialAnalystTools.ExtractByMask() {
                    in_raster = DEBUG_DIR + "RsVisibility_" + (i).ToString() + ".tif",
                    in_mask_data = pFeatureLayer_Action,
                    out_raster = DEBUG_DIR + "RsVisAction_" + (i).ToString() + ".tif"
                };
                gp.Execute(pExtractByMask, null);
                bar.GO();

                // 栅格转面
                ESRI.ArcGIS.ConversionTools.RasterToPolygon pRasterToPolygon = new ESRI.ArcGIS.ConversionTools.RasterToPolygon() {
                    in_raster = DEBUG_DIR + "RsVisAction_" + (i).ToString() + ".tif",
                    raster_field = "Value",
                    out_polygon_features = DEBUG_DIR + "VisAction_" + (i).ToString() + ".shp"
                };
                gp.Execute(pRasterToPolygon, null);
                m_pMapC2.AddShapeFile(DEBUG_DIR, "VisAction_" + (i).ToString() + ".shp");
                IFeatureLayer pFeatureLayer_vis = GetFeatureLayerByName("visaction_" + (i).ToString());
                IFeatureCursor pFeatureCursor_vis = pFeatureLayer_vis.FeatureClass.Search(null, false);
                IFeature pFeat = pFeatureCursor_vis.NextFeature();
                while (pFeat != null)
                {
                    if (pFeat.get_Value(3).ToString() == "1")
                    {
                        IArea pArea = pFeat.Shape as IArea;
                        MessageBox.Show(pArea.Area.ToString());
                    }
                    pFeat = pFeatureCursor_vis.NextFeature();
                }
                bar.GO();

                pFeature = pFeatureCursor.NextFeature();
                i += 1;
            }


            bar.OK();

            //m_pMapC2.Map.DeleteLayer(GetFeatureLayerByName("Viewer"));
            //m_pMapC2.Refresh();

            //Geoprocessor gp = new Geoprocessor()
            //{
            //    OverwriteOutput = true,
            //    //TemporaryMapLayers = false
                
            //    //AddOutputsToMap = true
            //};

            //gp.AddToolbox(DEBUG_DIR + "toolbox.tbx");

            //IVariantArray parameters = new VarArrayClass();
            //parameters.RemoveAll();
            //parameters.Add(DEBUG_DIR + "Action.shp");
            //parameters.Add(DEBUG_DIR + "Building.shp");
            //parameters.Add(GetFeatureLayerByName("Viewer"));
            ////parameters.Add(DEBUG_DIR + "Viewer.shp");
            //parameters.Add(DEBUG_DIR + "VisitArea_%Value%.shp");

            //gp.Execute("myMod", parameters, null);
            //axTOCControl_main.EnableLayerDragDrop = true;
            //m_pMapC2.AddShapeFile(DEBUG_DIR, "VisitArea_0.shp");
            //m_pMapC2.AddShapeFile(DEBUG_DIR, "VisitArea_1.shp");
            //m_pMapC2.AddShapeFile(DEBUG_DIR, "VisitArea_2.shp");

            ////IArea pArea = GetFeatureLayerByName("Building").FeatureClass.Search(null, false).NextFeature().Shape as IArea;
            //////IArea pArea = GetFeatureLayerByName("VisitArea_0") as IArea;
            ////MessageBox.Show(pArea.Area.ToString());
        }

        private IFeatureLayer GetFeatureLayerByName(string layername)
        {
            for (int i = 0; i < m_pMapC2.Map.LayerCount; i++)
            {
                if (m_pMapC2.Map.get_Layer(i).Name == layername)
                {
                    return m_pMapC2.Map.get_Layer(i) as IFeatureLayer;
                }
            }
            return null;
        }

    }
}
