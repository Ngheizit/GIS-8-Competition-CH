using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using ESRI.ArcGIS.esriSystem;

namespace Temp_1101_4_A
{
    static class Program
    {
        //private static LicenseInitializer m_AOLicenseInitializer = new Temp_1101_4_A.LicenseInitializer();
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            //ESRI License Initializer generated code.
            //m_AOLicenseInitializer.InitializeApplication(
            //    new esriLicenseProductCode[] { esriLicenseProductCode.esriLicenseProductCodeEngine },
            //    new esriLicenseExtensionCode[] { esriLicenseExtensionCode.esriLicenseExtensionCode3DAnalyst, 
            //                                     esriLicenseExtensionCode.esriLicenseExtensionCodeNetwork, 
            //                                     esriLicenseExtensionCode.esriLicenseExtensionCodeSpatialAnalyst, 
            //                                     esriLicenseExtensionCode.esriLicenseExtensionCodeSchematics, 
            //                                     esriLicenseExtensionCode.esriLicenseExtensionCodeMLE, 
            //                                     esriLicenseExtensionCode.esriLicenseExtensionCodeDataInteroperability, 
            //                                     esriLicenseExtensionCode.esriLicenseExtensionCodeTracking });
            ESRI.ArcGIS.RuntimeManager.Bind(ESRI.ArcGIS.ProductCode.Desktop);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormMain());
            //ESRI License Initializer generated code.
            //Do not make any call to ArcObjects after ShutDownApplication()
            //m_AOLicenseInitializer.ShutdownApplication();
        }
    }
}
