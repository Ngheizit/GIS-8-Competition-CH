using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;

using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Carto;

namespace Temp_1119_6_B
{
    class AeUtils
    {
        private static IMapControl2 m_pMapC2;
        private static IMapDocument m_pMapDoc;
        public static void SetMapControl(IMapControl2 mapControl)
        {
            m_pMapC2 = mapControl;
        }
        public static void SetMapDocument(IMapDocument mapDocument)
        {
            m_pMapDoc = mapDocument;
        }
        public static void LoadMxd(string mxdPath)
        {
            if (m_pMapC2.CheckMxFile(mxdPath))
            {
                m_pMapDoc.Open(mxdPath);
                m_pMapC2.Map = m_pMapDoc.Map[0];
            }
            else
            {
                MessageBox.Show(String.Format("地图文档【{0}】无法打开", mxdPath));
            }
        }

        public static void Pan()
        {
            m_pMapC2.MousePointer = esriControlsMousePointer.esriPointerPanning;
            m_pMapC2.Pan();
            m_pMapC2.MousePointer = esriControlsMousePointer.esriPointerArrow;
        }

        public static ILayer GetLayerByName(string layername)
        {
            IMap pMap = m_pMapC2.Map;
            for (int i = 0; i < pMap.LayerCount; i++)
            {
                if (pMap.get_Layer(i).Name == layername)
                    return pMap.get_Layer(i);
            }
            return null;
        }

    }
}
