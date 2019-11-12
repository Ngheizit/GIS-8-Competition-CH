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
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.Geodatabase;

namespace Temp_1110_4_3
{
    public partial class FormExportMap : Form
    {
        private ILayer m_pLayer;

        public FormExportMap(ILayer layer)
        {
            InitializeComponent();
            m_pLayer = layer;
            axPageLayoutControl_main.ActiveView.FocusMap.AddLayer(layer);
        }

        // 获取颜色对象
        public IRgbColor GetRgbColor(byte r, byte g, byte b, byte a = 255)
        {
            IRgbColor pColor = new RgbColorClass()
            {
                Red = r,
                Green = g,
                Blue = b,
                Transparency = a,
                UseWindowsDithering = true
            };
            return pColor;
        }
        // 获取渐变颜色集
        public IColorRamp GetColorRamp(IRgbColor fromColor, IRgbColor toColor, int size)
        {
            IColorRamp pColorRamp = new AlgorithmicColorRampClass()
            {
                FromColor = fromColor,
                ToColor = toColor,
                Size = size,
                Algorithm = esriColorRampAlgorithm.esriCIELabAlgorithm
            };
            bool bOk = true;
            pColorRamp.CreateRamp(out bOk);
            return pColorRamp;
        }
        #region // 添加图例
        ///<summary>Add a Legend to the Page Layout from the Map.</summary>
        ///
        ///<param name="pageLayout">An IPageLayout interface.</param>
        ///<param name="map">An IMap interface.</param>
        ///<param name="posX">A System.Double that is X coordinate value in page units for the start of the Legend. Example: 2.0</param>
        ///<param name="posY">A System.Double that is Y coordinate value in page units for the start of the Legend. Example: 2.0</param>
        ///<param name="legW">A System.Double that is length in page units of the Legend in both the X and Y direction. Example: 5.0</param>
        /// 
        ///<remarks></remarks>
        public void AddLegend(IPageLayout pageLayout, IMap map, Double posX, Double posY, Double legW)
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

            // 
            ILegend pLegend = mapSurroundFrame.MapSurround as ILegend;
            pLegend.Title = "图例";
            pLegend.Format.TitlePosition = esriRectanglePosition.esriLeftSide | esriRectanglePosition.esriTopSide;
            pLegend.Format.TitleSymbol = new TextSymbolClass() { 
                Font = GetFontDisp(24)
            };
            pLegend.get_Item(0).ShowLayerName = true;
            pLegend.get_Item(0).LayerNameSymbol = new TextSymbolClass() {
                Font = GetFontDisp(22)
            };
            pLegend.get_Item(0).LegendClassFormat.LabelSymbol = new TextSymbolClass() {
                Font = GetFontDisp(20)
            };

            ESRI.ArcGIS.Geometry.IEnvelope envelope = new ESRI.ArcGIS.Geometry.EnvelopeClass();
            envelope.PutCoords(posX, posY, (posX * legW), (posY * legW / aspectRatio));
            ESRI.ArcGIS.Carto.IElement element = mapSurroundFrame as ESRI.ArcGIS.Carto.IElement; // Dynamic Cast

            element.Geometry = envelope;
            graphicsContainer.AddElement(element, 0);
        }
        #endregion
        #region // 添加指北针
        ///<summary>Add a North Arrow to the Page Layout from the Map.</summary>
        ///      
        ///<param name="pageLayout">An IPageLayout interface.</param>
        ///<param name="map">An IMap interface.</param>
        ///      
        ///<remarks></remarks>
        public void AddNorthArrow(IPageLayout pageLayout, IMap map)
        {

            if (pageLayout == null || map == null)
            {
                return;
            }
            ESRI.ArcGIS.Geometry.IEnvelope envelope = new ESRI.ArcGIS.Geometry.EnvelopeClass();
            envelope.PutCoords(1, 24, 5, 24); //  Specify the location and size of the north arrow

            ESRI.ArcGIS.esriSystem.IUID uid = new ESRI.ArcGIS.esriSystem.UIDClass();
            uid.Value = "esriCarto.MarkerNorthArrow";

            // Create a Surround. Set the geometry of the MapSurroundFrame to give it a location
            // Activate it and add it to the PageLayout's graphics container
            ESRI.ArcGIS.Carto.IGraphicsContainer graphicsContainer = pageLayout as ESRI.ArcGIS.Carto.IGraphicsContainer; // Dynamic Cast
            ESRI.ArcGIS.Carto.IActiveView activeView = pageLayout as ESRI.ArcGIS.Carto.IActiveView; // Dynamic Cast
            ESRI.ArcGIS.Carto.IFrameElement frameElement = graphicsContainer.FindFrame(map);
            ESRI.ArcGIS.Carto.IMapFrame mapFrame = frameElement as ESRI.ArcGIS.Carto.IMapFrame; // Dynamic Cast
            ESRI.ArcGIS.Carto.IMapSurroundFrame mapSurroundFrame = mapFrame.CreateSurroundFrame(uid as ESRI.ArcGIS.esriSystem.UID, null); // Dynamic Cast
            ESRI.ArcGIS.Carto.IElement element = mapSurroundFrame as ESRI.ArcGIS.Carto.IElement; // Dynamic Cast
            element.Geometry = envelope;
            element.Activate(activeView.ScreenDisplay);
            graphicsContainer.AddElement(element, 0);
            ESRI.ArcGIS.Carto.IMapSurround mapSurround = mapSurroundFrame.MapSurround;

            // Change out the default north arrow
            ESRI.ArcGIS.Carto.IMarkerNorthArrow markerNorthArrow = mapSurround as ESRI.ArcGIS.Carto.IMarkerNorthArrow; // Dynamic Cast
            ESRI.ArcGIS.Display.IMarkerSymbol markerSymbol = markerNorthArrow.MarkerSymbol;
            ESRI.ArcGIS.Display.ICharacterMarkerSymbol characterMarkerSymbol = markerSymbol as ESRI.ArcGIS.Display.ICharacterMarkerSymbol; // Dynamic Cast
            characterMarkerSymbol.CharacterIndex = 200; // change the symbol for the North Arrow
            markerNorthArrow.MarkerSymbol = characterMarkerSymbol;
        }
        #endregion
        #region // 添加比例尺
        ///<summary>Add a Scale Bar to the Page Layout from the Map.</summary>
        ///
        ///<param name="pageLayout">An IPageLayout interface.</param>
        ///<param name="map">An IMap interface.</param>
        ///
        ///<remarks></remarks>
        public void AddScalebar(IPageLayout pageLayout, IMap map)
        {

            if (pageLayout == null || map == null)
            {
                return;
            }

            ESRI.ArcGIS.Geometry.IEnvelope envelope = new ESRI.ArcGIS.Geometry.EnvelopeClass();
            envelope.PutCoords(7, 1, 25, 1.5); // Specify the location and size of the scalebar
            ESRI.ArcGIS.esriSystem.IUID uid = new ESRI.ArcGIS.esriSystem.UIDClass();
            uid.Value = "esriCarto.AlternatingScaleBar";

            // Create a Surround. Set the geometry of the MapSurroundFrame to give it a location
            // Activate it and add it to the PageLayout's graphics container
            ESRI.ArcGIS.Carto.IGraphicsContainer graphicsContainer = pageLayout as ESRI.ArcGIS.Carto.IGraphicsContainer; // Dynamic Cast
            ESRI.ArcGIS.Carto.IActiveView activeView = pageLayout as ESRI.ArcGIS.Carto.IActiveView; // Dynamic Cast
            ESRI.ArcGIS.Carto.IFrameElement frameElement = graphicsContainer.FindFrame(map);
            ESRI.ArcGIS.Carto.IMapFrame mapFrame = frameElement as ESRI.ArcGIS.Carto.IMapFrame; // Dynamic Cast
            ESRI.ArcGIS.Carto.IMapSurroundFrame mapSurroundFrame = mapFrame.CreateSurroundFrame(uid as ESRI.ArcGIS.esriSystem.UID, null); // Dynamic Cast
            ESRI.ArcGIS.Carto.IElement element = mapSurroundFrame as ESRI.ArcGIS.Carto.IElement; // Dynamic Cast
            element.Geometry = envelope;
            element.Activate(activeView.ScreenDisplay);
            graphicsContainer.AddElement(element, 0);
            ESRI.ArcGIS.Carto.IMapSurround mapSurround = mapSurroundFrame.MapSurround;


            ESRI.ArcGIS.Carto.IScaleBar markerScaleBar = ((ESRI.ArcGIS.Carto.IScaleBar)(mapSurround));

            markerScaleBar.LabelSymbol = new TextSymbolClass() { 
                Font = GetFontDisp(20)
            };
            markerScaleBar.UnitLabelSymbol = new TextSymbolClass() {
                Font = GetFontDisp(20)
            };

            markerScaleBar.LabelPosition = ESRI.ArcGIS.Carto.esriVertPosEnum.esriBelow;
            markerScaleBar.UseMapSettings();
        }
        #endregion
        #region // 创建字体对象
        ///<summary>Generate a default FontDisp object.</summary>
        /// 
        ///<returns>An stdole.IFontDisp interface</returns>
        ///  
        ///<remarks></remarks>
        public stdole.IFontDisp GetFontDisp(int size, bool isbold = false)
        {
            stdole.IFontDisp fontDisp = new stdole.StdFontClass() as stdole.IFontDisp; // Dynamic Cast
            fontDisp.Bold = isbold;
            fontDisp.Name = "Arial";
            fontDisp.Italic = false;
            fontDisp.Underline = false;
            fontDisp.Size = size;

            return fontDisp;
        }
        #endregion
        // 添加标题
        public void AddTitle(string text)
        { 
            // 放置位置
            IEnvelope pEnv = axPageLayoutControl_main.Extent;
            IPoint pPoint = new PointClass() { 
                X = (pEnv.XMin + pEnv.XMax) / 2,
                Y = pEnv.YMax - 4
            };
            // 文本符号
            ITextSymbol pTextSymbol = new TextSymbolClass() { 
                Font = GetFontDisp(30, true),
                Color = GetRgbColor(0, 0, 0)
            };
            // 文本对象
            IElement pElement = new TextElementClass() { 
                Text = text,
                Symbol = pTextSymbol,
                Geometry = pPoint
            };
            (axPageLayoutControl_main.PageLayout as IGraphicsContainer).AddElement(pElement, 0);
            axPageLayoutControl_main.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGraphics, null, null);
        }
        // 专题图符号化（唯一值符号化 - 颜色带渐变） - 事件入口
        private void btn_symbology_Click(object sender, EventArgs e)
        {
            //IRasterRenderer pRenderer = new RasterStretchColorRampRendererClass(){
            //    BandIndex = 0,
            //    ColorRamp = GetColorRamp(GetRgbColor(0, 255, 0), GetRgbColor(255, 0, 0), 5)
            //};
            //pRenderer.Raster = (m_pLayer as IRasterLayer).Raster;
            //pRenderer.Update();

            //(m_pLayer as IRasterLayer).Renderer = pRenderer;
            //axPageLayoutControl_main.Refresh();

            IRasterUniqueValueRenderer pRenderer = new RasterUniqueValueRendererClass() {
                ColorRamp = GetColorRamp(GetRgbColor(0, 255, 0), GetRgbColor(255, 0, 0), 4)
            };
            (pRenderer as IRasterRenderer).Raster = (m_pLayer as IRasterLayer).Raster;
            (pRenderer as IRasterRenderer).Update();
            SetRasterRendererInfo(pRenderer, 0, 1, "非敏感");
            SetRasterRendererInfo(pRenderer, 1, 2, "低敏感");
            SetRasterRendererInfo(pRenderer, 2, 3, "中敏感");
            SetRasterRendererInfo(pRenderer, 3, 4, "高敏感");
            (m_pLayer as IRasterLayer).Renderer = pRenderer as IRasterRenderer;
            axPageLayoutControl_main.Refresh();
        }
        // 唯一值渲染器设置
        private void SetRasterRendererInfo(IRasterUniqueValueRenderer renderer, int iclass,object value, string label)
        {
            renderer.AddValue(0, iclass, value);
            renderer.set_Label(0, iclass, label);
        }

        #region // 输出地图
        public System.Boolean ExportMap(IActiveView activeView, String pathFileName)
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

        // 添加地图三要素（指北针、比例尺、图例）
        private void btn_addMapElementts_Click(object sender, EventArgs e)
        {
            IPageLayout pPageLayout = axPageLayoutControl_main.PageLayout;
            IMap pMap = axPageLayoutControl_main.ActiveView.FocusMap;

            try
            {
                AddLegend(pPageLayout, pMap, 1, 1, 5.0);
                AddNorthArrow(pPageLayout, pMap);
                AddScalebar(pPageLayout, pMap);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "错误信息");
            }
            

            axPageLayoutControl_main.Refresh();
        }

        // 添加标题 - 事件入口
        private void btn_addTitle_Click(object sender, EventArgs e)
        {
            AddTitle("某地区生态环境敏感性等级分布专题图");
        }

        // 输出专题图 - 事件入口
        private void btn_exportMap_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfg = new SaveFileDialog() { 
                Title = "输出专题图",
                Filter = "图片 (*.jpg)|*.jpg"
            };
            if (sfg.ShowDialog() == DialogResult.OK)
            {
                ExportMap(axPageLayoutControl_main.ActiveView, sfg.FileName);
                MessageBox.Show("出图成功");
            }
        }



        

    }
}
