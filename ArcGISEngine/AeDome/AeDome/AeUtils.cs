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

        public static void Symbology_UniqueValue(IFeatureLayer featureLayer, string fieldName, IMapControl2 mapControl, AxTOCControl tocControl)
        {
            IUniqueValueRenderer pRenderer = new UniqueValueRendererClass() { 
                FieldCount = 1
            };
            pRenderer.set_Field(0, fieldName);
            // 设置符号化色带
            IRandomColorRamp pColorRamp = new RandomColorRampClass() { 
                StartHue = 0, MinValue = 0, MinSaturation = 0,
                EndHue = 360, MaxValue = 100, MaxSaturation = 100,
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
                if (pColor == null)
                {
                    pColors.Reset();
                    pColor = pColors.Next();
                }
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
