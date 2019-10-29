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
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.Analyst3D;

namespace Temp_Scene
{
    public partial class FormMain : Form
    {
        private IMapControl2 m_pMapC2;
        private IMapDocument m_pMapDoc;
        private ISceneControl m_pSceneCtl;
        private string DEBUG_DIR = System.IO.Path.GetDirectoryName(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName) + "\\Data\\";
        private string DEM = "ASTGTM_N38E113H.img";
        private string Outlet = "oulet.shp";


        public FormMain()
        {
            InitializeComponent();
            m_pMapC2 = axMapControl_main.Object as IMapControl2;
            m_pMapDoc = new MapDocumentClass();
            m_pSceneCtl = axSceneControl_main.Object as ISceneControl;
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            InitMxd();
        }

        private void InitMxd()
        {
            string fileName = DEBUG_DIR + "Map.mxd";
            if (m_pMapC2.CheckMxFile(fileName))
            {
                
            }
        }



    }
}
