using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using ESRI.ArcGIS.ADF.BaseClasses;
using ESRI.ArcGIS.Controls;

namespace AE_Complex.CommandTool
{
    class OpenMxd : BaseCommand
    {

        private IMapControl2 m_pMapC2;
        private IHookHelper m_pHookHelper;

        public OpenMxd()
        {
            base.m_category = "AE_Complex.CommandTool";
            base.m_caption = "Open";
            base.m_toolTip = "Open a mxd.";
        }


        #region Hook2pMap()
        private void Hook2pMap()
        {
            if (this.m_pHookHelper.Hook is ToolbarControl)
            {
                this.m_pMapC2 = (this.m_pHookHelper.Hook as ToolbarControl).Buddy as IMapControl2;
                return;
            }
            if (this.m_pHookHelper.Hook is IMapControl2)
            {
                this.m_pMapC2 = this.m_pHookHelper.Hook as IMapControl2;
                return;
            }
            if (this.m_pHookHelper.Hook is TOCControl)
            {
                this.m_pMapC2 = (this.m_pHookHelper.Hook as TOCControl).Buddy as IMapControl2;
                return;
            }
        }
        #endregion
        public override void OnCreate(object hook)
        {
            this.m_pHookHelper = new HookHelperClass();
            this.m_pHookHelper.Hook = hook;
            this.Hook2pMap();
        }



        public override void OnClick()
        {
            OpenFileDialog ofg = new OpenFileDialog();
            ofg.Title = "Chance a mxd witch will be opened";
            ofg.Filter = "Map Document(*.mxd)|*mxd";
            if (ofg.ShowDialog() == DialogResult.OK) 
            {
                string path = ofg.FileName;
                if (this.m_pMapC2.CheckMxFile(path))
                {
                    this.m_pMapC2.LoadMxFile(path);
                }
            }
        }

    }
}
