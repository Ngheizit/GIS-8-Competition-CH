using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;

using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Geometry;

namespace Temp_1120_7
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
                m_pMapC2.Map = m_pMapDoc.ActiveView.FocusMap;
            }
            else
            {
                MessageBox.Show(String.Format("无法打开地图文档【{0}】", mxdPath));
            }
        }


        public static void Pan()
        {
            m_pMapC2.MousePointer = esriControlsMousePointer.esriPointerPanning;
            m_pMapC2.Pan();
            m_pMapC2.MousePointer = esriControlsMousePointer.esriPointerArrow;
        }

        public static IRgbColor CreateRgbColor(byte r, byte g, byte b, byte a = 255)
        {
            return new RgbColorClass() { 
                Red = r, Green = g, Blue = b, Transparency = a,
                UseWindowsDithering = true
            };
        }
        public static ISimpleFillSymbol CreateSimpleFillSymbol(IRgbColor fillColor, IRgbColor outlineColor, int outlineWidth)
        {
            return new SimpleFillSymbolClass() { 
                Color = fillColor,
                Outline = new SimpleLineSymbolClass(){
                    Color = outlineColor,
                    Width = outlineWidth
                }
            };
        }
        public static void DrawExtent(IEnvelope envelope, IMapControl2 mapControl)
        {
            IGraphicsContainer pGC = mapControl.Map as IGraphicsContainer;
            pGC.DeleteAllElements();

            IRgbColor fillColor = CreateRgbColor(0, 0, 0, 0);
            IRgbColor outlineColor = CreateRgbColor(255, 0, 0);
            IElement pElement = new RectangleElementClass() { 
                Geometry = envelope,
                Symbol = CreateSimpleFillSymbol(fillColor, outlineColor, 2)
            };
            pGC.AddElement(pElement, 0);
            mapControl.Refresh(esriViewDrawPhase.esriViewGraphics, null, null);
        }

        public static ILayer GetLayerByName(string layerName)
        {
            IMap pMap = m_pMapC2.Map;
            for (int i = 0; i < pMap.LayerCount; i++)
            {
                if (pMap.get_Layer(i).Name == layerName)
                {
                    return pMap.get_Layer(i);
                }
            }
            return null;
        }

    }
}
