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
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.Geoprocessor;

namespace Temp_1024_5_1
{
    public partial class FormMain : Form
    {
        // 项目相对位置定位(...\bin\Debug\)
        string debugDir = System.IO.Path.GetDirectoryName(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName);

        private IMapControl2 m_pMapC2;
        private IMapDocument m_pMapDoc;
        private bool m_isIdentify = false; // 控制检测站点查询开关
        private bool m_isDraw = false; // 控制绘制多边形查询开关
        private bool m_isAddpoint = false; // 控制添加站点开关

        public FormMain()
        {
            InitializeComponent();
        }
        
        private void FormMain_Load(object sender, EventArgs e)
        {
            axTOCControl_main.SetBuddyControl(axMapControl_main);
            m_pMapC2 = axMapControl_main.Object as IMapControl2;
            m_pMapDoc = new MapDocumentClass();

            axMapControl_main.OnMouseDown += axMapControl_main_OnMouseDown;

            // 清空地图选择集
            btn_clearselect.Click += (object s, EventArgs ent) => {
                m_pMapC2.Map.ClearSelection();
                (m_pMapC2.Map as IGraphicsContainer).DeleteAllElements();
                m_pMapC2.Refresh();
                m_isIdentify = false;
                m_isDraw = false;
                m_isAddpoint = false;
            };


            // a. 打开地图文档功能（地图文档位于AirQuality文件夹下）
            LoadMxd();

            // b. 退出程序并保存地图文档功能
            this.FormClosing += (object s, FormClosingEventArgs ent) => {
                m_pMapDoc.Save();
            };

            // c. 在地图上点击，选择一个监测站点，并显示该监测站点的属性信息 第①步
            btn_Identify.Click += Button_Click;
            // e. 在地图上选择一个多边形，统计该多边形内部的监测站点内数量，并高亮显示
            btn_select.Click += Button_Click;
            // f. 将Excel中的数据匹配到监测站点
            btn_link.Click += Button_Click;
            // g. 在地图上显示北京各个区县的名称
            btn_anno.Click += Button_Click;
            // h. 为北京各个区县匹配一个符号
            btn_symbol.Click += Button_Click;
            // i. 导出北京区县图层为一个新的数据
            btn_outlyr.Click += Button_Click;
            // j. 在监测站点图层添加一个新站点
            btn_addpt.Click += Button_Click;

            // d. 在监测站点列表中选择一个监测站点后，在地图上高亮显示，缩放至该监测站点，并显示该监测站点的属性信息 第①步
            setListBox();
        }

        void Button_Click(object sender, EventArgs e)
        {
            #region 识别
            if ((Button)sender == btn_Identify)
            {
                m_isIdentify = !m_isIdentify;
                if (m_isIdentify)
                {
                    m_isDraw = false;
                    m_isAddpoint = false;
                    m_pMapC2.MousePointer = esriControlsMousePointer.esriPointerIdentify;
                }
                else
                    m_pMapC2.MousePointer = esriControlsMousePointer.esriPointerArrow;
                return;
            } 
            #endregion
            #region 选择
            if ((Button)sender == btn_select)
            {
                m_isDraw = !m_isDraw;
                if (m_isDraw)
                {
                    m_isIdentify = false;
                    m_isAddpoint = false;
                    m_pMapC2.MousePointer = esriControlsMousePointer.esriPointerCrosshair;
                }
                else
                    m_pMapC2.MousePointer = esriControlsMousePointer.esriPointerArrow;
                return;
            } 
            #endregion
            #region 链接
            if ((Button)sender == btn_link)
            {
                Geoprocessor gp = new Geoprocessor()
                {
                    OverwriteOutput = true
                };
                string table = debugDir + "\\AirQuality\\kqzlzk.dbf";
                ESRI.ArcGIS.ConversionTools.ExcelToTable pExcelToTavle = new ESRI.ArcGIS.ConversionTools.ExcelToTable()
                {
                    Input_Excel_File = debugDir + "\\AirQuality\\空气质量状况.xlsx",
                    Output_Table = table,
                    Sheet = "Sheet1"
                };
                gp.Execute(pExcelToTavle, null);

                IFeatureLayer pFeatureLayer = AeUtils.GetFeatureLayerByName(m_pMapC2.Map, "监测站");
                ESRI.ArcGIS.DataManagementTools.JoinField pJoinField = new ESRI.ArcGIS.DataManagementTools.JoinField()
                {
                    in_data = pFeatureLayer,
                    in_field = "Name",
                    join_table = table,
                    join_field = "NAME",
                    fields = "StationID,PM2_5,SO2,NO2"
                };
                gp.Execute(pJoinField, null);
            } 
            #endregion
            #region 注记
            if ((Button)sender == btn_anno)
            {
                IFeatureLayer pFeatureLayer = AeUtils.GetFeatureLayerByName(m_pMapC2.Map, "北京区县界");
                AeUtils.TextElementLabel(m_pMapC2, pFeatureLayer, "NAME");
            } 
            #endregion
            #region 符号化
            if ((Button)sender == btn_symbol)
            {
                IFeatureLayer pFeatureLayer = AeUtils.GetFeatureLayerByName(m_pMapC2.Map, "北京区县界");
                AeUtils.UniqueValueRenderer(pFeatureLayer, "NAME", m_pMapC2, axTOCControl_main);
            } 
            #endregion
            #region 保存图层
            if ((Button)sender == btn_outlyr)
            {
                IFeatureLayer pFeatureLayer = AeUtils.GetFeatureLayerByName(m_pMapC2.Map, "北京区县界");
                SaveFileDialog sfg = new SaveFileDialog()
                {
                    Title = "保存图层",
                    Filter = "图层文件 (*.lyr)|*.lyr"
                };
                if (sfg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    ILayerFile layerfile = new LayerFileClass();
                    layerfile.New(sfg.FileName);
                    layerfile.ReplaceContents(pFeatureLayer);
                    layerfile.Save();
                }
            } 
            #endregion
            if ((Button)sender == btn_addpt)
            {
                m_isAddpoint = !m_isAddpoint;
                if (m_isAddpoint)
                {
                    m_isDraw = false;
                    m_isIdentify = false;
                    m_pMapC2.MousePointer = esriControlsMousePointer.esriPointerCrosshair;
                }
                else
                    m_pMapC2.MousePointer = esriControlsMousePointer.esriPointerArrow;
            }
        }


        
        void axMapControl_main_OnMouseDown(object sender, IMapControlEvents2_OnMouseDownEvent e)
        {
            // c. 在地图上点击，选择一个监测站点，并显示该监测站点的属性信息 第②步
            #region ...
            if (e.button == 1 && m_isIdentify)
            {
                IEnvelope pClickEnv = new EnvelopeClass()
                {
                    XMin = e.mapX - 0.01,
                    YMin = e.mapY - 0.01,
                    XMax = e.mapX + 0.01,
                    YMax = e.mapY + 0.01
                };
                IFeatureLayer pFeatureLayer = AeUtils.GetFeatureLayerByName(m_pMapC2.Map, "监测站");
                IFeatureCursor pFeatureCursor = pFeatureLayer.FeatureClass.Search(null, false);
                IFeature pFeature = pFeatureCursor.NextFeature();
                while (pFeature != null)
                {
                    IEnvelope pTargetEnv = pFeature.Extent;
                    if (pTargetEnv.XMax < pClickEnv.XMax && pTargetEnv.XMin > pClickEnv.XMin &&
                        pTargetEnv.YMax < pClickEnv.YMax && pTargetEnv.YMin > pClickEnv.YMin)
                        break;
                    pFeature = pFeatureCursor.NextFeature();
                }
                m_pMapC2.Map.ClearSelection();
                m_pMapC2.Map.SelectFeature(pFeatureLayer, pFeature);
                m_pMapC2.Refresh();
                if (pFeature != null)
                    showInfo(pFeature);
            } 
            #endregion
            // d. 在监测站点列表中选择一个监测站点后，在地图上高亮显示，缩放至该监测站点，并显示该监测站点的属性信息 第②步
            #region ...
            if (e.button == 1 && m_isDraw)
            {
                IFeatureLayer pFeatureLayer = AeUtils.GetFeatureLayerByName(m_pMapC2.Map, "监测站");

                IGeometry pGeometry = m_pMapC2.TrackPolygon();
                IElement pElement = new PolygonElementClass()
                {
                    Geometry = pGeometry
                };
                IFillShapeElement pFillShapeElement = pElement as IFillShapeElement;
                pFillShapeElement.Symbol = new SimpleFillSymbolClass()
                {
                    Color = AeUtils.GetRgbColor(0, 0, 0, 0),
                    Outline = new SimpleLineSymbolClass()
                    {
                        Color = AeUtils.GetRgbColor(255, 0, 0),
                        Width = 1
                    }
                };
                IGraphicsContainer pGraphicsContainer = m_pMapC2.Map as IGraphicsContainer;
                pGraphicsContainer.DeleteAllElements();
                pGraphicsContainer.AddElement(pFillShapeElement as IElement, 0);
                m_pMapC2.Refresh(esriViewDrawPhase.esriViewGraphics);


                AeUtils.GetFeatureLayerByName(m_pMapC2.Map, "北京区县界").Selectable = false;

                m_pMapC2.Map.SelectByShape(pGeometry, null, false);
                m_pMapC2.Refresh(esriViewDrawPhase.esriViewGeoSelection);
                MessageBox.Show(String.Format("当前已选中{0}个监测站", m_pMapC2.Map.SelectionCount));
            } 
            #endregion
            // j. 在监测站点图层添加一个新站点
            #region ...
            if (e.button == 1 && m_isAddpoint)
            {
                IFeatureLayer pFeatureLayer = AeUtils.GetFeatureLayerByName(m_pMapC2.Map, "监测站");
                IPoint pPoint = new PointClass()
                {
                    X = e.mapX,
                    Y = e.mapY,
                    SpatialReference = m_pMapC2.SpatialReference
                };
                IFeatureClassWrite pWrite = pFeatureLayer.FeatureClass as IFeatureClassWrite;
                IWorkspaceEdit pEdit = (pFeatureLayer.FeatureClass as IDataset).Workspace as IWorkspaceEdit;
                pEdit.StartEditing(true);
                pEdit.StartEditOperation();
                IFeature pFeature = pFeatureLayer.FeatureClass.CreateFeature();
                pFeature.Shape = pPoint;
                FormSetName formSetName = new FormSetName();
                formSetName.ShowDialog();
                pFeature.set_Value(pFeatureLayer.FeatureClass.Fields.FindField("Name"), formSetName.name);
                pFeature.Store();
                pWrite.WriteFeature(pFeature);
                pEdit.StopEditOperation();
                pEdit.StopEditing(true);
                m_pMapC2.Refresh();
            } 
            #endregion
            if (e.button == 4)
            {
                m_pMapC2.MousePointer = esriControlsMousePointer.esriPointerPanning;
                m_pMapC2.Pan();
                m_pMapC2.MousePointer = esriControlsMousePointer.esriPointerPan;
            }

        }


        // 加载地图文档
        private void LoadMxd()
        {
            string filename = debugDir + "\\AirQuality\\空气质量状况.mxd";
            if(m_pMapC2.CheckMxFile(filename))
            {
                m_pMapDoc.Open(filename);
                m_pMapC2.Map = m_pMapDoc.Map[0];
            }

        }


        // 显示属性信息
        private void showInfo(IFeature feature)
        {
            rtbx_info.Text = "监测站点信息： \n";
            for (int i = 0; i < feature.Fields.FieldCount; i++)
            {
                string field = feature.Fields.get_Field(i).Name; // 字段
                string value = i != 1 ? feature.get_Value(i).ToString() :
                                        feature.Shape.GeometryType.ToString().Substring(12); // 属性
                rtbx_info.Text += String.Format("{0}: {1}\n", field, value);
            }
        }


        // 将检测站点导入列表，并设置选择触发事件
        private void setListBox()
        {
            IFeatureLayer pFeatureLayer = AeUtils.GetFeatureLayerByName(m_pMapC2.Map, "监测站");
            IFields pFields = pFeatureLayer.FeatureClass.Fields;
            IFeatureCursor pFeatureCursor = pFeatureLayer.FeatureClass.Search(null, false);
            IFeature pFeature = pFeatureCursor.NextFeature();
            while (pFeature != null)
            {
                string name = pFeature.get_Value(pFields.FindField("Name")).ToString();
                listBox_pts.Items.Add(name);
                pFeature = pFeatureCursor.NextFeature();
            }
            // 列表选择项变化触发事件
            listBox_pts.SelectedIndexChanged += (object sender, EventArgs e) => {
                m_pMapC2.Map.ClearSelection();
                string name = listBox_pts.SelectedItem.ToString();
                pFeatureCursor = pFeatureLayer.FeatureClass.Search(null, false);
                pFeature = pFeatureCursor.NextFeature();
                while (pFeature != null)
                {
                    string value = pFeature.get_Value(pFields.FindField("Name")).ToString();
                    if (value == name)
                        break;
                    pFeature = pFeatureCursor.NextFeature();
                }
                m_pMapC2.Map.SelectFeature(pFeatureLayer, pFeature);
                m_pMapC2.Refresh(esriViewDrawPhase.esriViewGeoSelection);
                IEnvelope pEnv = pFeature.Extent;
                pEnv.XMin -= 0.5; pEnv.YMin -= 0.5;
                pEnv.XMax += 0.5; pEnv.YMax += 0.5;
                m_pMapC2.Extent = pEnv;
                showInfo(pFeature);
            };
        }


    }
}
