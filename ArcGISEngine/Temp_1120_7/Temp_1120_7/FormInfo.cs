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
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Geometry;

namespace Temp_1120_7
{
    public partial class FormInfo : Form
    {
        private IFeatureLayer m_pFeatureLayer;

        public FormInfo(IFeatureLayer featureLayer)
        {
            InitializeComponent();
            this.m_pFeatureLayer = featureLayer;
        }

        private void FormInfo_Load(object sender, EventArgs e)
        {
            listView1.HeaderStyle = ColumnHeaderStyle.Clickable;
            listView1.View = View.Details;
            listView1.FullRowSelect = true;
        }
        private void AddHeader(string name)
        {
            ColumnHeader colhdr = new ColumnHeader() { 
                Text = name,
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
                for (int i = 0; i < len; i++)
                {
                    ListViewItem item = new ListViewItem() { 
                        f
                    };
                }
            }
        }
    }
}
