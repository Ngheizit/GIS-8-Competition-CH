   Form1.cs
 public partial class Form1 : Form
    {
        private int operatiom = 0;
        private int selectionWay = 0;
        private ILayer currentLayer;
        AttributeTable At = null;
        bool edit = false;
        bool netWork = false;
        string path = System.IO.Path.GetFullPath("../../");
        public Form1()
        {
            InitializeComponent();
        }

        private void 打开ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ICommand pCOmmand = new ControlsOpenDocCommandClass();
            pCOmmand.OnCreate(axMapControl1.Object);
            pCOmmand.OnClick();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            axToolbarControl2.Hide();
            axToolbarControl3.Hide();
            axTOCControl1.SetBuddyControl(axMapControl1);
        }

        private void 添加数据DToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ICommand pCOmmand = new ControlsAddDataCommandClass();
            pCOmmand.OnCreate(axMapControl1.Object);
            pCOmmand.OnClick();
        }

        private void 另存为AToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ICommand pCOmmand = new ControlsSaveAsDocCommandClass();
            pCOmmand.OnCreate(axMapControl1.Object);
            pCOmmand.OnClick();
        }

        private void 退出EToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void 平移PToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ICommand pCOmmand = new ControlsMapPanToolClass();
            pCOmmand.OnCreate(axMapControl1.Object);
            pCOmmand.OnClick();
            axMapControl1.CurrentTool = pCOmmand as ITool;
        }

        private void 放大OToolStripMenuItem_Click(object sender, EventArgs e)
        {
            operatiom = 0;
            ICommand pCOmmand = new ControlsMapZoomInToolClass();
            pCOmmand.OnCreate(axMapControl1.Object);
            pCOmmand.OnClick();
            axMapControl1.CurrentTool = pCOmmand as ITool;
        }

        private void 缩小IToolStripMenuItem_Click(object sender, EventArgs e)
        {
            operatiom = 0;
            ICommand pCOmmand = new ControlsMapZoomOutToolClass();
            pCOmmand.OnCreate(axMapControl1.Object);
            pCOmmand.OnClick();
            axMapControl1.CurrentTool = pCOmmand as ITool;
        }

        private void 全图EToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ICommand pCOmmand = new ControlsMapFullExtentCommandClass();
            pCOmmand.OnCreate(axMapControl1.Object);
            pCOmmand.OnClick();
        }

        private void 缩放到所选要素TToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ICommand pCOmmand = new ControlsZoomToSelectedCommandClass();
            pCOmmand.OnCreate(axMapControl1.Object);
            pCOmmand.OnClick();
        }

        private void 清除选择CToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ICommand pCOmmand = new ControlsClearSelectionCommandClass();
            pCOmmand.OnCreate(axMapControl1.Object);
            pCOmmand.OnClick();
        }

        private void 按属性选择AToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new AttributeQuery(axMapControl1).ShowDialog();
        }

        private void axMapControl1_OnMapReplaced(object sender, ESRI.ArcGIS.Controls.IMapControlEvents2_OnMapReplacedEvent e)
        {
            for (int i = axMapControl1.Map.LayerCount; i > 0; i--)
            {
                axMapControl2.Map.AddLayer(axMapControl1.Map.get_Layer(i-1));
            }
            axMapControl2.Extent = axMapControl1.FullExtent;
        }

        private void axMapControl2_OnMouseDown(object sender, ESRI.ArcGIS.Controls.IMapControlEvents2_OnMouseDownEvent e)
        {
            IEnvelope pEnvelope=null;
            if (e.button == 1)
            {
                pEnvelope = axMapControl1.Extent;
                IPoint pPt = new PointClass();
                pPt.X = e.mapX;
                pPt.Y = e.mapY;
            }
            else
            {
                pEnvelope = axMapControl2.TrackRectangle();
            }
            axMapControl1.Extent = pEnvelope;
            axMapControl1.Refresh();
        }

        private void axMapControl2_OnMouseMove(object sender, ESRI.ArcGIS.Controls.IMapControlEvents2_OnMouseMoveEvent e)
        {
            if (e.button == 1)
            {
                IPoint pPt=new PointClass();
                pPt.X=e.mapX;
                pPt.Y=e.mapY;
                axMapControl1.CenterAt(pPt);
                axMapControl1.Refresh();
            }
        }

        private void axMapControl1_OnExtentUpdated(object sender, ESRI.ArcGIS.Controls.IMapControlEvents2_OnExtentUpdatedEvent e)
        {
            IGraphicsContainer pGc = axMapControl2.Map as IGraphicsContainer;
            pGc.DeleteAllElements();

            IElement pEle = new RectangleElementClass();
            IEnvelope pEnvelope = e.newEnvelope as IEnvelope;
            pEle.Geometry = pEnvelope;

            ILineSymbol pLIneSymbol = new SimpleLineSymbolClass();
            pLIneSymbol.Width = 2;
            pLIneSymbol.Color = GetColor(255, 0, 0);

            IFillSymbol pFillSymbpl = new SimpleFillSymbolClass();
            pFillSymbpl.Outline = pLIneSymbol;
            pFillSymbpl.Color = GetColor(255, 0, 0, 0);

            IFillShapeElement pFillShape = pEle as IFillShapeElement;
            pFillShape.Symbol = pFillSymbpl;

            pGc.AddElement(pEle, 0);
            axMapControl2.Refresh();
        }
        private IRgbColor GetColor(int r, int g, int b, byte t = 255)
        {
            IRgbColor pColor = new RgbColorClass();
            pColor.Red = r;
            pColor.Green = g; 
            pColor.Blue = b;
            pColor.Transparency = t;
            return pColor;

        }

        private void axTOCControl1_OnMouseDown(object sender, ESRI.ArcGIS.Controls.ITOCControlEvents_OnMouseDownEvent e)
        {
            if (e.button == 2)
            {
                esriTOCControlItem item = esriTOCControlItem.esriTOCControlItemNone;
                IBasicMap map = null;
                ILayer pLayer = null;
                object unk = null;
                object data = null;
                axTOCControl1.HitTest(e.x, e.y, ref item, ref map, ref pLayer, ref unk, ref data);
                if (item == esriTOCControlItem.esriTOCControlItemLayer)
                {
                    if (pLayer is IFeatureLayer)
                    {
                        打开属性表ToolStripMenuItem.Enabled = true;
                    }
                    else
                    {
                        打开属性表ToolStripMenuItem.Enabled = false;
                    }
                    System.Drawing.Point pPt = new System.Drawing.Point();
                    pPt.X = e.x;
                    pPt.Y = e.y;
                    contextMenuStrip1.Show(axTOCControl1, pPt);
                    currentLayer = pLayer;
                }
            }
        }

        private void 打开属性表ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (At == null || At.IsDisposed)
            {
                At = new AttributeTable();
            }
            At.ShowData(axMapControl1, currentLayer as IFeatureLayer);
            At.Show();
        }

        private void 缩放到所选图层ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IEnvelope pEnvelope = axMapControl1.ActiveView.Extent;
            axMapControl1.Extent = pEnvelope;
            axMapControl1.Refresh();
        }

        private void 移除图层ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            axMapControl1.Map.DeleteLayer(currentLayer);

        }

        private void 移动上一个图层ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int index = GetLayerIndex(currentLayer);
            if (index > 0)
            {
                axMapControl1.Map.MoveLayer(currentLayer, index - 1);
            }
        }
        private int GetLayerIndex(ILayer pLayer)
        {
            for (int i = 0; i < axMapControl1.Map.LayerCount; i++)
            {
                if (axMapControl1.Map.get_Layer(i) == pLayer)
                {
                    return i;
                }
            }
            return 0;
        }

        private void 移动到下一个图层ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int index = GetLayerIndex(currentLayer);
            if (index < axMapControl1.Map.LayerCount - 1)
            {
                axMapControl1.Map.MoveLayer(currentLayer, index + 1);
            }
        }

        private void 移动到顶部ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            axMapControl1.Map.MoveLayer(currentLayer, 0);
        }

        private void 移动到底部ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            axMapControl1.Map.MoveLayer(currentLayer, axMapControl1.Map.LayerCount - 1);
        }

        private void axMapControl1_OnMouseMove(object sender, ESRI.ArcGIS.Controls.IMapControlEvents2_OnMouseMoveEvent e)
        {
            toolStripStatusLabel1.Text = e.mapX + "    " + e.mapY + "米";
        }

        private void axMapControl1_OnSelectionChanged(object sender, EventArgs e)
        {
            if (At != null && !At.IsDisposed && At.IsAllData == false)
            {
                At.ShowData(axMapControl1, currentLayer as IFeatureLayer);
            }
        }

        private void 统计SToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Statics(axMapControl1).ShowDialog();
        }

        private void 点选PToolStripMenuItem_Click(object sender, EventArgs e)
        {
            operatiom = 1;
            selectionWay = 1;
        }

        private void 线选LToolStripMenuItem_Click(object sender, EventArgs e)
        {
            operatiom = 1;
            selectionWay = 2;
        }

        private void 圆选CToolStripMenuItem_Click(object sender, EventArgs e)
        {
            operatiom = 1; 
            selectionWay = 3;
        }

        private void 面选gToolStripMenuItem_Click(object sender, EventArgs e)
        {
            operatiom = 1;
            selectionWay = 4;
        }

        private void 框选RToolStripMenuItem_Click(object sender, EventArgs e)
        {
            operatiom = 1;
            selectionWay = 5;
        }

        private void axMapControl1_OnMouseDown(object sender, ESRI.ArcGIS.Controls.IMapControlEvents2_OnMouseDownEvent e)
        {
            if (operatiom == 1)
            {
                axMapControl1.CurrentTool = null;
                ISelectionEnvironment pEnv = new SelectionEnvironmentClass();
                IGeometry pGeometry = null;
                switch (selectionWay)
                {
                    case 1:
                        pEnv.PointSelectionMethod = esriSpatialRelEnum.esriSpatialRelContains;
                        IPoint pPt = new PointClass();
                        pPt.X = e.mapX;
                        pPt.Y = e.mapY;
                        pGeometry = pPt;
                        break;
                    case 2:
                        pEnv.LinearSelectionMethod = esriSpatialRelEnum.esriSpatialRelCrosses;
                        pGeometry=axMapControl1.TrackLine();
                        break;
                    case 3:
                        pEnv.AreaSelectionMethod=esriSpatialRelEnum.esriSpatialRelIntersects;
                        pGeometry = axMapControl1.TrackCircle();
                        break;
                    case 4:
                        pEnv.AreaSelectionMethod = esriSpatialRelEnum.esriSpatialRelIntersects;
                        pGeometry = axMapControl1.TrackPolygon();
                        break;
                    case 5:
                        pEnv.AreaSelectionMethod = esriSpatialRelEnum.esriSpatialRelIntersects;
                        pGeometry = axMapControl1.TrackRectangle();
                        break;
                }
                axMapControl1.Map.SelectByShape(pGeometry, pEnv, false);
                axMapControl1.Refresh();
            }
        }

        private void 编辑器EToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (edit == false)
            {
                axToolbarControl2.Show();
                edit = true;
            }
            else
            {
                axToolbarControl2.Hide();
                edit = false;
            }
        }

        private void 网络分析NToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (netWork == false)
            {
                axToolbarControl3.Show();
                netWork = true;
            }
            else
            {
                axToolbarControl3.Hide();
                netWork = false;
            }
        }

        private void 帮助HToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(path + "/1.docx");
        }
        private void AddFeatureLayer(string str)
        {
            IWorkspaceFactory pWf = new FileGDBWorkspaceFactoryClass();
            IFeatureWorkspace pFw = pWf.OpenFromFile(path,0) as IFeatureWorkspace;
            IFeatureClass pFeatureClass = pFw.OpenFeatureClass(str);
            IFeatureDataset pFeatureDataset = pFeatureClass as IFeatureDataset;
            IFeatureLayer pFeatureLayer = new FeatureLayerClass();
            pFeatureLayer.FeatureClass = pFeatureClass;
            pFeatureLayer.Name = pFeatureDataset.Name;
            axMapControl1.Map.AddLayer(pFeatureLayer);
            axMapControl2.Map.AddLayer(pFeatureLayer);
        }
        private void AddRasterLayer(string str)
        {
            IWorkspaceFactory pWf = new FileGDBWorkspaceFactoryClass();
            IRasterWorkspaceEx pRw = pWf.OpenFromFile(path, 0) as IRasterWorkspaceEx;
            IRasterDataset pRasterDataset = pRw.OpenRasterDataset(str);
            IRasterLayer pRasterLayer = new RasterLayerClass();
            pRasterLayer.CreateFromDataset(pRasterDataset);
            axMapControl1.Map.AddLayer(pRasterLayer);
            
        }
    }













AttributeQuery.cs

public partial class AttributeQuery : Form
    {
        IFeatureLayer pFeatureLayer;
        AxMapControl mapControl;
        public AttributeQuery(AxMapControl mapControl)
        {
            InitializeComponent();
            this.mapControl = mapControl;
        }

        private void AttributeQuery_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < mapControl.Map.LayerCount; i++)
            {
                ILayer pLayer = mapControl.Map.get_Layer(i);
                if (pLayer is IFeatureLayer)
                {
                    comboBox1.Items.Add(pLayer.Name);
                }
            }
            comboBox1.SelectedIndex = 1;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = 0;
            for (int i = 0; i < mapControl.LayerCount; i++)
            {
                if (mapControl.Map.get_Layer(i).Name == comboBox1.SelectedItem.ToString())
                {
                    index = i;
                }
            }
            pFeatureLayer=mapControl.Map.get_Layer(index) as IFeatureLayer;
            IFields pFields=pFeatureLayer.FeatureClass.Fields;
            for (int i = 0; i < pFields.FieldCount; i++)
            {
                IField pField=pFields.get_Field(i);
                int varType=pField.VarType;
                if (varType > 1 && varType < 6)
                {
                    comboBox2.Items.Add(pField.Name);
                }
            }
            comboBox2.SelectedIndex = 1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            IQueryFilter pQueryFilter = new QueryFilterClass();
            IFeatureCursor pCursor=null;;
            try
            {
                pCursor = pFeatureLayer.Search(pQueryFilter, true);
            }
            catch (Exception)
            {
                MessageBox.Show("输入的SQL语句有误！！！");
            }
            IFeature pFeature = pCursor.NextFeature();
            while (pFeature != null)
            {
                mapControl.Map.SelectFeature(pFeatureLayer, pFeature);
                pFeature = pCursor.NextFeature();
            }
            mapControl.Refresh();
            this.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }




AttributeTable.cs

    public partial class AttributeTable : Form
    {
        AxMapControl mapControl;
        IFeatureLayer pFeatureLayer;
        private bool isAllData = true;
        public bool IsAllData 
        {
            get { return isAllData; }
        }
        public AttributeTable()
        {
            InitializeComponent();
        }

        private void AttributeTable_Load(object sender, EventArgs e)
        {
            button1.Enabled = false;
            button2.Enabled = true;
            ShowData(mapControl, pFeatureLayer);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            isAllData = true;
            button1.Enabled = false;
            button2.Enabled = true;
            ShowData(mapControl, pFeatureLayer);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            isAllData = false;
            button1.Enabled = true;
            button2.Enabled = false;
            ShowData(mapControl, pFeatureLayer);
        }
        public void ShowData(AxMapControl mapControl, IFeatureLayer pFeatureLayer)
        {
            this.mapControl = mapControl;
            this.pFeatureLayer = pFeatureLayer;
            IFields pFields = pFeatureLayer.FeatureClass.Fields;
            DataTable pDataTable = AddHeader(pFields);
            if (isAllData == true)
            {
                IFeatureCursor pCursor = pFeatureLayer.Search(null, true);
                IFeature pFeature = pCursor.NextFeature();
                while (pFeature != null)
                {
                    DataRow dr = pDataTable.NewRow();
                    for (int i = 0; i < pFields.FieldCount; i++)
                    {
                        if (pFields.get_Field(i).Name == "Shape")
                        {
                            dr[i] = GetLayerType(pFeature);
                        }
                        else
                        {
                            dr[i] = pFeature.get_Value(i);
                        }
                    }
                    pDataTable.Rows.Add(dr);
                    pFeature = pCursor.NextFeature();
                }
            }
            else
            {
                ISelection pSelection = mapControl.Map.FeatureSelection;
                IEnumFeatureSetup pEnumSetup = pSelection as IEnumFeatureSetup;
                pEnumSetup.AllFields = true;
                IEnumFeature pEnumFeature = pEnumSetup as IEnumFeature;
                pEnumFeature.Reset();
                IFeature pFeature = pEnumFeature.Next();
                while (pFeature != null)
                {
                    if (pFeature.Class == pFeatureLayer.FeatureClass)
                    {
                        DataRow dr = pDataTable.NewRow();
                        for (int i = 0; i < pFields.FieldCount; i++)
                        {
                            if (pFields.get_Field(i).Name == "Shape")
                            {
                                dr[i] = GetLayerType(pFeature);
                            }
                            else
                            {
                                dr[i] = pFeature.get_Value(i);
                            }
                        }
                        pDataTable.Rows.Add(dr);
                    }
                    pFeature = pEnumFeature.Next();
                }
            }
            dataGridView1.DataSource = pDataTable;
        }

        private string GetLayerType(IFeature pFeature)
        {
            esriGeometryType t = pFeature.Shape.GeometryType;
            string str = null;
            switch (t)
            {
                case esriGeometryType.esriGeometryPoint:
                    str = "点要素";
                    break;
                case esriGeometryType.esriGeometryPolyline:
                case esriGeometryType.esriGeometryLine:
                    str = "线要素";
                    break;
                case esriGeometryType.esriGeometryPolygon:
                    str = "面要素";
                    break;           
            }
            return str;
        }

        private DataTable AddHeader(IFields pFields)
        {
            DataTable pDataTable = new DataTable();
            for (int i = 0; i < pFields.FieldCount; i++)
            {
                pDataTable.Columns.Add(pFields.get_Field(i).Name);
            }
            return pDataTable;
        }
    }




Statics.cs
    public partial class Statics : Form
    {
        AxMapControl mapControl;
        IFeatureLayer pFeatureLayer;
        public Statics(AxMapControl mapControl)
        {
            InitializeComponent();
            this.mapControl = mapControl;
        }

        private void Statics_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < mapControl.Map.LayerCount; i++)
            {
                ILayer pLayer = mapControl.Map.get_Layer(i);
                if (pLayer is IFeatureLayer)
                {
                    comboBox1.Items.Add(pLayer.Name);
                }
            }
            comboBox1.SelectedIndex = 1;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = 0;
            for (int i = 0; i < mapControl.LayerCount; i++)
            {
                if (mapControl.Map.get_Layer(i).Name == comboBox1.SelectedItem.ToString())
                {
                    index = i;
                }
            }
            pFeatureLayer = mapControl.Map.get_Layer(index) as IFeatureLayer;
            IFields pFields = pFeatureLayer.FeatureClass.Fields;
            for (int i = 0; i < pFields.FieldCount; i++)
            {
                IField pField = pFields.get_Field(i);
                int varType = pField.VarType;
                if (varType > 1 && varType < 6)
                {
                    comboBox2.Items.Add(pField.Name);
                }
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            double maxValue = double.MinValue;
            double minValue = double.MaxValue;
            double sumValue = 0;
            int sumCount = 0;
            int[] count = new int[10];
            double intervar = 0;
            IFeatureCursor pCursor= pFeatureLayer.Search(null, true);
            IFeature pFeature = pCursor.NextFeature();
            int index=0;
            IFields pFields=pFeatureLayer.FeatureClass.Fields;

            for(int i=0;i<pFields.FieldCount;i++)
            {
                if(pFields.get_Field(i).Name==comboBox2.SelectedItem.ToString())
                {
                    index=i;
                }
            }
            while (pFeature != null)
            {
                double value=Convert.ToDouble(pFeature.get_Value(index));
                if (value > maxValue)
                {
                    maxValue = value;
                }
                if (value < minValue)
                {
                    minValue = value;
                }
                sumValue += value;
                sumCount++;
                pFeature = pCursor.NextFeature();
            }
            intervar = (maxValue - minValue) / 10.0;
            chart1.ChartAreas[0].AxisX.Minimum = Convert.ToDouble(minValue.ToString("f2"));
            chart1.Series[0].Points.Clear();
            pCursor = pFeatureLayer.Search(null, true);
            pFeature = pCursor.NextFeature();
            while (pFeature != null)
            {
                double value=Convert.ToDouble(pFeature.get_Value(index));
                for (int i = 0; i < 10; i++)
                {
                    if (value >= minValue + intervar * i && value <= minValue + intervar * (i + 1))
                    {
                        count[i]++;
                        break;
                    }
                }
                pFeature = pCursor.NextFeature();
            }
            for (int i = 0; i < 10; i++)
            {
                chart1.Series[0].Points.AddXY(minValue + intervar * (i + 1), count[i]);
            }
            richTextBox1.Text ="总计："+sumCount+"\n最大值：" + maxValue.ToString("f2") + "\n最小值：" + minValue.ToString("f2") + "\n总值：" + sumValue.ToString("f2")
                + "\n平均值：" + (sumValue / sumCount).ToString("f2");
        }
    }







