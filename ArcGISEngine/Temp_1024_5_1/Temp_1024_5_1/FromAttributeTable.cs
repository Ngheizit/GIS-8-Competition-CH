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
using ESRI.ArcGIS.Geodatabase;

namespace Temp_1024_5_1
{
    public partial class FromAttributeTable : Form
    {
        private IFeatureLayer m_pFeatureLayer;

        public FromAttributeTable(ILayer layer)
        {
            InitializeComponent();
            m_pFeatureLayer = layer as IFeatureLayer;
        }

        private void FromAttributeTable_Load(object sender, EventArgs e)
        {
            listView_table.HeaderStyle = ColumnHeaderStyle.Clickable;
            listView_table.View = View.Details;
            listView_table.FullRowSelect = true;

            // 添加字段
            IFields pFields = m_pFeatureLayer.FeatureClass.Fields;
            for (int i = 0; i < pFields.FieldCount; i++)
            {
                AddHeader(pFields.get_Field(i).Name);
            }

            // 添加属性
            IFeatureCursor pFeatureCursor = m_pFeatureLayer.FeatureClass.Search(null, false);
            IFeature pFeature = pFeatureCursor.NextFeature();
            while (pFeature != null)
            {
                string[] values = new string[pFields.FieldCount];
                for (int i = 0; i < pFields.FieldCount; i++)
                {
                    if (i == 1)
                        values[i] = pFeature.Shape.GeometryType.ToString().Substring(12);
                    else
                        values[i] = pFeature.get_Value(i).ToString();
                }
                ListViewItem item = new ListViewItem(values);
                listView_table.Items.Add(item);
                pFeature = pFeatureCursor.NextFeature();
            }
        }

        private void AddHeader(string name)
        {
            ColumnHeader colhdr = new ColumnHeader() {
                Text = name, Width = 100
            };
            listView_table.Columns.Add(colhdr);
        }

    }
}
