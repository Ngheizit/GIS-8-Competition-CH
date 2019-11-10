using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Geodatabase;

namespace Temp_1110_4_3
{
    public partial class FormExportMap : Form
    {
        private ILayer m_pLayer;

        public FormExportMap(ILayer layer)
        {
            InitializeComponent();
            m_pLayer = layer;
            axPageLayoutControl_main.ActiveView.FocusMap.AddLayer(layer);
        }

        // 专题图符号化
        private void btn_symbology_Click(object sender, EventArgs e)
        {

        }

        #region // 分级符号化
        public static void Symbology_GraduatedColors(IFeatureLayer featureLayer, string fieldName, int numClasses, IMapControl2 mapControl, AxTOCControl tocControl)
        {
            // 获取渲染字段的值及其出现的频率
            ITable pTable = featureLayer as ITable;
            IBasicHistogram pBasicHistogram = new BasicTableHistogramClass()
            {
                Field = fieldName,
                Table = pTable
            };
            object dataFrequency, dataValue; // 频率和值
            pBasicHistogram.GetHistogram(out dataValue, out dataFrequency);
            // 数据分级
            IClassifyGEN pClassifyGEN = new EqualIntervalClass(); // 等间隔
            //IClassifyGEN pClassifyGEN = new GeometricalIntervalClass(); // 几何间隔
            //IClassifyGEN pClassifyGEN = new NaturalBreaksClass(); // 自然裂变
            //IClassifyGEN pClassifyGEN = new QuantileClass(); // 分位数
            //IClassifyGEN pClassifyGEN = new StandardDeviationClass(); // 标准偏差
            try { pClassifyGEN.Classify(dataValue, dataFrequency, numClasses); }
            catch { }
            double[] Classes = pClassifyGEN.ClassBreaks as double[];
            int ClassesCount = Classes.GetUpperBound(0);
            IClassBreaksRenderer pRenderer = new ClassBreaksRendererClass()
            {
                // 分类字段 分类数目 升序
                Field = fieldName,
                BreakCount = ClassesCount,
                SortClassesAscending = true
            };
            // 生成颜色色带
            IAlgorithmicColorRamp pColorRamp = new AlgorithmicColorRamp()
            {
                FromColor = GetRgbColor(255, 200, 200),
                ToColor = GetRgbColor(255, 0, 0),
                Size = ClassesCount
            };
            bool bOk = false;
            pColorRamp.CreateRamp(out bOk);
            IEnumColors pColors = pColorRamp.Colors;
            // 逐一设置填充符号及每一分级的分级断点
            for (int index = 0; index < ClassesCount; index++)
            {
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
                pRenderer.set_Symbol(index, pSymbol); // 每级的符号
                pRenderer.set_Break(index, Classes[index + 1]); // 每级的断点
            }
            (featureLayer as IGeoFeatureLayer).Renderer = pRenderer as IFeatureRenderer;
            mapControl.Refresh();
            tocControl.Update();
        }
        #endregion

    }
}
