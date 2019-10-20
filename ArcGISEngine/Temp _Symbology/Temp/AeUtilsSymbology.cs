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
        public static IColorRamp CreateColorRamp(IRgbColor fromColor, IRgbColor toColor)
        { 
            IAlgorithmicColorRamp pColorRamp = new AlgorithmicColorRampClass()
            {
                FromColor = fromColor, ToColor = toColor, // 起止颜色
                Algorithm = esriColorRampAlgorithm.esriCIELabAlgorithm, // 梯度类型
                Size = 10 // 色带颜色数量
            };
            // 创建色带
            bool bture = true;
            pColorRamp.CreateRamp(out bture);
            return pColorRamp;
        }

        // 唯一值符号化
        public static void UniqueValueRenderer(IFeatureLayer featureLayer, string fieldName, IMapControl2 mapControl, AxTOCControl tocControl)
        {
            IGeoFeatureLayer pGeoFeatureLayer = featureLayer as IGeoFeatureLayer;
            ITable pTable = featureLayer as ITable;
            IUniqueValueRenderer pRenderer = new UniqueValueRendererClass();
            int fieldNumber = pTable.FindField(fieldName); // 获取渲染字段索引
            pRenderer.FieldCount = 1; // 设置唯一值符号化的关键字段为一个
            pRenderer.set_Field(0, fieldName); // 设置唯一值符号化的第一个关键字段
            IRandomColorRamp pColorRamp = new RandomColorRampClass() 
            { 
                StartHue = 0, MinValue = 0, MinSaturation = 0,
                EndHue = 360, MaxValue = 100, MaxSaturation = 100
            };
            // 根据渲染字段的值的个数，设置一组随机颜色
            IQueryFilter pQueryFilter = new QueryFilterClass();
            pColorRamp.Size = featureLayer.FeatureClass.FeatureCount(pQueryFilter);
            bool bSuccess = false;
            pColorRamp.CreateRamp(out bSuccess);
            IEnumColors pEnumColors = pColorRamp.Colors;
            IColor pNextUniqueColor = null;
            // 查询字段的值
            pQueryFilter.AddField(fieldName);
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
                switch (pGeoFeatureLayer.FeatureClass.ShapeType)
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
            pGeoFeatureLayer.Renderer = pRenderer as IFeatureRenderer;
            mapControl.Refresh();
            tocControl.Update();
        }

        // 分级色彩符号化
        public static void GraduatedColors(IFeatureLayer featureLayer, string fieldName, int numClasses)
        { 
            
        }
    }
}
