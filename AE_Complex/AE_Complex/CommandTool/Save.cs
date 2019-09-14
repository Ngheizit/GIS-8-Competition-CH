using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using ESRI.ArcGIS.ADF.BaseClasses;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Carto;

namespace AE_Complex.CommandTool
{
    class Save : BaseCommand
    {
        private IMapControl2 m_pMapC2;
        private IHookHelper m_pHookHelper;

        public Save()
        {
            base.m_category = "AE_Complex.CommandTool";
            base.m_caption = "Save";
            base.m_toolTip = "Save a mxd.";
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
            IMapDocument pMapDocument = new MapDocumentClass();
            pMapDocument.New((this.m_pMapC2 as IMapControl3).DocumentFilename);
            pMapDocument.ReplaceContents(this.m_pMapC2.Map as IMxdContents);
            pMapDocument.Save(pMapDocument.UsesRelativePaths, true);
            pMapDocument.Close();
        }
    }

}
