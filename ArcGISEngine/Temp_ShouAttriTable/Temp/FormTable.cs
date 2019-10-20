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
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Geodatabase;

namespace Temp
{
    public partial class FormTable : Form
    {
        private ILayer m_pLayer;

        public FormTable(ILayer layer)
        {
            InitializeComponent();
            m_pLayer = layer;
        }

        private void FormTable_Load(object sender, EventArgs e)
        {
            listView_table.FullRowSelect = true;
            listView_table.HeaderStyle = ColumnHeaderStyle.Clickable;
            listView_table.View = View.Details;

            initTable();
        }

        private void initTable()
        { 
            // 获取图层字段信息
            IFeatureLayer pFeatureLayer = m_pLayer as IFeatureLayer;
            IFields pFields = pFeatureLayer.FeatureClass.Fields;

            // 添加字段信息到表头
            for (int i = 0; i < pFields.FieldCount; i++)
            {
                ColumnHeader colher = new ColumnHeader();
                colher.Text = pFields.Field[i].Name;
                colher.Width = 100;
                listView_table.Columns.Add(colher);
            }

            // 逐一添加要素属性信息
            IFeatureCursor pFeatureCursor = pFeatureLayer.FeatureClass.Search(null, false);
            IFeature pFeature = pFeatureCursor.NextFeature();
            while (pFeature != null)
            {
                string[] values = new string[pFields.FieldCount];
                // 循环添加要素中的每个字段信息
                for (int i = 0; i < pFields.FieldCount; i++)
                {
                    string fldName = pFields.get_Field(i).Name;
                    if (fldName == pFeatureLayer.FeatureClass.ShapeFieldName)
                    {
                        // 去除 "esrigeometry"前缀
                        string type = Convert.ToString(pFeature.Shape.GeometryType).Substring(12);
                        values[i] = type;
                    }
                    else
                        values[i] = Convert.ToString(pFeature.get_Value(i)); // 属性信息
                }

                ListViewItem lstVwItem = new ListViewItem(values);
                listView_table.Items.Add(lstVwItem);

                pFeature = pFeatureCursor.NextFeature(); // 迭代
            }
        }

    }
}
