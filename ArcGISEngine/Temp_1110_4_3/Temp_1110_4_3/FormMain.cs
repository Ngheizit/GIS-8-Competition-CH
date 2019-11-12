using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.DataSourcesGDB;
using ESRI.ArcGIS.Geoprocessor;

namespace Temp_1110_4_3
{
    public partial class FormMain : Form
    {
        private IMapControl2 m_pMapC2;
        private IMapDocument m_pMapDoc;
        private string DATADIR = Application.StartupPath + "\\Data\\";
        private Geoprocessor GP;

        public FormMain()
        {
            InitializeComponent();
            m_pMapC2 = axMapControl_main.GetOcx() as IMapControl2;
            m_pMapDoc = new MapDocumentClass();
            GP = new Geoprocessor() { 
                OverwriteOutput = true,
                AddOutputsToMap = true
            };
        }

        // 窗体加载完成后触发的事件
        private void FormMain_Load(object sender, EventArgs e)
        {
            axTOCControl_main.EnableLayerDragDrop = true; // 允许移动图层以改变图层显示顺序

            #region # 按钮操作流程控制
            SetButtonsEnableStatus(false, btn_AnalysisFillArr, btn_GetWater, btn_classify, btn_weightedOverlay, btn_ExportMap); 
            #endregion
        }

        // 控制图层显示状态
        private void SetLayersVisibleStatus(bool isVisible, params ILayer[] layers)
        {
            for (int i = 0; i < m_pMapC2.LayerCount; i++)
            {
                m_pMapC2.get_Layer(i).Visible = !isVisible;
            }
            foreach (ILayer lyr in layers)
            {
                lyr.Visible = isVisible;
            }
        }
        // 控制按钮可用性
        private void SetButtonsEnableStatus(bool isEnable, params Button[] buttons)
        {
            foreach (Button btn in buttons)
            {
                btn.Enabled = isEnable;
            }
        }
        // 打开文件对话框读取文件
        private string GetFilenameFromOFG(string title, string filter)
        {
            OpenFileDialog ofg = new OpenFileDialog() { 
                Title = title, Filter = filter
            };
            ofg.ShowDialog();
            return ofg.FileName;
        }
        // 加载Mxd地图文档
        private void LoadMxdFromFilename(string filename)
        {
            if (m_pMapC2.CheckMxFile(filename))
            {
                m_pMapDoc.Open(filename);
                m_pMapC2.Map = m_pMapDoc.get_Map(0);
            }
            else
            {
                MessageBox.Show(String.Format("加载【{0}】地图文档失败", filename));
            }
        }
        // 根据名称获取图层
        private ILayer GetLayerFromName(string layername)
        {
            IMap pMap = m_pMapC2.Map;
            for (int i = 0; i < pMap.LayerCount; i++)
            {
                if (pMap.get_Layer(i).Name == layername)
                    return pMap.get_Layer(i);
            }
            return null;
        }
        // 空间分析：按掩模提取
        private void ExtractByMask(object in_raster, object in_mask_data, object out_raster)
        {
            ESRI.ArcGIS.SpatialAnalystTools.ExtractByMask pTool = new ESRI.ArcGIS.SpatialAnalystTools.ExtractByMask() { 
                in_raster = in_raster,
                in_mask_data = in_mask_data,
                out_raster = out_raster
            };
            GP.Execute(pTool, null);
        }
        // 从地理数据库中加载栅格数据
        private void AddRasterFromGDB(string rastername)
        {
            FileGDBWorkspaceFactory pWorkspaceFactory = new FileGDBWorkspaceFactoryClass();
            IWorkspace pWorkspace = pWorkspaceFactory.OpenFromFile(DATADIR + "Database.gdb", 0);
            IRasterWorkspaceEx pRasterWorkspace = pWorkspace as IRasterWorkspaceEx;
            IRasterDataset pRasterDataset = pRasterWorkspace.OpenRasterDataset(rastername);
            IRasterLayer pRasterLayer = new RasterLayerClass();
            pRasterLayer.CreateFromDataset(pRasterDataset);
            m_pMapC2.AddLayer(pRasterLayer);
        }
        private void AddRasterFromGDB(params string[] rasternames)
        {
            FileGDBWorkspaceFactory pWorkspaceFactory = new FileGDBWorkspaceFactoryClass();
            IWorkspace pWorkspace = pWorkspaceFactory.OpenFromFile(DATADIR + "Database.gdb", 0);
            IRasterWorkspaceEx pRasterWorkspace = pWorkspace as IRasterWorkspaceEx;
            foreach (string name in rasternames)
            {
                IRasterDataset pRasterDataset = pRasterWorkspace.OpenRasterDataset(name);
                IRasterLayer pRasterLayer = new RasterLayerClass();
                pRasterLayer.CreateFromDataset(pRasterDataset);
                m_pMapC2.AddLayer(pRasterLayer); 
            }
        }
        // 空间分析：坡度
        private void Slope(object in_raster, object out_raster)
        {
            ESRI.ArcGIS.SpatialAnalystTools.Slope pTool = new ESRI.ArcGIS.SpatialAnalystTools.Slope() { 
                in_raster = in_raster,
                out_raster = out_raster
            };
            GP.Execute(pTool, null);
        }
        // 空间分析：坡向
        private void Aspect(object in_raster, object out_raster)
        {
            ESRI.ArcGIS.SpatialAnalystTools.Aspect pTool = new ESRI.ArcGIS.SpatialAnalystTools.Aspect() { 
                in_raster = in_raster,
                out_raster = out_raster
            };
            GP.Execute(pTool, null);
        }
        // 空间分析：填挖
        private void Fill(object in_raster, object out_raster)
        {
            ESRI.ArcGIS.SpatialAnalystTools.Fill pTool = new ESRI.ArcGIS.SpatialAnalystTools.Fill() { 
                in_surface_raster = in_raster,
                out_surface_raster = out_raster
            };
            GP.Execute(pTool, null);
        }
        // 空间分析：流向
        private void FlowDirection(object in_raster, object out_raster)
        {
            ESRI.ArcGIS.SpatialAnalystTools.FlowDirection pTool = new ESRI.ArcGIS.SpatialAnalystTools.FlowDirection() { 
                in_surface_raster = in_raster,
                out_flow_direction_raster = out_raster
            };
            GP.Execute(pTool, null);
        }
        // 空间分析：流量
        private void FlowAccumulation(object in_raster, object out_raster)
        {
            ESRI.ArcGIS.SpatialAnalystTools.FlowAccumulation pTool = new ESRI.ArcGIS.SpatialAnalystTools.FlowAccumulation() { 
                in_flow_direction_raster = in_raster,
                out_accumulation_raster = out_raster,
                data_type = "INTEGER"
            };
            GP.Execute(pTool, null);
        }
        // 空间分析：按属性提取
        private void ExtractByAttributes(object in_raster, object out_raster, object where_clause)
        {
            ESRI.ArcGIS.SpatialAnalystTools.ExtractByAttributes pTool = new ESRI.ArcGIS.SpatialAnalystTools.ExtractByAttributes() { 
                in_raster = in_raster,
                out_raster = out_raster,
                where_clause = where_clause
            };
            GP.Execute(pTool, null);
        }
        // 空间分析：欧式距离
        private void EuclideanDistance(object in_raster, object out_raster)
        {
            ESRI.ArcGIS.SpatialAnalystTools.EucDistance pTool = new ESRI.ArcGIS.SpatialAnalystTools.EucDistance() { 
                in_source_data = in_raster,
                out_distance_raster = out_raster
            };
            GP.SetEnvironmentValue("extent", DATADIR + "Database.gdb\\填挖研究区DEM");
            GP.Execute(pTool, null);
        }
        // 空间分析：重分类
        private void Reclassify(object in_raster, object reclass_field, object remap, object out_raster)
        {
            ESRI.ArcGIS.SpatialAnalystTools.Reclassify pTool = new ESRI.ArcGIS.SpatialAnalystTools.Reclassify() { 
                in_raster = in_raster,
                out_raster = out_raster,
                reclass_field = reclass_field,
                remap = remap
            };
            GP.Execute(pTool, null);
        }


        // 加载数据 - 事件入口
        private void btn_AddData_Click(object sender, EventArgs e)
        {
            #region # 按钮操作流程控制
            if (btn_AddData.BackColor == Color.White)
            {
                MessageBox.Show("数据已添加");
                return;
            } 
            #endregion

            string filename = "";
            if (MessageBox.Show("是否加载默认数据", "加载数据对话框", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                filename = DATADIR + "Map.mxd";
            }
            else
            {
                filename = GetFilenameFromOFG("打开地图文档", "地图文档 (*.mxd)|*.mxd");
            }
            LoadMxdFromFilename(filename);

            #region # 按钮操作流程控制
            SetButtonsEnableStatus(true, btn_AnalysisFillArr, btn_GetWater);
            btn_AddData.BackColor = Color.White; 
            #endregion
        }

        // 计算“植被覆盖”图层范围内的坡度和坡向 - 事件入口
        private void btn_AnalysisFillArr_Click(object sender, EventArgs e) 
        {
            #region # 按钮操作流程控制
            if (btn_AnalysisFillArr.BackColor == Color.White)
            {
                MessageBox.Show("坡度和坡向计算已完成");
                return;
            } 
            #endregion
            try
            {
                FromSchedule schedule = new FromSchedule(4);
                schedule.Show();

                ILayer pLayer_DEM = GetLayerFromName("DEM");
                ILayer pLayer_vagetable = GetLayerFromName("植被覆盖");

                schedule.GO("正在提取植被覆盖图层范围内的DEM数据"); // = 1
                ILayer pLayer_dem = GetLayerFromName("研究区DEM");
                if (pLayer_dem == null)
                {
                    string out_dem = DATADIR + "Database.gdb\\研究区DEM";
                    ExtractByMask(pLayer_DEM, pLayer_vagetable, out_dem);
                    AddRasterFromGDB("研究区DEM");
                    pLayer_dem = GetLayerFromName("研究区DEM");
                }

                schedule.GO("正在提取研究区DEM坡度"); // = 2
                pLayer_DEM = GetLayerFromName("研究区DEM");
                string out_slope = DATADIR + "Database.gdb\\坡度";
                Slope(pLayer_DEM, out_slope);

                schedule.GO("正在提取研究区DEM坡向"); // = 3
                string out_aspect = DATADIR + "Database.gdb\\坡向";
                Aspect(pLayer_DEM, out_aspect);


                schedule.GO("正在可视化结果"); // = 4
                AddRasterFromGDB("坡向", "坡度");
                SetLayersVisibleStatus(true, GetLayerFromName("坡向"), GetLayerFromName("坡度"));

                schedule.OK();

                #region # 按钮操作流程控制
                btn_AnalysisFillArr.BackColor = Color.White;
                if (btn_GetWater.BackColor == Color.White)
                {
                    SetButtonsEnableStatus(true, btn_classify);
                } 
                #endregion
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "错误信息");
            }
        }

        // 提取“植被覆盖”图层范围内的河流数据 - 事件入口
        private void btn_GetWater_Click(object sender, EventArgs e)
        {
            #region # 按钮操作流程控制
            if (btn_GetWater.BackColor == Color.White)
            {
                MessageBox.Show("河流数据提取已完成");
                return;
            } 
            #endregion

            try
            {
                FromSchedule schedule = new FromSchedule(6);
                schedule.Show();

                ILayer pLayer_dem = GetLayerFromName("研究区DEM");
                if (pLayer_dem == null)
                {
                    ILayer pLayer_DEM = GetLayerFromName("DEM");
                    ILayer pLayer_vagetable = GetLayerFromName("植被覆盖");
                    string out_dem = DATADIR + "Database.gdb\\研究区DEM";
                    ExtractByMask(pLayer_DEM, pLayer_vagetable, out_dem);
                    AddRasterFromGDB("研究区DEM");
                    pLayer_dem = GetLayerFromName("研究区DEM");
                }
                
                schedule.GO("正在填挖研究区DEM"); // = 1
                string out_filldem = DATADIR + "Database.gdb\\填挖研究区DEM";
                Fill(pLayer_dem, out_filldem);
                AddRasterFromGDB("填挖研究区DEM");

                schedule.GO("正在提取流向数据"); // = 2
                pLayer_dem.Visible = false;
                pLayer_dem = GetLayerFromName("填挖研究区DEM");
                string out_flowdir = DATADIR + "Database.gdb\\流向";
                FlowDirection(pLayer_dem, out_flowdir);
                AddRasterFromGDB("流向");

                schedule.GO("正在提取流量数据"); // = 3
                ILayer pLayer_flowdir = GetLayerFromName("流向");
                string out_flowacc = DATADIR + "Database.gdb\\流量";
                FlowAccumulation(pLayer_flowdir, out_flowacc);
                AddRasterFromGDB("流量");

                schedule.GO("正在提取河流数据"); // = 4
                ILayer pLayer_flowacc = GetLayerFromName("流量");
                string out_river = DATADIR + "Database.gdb\\河流";
                ExtractByAttributes(pLayer_flowacc, out_river, "Value >= 1000");
                AddRasterFromGDB("河流");

                schedule.GO("正在计算河流距离"); // = 5
                ILayer pLayer_river = GetLayerFromName("河流");
                string out_riverdis = DATADIR + "Database.gdb\\河流距离";
                EuclideanDistance(pLayer_river, out_riverdis);

                schedule.GO("河流距离数据淹没"); // = 6
                string out_riverDis = DATADIR + "Database.gdb\\河流缓冲";
                ExtractByMask(out_riverdis, pLayer_dem, out_riverDis);
                AddRasterFromGDB("河流缓冲");

                SetLayersVisibleStatus(true, GetLayerFromName("河流"), GetLayerFromName("河流缓冲"));
                schedule.OK();

                #region # 按钮操作流程控制
                btn_GetWater.BackColor = Color.White;
                if (btn_AnalysisFillArr.BackColor == Color.White)
                {
                    SetButtonsEnableStatus(true, btn_classify);
                } 
                #endregion
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "错误信息");
            }
        }

        // 生态因子敏感性等级分类 - 事件入口
        private void btn_classify_Click(object sender, EventArgs e)
        {
            #region # 按钮操作流程控制
            if (btn_classify.BackColor == Color.White)
            {
                MessageBox.Show("生态因子敏感性等级分类已完成");
                return;
            }
            #endregion

            try
            {
                FromSchedule schedule = new FromSchedule(7);
                schedule.Show();

                schedule.GO("正在获取图层数据"); // = 1
                ILayer pLayer_Slope = GetLayerFromName("坡度");           // 地形因子 - 坡度
                string reclass_slope = DATADIR + "Database.gdb\\reclassify_坡度";

                ILayer pLayer_DEM = GetLayerFromName("研究区DEM");        // 地形因子 - 高程
                string reclass_dem = DATADIR + "Database.gdb\\reclassify_研究区DEM";

                ILayer pLayer_Aspect = GetLayerFromName("坡向");          // 地形因子 - 坡向
                string reclass_aspect = DATADIR + "Database.gdb\\reclassify_坡向";

                ILayer pLayer_Vagetable = GetLayerFromName("植被覆盖");   // 植被因子 - 植被
                string reclass_vagetable = DATADIR + "Database.gdb\\reclassify_植被覆盖";

                ILayer pLayer_Water = GetLayerFromName("流量");           // 水体因子 - 水系
                string reclass_water = DATADIR + "Database.gdb\\reclassify_水系";

                ILayer pLayer_WaterBfr = GetLayerFromName("河流缓冲");    // 水体因子 - 河流缓冲
                string reclass_waterbfr = DATADIR + "Database.gdb\\reclassify_河流缓冲";

                schedule.GO("正在进行地形因子（坡度）敏感度等级分类"); // = 2
                Reclassify(pLayer_Slope, "Value", "0 10 1;10 25 2;25 45 3;45 60 4;60 75.30560302734375 5", reclass_slope);
                AddRasterFromGDB("reclassify_坡度");

                schedule.GO("正在进行地形因子（高程）敏感度等级分类"); // = 3
                Reclassify(pLayer_DEM, "Value", "999 1000 1;1000 1500 2;1500 2500 3;2500 3000 4;3000 2403 5", reclass_dem);
                AddRasterFromGDB("reclassify_研究区DEM");

                schedule.GO("正在进行地形因子（坡向）敏感度等级分类"); // = 4
                Reclassify(pLayer_Aspect, "Value", "-1 0 1;0 22.5 5;22.5 67.5 4;67.5 112.5 3;112.5 156.5 2;156.5 202.5 1;202.5 248.5 2;248.5 292.5 3;292.5 337.5 4;337.5 360 5", reclass_aspect);
                AddRasterFromGDB("reclassify_坡向");

                schedule.GO("正在进行地形因子（植被）敏感度等级分类"); // = 5
                Reclassify(pLayer_Vagetable, "Value", "-1 1;-1 0 4", reclass_vagetable);
                AddRasterFromGDB("reclassify_植被覆盖");

                schedule.GO("正在进行地形因子（水系）敏感度等级分类"); // = 6
                Reclassify(pLayer_Water, "Value", "0 1000 1;1000 122577 4", reclass_water);
                AddRasterFromGDB("reclassify_水系");

                schedule.GO("正在进行地形因子（河流缓冲）敏感度等级分类"); // = 7
                Reclassify(pLayer_WaterBfr, "Value", "0 25 5;25 50 4;50 100 3;100 150 2;150 1782.037842 1", reclass_waterbfr);
                AddRasterFromGDB("reclassify_河流缓冲");

                schedule.OK();

                #region # 按钮操作流程控制
                btn_classify.BackColor = Color.White;
                SetButtonsEnableStatus(true, btn_weightedOverlay);
                #endregion
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "错误信息");
            }


        }

        // 加权叠加生成生态因子敏感度等级分布 - 事件入口
        private void btn_weightedOverlay_Click(object sender, EventArgs e)
        {
            #region # 按钮操作流程控制
            if (btn_weightedOverlay.BackColor == Color.White)
            {
                MessageBox.Show("生态因子敏感性等级分类已完成");
                return;
            }
            #endregion

            FromSchedule schedule = new FromSchedule(1);
            schedule.Show();

            schedule.GO("正在执行加权叠加生成生态因子敏感度等级分布计算"); // = 1

            ILayer pLayer_reSlope = GetLayerFromName("reclassify_坡度");
            ILayer pLayer_reDEM = GetLayerFromName("reclassify_研究区DEM");
            ILayer pLayer_reAspect = GetLayerFromName("reclassify_坡向");
            ILayer pLayer_reVagetable = GetLayerFromName("reclassify_植被覆盖");
            ILayer pLayer_reWater = GetLayerFromName("reclassify_水系");
            ILayer pLayer_reWaterBfr = GetLayerFromName("reclassify_河流缓冲");


            ESRI.ArcGIS.SpatialAnalystTools.WeightedOverlay pTool = new ESRI.ArcGIS.SpatialAnalystTools.WeightedOverlay() { 
                in_weighted_overlay_table = @"('D:\gitproj\GIS-8-Competition-CH\ArcGISEngine\Temp_1110_4_3\Temp_1110_4_3\bin\Debug\Data\Database.gdb\reclassify_坡度' 20 'Value' (1 1; 2 2; 3 3; 4 4; 5 5;NODATA NODATA); 'D:\gitproj\GIS-8-Competition-CH\ArcGISEngine\Temp_1110_4_3\Temp_1110_4_3\bin\Debug\Data\Database.gdb\reclassify_研究区DEM' 10 'Value' (1 1; 2 2; 3 3;NODATA NODATA); 'D:\gitproj\GIS-8-Competition-CH\ArcGISEngine\Temp_1110_4_3\Temp_1110_4_3\bin\Debug\Data\Database.gdb\reclassify_坡向' 10 'Value' (1 1; 2 2; 3 3; 4 4; 5 5;NODATA NODATA); 'D:\gitproj\GIS-8-Competition-CH\ArcGISEngine\Temp_1110_4_3\Temp_1110_4_3\bin\Debug\Data\Database.gdb\reclassify_植被覆盖' 30 'Value' (1 1; 4 4;NODATA NODATA); 'D:\gitproj\GIS-8-Competition-CH\ArcGISEngine\Temp_1110_4_3\Temp_1110_4_3\bin\Debug\Data\Database.gdb\reclassify_水系' 20 'Value' (1 1; 4 4;NODATA NODATA); 'D:\gitproj\GIS-8-Competition-CH\ArcGISEngine\Temp_1110_4_3\Temp_1110_4_3\bin\Debug\Data\Database.gdb\reclassify_河流缓冲' 10 'Value' (1 1; 2 2; 3 3; 4 4; 5 5;NODATA NODATA));1 5 1",
                out_raster = DATADIR + "Database.gdb\\生态敏感度等级"
            };
            GP.Execute(pTool, null);
            AddRasterFromGDB("生态敏感度等级");

            SetLayersVisibleStatus(true, GetLayerFromName("生态敏感度等级"));

            schedule.OK();

            #region # 按钮操作流程控制
            btn_weightedOverlay.BackColor = Color.White;
            SetButtonsEnableStatus(true, btn_ExportMap);
            #endregion
        }

        // 绘制生态敏感性等级分布专题图 - 事件入口
        private void btn_ExportMap_Click(object sender, EventArgs e)
        {
            ILayer pLayer = GetLayerFromName("生态敏感度等级");
            new FormExportMap(pLayer).ShowDialog();
        }


        // 地图平移
        private void axMapControl_main_OnMouseDown(object sender, IMapControlEvents2_OnMouseDownEvent e)
        {
            if (e.button == 4)
            {
                m_pMapC2.MousePointer = esriControlsMousePointer.esriPointerPanning;
                m_pMapC2.Pan();
                m_pMapC2.MousePointer = esriControlsMousePointer.esriPointerArrow;
            }
        }









    }
}
