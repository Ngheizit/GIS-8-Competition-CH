using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.Output;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.esriSystem;
using System.Windows.Forms;

namespace Temp_1101_4_A
{
    class AeUtils
    {

        // 获取颜色
        public static IRgbColor GetRgbColor(byte r, byte g, byte b, byte a)
        {
            return new RgbColorClass() { 
                Red = r, Green = g, Blue = b, Transparency = a
            };
        }

        // 属性统计
        public static IStatisticsResults GetStatResult(IFeatureLayer featureLayer, string fieldName)
        {
            ITable pTable = featureLayer as ITable;
            ICursor pCursor = pTable.Search(null, false);
            IDataStatistics pDataStatistics = new DataStatisticsClass() { 
                Cursor = pCursor, Field = fieldName
            };
            return pDataStatistics.Statistics;
        }

        // 唯一值符号化
        public static void Symbology_UniqueValue(IFeatureLayer featureLayer, string fieldName, IMapControl2 mapControl, AxTOCControl tocControl)
        {
            IUniqueValueRenderer pRenderer = new UniqueValueRendererClass() { 
                FieldCount = 1
            };
            // 随机色带
            IColorRamp pColorRamp = new RandomColorRampClass() { 
                StartHue = 0, MinSaturation = 0, MinValue = 0,
                EndHue = 360, MaxSaturation = 100, MaxValue = 100,
                Size = featureLayer.FeatureClass.FeatureCount(new QueryFilterClass())
            };
            bool bOk = false;
            pColorRamp.CreateRamp(out bOk);
            IEnumColors pColors = pColorRamp.Colors;
            ITable pTable = featureLayer as ITable;
            int fieldIndex = pTable.FindField(fieldName);
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
    }
}
