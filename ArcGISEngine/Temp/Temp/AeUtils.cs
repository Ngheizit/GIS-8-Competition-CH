using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Carto;
using System.Windows.Forms;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.Display;

namespace Temp
{
    class AeUtils
    {

        // *************************************************************************

        /// <summary>
        /// 根据选择器选择加载地图文档 方法1
        /// </summary>
        /// <param name="mapControl">地图文档接口</param>
        public static void LoadMapDocument(IMapControl2 mapControl)
        {
            OpenFileDialog ofg = new OpenFileDialog();
            ofg.Title = "打开地图文档";
            ofg.Filter = "地图文档 (*.mxd)|*.mxd";
            if (ofg.ShowDialog() == DialogResult.OK)
            {
                string sFilePath = ofg.FileName;
                if (mapControl.CheckMxFile(sFilePath))
                    mapControl.LoadMxFile(sFilePath);
                else
                    MessageBox.Show(sFilePath + "不属于ArcGIS地图文档");
            }
        }

        /// <summary>
        /// 保存地图文档
        /// </summary>
        public static void SaveDocument(IMapDocument mapDocument)
        {
            if (mapDocument.get_IsReadOnly(mapDocument.DocumentFilename))
                MessageBox.Show("当前文档为只读文档，无法保存更改");
            else
            {
                mapDocument.Save(mapDocument.UsesRelativePaths);
                MessageBox.Show("已保存当前地图文档");
            }
        }

        // *************************************************************************

        /// <summary>
        /// 在地图上绘制形状
        /// </summary>
        /// <param name="geometry">需要绘制的形状</param>
        /// <param name="mapControl">绘制目标（地图控件接口）</param>
        public static void DrawMapShape(IGeometry geometry, IMapControl2 mapControl)
        {
            ISimpleLineSymbol pSymbol_line = getLineSymbol();
            ISimpleFillSymbol pSymbol_fill = getFillSymbol(pSymbol_line);
            object oSymbol;
            if(geometry.GeometryType == esriGeometryType.esriGeometryPolyline)
                oSymbol = pSymbol_line;
            else
                oSymbol = pSymbol_fill;
            mapControl.DrawShape(geometry, ref oSymbol);
        }

        /// <summary>
        /// 设置RGB颜色
        /// </summary>
        /// <param name="color">RGB颜色对象</param>
        /// <param name="r">红色度</param>
        /// <param name="g">绿色度</param>
        /// <param name="b">蓝色度</param>
        /// <param name="a">透明度</param>
        private static void setRGB(IRgbColor color, byte r, byte g, byte b, byte a = 255)
        { 
            color.Red = r; 
            color.Green = g; 
            color.Blue = b; 
            color.Transparency = a; 
        }

        /// <summary>
        /// 获取线对象颜色 红色
        /// </summary>
        /// <returns>返回RGB颜色对象</returns>
        private static IRgbColor getLineRGB()
        {
            IRgbColor pColor = new RgbColorClass();
            setRGB(pColor, 255, 0, 0);
            return pColor;
        }

        /// <summary>
        /// 获取填充对象颜色 透明色
        /// </summary>
        /// <returns>返回RGB颜色对象</returns>
        private static IRgbColor getFillRGB()
        {
            IRgbColor pColor = new RgbColorClass();
            setRGB(pColor, 0, 0, 0, 0);
            return pColor;
        }

        /// <summary>
        /// 获取简单线符号样式 红色
        /// </summary>
        /// <returns>返回简单线符号样式对象</returns>
        private static ISimpleLineSymbol getLineSymbol()
        { 
            return new SimpleLineSymbolClass() 
            { 
                Color = getLineRGB(), 
                Width = 2 
            }; 
        }

        /// <summary>
        /// 获取简单填充符号样式 内部填充透明
        /// </summary>
        /// <param name="lineSymbol">边框样式</param>
        /// <returns>返回简单填充符号样式对象</returns>
        private static ISimpleFillSymbol getFillSymbol(ISimpleLineSymbol lineSymbol = null)
        { 
            return new SimpleFillSymbolClass() 
            { 
                Color = getFillRGB(), 
                Outline = lineSymbol 
            }; 
        }

        /// <summary>
        /// 在地图上绘制图形（单一）
        /// </summary>
        /// <param name="envelope">图形外包络</param>
        /// <param name="mapControl">绘制目标（地图控件对象）</param>
        public static void DrawMapShape(IEnvelope envelope, IMapControl2 mapControl)
        {
            IElement pElement = new RectangleElementClass();
            pElement.Geometry = envelope;
            IFillShapeElement pFillShapeElement = pElement as IFillShapeElement;
            pFillShapeElement.Symbol = getFillSymbol(getLineSymbol());
            IGraphicsContainer pGC = mapControl.Map as IGraphicsContainer;
            pGC.DeleteAllElements();
            pGC.AddElement(pFillShapeElement as IElement, 0);
            mapControl.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGraphics, null, null);
        }

        // *************************************************************************
    }
}
