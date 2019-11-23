using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Geometry;

namespace Test5
{
    class AeUtils
    {
        private static IMapControl2 m_pMapC2;
        private static IMapDocument m_pMapDoc;
        private static AxPageLayoutControl m_pPageLayoutCtl;
        public static void SetMapControl(IMapControl2 mapControl)
        {
            m_pMapC2 = mapControl;
        }
        public static void SetMapDocument(IMapDocument mapDocument)
        {
            m_pMapDoc = mapDocument;
        }
        public static void SetPageLayoutControl(AxPageLayoutControl pageLayoutControl)
        {
            m_pPageLayoutCtl = pageLayoutControl;
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

        public static void Save()
        {
            if (m_pMapDoc.get_IsReadOnly(m_pMapDoc.DocumentFilename))
            {
                m_pMapDoc.Save();
            }
            else
            {
                MessageBox.Show(String.Format("无法保存地图文档", m_pMapDoc.DocumentFilename));
            }
        }

        public static void Pan()
        {
            m_pMapC2.MousePointer = esriControlsMousePointer.esriPointerPanning;
            m_pMapC2.Pan();
            m_pMapC2.MousePointer = esriControlsMousePointer.esriPointerArrow;
        }

        private static IRgbColor CreateRgbColor(byte r, byte g, byte b, byte a = 255)
        {
            return new RgbColorClass() { 
                Red = r, Green = g, Blue = b, Transparency = a,
                UseWindowsDithering = true
            };
        }
        private static ISimpleFillSymbol CreateSimpleFillSymbol(IRgbColor fillColor, IRgbColor outColor, int outWidth)
        {
            return new SimpleFillSymbolClass() { 
                Color = fillColor,
                Outline = new SimpleLineSymbolClass(){
                    Color = outColor,
                    Width = outWidth
                }
            };
        }
        public static void DrawExtent(IEnvelope envelope, AxMapControl axMapControl_HawkEye)
        {
            IRgbColor fillColor = CreateRgbColor(0, 0, 0, 0);
            IRgbColor outColor = CreateRgbColor(255, 0, 0);
            IElement pElement = new RectangleElementClass() { 
                Geometry = envelope,
                Symbol = CreateSimpleFillSymbol(fillColor, outColor, 2)
            };
            IGraphicsContainer pGC = axMapControl_HawkEye.Map as IGraphicsContainer;
            pGC.DeleteAllElements();
            pGC.AddElement(pElement, 0);
            axMapControl_HawkEye.Refresh(esriViewDrawPhase.esriViewGraphics, null, null);
        }

        public static void AddLayoutToHawkEye(AxMapControl axMapControl_HawkEye)
        {
            IMap pMap = m_pMapC2.Map;
            for (int i = pMap.LayerCount - 1; i >= 0; i--)
            {
                axMapControl_HawkEye.AddLayer(pMap.get_Layer(i));
            }
        }


        public static void CopyMap()
        {
            IActiveView pActiveView = m_pPageLayoutCtl.ActiveView.FocusMap as IActiveView;
            pActiveView.ScreenDisplay
                .DisplayTransformation.VisibleBounds = m_pMapC2.Extent;
            pActiveView.Refresh();
            IObjectCopy pObjectCopy = new ObjectCopyClass();
            object copyMap = pObjectCopy.Copy(m_pMapC2.Map);
            object overwriteMap = pActiveView;
            pObjectCopy.Overwrite(copyMap, overwriteMap);
        }
    }
}
