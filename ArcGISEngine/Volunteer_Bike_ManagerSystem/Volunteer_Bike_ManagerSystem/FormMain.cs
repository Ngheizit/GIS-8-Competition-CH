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
using ESRI.ArcGIS.Geoprocessor;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Carto;

namespace Volunteer_Bike_ManagerSystem
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private string PATH_ENVIEMNT = System.IO.Path.GetDirectoryName(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName);
        private IMapControl2 m_pMapC2;
        private string str_shp_bikes;
        private string str_shp_road;
        private string str_shp_range;
        private string str_tab_volunteer;
        private string str_shp_net6x6;


        #region 窗体加载时触发的事件
        private void FormMain_Load(object sender, EventArgs e)
        {
            this.m_pMapC2 = axMapControl_Main.GetOcx() as IMapControl2;
            this.str_shp_bikes = this.PATH_ENVIEMNT + @"\Data\bikes.shp";
            this.str_shp_road = this.PATH_ENVIEMNT + @"\Data\road.shp";
            this.str_shp_range = this.PATH_ENVIEMNT + @"\Data\range.shp";
            this.str_tab_volunteer = this.PATH_ENVIEMNT + @"\Data\volunteer.xlsx";
            this.str_shp_net6x6 = this.PATH_ENVIEMNT + @"\Data\net6x6.shp";

            this.m_pMapC2.AddShapeFile(this.PATH_ENVIEMNT + @"\Data", "range.shp");
            this.m_pMapC2.AddShapeFile(this.PATH_ENVIEMNT + @"\Data", "road.shp");
            this.m_pMapC2.AddShapeFile(this.PATH_ENVIEMNT + @"\Data", "bikes.shp");
        } 
        #endregion

        #region MapControl 地图控件鼠标点击移动事件
        private void axMapControl_Main_OnMouseDown(object sender, IMapControlEvents2_OnMouseDownEvent e)
        {
            if (e.button == 4)
            {
                this.m_pMapC2.MousePointer = esriControlsMousePointer.esriPointerPanning;
                this.m_pMapC2.Pan();
                this.m_pMapC2.MousePointer = esriControlsMousePointer.esriPointerArrow;

            }
        }
        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            Geoprocessor gp = new Geoprocessor();
            gp.OverwriteOutput = true;
            gp.AddToolbox(this.PATH_ENVIEMNT + @"\Data\toolbox.tbx");
            IVariantArray parameters = new VarArrayClass();
            //MessageBox.Show(this.str_shp_road);
            //MessageBox.Show(this.str_tab_volunteer);
            //MessageBox.Show(this.str_shp_net6x6);
            //parameters.Add(6);
            //parameters.Add(6);
            parameters.Add("6");
            parameters.Add("6");
            parameters.Add(this.str_shp_road);
            //parameters.Add(this.m_pMapC2.Extent);
            parameters.Add(this.str_tab_volunteer);
            parameters.Add(this.str_shp_net6x6);
            gp.Execute("VModel", parameters, null);
            //this.m_pMapC2.AddShapeFile(this.PATH_ENVIEMNT + @"\Data", "net6x6.shp");

        }

    }
}
