using System;
using System.Drawing;
using System.Runtime.InteropServices;
using ESRI.ArcGIS.ADF.BaseClasses;
using ESRI.ArcGIS.ADF.CATIDs;
using ESRI.ArcGIS.Controls;
using System.Windows.Forms;

using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Carto;

namespace Temp_1119_6_B
{

    public sealed class AddNetStopsTool : BaseTool
    {
        private IHookHelper m_hookHelper = null;

        private IFeatureWorkspace pFWorkspace;
        private IFeatureClass inputFClass;
        private string path = System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase;

        public AddNetStopsTool()
        {
            base.m_caption = "ÃÌº”’æµ„";
        }

        public override void OnCreate(object hook)
        {
            try
            {
                m_hookHelper = new HookHelperClass();
                m_hookHelper.Hook = hook;
                if (m_hookHelper.ActiveView == null)
                {
                    m_hookHelper = null;
                }
            }
            catch
            {
                m_hookHelper = null;
            }

            if (m_hookHelper == null)
                base.m_enabled = false;
            else
                base.m_enabled = true;
        }


        public override void OnClick()
        {

        }

        public override void OnMouseDown(int Button, int Shift, int X, int Y)
        {

        }

        public override void OnMouseMove(int Button, int Shift, int X, int Y)
        {

        }

        public override void OnMouseUp(int Button, int Shift, int X, int Y)
        {

        }
    }
}
