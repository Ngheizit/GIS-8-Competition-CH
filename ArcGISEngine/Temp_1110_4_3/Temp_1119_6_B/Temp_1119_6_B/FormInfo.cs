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

namespace Temp_1119_6_B
{
    public partial class FormInfo : Form
    {
        private IFeatureLayer m_pFeatureLayer;
        private int _fid;

        public FormInfo(IFeatureLayer featureLayer, int fid)
        {
            InitializeComponent();
            this.m_pFeatureLayer = featureLayer;
            this._fid = fid;
        }

        private void FormInfo_Load(object sender, EventArgs e)
        {
            listView1.HeaderStyle = ColumnHeaderStyle.Clickable;
            listView1.View = View.Details;
            listView1.FullRowSelect = true;

            ShowInfo();

        }

        private void ShowInfo()
        {

            IFields pFields = m_pFeatureLayer.FeatureClass.Fields;
            int len = pFields.FieldCount;

            for (int i = 0; i < len; i++)
            {
                string name = pFields.get_Field(i).Name;
                AddHeader(name);
                
            }

            string[] values = new string[len];
            IFeatureCursor pFeatureCursor = m_pFeatureLayer.FeatureClass.Search(null, false);
            IFeature pFeature = pFeatureCursor.NextFeature();
            while (pFeature != null)
            {
                int fid = (int)pFeature.get_Value(0);
                if (fid == _fid)
                {
                    for (int i = 0; i < len; i++)
                    {
                        if (i == 1)
                            values[1] = pFeature.Shape.GeometryType.ToString().Substring(12);
                        else
                            values[i] = pFeature.get_Value(i).ToString();
                    }
                    ShowPicture(pFeature);
                    break;
                }
                pFeature = pFeatureCursor.NextFeature();

            }
            ListViewItem item = new ListViewItem(values);
            listView1.Items.Add(item);


        }

        private void ShowPicture(IFeature feature)
        {
            string picName = feature.get_Value(feature.Fields.FindField("NAME")).ToString();
            string picPath = Application.StartupPath + String.Format(@"\data\photo\{0}.jpg", picName);
            pictureBox1.ImageLocation = picPath;
        }

        private void AddHeader(string name)
        {
            ColumnHeader colhdr = new ColumnHeader() { 
                Text = name,
                Width = 100
            };
            listView1.Columns.Add(colhdr);
        }

    }
}
