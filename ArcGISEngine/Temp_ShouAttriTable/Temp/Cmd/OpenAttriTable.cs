using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ESRI.ArcGIS.ADF.BaseClasses;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Carto;

namespace Temp.Cmd
{
    class OpenAttriTable : BaseCommand
    {
        private IMapControl2 m_pMapC2;
        private IHookHelper m_pHookHelper;

        public OpenAttriTable() { base.m_caption = "查看属性表"; }

        public override void OnCreate(object hook)
        {
            m_pHookHelper = new HookHelperClass() { Hook = hook };
            if (m_pHookHelper.Hook is ToolbarControl)
                m_pMapC2 = (m_pHookHelper.Hook as ToolbarControl).Buddy as IMapControl2;
            else if (m_pHookHelper.Hook is MapControl)
                m_pMapC2 = m_pHookHelper.Hook as IMapControl2;
        }

        public override void OnClick()
        {
            if (m_pMapC2 != null)
            {
                ILayer pLayer = (m_pMapC2 as IMapControl4).CustomProperty as ILayer;
                new FormTable(pLayer).Show();
            }
        }
    }
}
