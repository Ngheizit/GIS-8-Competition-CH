using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Display;

namespace Temp
{
    class AeUtils
    {

        public static IFeatureLayer GetFeatureLayer(IMap map, string layerName)
        {
            // 遍历地图图层
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
                Red = r, Green = g, Blue = b, Transparency = a
            };
        }

    }
}
