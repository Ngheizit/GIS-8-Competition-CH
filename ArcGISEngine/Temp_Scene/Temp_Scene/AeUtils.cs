using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ESRI.ArcGIS.Carto;

namespace Temp_Scene
{
    class AeUtils
    {
        public static ILayer GetLayerByName(IMap map, string layerName)
        {
            for (int i = 0; i < map.LayerCount; i++)
            {
                if (map.get_Layer(i).Name == layerName)
                    return map.get_Layer(i);
            }
            return null;
        }
    }
}
