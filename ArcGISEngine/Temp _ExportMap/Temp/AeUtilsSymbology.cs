using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.esriSystem;

namespace Temp
{
    class AeUtilsSymbology
    {
        // 输入RGB值，获得IRgbColor接口对象
        public static IRgbColor GetRgbColor(byte r, byte g, byte b, byte a = 255)
        {
            return new RgbColorClass()
            {
                Red = r, Green = g, Blue = b, Transparency = a
            };
        }

        // 输入HSV值，获得IHsvColor接口对象
        public static IHsvColor GetHsvColor(int h, int s, int v)
        {
            return new HsvColorClass()
            {
                Hue = h, Saturation = s, Value = v
            };
        }

        // 创建渐变色带
        public static IAlgorithmicColorRamp CreateColorRamp(IRgbColor fromColor, IRgbColor toColor, int size = 10)
        { 
            IAlgorithmicColorRamp pColorRamp = new AlgorithmicColorRampClass()
            {
                FromColor = fromColor, ToColor = toColor, // 起止颜色
                Algorithm = esriColorRampAlgorithm.esriCIELabAlgorithm, // 梯度类型
                Size = size // 色带颜色数量
            };
            // 创建色带
            bool bture = true;
            pColorRamp.CreateRamp(out bture);
            return pColorRamp;
        }
        public static IAlgorithmicColorRamp CreateColorRamp(IHsvColor fromColor, IHsvColor toColor, int size = 10)
        {
            IAlgorithmicColorRamp pColorRamp = new AlgorithmicColorRampClass()
            {
                FromColor = fromColor,
                ToColor = toColor, // 起止颜色
                Algorithm = esriColorRampAlgorithm.esriHSVAlgorithm, // 梯度类型
                Size = size // 色带颜色数量
            };
            // 创建色带
            bool bture = true;
            pColorRamp.CreateRamp(out bture);
            return pColorRamp;
        }

        // 唯一值符号化
        public static void UniqueValueRenderer(IFeatureLayer featureLayer, string fieldName, IMapControl2 mapControl, AxTOCControl tocControl)
        {
            ITable pTable = featureLayer as ITable;
            IUniqueValueRenderer pRenderer = new UniqueValueRendererClass();
            pRenderer.FieldCount = 1; // 设置唯一值符号化的关键字段为一个
            pRenderer.set_Field(0, fieldName); // 设置唯一值符号化的第一个关键字段
            IRandomColorRamp pColorRamp = new RandomColorRampClass() 
            { 
                StartHue = 0, MinValue = 0, MinSaturation = 0,
                EndHue = 360, MaxValue = 100, MaxSaturation = 100
            };
            // 根据渲染字段的值的个数，设置一组随机颜色
            pColorRamp.Size = featureLayer.FeatureClass.FeatureCount(new QueryFilterClass());
            bool bSuccess = false;
            pColorRamp.CreateRamp(out bSuccess);
            IEnumColors pEnumColors = pColorRamp.Colors;
            IColor pNextUniqueColor = null;
            // 查询字段的值
            IQueryFilter pQueryFilter = new QueryFilterClass();
            pQueryFilter.AddField(fieldName);
            int fieldNumber = pTable.FindField(fieldName); // 获取渲染字段索引
            ICursor pCursor = pTable.Search(pQueryFilter, true);
            IRow pNextRow = pCursor.NextRow();
            object codeValue = null;
            IRowBuffer pNextRowBuffer = null;
            while (pNextRow != null)
            {
                pNextRowBuffer = pNextRow as IRowBuffer;
                // 获取渲染字段的每一个值
                codeValue = pNextRowBuffer.get_Value(fieldNumber);
                pNextUniqueColor = pEnumColors.Next();
                if (pNextUniqueColor == null)
                {
                    pEnumColors.Reset();
                    pNextUniqueColor = pEnumColors.Next();
                }
                ISymbol pSymbol = null;
                switch (featureLayer.FeatureClass.ShapeType)
                { 
                    case esriGeometryType.esriGeometryPolygon:
                        pSymbol = new SimpleFillSymbolClass() { Color = pNextUniqueColor };
                        break;
                    case esriGeometryType.esriGeometryPolyline:
                        pSymbol = new SimpleLineSymbolClass(){ Color = pNextUniqueColor };
                        break;
                    case esriGeometryType.esriGeometryPoint:
                        pSymbol = new SimpleMarkerSymbolClass() { Color = pNextUniqueColor };
                        break;
                }
                pRenderer.AddValue(codeValue.ToString(), "", pSymbol);
                pNextRow = pCursor.NextRow();
            }
            (featureLayer as IGeoFeatureLayer).Renderer = pRenderer as IFeatureRenderer;
            mapControl.Refresh();
            tocControl.Update();
        }

        // 分级色彩符号化
        public static void GraduatedColors(IFeatureLayer featureLayer, string fieldName, int numClasses, IMapControl2 mapControl, AxTOCControl tocControl)
        {
            object dataFrequency;
            object dataValue;
            int breakIndex;
            ITable pTable = featureLayer.FeatureClass as ITable;
            ITableHistogram pTableHistogram = new BasicTableHistogramClass() { Field = fieldName, Table = pTable };
            IBasicHistogram pBasicHistogram = (IBasicHistogram)pTableHistogram;
            // 获取渲染字段的值及其出现的频率
            pBasicHistogram.GetHistogram(out dataValue, out dataFrequency);
            IClassifyGEN pClassifyGEN = new EqualIntervalClass();
            try { pClassifyGEN.Classify(dataValue, dataFrequency, ref numClasses); }
            catch { }
            // 返回一个数组
            double[] Classes = pClassifyGEN.ClassBreaks as double[];
            int ClassesCount = Classes.GetUpperBound(0);
            IClassBreaksRenderer pRenderer = new ClassBreaksRendererClass() { 
                // 分级字段 分级数目 分级后的图例是否按升级顺序排序
                Field = fieldName, BreakCount = ClassesCount, SortClassesAscending = true
            };
            // 设置分级说色所需颜色带的起止颜色
            //IHsvColor pFromColor = GetHsvColor(0, 50, 96);
            //IHsvColor pToColor = GetHsvColor(80, 100, 96);
            IRgbColor pFromColor = GetRgbColor(255, 200, 200);
            IRgbColor pToColor = GetRgbColor(255, 0, 0);
            // 生成颜色带对象
            IAlgorithmicColorRamp pColorRamp = CreateColorRamp(pFromColor, pToColor, ClassesCount);
            // 获取色带颜色集
            IEnumColors pEnumColors = pColorRamp.Colors;
            // 逐一设置填充符号及每一分级的分级断点
            for (breakIndex = 0; breakIndex < ClassesCount; breakIndex++)
            {
                IColor pColor = pEnumColors.Next();
                ISymbol pSymbol = null;
                switch (featureLayer.FeatureClass.ShapeType)
                { 
                    case esriGeometryType.esriGeometryPolygon:
                        pSymbol = new SimpleFillSymbolClass() {
                            Color = pColor, Style = esriSimpleFillStyle.esriSFSSolid
                        };
                        break;
                    case esriGeometryType.esriGeometryPolyline:
                        pSymbol = new SimpleLineSymbolClass() { 
                            Color = pColor
                        };
                        break;
                    case esriGeometryType.esriGeometryPoint:
                        pSymbol = new SimpleMarkerSymbolClass() { 
                            Color = pColor
                        };
                        break;
                }
                // 设置填充符号
                pRenderer.set_Symbol(breakIndex, pSymbol);
                // 设置每一级的分级断点
                pRenderer.set_Break(breakIndex, Classes[breakIndex + 1]);
            }
            (featureLayer as IGeoFeatureLayer).Renderer = pRenderer as IFeatureRenderer;
            mapControl.Refresh();
            tocControl.Update();
        }
        
        // 比例符号化
        public static void Proportional(IFeatureLayer featureLayer, string fieldName, IMapControl2 mapControl, AxTOCControl tocControl)
        {
            ITable pTable = featureLayer as ITable;
            ICursor pCursor = pTable.Search(null, false);
            // 利用IDataStatistics和IStatisticsResults获取渲染字段的统计值（最大值 and 最小值）
            IDataStatistics pDataStat = new DataStatisticsClass() { 
                Cursor = pCursor, Field = fieldName
            };
            IStatisticsResults pStatResult = pDataStat.Statistics;
            if (pStatResult != null)
            { 
                // 设置渲染背景色
                IFillSymbol pFillSymbol = new SimpleFillSymbolClass() { Color = GetRgbColor(155, 255, 0) };
                ISimpleMarkerSymbol pSimpleMaskerSymbol = new SimpleMarkerSymbolClass() { 
                    Style = esriSimpleMarkerStyle.esriSMSDiamond,
                    Size = 3,
                    Color = GetRgbColor(255, 90, 0)
                };
                IProportionalSymbolRenderer pRenderer = new ProportionalSymbolRendererClass() { 
                    ValueUnit = esriUnits.esriUnknownUnits, // 渲染单位
                    Field = fieldName, // 渲染字段
                    FlanneryCompensation =false, // 是否使用Flannery补偿
                    MinDataValue = pStatResult.Minimum, // 获取渲染字段的最小值
                    MaxDataValue = pStatResult.Maximum, // 获取渲染字段的最大值
                    BackgroundSymbol = pFillSymbol,
                    MinSymbol = pSimpleMaskerSymbol as ISymbol, // 渲染字段最小值的渲染符号
                    LegendSymbolCount = 5 // 设置TOC控件中的显示条目
                };
                pRenderer.CreateLegendSymbols(); // 生成图例
                (featureLayer as IGeoFeatureLayer).Renderer = pRenderer as IFeatureRenderer;
            }
            mapControl.Refresh();
            tocControl.Update();
        }
    }
}
