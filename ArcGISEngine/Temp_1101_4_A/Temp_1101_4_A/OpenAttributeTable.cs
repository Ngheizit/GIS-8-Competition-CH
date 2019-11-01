using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ESRI.ArcGIS.ADF.BaseClasses;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Carto;

namespace Temp_1101_4_A
{
    class OpenAttributeTable : BaseCommand
    {
        private IMapControl2 m_pMapC2;

        public OpenAttributeTable() { m_caption = "打开属性表"; }
        public override void OnCreate(object hook)
        {
            m_pMapC2 = hook as IMapControl2;
        }
        public override void OnClick()
        {
            new FormAttriTable((m_pMapC2 as IMapControl4).CustomProperty as ILayer).Show();
        }
    }
}
