using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ESRI.ArcGIS.ADF.BaseClasses;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Carto;

namespace Temp_1024_5_1
{
    class OpenAttriTable : BaseCommand
    {
        private IMapControl2 pMapC2;

        public OpenAttriTable() { this.m_caption = "打开属性表"; }

        public override void OnCreate(object hook)
        {
            pMapC2 = hook as IMapControl2;
        }

        public override void OnClick()
        {
            new FromAttributeTable((pMapC2 as IMapControl4).CustomProperty as ILayer).Show();
        }
    }
}
