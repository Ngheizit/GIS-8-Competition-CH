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
using ESRI.ArcGIS.Geoprocessor;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.Output;

namespace Temp_1107_6_B
{
    public partial class FormMain : Form
    {
        private string DEBUG_DIR = System.IO.Path.GetDirectoryName(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName) + "\\Data\\";
        private IMapControl2 m_pMapC2;
        private IMapDocument m_pMapDoc;

        public FormMain()
        {
            InitializeComponent();

            m_pMapC2 = axMapControl_main.Object as IMapControl2;
            m_pMapDoc = new MapDocumentClass();
        }

        // 打开地图文档事件入口
        private void btn_OpenMxd_Click(object sender, EventArgs e)
        {
            string mxdPath = GetMxdPath();
            CheckAndOpenMxd(mxdPath);

        }
        // 获取地图文档路径
        private string GetMxdPath()
        {
            if (MessageBox.Show("是否打开默认地图文档", "打开地图文档", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                return DEBUG_DIR + "Map.mxd";
            }
            else
            {
                return SelectMxdByOpenFileDialog();
            }
        }
        // 通过文件对话框选择地图文档
        private string SelectMxdByOpenFileDialog()
        {
            OpenFileDialog ofg = new OpenFileDialog() {
                Title = "打开地图文档", Filter = "地图文档 (*.mxd)|*.mxd"
            };
            if (ofg.ShowDialog() == DialogResult.OK)
            {
                return ofg.FileName;
            }
            else 
            { 
                return string.Empty;
            }
        }
        // 检查地图文档有效性并打开
        private void CheckAndOpenMxd(string mxdPath)
        {
            if (m_pMapC2.CheckMxFile(mxdPath))
            {
                m_pMapDoc.Open(mxdPath);
                m_pMapC2.Map = m_pMapDoc.Map[0];
            }
        }

        // 地图平移
        private void axMapControl_main_OnMouseDown(object sender, IMapControlEvents2_OnMouseDownEvent e)
        {
            if (e.button == 4)
            {
                m_pMapC2.MousePointer = esriControlsMousePointer.esriPointerPanning;
                m_pMapC2.Pan();
                m_pMapC2.MousePointer = esriControlsMousePointer.esriPointerArrow;
            }
        }

        // 添加观看预设点事件入口
        private void btn_AddViewer_Click(object sender, EventArgs e)
        {
            // 添加观看预设点至地图控件
            m_pMapC2.AddShapeFile(DEBUG_DIR, "Viewer.shp");
        }

        // 观看预设点可见范围分析事件入口
        private void btn_visibility_Click(object sender, EventArgs e)
        {
            if (isAddedViewer())
            {
                IFeatureLayer pFeatureLayer_Viewer = GetLayerByName("Viewer") as IFeatureLayer;
                IFeatureLayer pFeatureLayer_Action = GetLayerByName("Action") as IFeatureLayer;
                IFeatureLayer pFeatureLayer_Building = GetLayerByName("Building") as IFeatureLayer;
                //VisbilityModel(pFeatureLayer_Viewer, pFeatureLayer_Action, pFeatureLayer_Building);
                AddModelResult();
                ShowViewerFIDLabel();
            }
        }
        // 检测是否已添加观看预设点数据
        private bool isAddedViewer()
        {
            if (GetLayerByName("Viewer") == null)
            {
                MessageBox.Show("未添加观看预设点");
                return false;
            }
            return true;
        }
        // 根据命名获取图层
        private ILayer GetLayerByName(string layerName)
        {
            IMap pMap = m_pMapC2.Map;
            for (int i = 0; i < pMap.LayerCount; i++)
            {
                if (pMap.get_Layer(i).Name == layerName)
                {
                    return pMap.get_Layer(i);
                }
            }
            return null;
        }
        // 执行可见范围分析模型
        private void VisbilityModel(IFeatureLayer viewer, IFeatureLayer action, IFeatureLayer building)
        {
            Geoprocessor gp = new Geoprocessor() {
                OverwriteOutput = true
            };

            gp.AddToolbox(DEBUG_DIR + "toolbox.tbx");

            IVariantArray parameters = new VarArrayClass();
            parameters.RemoveAll();
            //parameters.Add(DEBUG_DIR + "Action.shp");
            //parameters.Add(DEBUG_DIR + "Building.shp");
            //parameters.Add(DEBUG_DIR + "Viewer.shp");
            parameters.Add(action);
            parameters.Add(building);
            parameters.Add(viewer);
            parameters.Add(DEBUG_DIR + "VisitArea_FID_%值%.shp");

            gp.Execute("myModel", parameters, null);
        }
        // 添加可见范围分析模型结果图岑
        private void AddModelResult()
        {
            m_pMapC2.AddShapeFile(DEBUG_DIR, "VisitArea_FID_0.shp");
            m_pMapC2.AddShapeFile(DEBUG_DIR, "VisitArea_FID_1.shp");
            m_pMapC2.AddShapeFile(DEBUG_DIR, "VisitArea_FID_2.shp");
            IFeatureLayer pFeatureLayer_vaID0 = GetLayerByName("VisitArea_FID_0") as IFeatureLayer;
            IFeatureLayer pFeatureLayer_vaID1 = GetLayerByName("VisitArea_FID_1") as IFeatureLayer;
            IFeatureLayer pFeatureLayer_vaID2 = GetLayerByName("VisitArea_FID_2") as IFeatureLayer;
            Symbology(GetLayerByName("VisitArea_FID_0") as IFeatureLayer, esriSimpleFillStyle.esriSFSBackwardDiagonal, 0);
            Symbology(GetLayerByName("VisitArea_FID_1") as IFeatureLayer, esriSimpleFillStyle.esriSFSForwardDiagonal, 1);
            Symbology(GetLayerByName("VisitArea_FID_2") as IFeatureLayer, esriSimpleFillStyle.esriSFSHorizontal, 2);
        }
        // 获取颜色对象
        private IRgbColor GetRgbColor(byte r, byte g, byte b, byte a = 255)
        {
            return new RgbColorClass() { 
                Red = r, Green = g, Blue = b, Transparency = a
            };
        }
        // 符号化可见范围
        private void Symbology(IFeatureLayer featureLayer, esriSimpleFillStyle style, int i)
        {
            featureLayer.Name = i + "号观测预设点可见范围";
            ISymbol pSymbol = new SimpleFillSymbolClass() {
                Style = style,
                Color = GetRgbColor(0, 0, 0)
            };
            (featureLayer as IGeoFeatureLayer).Renderer = new SimpleRendererClass() {
                Symbol = pSymbol
            };
            axTOCControl_main.Update();
        }
        // 显示观看预设点注记
        private void ShowViewerFIDLabel()
        {
            IFeatureLayer pFeatureLayer = GetLayerByName("Viewer") as IFeatureLayer;
            IFeatureCursor pFeatureCursor = pFeatureLayer.FeatureClass.Search(null, false);
            IFeature pFeature = pFeatureCursor.NextFeature();
            while (pFeature != null)
            { 
                // 注记放置位置
                IEnvelope pEnv = pFeature.Extent;
                IPoint pPoint = new PointClass() { 
                    X = pEnv.XMin, Y = pEnv.YMin + 0.0001
                };
                // 文本符号
                stdole.IFontDisp pFont = new stdole.StdFontClass() as stdole.IFontDisp;
                pFont.Name = "arial";
                ITextSymbol pSymbol = new TextSymbolClass() { 
                    Size = 24,
                    Font = pFont,
                    Color = GetRgbColor(255 ,0 ,0)
                };
                // 添加文本对象
                IElement pElement = new TextElementClass() { 
                    Text = pFeature.get_Value(0) + "号观看预设点",
                    ScaleText = true,
                    Symbol = pSymbol,
                    Geometry = pPoint
                };
                (m_pMapC2.Map as IGraphicsContainer).AddElement(pElement, 0);
                m_pMapC2.Refresh(esriViewDrawPhase.esriViewGraphics, null, null);
                pFeature = pFeatureCursor.NextFeature();
            }
        }

        // 导出jpg格式图片事件入口
        private void btn_ExportMap_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 1;
            //AddLegend();
            AddLegend(axPageLayoutControl_main.PageLayout, axPageLayoutControl_main.ActiveView.FocusMap, 1, 1, 5.0);
            AddTitle();
            //ExportMap(axPageLayoutControl_main.ActiveView);

        }
        // 布局视图同步数据视图
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
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
        // 添加图例
        private void AddLegend()
        {
            IActiveView pActiveView = axPageLayoutControl_main.ActiveView;
            IGraphicsContainer pGC = axPageLayoutControl_main.PageLayout as IGraphicsContainer;

            UID pUID = new UIDClass() { Value = "esriCarto.Legend" };
            IMapFrame pMapFrame = pGC.FindFrame(pActiveView.FocusMap) as IMapFrame;
            // 根据唯一标识符，创建与之对应的MapSurroundFrame
            IMapSurroundFrame pMapSurroundFrame = pMapFrame.CreateSurroundFrame(pUID, null);
            // 检查PageLayout中是否已有图例（有则删除）
            IElement pDelElement = axPageLayoutControl_main.FindElementByName("Legend");
            if (pDelElement != null)
                pGC.DeleteElement(pDelElement);
            // 设置MapSurroundFrame背景
            ISymbolBackground pSymbolBackground = new SymbolBackgroundClass() {
                FillSymbol = new SimpleFillSymbolClass() {
                    Color = GetRgbColor(240, 240, 240),
                    Outline = new SimpleLineSymbolClass() { 
                        Color = GetRgbColor(0 ,0 ,0),
                        Width = 1
                    }
                }
            };
            pMapSurroundFrame.Background = pSymbolBackground;
            // 添加图例
            IElement pElement = pMapSurroundFrame as IElement;
            IEnvelope pEnv = axPageLayoutControl_main.Extent;
            pEnv.XMin += 2;
            pEnv.YMin += 3;
            pElement.Geometry = pEnv;
            IMapSurround pMapSurround = pMapSurroundFrame.MapSurround;
            ILegend pLegend = pMapSurround as ILegend;
            pLegend.ClearItems();
            pLegend.Title = "图例";
            for (int i = 0; i < pActiveView.FocusMap.LayerCount; i++)
            {
                ILegendItem pLegendItem = new HorizontalLegendItemClass()
                {
                    Layer = pActiveView.FocusMap.get_Layer(i),
                    ShowDescriptions = false,
                    Columns = 1,
                    ShowHeading = true,
                    ShowLabels = true
                };
                pLegend.AddItem(pLegendItem);
            }
            pGC.AddElement(pElement, 0);
            pActiveView.PartialRefresh(esriViewDrawPhase.esriViewGraphics, null, null); 
        }
        // 添加标题
        private void AddTitle()
        {
            // 注记放置位置
            IEnvelope pEnv = axPageLayoutControl_main.Extent;
            IPoint pPoint = new PointClass()
            {
                X = (pEnv.XMin + pEnv.XMax) / 2,
                Y = pEnv.YMax - 3
            };

            // 文本符号
            stdole.IFontDisp pFont = new stdole.StdFontClass() as stdole.IFontDisp;
            pFont.Name = "arial";
            ITextSymbol pSymbol = new TextSymbolClass()
            {
                Size = 360.0,
                Font = pFont,
                Color = GetRgbColor(0, 0, 0)
            };
            // 添加文本对象
            IElement pElement = new TextElementClass()
            {
                Text = "观看预设点可见性专题图",
                Size = 360.0,
                Symbol = pSymbol,
                Geometry = pPoint
            };
            (axPageLayoutControl_main.PageLayout as IGraphicsContainer).AddElement(pElement, 0);
            axPageLayoutControl_main.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGraphics, null, null);
        }
        // 打印地图
        public void ExportMap(IActiveView activeView)
        {
            SaveFileDialog sfg = new SaveFileDialog()
            {
                Title = "导出jpg格式图片",
                Filter = "JPG图片(*.jpg)|*.jpg"
            };
            if (sfg.ShowDialog() == DialogResult.OK)
            {
                //CreateJPEGFromActiveView(axPageLayoutControl_main.ActiveView, sfg.FileName);
                CreateJPEGHiResolutionFromActiveView(axPageLayoutControl_main.ActiveView, sfg.FileName);
                //// 打印机接口
                //IExporter pExporter = new JpegExporterClass()
                //{
                //    ExportFileName = sfg.FileName,
                //    Resolution = (short)activeView.ScreenDisplay.DisplayTransformation.Resolution
                //};

                //// 设置输出地图范围
                //tagRECT pTagRECT = activeView.ScreenDisplay.DisplayTransformation.get_DeviceFrame();
                //IEnvelope pEnvelope = new EnvelopeClass()
                //{
                //    XMin = pTagRECT.left,
                //    XMax = pTagRECT.right,
                //    YMin = pTagRECT.bottom,
                //    YMax = pTagRECT.top
                //};
                //pExporter.PixelBounds = pEnvelope;

                ////// 输出地图
                //activeView.Output(pExporter.StartExporting(), pExporter.Resolution, ref pTagRECT, activeView.Extent, null);
                //Application.DoEvents();
                //pExporter.FinishExporting();
                //MessageBox.Show("已将地图导出为jpg格式图片");
            }
        }


        #region"Create JPEG from ActiveView"
        // ArcGIS Snippet Title:
        // Create JPEG from ActiveView
        // 
        // Long Description:
        // Creates a .jpg (JPEG) file from IActiveView. Default values of 96 DPI are used for the image creation.
        // 
        // Add the following references to the project:
        // ESRI.ArcGIS.Carto
        // ESRI.ArcGIS.Display
        // ESRI.ArcGIS.Geometry
        // ESRI.ArcGIS.Output
        // ESRI.ArcGIS.System
        // 
        // Intended ArcGIS Products for this snippet:
        // ArcGIS Desktop (ArcEditor, ArcInfo, ArcView)
        // ArcGIS Engine
        // ArcGIS Server
        // 
        // Applicable ArcGIS Product Versions:
        // 9.2
        // 9.3
        // 9.3.1
        // 10.0
        // 
        // Required ArcGIS Extensions:
        // (NONE)
        // 
        // Notes:
        // This snippet is intended to be inserted at the base level of a Class.
        // It is not intended to be nested within an existing Method.
        // 

        ///<summary>Creates a .jpg (JPEG) file from IActiveView. Default values of 96 DPI are used for the image creation.</summary>
        ///
        ///<param name="activeView">An IActiveView interface</param>
        ///<param name="pathFileName">A System.String that the path and filename of the JPEG you want to create. Example: "C:\temp\test.jpg"</param>
        /// 
        ///<returns>A System.Boolean indicating the success</returns>
        /// 
        ///<remarks></remarks>
        private bool CreateJPEGFromActiveView(ESRI.ArcGIS.Carto.IActiveView activeView, System.String pathFileName)
        {
            //parameter check
            if (activeView == null || !(pathFileName.EndsWith(".jpg")))
            {
                return false;
            }
            ESRI.ArcGIS.Output.IExport export = new ESRI.ArcGIS.Output.ExportJPEGClass();
            export.ExportFileName = pathFileName;

            // Microsoft Windows default DPI resolution
            export.Resolution = 300;
            ESRI.ArcGIS.esriSystem.tagRECT exportRECT = activeView.ExportFrame;
            ESRI.ArcGIS.Geometry.IEnvelope envelope = new ESRI.ArcGIS.Geometry.EnvelopeClass();
            envelope.PutCoords(exportRECT.left, exportRECT.top, exportRECT.right, exportRECT.bottom);
            export.PixelBounds = envelope;
            System.Int32 hDC = export.StartExporting();
            activeView.Output(hDC, (System.Int16)export.Resolution, ref exportRECT, null, null);

            // Finish writing the export file and cleanup any intermediate files
            export.FinishExporting();
            export.Cleanup();

            MessageBox.Show("已将地图导出为jpg格式图片");
            return true;
        }
        #endregion
        #region"Create JPEG (hi-resolution) from ActiveView"
        // ArcGIS Snippet Title:
        // Create JPEG (hi-resolution) from ActiveView
        // 
        // Long Description:
        // Creates a .jpg (JPEG) file from IActiveView using a high resolution exporting option. Default values of 96 DPI are overwritten to 300 used for the image creation.
        // 
        // Add the following references to the project:
        // ESRI.ArcGIS.Carto
        // ESRI.ArcGIS.Display
        // ESRI.ArcGIS.Geometry
        // ESRI.ArcGIS.Output
        // 
        // Intended ArcGIS Products for this snippet:
        // ArcGIS Desktop (ArcEditor, ArcInfo, ArcView)
        // ArcGIS Engine
        // ArcGIS Server
        // 
        // Applicable ArcGIS Product Versions:
        // 9.2
        // 9.3
        // 9.3.1
        // 10.0
        // 
        // Required ArcGIS Extensions:
        // (NONE)
        // 
        // Notes:
        // This snippet is intended to be inserted at the base level of a Class.
        // It is not intended to be nested within an existing Method.
        // 

        ///<summary>Creates a .jpg (JPEG) file from the ActiveView using a high resolution exporting option. Default values of 96 DPI are overwritten to 300 used for the image creation.</summary>
        ///
        ///<param name="activeView">An IActiveView interface</param>
        ///<param name="pathFileName">A System.String that the path and filename of the JPEG you want to create. Example: "C:\temp\hiResolutionTest.jpg"</param>
        /// 
        ///<returns>A System.Boolean indicating the success</returns>
        /// 
        ///<remarks></remarks>
        public System.Boolean CreateJPEGHiResolutionFromActiveView(ESRI.ArcGIS.Carto.IActiveView activeView, System.String pathFileName)
        {
            //parameter check
            if (activeView == null || !(pathFileName.EndsWith(".jpg")))
            {
                return false;
            }
            ESRI.ArcGIS.Output.IExport export = new ESRI.ArcGIS.Output.ExportJPEGClass();
            export.ExportFileName = pathFileName;

            // Because we are exporting to a resolution that differs from screen 
            // resolution, we should assign the two values to variables for use 
            // in our sizing calculations
            System.Int32 screenResolution = 96;
            System.Int32 outputResolution = 300;

            export.Resolution = outputResolution;

            tagRECT exportRECT; // This is a structure
            exportRECT.left = 0;
            exportRECT.top = 0;
            exportRECT.right = activeView.ExportFrame.right * (outputResolution / screenResolution);
            exportRECT.bottom = activeView.ExportFrame.bottom * (outputResolution / screenResolution);

            // Set up the PixelBounds envelope to match the exportRECT
            ESRI.ArcGIS.Geometry.IEnvelope envelope = new ESRI.ArcGIS.Geometry.EnvelopeClass();
            envelope.PutCoords(exportRECT.left, exportRECT.top, exportRECT.right, exportRECT.bottom);
            export.PixelBounds = envelope;

            System.Int32 hDC = export.StartExporting();

            activeView.Output(hDC, (System.Int16)export.Resolution, ref exportRECT, null, null); // Explicit Cast and 'ref' keyword needed 
            export.FinishExporting();
            export.Cleanup();

            return true;
        }
        #endregion

        #region"Add Legend"
        // ArcGIS Snippet Title:
        // Add Legend
        // 
        // Long Description:
        // Add a Legend to the Page Layout from the Map.
        // 
        // Add the following references to the project:
        // ESRI.ArcGIS.Carto
        // ESRI.ArcGIS.Geometry
        // ESRI.ArcGIS.System
        // 
        // Intended ArcGIS Products for this snippet:
        // ArcGIS Desktop (ArcEditor, ArcInfo, ArcView)
        // ArcGIS Engine
        // ArcGIS Server
        // 
        // Applicable ArcGIS Product Versions:
        // 9.2
        // 9.3
        // 9.3.1
        // 10.0
        // 
        // Required ArcGIS Extensions:
        // (NONE)
        // 
        // Notes:
        // This snippet is intended to be inserted at the base level of a Class.
        // It is not intended to be nested within an existing Method.
        // 

        ///<summary>Add a Legend to the Page Layout from the Map.</summary>
        ///
        ///<param name="pageLayout">An IPageLayout interface.</param>
        ///<param name="map">An IMap interface.</param>
        ///<param name="posX">A System.Double that is X coordinate value in page units for the start of the Legend. Example: 2.0</param>
        ///<param name="posY">A System.Double that is Y coordinate value in page units for the start of the Legend. Example: 2.0</param>
        ///<param name="legW">A System.Double that is length in page units of the Legend in both the X and Y direction. Example: 5.0</param>
        /// 
        ///<remarks></remarks>
        public void AddLegend(ESRI.ArcGIS.Carto.IPageLayout pageLayout, ESRI.ArcGIS.Carto.IMap map, System.Double posX, System.Double posY, System.Double legW)
        {

            if (pageLayout == null || map == null)
            {
                return;
            }
            ESRI.ArcGIS.Carto.IGraphicsContainer graphicsContainer = pageLayout as ESRI.ArcGIS.Carto.IGraphicsContainer; // Dynamic Cast
            ESRI.ArcGIS.Carto.IMapFrame mapFrame = graphicsContainer.FindFrame(map) as ESRI.ArcGIS.Carto.IMapFrame; // Dynamic Cast
            ESRI.ArcGIS.esriSystem.IUID uid = new ESRI.ArcGIS.esriSystem.UIDClass();
            uid.Value = "esriCarto.Legend";
            ESRI.ArcGIS.Carto.IMapSurroundFrame mapSurroundFrame = mapFrame.CreateSurroundFrame((ESRI.ArcGIS.esriSystem.UID)uid, null); // Explicit Cast

            //Get aspect ratio
            ESRI.ArcGIS.Carto.IQuerySize querySize = mapSurroundFrame.MapSurround as ESRI.ArcGIS.Carto.IQuerySize; // Dynamic Cast
            System.Double w = 0;
            System.Double h = 0;
            querySize.QuerySize(ref w, ref h);
            System.Double aspectRatio = w / h;

            ESRI.ArcGIS.Geometry.IEnvelope envelope = new ESRI.ArcGIS.Geometry.EnvelopeClass();
            envelope.PutCoords(posX, posY, (posX * legW), (posY * legW / aspectRatio));
            ESRI.ArcGIS.Carto.IElement element = mapSurroundFrame as ESRI.ArcGIS.Carto.IElement; // Dynamic Cast
            element.Geometry = envelope;
            graphicsContainer.AddElement(element, 0);
        }
        #endregion



    }
}
