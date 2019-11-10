using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Output;
using System.Windows.Forms;

namespace AeDome
{
    class AeUtils
    {
        #region // 获取RgbColor对象
        public static IRgbColor GetRgbColor(byte r, byte g, byte b, byte a = 255)
        {
            return new RgbColorClass()
            {
                Red = r,
                Green = g,
                Blue = b,
                Transparency = a
            };
        } 
        #endregion

        #region // 属性统计
        public static IStatisticsResults GetDataSataResults(IFeatureLayer featureLayer, string fieldName)
        {
            ITable pTable = featureLayer as ITable;
            ICursor pCursor = pTable.Search(null, false);
            IDataStatistics pDataStat = new DataStatisticsClass() { 
                Cursor = pCursor, Field =fieldName
            };
            return pDataStat.Statistics;
        }
        #endregion

        #region // 获取FeatureLayer对象
        public static IFeatureLayer GetFeatureLayerByName(IMap map, string layerName)
        {
            for (int i = 0; i < map.LayerCount; i++)
            {
                if (map.get_Layer(i).Name == layerName)
                    return map.get_Layer(i) as IFeatureLayer;
            }
            return null;
        } 
        #endregion

        #region // 唯一值符号化
        public static void Symbology_UniqueValue(IFeatureLayer featureLayer, string fieldName, IMapControl2 mapControl, AxTOCControl tocControl)
        {
            IUniqueValueRenderer pRenderer = new UniqueValueRendererClass()
            {
                FieldCount = 1
            };
            pRenderer.set_Field(0, fieldName);
            // 设置符号化色带
            IRandomColorRamp pColorRamp = new RandomColorRampClass()
            {
                StartHue = 0,
                MinValue = 0,
                MinSaturation = 0,
                EndHue = 360,
                MaxValue = 100,
                MaxSaturation = 100,
                Size = featureLayer.FeatureClass.FeatureCount(new QueryFilterClass())
            };
            bool bOk = false;
            pColorRamp.CreateRamp(out bOk);
            IEnumColors pColors = pColorRamp.Colors;
            // 获取渲染字段索引
            ITable pTable = featureLayer as ITable;
            int fieldIndex = pTable.FindField(fieldName);
            // 遍历唯一值要素
            IQueryFilter pQueryFilter = new QueryFilterClass();
            pQueryFilter.AddField(fieldName);
            ICursor pCursor = pTable.Search(pQueryFilter, true);
            IRow pRow = pCursor.NextRow();
            while (pRow != null)
            {
                IRowBuffer pRowBuffer = pRow as IRowBuffer;
                string value = pRowBuffer.get_Value(fieldIndex).ToString();
                IColor pColor = pColors.Next();
                ISymbol pSymbol = null;
                switch (featureLayer.FeatureClass.ShapeType)
                {
                    case esriGeometryType.esriGeometryPoint:
                        pSymbol = new SimpleMarkerSymbolClass() { Color = pColor };
                        break;
                    case esriGeometryType.esriGeometryPolyline:
                        pSymbol = new SimpleLineSymbolClass() { Color = pColor };
                        break;
                    case esriGeometryType.esriGeometryPolygon:
                        pSymbol = new SimpleFillSymbolClass() { Color = pColor };
                        break;
                }
                pRenderer.AddValue(value, "", pSymbol);
                pRow = pCursor.NextRow();
            }
            (featureLayer as IGeoFeatureLayer).Renderer = pRenderer as IFeatureRenderer;
            mapControl.Refresh();
            tocControl.Update();
        } 
        #endregion

        #region // 分级符号化
        public static void Symbology_GraduatedColors(IFeatureLayer featureLayer, string fieldName, int numClasses, IMapControl2 mapControl, AxTOCControl tocControl)
        {
            // 获取渲染字段的值及其出现的频率
            ITable pTable = featureLayer as ITable;
            IBasicHistogram pBasicHistogram = new BasicTableHistogramClass()
            {
                Field = fieldName,
                Table = pTable
            };
            object dataFrequency, dataValue; // 频率和值
            pBasicHistogram.GetHistogram(out dataValue, out dataFrequency);
            // 数据分级
            IClassifyGEN pClassifyGEN = new EqualIntervalClass(); // 等间隔
            //IClassifyGEN pClassifyGEN = new GeometricalIntervalClass(); // 几何间隔
            //IClassifyGEN pClassifyGEN = new NaturalBreaksClass(); // 自然裂变
            //IClassifyGEN pClassifyGEN = new QuantileClass(); // 分位数
            //IClassifyGEN pClassifyGEN = new StandardDeviationClass(); // 标准偏差
            try { pClassifyGEN.Classify(dataValue, dataFrequency, numClasses); }
            catch { }
            double[] Classes = pClassifyGEN.ClassBreaks as double[];
            int ClassesCount = Classes.GetUpperBound(0);
            IClassBreaksRenderer pRenderer = new ClassBreaksRendererClass()
            {
                // 分类字段 分类数目 升序
                Field = fieldName,
                BreakCount = ClassesCount,
                SortClassesAscending = true
            };
            // 生成颜色色带
            IAlgorithmicColorRamp pColorRamp = new AlgorithmicColorRamp()
            {
                FromColor = GetRgbColor(255, 200, 200),
                ToColor = GetRgbColor(255, 0, 0),
                Size = ClassesCount
            };
            bool bOk = false;
            pColorRamp.CreateRamp(out bOk);
            IEnumColors pColors = pColorRamp.Colors;
            // 逐一设置填充符号及每一分级的分级断点
            for (int index = 0; index < ClassesCount; index++)
            {
                IColor pColor = pColors.Next();
                ISymbol pSymbol = null;
                switch (featureLayer.FeatureClass.ShapeType)
                {
                    case esriGeometryType.esriGeometryPoint:
                        pSymbol = new SimpleMarkerSymbolClass() { Color = pColor };
                        break;
                    case esriGeometryType.esriGeometryPolyline:
                        pSymbol = new SimpleLineSymbolClass() { Color = pColor };
                        break;
                    case esriGeometryType.esriGeometryPolygon:
                        pSymbol = new SimpleFillSymbolClass() { Color = pColor };
                        break;
                }
                pRenderer.set_Symbol(index, pSymbol); // 每级的符号
                pRenderer.set_Break(index, Classes[index + 1]); // 每级的断点
            }
            (featureLayer as IGeoFeatureLayer).Renderer = pRenderer as IFeatureRenderer;
            mapControl.Refresh();
            tocControl.Update();
        } 
        #endregion

        #region // 比例符号化
        public static void Symbology_Proportional(IFeatureLayer featureLayer, string fieldName, IMapControl2 mapControl, AxTOCControl tocControl)
        {
            // 获取渲染字段统计值
            IStatisticsResults pStatResult = GetDataSataResults(featureLayer, fieldName);
            // 比例符号渲染
            if (pStatResult != null)
            {
                IFillSymbol pFillSymbol = new SimpleFillSymbolClass() { Color = GetRgbColor(155, 255, 0) };
                ISymbol pMarkerSymbol = new SimpleMarkerSymbolClass()
                {
                    Style = esriSimpleMarkerStyle.esriSMSDiamond,
                    Size = 3,
                    Color = GetRgbColor(255, 90, 0)
                };
                IProportionalSymbolRenderer pRenderer = new ProportionalSymbolRendererClass()
                {
                    ValueUnit = esriUnits.esriUnknownUnits, // 渲染单位
                    Field = fieldName,                      // 渲染字段
                    FlanneryCompensation = false,
                    MinDataValue = pStatResult.Minimum,     // 最小值
                    MaxDataValue = pStatResult.Maximum,     // 最大值
                    BackgroundSymbol = pFillSymbol,         // 背景颜色
                    MinSymbol = pMarkerSymbol,              // 最小渲染符号
                    LegendSymbolCount = 5                   // TOC控件中的显示条目      
                };
                pRenderer.CreateLegendSymbols();
                (featureLayer as IGeoFeatureLayer).Renderer = pRenderer as IFeatureRenderer;
                mapControl.Refresh();
                tocControl.Update();
            }
        } 
        #endregion

        #region // 显示注记
        public static void ShowLabel(IFeatureLayer featureLayer, string fieldName, IMapControl2 mapControl)
        {
            // 逐一对每一个要素添加Label
            IFeatureCursor pFeatureCursor = featureLayer.FeatureClass.Search(null, false);
            IFeature pFeature = pFeatureCursor.NextFeature();
            while (pFeature != null)
            {
                // 注记摆放位置
                IEnvelope pEnvelope = pFeature.Extent;
                IPoint pPoint = new PointClass()
                {
                    X = pEnvelope.XMin + pEnvelope.Width / 2,
                    Y = pEnvelope.YMin + pEnvelope.Height / 2
                };
                // 文本符号
                stdole.IFontDisp pFont = new stdole.StdFontClass() as stdole.IFontDisp;
                pFont.Name = "arial";
                ITextSymbol pSymbol = new TextSymbolClass()
                {
                    Size = 20,
                    Font = pFont,
                    Color = GetRgbColor(255, 0, 0)
                };
                // 添加文本对象
                int index = pFeature.Fields.FindField(fieldName);
                IElement pTextElement = new TextElementClass()
                {
                    Text = pFeature.get_Value(index).ToString(),
                    ScaleText = true,
                    Symbol = pSymbol,
                    Geometry = pPoint
                };
                (mapControl.Map as IGraphicsContainer).AddElement(pTextElement, 0);
                mapControl.Refresh(esriViewDrawPhase.esriViewGraphics, null, null);
                pFeature = pFeatureCursor.NextFeature();
            }
        } 
        #endregion

        #region // 添加指北针
        public static void AddNorthArrow(AxPageLayoutControl pageLayoutControl, IEnvelope envelope)
        {
            IUID uid = new UIDClass() { Value = "esriCarto.MarkerNorthArrow" };

            IFrameElement frameElement = (pageLayoutControl.PageLayout as IGraphicsContainer)
                .FindFrame(pageLayoutControl.ActiveView.FocusMap);
            IMapFrame mapFrame = frameElement as IMapFrame;
            IMapSurroundFrame mapSurroundFrame = mapFrame.CreateSurroundFrame(uid as UID, null); // Dynamic Cast
            IElement element = mapSurroundFrame as IElement; // Dynamic Cast
            element.Geometry = envelope;
            element.Activate(pageLayoutControl.ActiveView.ScreenDisplay);
            (pageLayoutControl.PageLayout as IGraphicsContainer).AddElement(element, 0);
            IMapSurround mapSurround = mapSurroundFrame.MapSurround;

            // Change out the default north arrow
            IMarkerNorthArrow markerNorthArrow = mapSurround as IMarkerNorthArrow; // Dynamic Cast
            IMarkerSymbol markerSymbol = markerNorthArrow.MarkerSymbol;
            ICharacterMarkerSymbol characterMarkerSymbol = markerSymbol as ICharacterMarkerSymbol; // Dynamic Cast
            characterMarkerSymbol.CharacterIndex = 202;
            markerNorthArrow.MarkerSymbol = characterMarkerSymbol;
        } 
        #endregion

        #region // 添加比例尺
        public static void AddScalebar(AxPageLayoutControl pageLayoutControl, IEnvelope envelope)
        {
            IUID uid = new UIDClass() { Value = "esriCarto.AlternatingScaleBar" };

            IFrameElement frameElement = (pageLayoutControl.PageLayout as IGraphicsContainer)
                .FindFrame(pageLayoutControl.ActiveView.FocusMap);
            IMapFrame mapFrame = frameElement as IMapFrame;
            IMapSurroundFrame mapSurroundFrame = mapFrame.CreateSurroundFrame(uid as UID, null); // Dynamic Cast
            IElement element = mapSurroundFrame as IElement; // Dynamic Cast
            element.Geometry = envelope;
            element.Activate(pageLayoutControl.ActiveView.ScreenDisplay);
            (pageLayoutControl.PageLayout as IGraphicsContainer).AddElement(element, 0);
            IMapSurround mapSurround = mapSurroundFrame.MapSurround;    

            IScaleBar markerScaleBar = (IScaleBar)(mapSurround);
            markerScaleBar.LabelPosition = esriVertPosEnum.esriBelow;
            markerScaleBar.UseMapSettings();
        } 
        #endregion

        #region // 添加图例
        public static void AddLegend(AxPageLayoutControl pageLayoutControl, IEnvelope envelope)
        {
            IActiveView pActiveView = pageLayoutControl.ActiveView;

            UID pUID = new UID() { Value = "esriCarto.Legend" };
            IGraphicsContainer pGraphicsContainer = pageLayoutControl.PageLayout as IGraphicsContainer;
            IMapFrame pMapFrame = pGraphicsContainer.FindFrame(pActiveView.FocusMap) as IMapFrame;
            // 根据唯一标识符，创建与之对应的MapSurroundFrame
            IMapSurroundFrame pMapSurroundFrame = pMapFrame.CreateSurroundFrame(pUID, null);
            // 获取PageLayout中的图例元素
            IElement pDeleteElement = pageLayoutControl.FindElementByName("Legend");
            if (pDeleteElement != null)
                pGraphicsContainer.DeleteElement(pDeleteElement); // 如果已存在图例，删除已经存在的图例
            // 设置MapSurroundFrame背景
            ISymbolBackground pSymbolBackground = new SymbolBackgroundClass()
            {
                FillSymbol = new SimpleFillSymbolClass()
                {
                    Color = GetRgbColor(240, 240, 240),
                    Outline = new SimpleLineSymbolClass()
                    {
                        Color = GetRgbColor(0, 0, 0)
                    }
                }
            };
            pMapSurroundFrame.Background = pSymbolBackground;
            // 添加图例
            IElement pElement = pMapSurroundFrame as IElement;
            pElement.Geometry = envelope as IGeometry;
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
            pGraphicsContainer.AddElement(pElement, 0);
            pActiveView.PartialRefresh(esriViewDrawPhase.esriViewGraphics, null, null);
        } 
        #endregion

        #region // 打印输出地图
        public static void ExportMap(IActiveView activeView)
        {
            SaveFileDialog sfg = new SaveFileDialog()
            {
                Title = "导出jpg格式图片",
                Filter = "JPG图片(*.jpg)|*.jpg"
            };
            if (sfg.ShowDialog() == DialogResult.OK)
            {
                // 打印机接口
                IExporter pExporter = new JpegExporterClass()
                {
                    ExportFileName = sfg.FileName,
                    Resolution = (short)activeView.ScreenDisplay.DisplayTransformation.Resolution
                };

                // 设置输出地图范围
                tagRECT pTagRECT = activeView.ScreenDisplay.DisplayTransformation.get_DeviceFrame();
                IEnvelope pEnvelope = new EnvelopeClass()
                {
                    XMin = pTagRECT.left,
                    XMax = pTagRECT.right,
                    YMin = pTagRECT.bottom,
                    YMax = pTagRECT.top
                };
                pExporter.PixelBounds = pEnvelope;

                //// 输出地图
                activeView.Output(pExporter.StartExporting(), pExporter.Resolution, ref pTagRECT, activeView.Extent, null);
                Application.DoEvents();
                pExporter.FinishExporting();
                MessageBox.Show("已将地图导出为jpg格式图片");
            }
        }
        #endregion

        #region // SQL要素选择
        public static void SelectBySQL(string strSQL, IFeatureLayer featureLayer, IMapControl2 mapControl)
        {
            mapControl.Map.ClearSelection();
            IQueryFilter pQueryFilter = new QueryFilter() as IQueryFilter;
            pQueryFilter.WhereClause = strSQL;
            IFeatureSelection pFeatureSelection = featureLayer as IFeatureSelection;
            pFeatureSelection.SelectFeatures(pQueryFilter, esriSelectionResultEnum.esriSelectionResultNew, false);
            mapControl.Refresh(esriViewDrawPhase.esriViewGeoSelection, null, null);
        }
        #endregion

    }
}
