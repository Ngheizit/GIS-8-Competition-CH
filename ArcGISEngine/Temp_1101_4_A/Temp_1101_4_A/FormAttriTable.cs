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

namespace Temp_1101_4_A
{
    public partial class FormAttriTable : Form
    {
        private IFeatureLayer m_pFeatureLayer;

        public FormAttriTable(ILayer layer)
        {
            InitializeComponent();
            m_pFeatureLayer = layer as IFeatureLayer;
        }

        private void FormAttriTable_Load(object sender, EventArgs e)
        {
            listView1.HeaderStyle = ColumnHeaderStyle.Clickable;
            listView1.View = View.Details;
            listView1.FullRowSelect = true;

            IFields pFields = m_pFeatureLayer.FeatureClass.Fields;
            for (int i = 0; i < pFields.FieldCount; i++)
            {
                ColumnHeader colhdr = new ColumnHeader() { 
                    Text = pFields.get_Field(i).Name,
                    Width = 100
                };
                listView1.Columns.Add(colhdr);
            }

            IFeatureCursor pFeatureCursor = m_pFeatureLayer.FeatureClass.Search(null, false);
            IFeature pFeature = pFeatureCursor.NextFeature();
            while (pFeature != null)
            {
                string[] values = new string[pFields.FieldCount];
                for (int i = 0; i < pFields.FieldCount; i++)
                {
                    if (i != 1)
                        values[i] = pFeature.get_Value(i).ToString();
                    else
                        values[i] = pFeature.Shape.GeometryType.ToString().Substring(12);
                }
                ListViewItem item = new ListViewItem(values);
                listView1.Items.Add(item);
                pFeature = pFeatureCursor.NextFeature();
            }
        }
    }
}
