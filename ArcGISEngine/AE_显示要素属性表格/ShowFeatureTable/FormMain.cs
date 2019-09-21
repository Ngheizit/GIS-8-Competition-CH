using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geodatabase;

namespace ShowFeatureTable
{
    public partial class FormMain : Form
    {
        #region 属性变量（类域）

        // 工作空间 "......\ShowFeatureTable\bin\Debug" 相对路径
        public string DEBUG_DIR = System.IO.Path.GetDirectoryName(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName);

        private IMapControl2 pMapC2;
        #endregion

        public FormMain()
        {
            InitializeComponent();
        }

        #region 自定义方法
        /// <summary>
        /// 根据名称添加矢量数据
        /// </summary>
        /// <param name="filename">当前工作目录下的.shp文件名，带后缀</param>
        /// <param name="index">添加到的图层位置索引，从0开始，默认为0</param>
        private void gis_AddShapefileByPath(string filename, int index = 0)
        {
            if (this.pMapC2 != null)
            {
                this.pMapC2.AddShapeFile(this.DEBUG_DIR, filename);
                pMapC2.MoveLayerTo(0, index);
            }
        }
        /// <summary>
        /// 添加表头字段
        /// </summary>
        /// <param name="name">表头字段名</param>
        /// <param name="width">表头字段显示长度，默认为100</param>
        private void gis_CreateTableHeader(string name, int width = 100)
        {
            ColumnHeader colhdr = new ColumnHeader();
            colhdr.Text = name;
            colhdr.Width = width;
            listView_table.Columns.Add(colhdr);
        }
        #endregion



        #region 窗体加载时
        private void Form1_Load(object sender, EventArgs e)
        {
            #region 属性初始化
            this.pMapC2 = axMapControl1.GetOcx() as IMapControl2;
            axTOCControl1.SetBuddyControl(axMapControl1);
            #region listView控件初始属性
            listView_table.Visible = false;
            listView_table.HeaderStyle = ColumnHeaderStyle.Clickable;
            listView_table.View = View.Details; 
            #endregion
            #endregion

            #region 初始图层加载
            string[] shapefiles = new string[] { "Continents.shp", "Lakes.shp", "Rivers.shp", "Cities.shp" };
            foreach (string shp in shapefiles)
            {
                this.gis_AddShapefileByPath(shp);
            } 
            #endregion

        } 
        #endregion

        #region MapControl控件鼠标点击事件
        private void axMapControl1_OnMouseDown(object sender, IMapControlEvents2_OnMouseDownEvent e)
        {
            #region 中键点击：地图移动
            if (e.button == 4)
            {
                this.pMapC2.MousePointer = esriControlsMousePointer.esriPointerPanning;
                this.pMapC2.Pan();
                this.pMapC2.MousePointer = esriControlsMousePointer.esriPointerArrow;
            }
            #endregion
        } 
        #endregion

        private void axTOCControl1_OnMouseDown(object sender, ITOCControlEvents_OnMouseDownEvent e)
        {
            IBasicMap map = new MapClass();
            ILayer layer = new FeatureLayerClass(); // Carto
            object other = new object();
            object index = new object();
            esriTOCControlItem item = new esriTOCControlItem();
            axTOCControl1.HitTest(e.x, e.y, ref item, ref map, ref layer, ref other, ref index);



            if (layer != null)
            {
                #region 可视化表格
                if (!listView_table.Visible)
                {
                    axMapControl1.Height -= listView_table.Height;
                    listView_table.Visible = true;
                } 
                #endregion

                #region 清空可能已有的表格字段和属性列
                listView_table.Items.Clear();
                listView_table.Columns.Clear(); 
                #endregion

                // 获取当前点击图层的信息
                IFeatureLayer pFeatureLayer = layer as IFeatureLayer;
                IFields pFields = pFeatureLayer.FeatureClass.Fields;

                // 循环添加表头信息
                for (int i = 0; i < pFields.FieldCount; i++)
                {
                    this.gis_CreateTableHeader(pFields.Field[i].Name);
                }

                // 循环添加要素属性信息
                IFeatureCursor pFeatureCursor = pFeatureLayer.FeatureClass.Search(null, false);
                IFeature pFeature = pFeatureCursor.NextFeature();
                while (pFeature != null)
                {
                    string[] fldVaue = new string[pFields.FieldCount];

                    // 顺换添加要素中的每个字段信息
                    for (int i = 0; i < pFields.FieldCount; i++)
                    {
                        string fldName = pFields.get_Field(i).Name;
                        if (fldName == pFeatureLayer.FeatureClass.ShapeFieldName)
                        {
                            // 去除 "esrigeometry"前缀
                            string type = Convert.ToString(pFeature.Shape.GeometryType).Substring(12);
                            fldVaue[i] = type;
                        }
                        else
                            fldVaue[i] = Convert.ToString(pFeature.get_Value(i)); // 属性信息
                    }

                    ListViewItem lstVwItem = new ListViewItem(fldVaue);
                    listView_table.Items.Add(lstVwItem);

                    pFeature = pFeatureCursor.NextFeature(); // 迭代
                }
            }
        }
    }
}
