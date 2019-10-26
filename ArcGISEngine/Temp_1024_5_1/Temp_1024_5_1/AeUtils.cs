using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Geometry;

namespace Temp_1024_5_1
{
    class AeUtils
    {
        public static IFeatureLayer GetFeatureLayerByName(IMap map, string layerName)
        {
            for (int i = 0; i < map.LayerCount; i++)
            {
                if (map.get_Layer(i).Name == layerName)
                    return map.get_Layer(i) as IFeatureLayer;
            }
            return null;
        }

        public static IRgbColor GetRgbColor(byte r, byte g, byte b, byte a = 255)
        {
            return new RgbColorClass() { 
                Red = r, Blue = b, Green = g, Transparency = a
            };
        }

        public static void TextElementLabel(IMapControl2 mapControl, IFeatureLayer featureLayer, string fieldName)
        {
            IMap pMap = mapControl.Map;
            // 获取图层所有要素
            IFeatureCursor pFeatureCursor = featureLayer.FeatureClass.Search(null, false);
            IFeature pFeature = pFeatureCursor.NextFeature();
            while (pFeature != null)
            {
                IFields pFields = pFeature.Fields;
                // 找出标注字段的索引号
                int index = pFields.FindField(fieldName);
                // 得到要素的Envelope对象
                IEnvelope pEnv = pFeature.Extent;
                IPoint pPoint = new PointClass() { 
                    X = pEnv.XMin + pEnv.Width / 2,
                    Y = pEnv.YMin + pEnv.Height / 2
                };
                // 新建字体对象
                stdole.IFontDisp pFont = new stdole.StdFontClass() as stdole.IFontDisp;
                pFont.Name = "arial";
                // 设置文本符号
                ITextSymbol pTextSymbol = new TextSymbolClass() { 
                    Size = 20,
                    Font = pFont,
                    Color = AeUtils.GetRgbColor(255, 0, 0)
                };
                // 添加文本对象
                IElement pTextElement = new TextElementClass() { 
                    Text = pFeature.get_Value(index).ToString(),
                    ScaleText = true,
                    Symbol = pTextSymbol
                };
                pTextElement.Geometry = pPoint;
                (pMap as IGraphicsContainer).AddElement(pTextElement, 0);
                mapControl.Refresh(esriViewDrawPhase.esriViewGraphics);
                pFeature = pFeatureCursor.NextFeature();
            }
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
                StartHue = 0,
                MinValue = 0,
                MinSaturation = 0,
                EndHue = 100,
                MaxValue = 100,
                MaxSaturation = 100
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
                        pSymbol = new SimpleLineSymbolClass() { Color = pNextUniqueColor };
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
    }
}
