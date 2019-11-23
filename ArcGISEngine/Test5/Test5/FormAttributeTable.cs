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

namespace Test5
{
    public partial class FormAttributeTable : Form
    {
        private IFeatureLayer m_pFeatureLayer;

        public FormAttributeTable(IFeatureLayer featureLayer)
        {
            InitializeComponent();
            this.m_pFeatureLayer = featureLayer;
        }

        private void FormAttributeTable_Load(object sender, EventArgs e)
        {
            listView1.HeaderStyle = ColumnHeaderStyle.Clickable;
            listView1.View = View.Details;
            listView1.FullRowSelect = true;

            InitTable();
        }

        private void AddHeader(string name)
        {
            ColumnHeader colhdr = new ColumnHeader() { 
                Name = name,
                Width = 100
            };
            listView1.Columns.Add(colhdr);
        }

        private void InitTable()
        {
            IFields pFields = m_pFeatureLayer.FeatureClass.Fields;
            int len = pFields.FieldCount;
            for (int i = 0; i < len; i++)
            {
                AddHeader(pFields.get_Field(i).Name);
            }
            IFeatureCursor pFeatureCursor = m_pFeatureLayer.FeatureClass.Search(null, false);
            IFeature pFeature = pFeatureCursor.NextFeature();
            while (pFeature != null)
            {
                string[] values = new string[len];
                for (int i = 0; i < len; i++)
                {
                    if (i == 1)
                        values[1] = pFeature.Shape.GeometryType.ToString().Substring(12);
                    else
                        values[i] = pFeature.get_Value(i).ToString();
                }
                ListViewItem item = new ListViewItem(values);
                listView1.Items.Add(item);
                pFeature = pFeatureCursor.NextFeature();
            }
        }
    }
}
