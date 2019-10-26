using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Display;

namespace Temp
{
    class AeUtilsLayout
    {
        // 添加图例
        public static void MakeLegend(AxPageLayoutControl pageLayoutControl, IEnvelope envelope)
        {
            IActiveView pActiveView = pageLayoutControl.ActiveView;

            UID pUID = new UID() { Value = "esriCarto.Legend" };
            IGraphicsContainer pGraphicsContainer = pageLayoutControl.PageLayout as IGraphicsContainer;
            IMapFrame pMapFrame = pGraphicsContainer.FindFrame(pActiveView.FocusMap) as IMapFrame;
            // 根据唯一标识符，创建与之对应的MapSurroundFrame
            IMapSurroundFrame pMapSurroundFrame = pMapFrame.CreateSurroundFrame(pUID, null);
            // 获取PageLayout中的图例元素
            IElement pDeleteElement = pageLayoutControl.FindElementByName("Legend");
            if (pDeleteElement != null)
                pGraphicsContainer.DeleteElement(pDeleteElement); // 如果已存在图例，删除已经存在的图例
            // 设置MapSurroundFrame背景
            ISymbolBackground pSymbolBackground = new SymbolBackgroundClass()
            {
                FillSymbol = new SimpleFillSymbolClass()
                {
                    Color = AeUtilsSymbology.GetRgbColor(240, 240, 240),
                    Outline = new SimpleLineSymbolClass()
                    {
                        Color = AeUtilsSymbology.GetRgbColor(0, 0, 0)
                    }
                }
            };
            pMapSurroundFrame.Background = pSymbolBackground;
            // 添加图例
            IElement pElement = pMapSurroundFrame as IElement;
            pElement.Geometry = envelope as IGeometry;
            IMapSurround pMapSurround = pMapSurroundFrame.MapSurround;
            ILegend pLegend = pMapSurround as ILegend;
            pLegend.ClearItems();
            pLegend.Title = "图例";
            for (int i = 0; i < pActiveView.FocusMap.LayerCount; i++)
            {
                ILegendItem pLegendItem = new HorizontalLegendItemClass() { 
                    Layer = pActiveView.FocusMap.get_Layer(i),
                    ShowDescriptions = false,
                    Columns = 1,
                    ShowHeading = true,
                    ShowLabels = true
                };
                pLegend.AddItem(pLegendItem);
            }
            pGraphicsContainer.AddElement(pElement, 0);
            pActiveView.PartialRefresh(esriViewDrawPhase.esriViewGraphics, null, null);
        }

        // 添加指北针
        public static void AddNorthArrow(AxPageLayoutControl pageLayoutControl, IEnvelope envelope)
        {
            IMap pMap = pageLayoutControl.ActiveView.FocusMap;
            IGraphicsContainer pGraphicsContariner = pageLayoutControl.PageLayout as IGraphicsContainer;
            IMapFrame pMapFrame = pGraphicsContariner.FindFrame(pMap) as IMapFrame;
            IMapSurroundFrame pMapSurroundFrame = new MapSurroundFrameClass() { 
               MapFrame = pMapFrame
            };
            INorthArrow pNorthArrow = new MarkerNorthArrowClass() { 
                //MarkerSymbol = new MarkerSym
            };
        }
    }
}
