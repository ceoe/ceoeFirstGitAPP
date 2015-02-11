using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

namespace DrilTapeTest1
{
    public partial class Form1 : Form
    {
        private readonly Color[] colorList = new Color[32];
        private readonly PointF[] minMaxPoint = new PointF[2];

        private PointF[] XYCoordinate;
        public DrillTAPE drill1;
        private string m_Data;
        protected bool RunedorRunAbort = false;
        public List<string> str3;

        public delegate void Updatebtn();
        public Updatebtn updateBtn;
        public Thread objThread;

        public Image OrigImage;

        public Axis XAxis, YAxis, CAxis, LAxis;
        public List<Axis> AxisGroup;
        // public  Axis[] AxisGroup=new Axis[4];
        public Motion2610Control motion = new Motion2610Control();
        public Form1()
        {
            InitializeComponent();
            GeneratorColorList();
        }

        private void GeneratorColorList()
        {
            for (int i = 0; i < colorList.Length; i++)
            {
                colorList[i] = GetRandomColor();
            }
        }

        private void filltxtBx()
        {
            try
            {
                var m_SW = new StreamReader(@"test2.drl");

                m_Data = m_SW.ReadToEnd();
                tb_MiscOP.Text = m_Data;

                //string pData = m_SW.ReadLine();
            }
            catch (IOException ex)
            {
                MessageBox.Show("This is a IO Exception :" + ex.Message);
            }
        }

        private List<string> ConverttxtBx()
        {
            var list1 = new List<string>();

            var rg = new Regex(@"([xyXY]\d+)");
            var rg2 = new Regex(@"([xyXY]\d{6})0*");
            var rg3 = new Regex(@"([xyXY]\d{3})(\d{3})");

            string tempstr1, tempstr2;


            try
            {
                var m_SW = new StreamReader(@"test2.drl");

                do
                {
                    tempstr1 = m_SW.ReadLine();
                    if (tempstr1 != null)
                    {
                        if (rg.IsMatch(tempstr1))
                        {
                            tempstr2 = rg.Replace(tempstr1, @"${1}00000");
                            tempstr2 = rg2.Replace(tempstr2, @"${1}");
                            tempstr2 = rg3.Replace(tempstr2, @"${1}.${2}");

                            if (tempstr2 != null)
                            {
                                list1.Add(tempstr2);
                            }
                        }
                    }
                } while (tempstr1 != null);
            }
            catch (IOException ex)
            {
                MessageBox.Show("This is a IO Exception :" + ex.Message);
            }

            return list1;
        }

        private void SearchMinMaxPoint(List<string> Instr)
        {
            var rgx = new Regex(@"([X](\d{3}\.\d{3}))", RegexOptions.IgnoreCase | RegexOptions.Singleline);
            var rgy = new Regex(@"([Y](\d{3}\.\d{3}))", RegexOptions.IgnoreCase | RegexOptions.Singleline);

            var xFloats = new List<Single>();
            var yFloats = new List<Single>();

            foreach (string str in Instr)
            {
                Match mmMatch = rgx.Match(str);
                if (mmMatch.Success)
                {
                    xFloats.Add(Convert.ToSingle(mmMatch.Groups[2].ToString()));
                }

                mmMatch = rgy.Match(str);
                if (mmMatch.Success)
                {
                    yFloats.Add(Convert.ToSingle(mmMatch.Groups[2].ToString()));
                }
            }

            xFloats.Sort();
            yFloats.Sort();


            minMaxPoint[0].X = xFloats.First();
            minMaxPoint[0].Y = yFloats.First();


            minMaxPoint[1].X = xFloats.Last();
            minMaxPoint[1].Y = yFloats.Last();
        }

        private PointF[] GetCoordinatesArray(List<string> Instr)
        {
            var pointArrayFs = new PointF[Instr.Count];

            var rgx = new Regex(@"([X](\d{3}\.\d{3}))", RegexOptions.IgnoreCase | RegexOptions.Singleline);
            var rgy = new Regex(@"([Y](\d{3}\.\d{3}))", RegexOptions.IgnoreCase | RegexOptions.Singleline);

            var xFloats = new List<Single>();
            var yFloats = new List<Single>();

            string test1;
            for (int i = 0; i < Instr.Count; i++)
            {
                test1 = Instr[i];
                Match mmMatch = rgx.Match(test1);
                if (mmMatch.Success)
                {
                    xFloats.Add(Convert.ToSingle(mmMatch.Groups[2].ToString()));
                }

                mmMatch = rgy.Match(test1);
                if (mmMatch.Success)
                {
                    yFloats.Add(Convert.ToSingle(mmMatch.Groups[2].ToString()));
                }
                pointArrayFs[i].X = xFloats[xFloats.Count - 1];
                pointArrayFs[i].Y = yFloats[yFloats.Count - 1];
            }

            return pointArrayFs;
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            filltxtBx();

            str3 = ConverttxtBx();

            var sb = new StringBuilder();

            foreach (string str in str3)
            {
                sb.AppendLine(str);
            }
            SearchMinMaxPoint(str3);
            XYCoordinate = GetCoordinatesArray(str3);
        }

        private void btnDrawDrl_Click(object sender, EventArgs e)
        {
            float DriltapeWidth = drill1.MaxPointF.X - drill1.MinPointF.X;
            float DriltapeHeight = drill1.MaxPointF.Y - drill1.MinPointF.Y;

            float xscale = (picBox1.Width - 10) / DriltapeWidth;
            numUDbox.Text = xscale.ToString();

            picBox1.Image = DrawDrillBitmap(xscale);

            OrigImage = new Bitmap(picBox1.Image);
        }

        private Bitmap DrawDrillBitmap(float xscale)
        {
            var bmap = new Bitmap(picBox1.Width, picBox1.Height, PixelFormat.Format16bppRgb555);
            Graphics g2 = Graphics.FromImage(bmap);

            var p = new Pen(Color.Gold, 1);

            Brush brushpen;

            int colorindex = 0;
            foreach (DrillTAPE.HoleShape holeShape in drill1.HoleList)
            {
                float xPositionafterScale,
                    yPositionafterScale,
                    DiameterafterScale;
                float EllipseWidth, EllipseHeight;

                DiameterafterScale = holeShape.HoleSize * xscale;

                EllipseWidth = DiameterafterScale;
                EllipseHeight = DiameterafterScale;

                //Random rand1 = new Random(32);
                //Color Colorset = GetRandomColor();
                // p = new Pen(Colorset, 1);
                brushpen = new SolidBrush(colorList[colorindex++]);
                for (int i = 0; i < holeShape.XYCoordinateGroup.GetCoordinateCount(); i++)
                {
                    xPositionafterScale = holeShape.XYCoordinateGroup.Pointfs[i].X * xscale;
                    yPositionafterScale = holeShape.XYCoordinateGroup.Pointfs[i].Y * xscale;

                    // g2.DrawEllipse(p, xPositionafterScale, yPositionafterScale, DiameterafterScale, DiameterafterScale);
                    g2.FillEllipse(brushpen, xPositionafterScale - EllipseWidth / 2, yPositionafterScale - EllipseHeight / 2,
                        EllipseWidth, EllipseHeight);
                }
            }
          return bmap;
        }

        public Color GetRandomColor()
        {
            var RandomNum_First = new Random((int)DateTime.Now.Ticks);
            Thread.Sleep(RandomNum_First.Next(100));
            var RandomNum_Sencond = new Random((int)DateTime.Now.Ticks); // 为了在白色背景上显示，尽量生成深色 
            int int_Red = RandomNum_First.Next(256);
            int int_Green = RandomNum_Sencond.Next(256);
            int int_Blue = (int_Red + int_Green > 400) ? 0 : 400 - int_Red - int_Green;
            int_Blue = (int_Blue > 255) ? 255 : int_Blue;
            return Color.FromArgb(int_Red, int_Green, int_Blue);
        }

        private void btnFindMinMax_Click(object sender, EventArgs e)
        {
            string msg = "Min Coordinate is : X" + minMaxPoint[0].X + "  Y " + minMaxPoint[0].Y +
                         " \r\nMax Coordinate is : X" +
                         minMaxPoint[1].X + "  Y" + minMaxPoint[1].Y;

            MessageBox.Show(msg);
        }

        private void btnFillDataGR1_Click(object sender, EventArgs e)
        {
            var dt = new DataTable();
            dt.Columns.Add("Line", typeof(int));
            dt.Columns.Add("X", typeof(float));
            dt.Columns.Add("Y", typeof(float));

            for (int i = 0; i < XYCoordinate.Count(); i++)
            {
                DataRow dr = dt.NewRow();
                dr[0] = i;
                dr[1] = XYCoordinate[i].X;
                dr[2] = XYCoordinate[i].Y;
                dt.Rows.Add(dr);
            }

            dataGR1.DataSource = dt;
            //this.dataGR1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            //this.dataGR1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            //this.dataGR1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            dataGR1.Columns[0].Width = 50;
            dataGR1.Columns[1].Width = 60;
            dataGR1.Columns[2].Width = 60;
            //this.dataGR1.AutoResizeColumn(0);
            //this.dataGR1.AutoResizeColumn(1);
            //this.dataGR1.AutoResizeColumn(2);
            //this.dataGR1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.Fill);
            //this.dataGR1.AutoResizeRows(DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders);
        }


        private void button2_Click(object sender, EventArgs e)
        {
            drill1 = new DrillTAPE(@"test2.drl");
            lbTotalNumofHole.Text = "Total Holes:" + drill1.TotalNumofhole;
            lbKindofTools.Text = "Kind of Tools:" + drill1.KindofTools;
            lbMinCoordXY.Text = "MinCoord:" + " X:" + drill1.MinPointF.X + " Y:" + drill1.MinPointF.Y;
            lbMaxCoordXY.Text = "MaxCoord:" + " X:" + drill1.MaxPointF.X + " Y:" + drill1.MaxPointF.Y;
        }

        private void picBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
        }

        private void numUDbox_ValueChanged(object sender, EventArgs e)
        {
            picBox1.Image = DrawDrillBitmap(Convert.ToSingle(numUDbox.Value));
            OrigImage = new Bitmap(picBox1.Image);
        }

        private void btnLoadAxisPara_Click(object sender, EventArgs e)
        {
            // DMC2610卡的函数调用                       
            UInt16 nCard = 0;
            nCard = Dmc2610.d2610_board_init();//'为控制卡分配系统资源，并初始化控制卡。
            if (nCard <= 0)//DMC1000控制卡初始化
            {
                MessageBox.Show("未找到DMC2610控制卡!", "警告");
                return;//退出当前程序  
            }

            string connectionString = @"Data Source=.\AOI;Initial Catalog=aoi5sys;Integrated Security=True";

            SqlConnection connection = new SqlConnection(connectionString);
            //string sql=@"SELECT * FROM AXIS_PARAM WHERE NAME='#1HOST'";
            string sql = @"SELECT [NAME]
      ,[AXIS]
      ,[AXIS_ID]
      ,[PULSE_MODE]
      ,[MAX_DIST]
      ,[ORG_POSITION]
      ,[RESET_SPEED]
      ,[START_SPEED]
      ,[MAX_SPEED]
      ,[ADD_SPEED]
      ,[ADD_MODE]
      ,[PULSE_PER_MM]
  FROM [aoi5sys].[dbo].[AXIS_PARAM]
  WHERE	NAME='#1HOST'";
            try
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand(sql, connection);

                SqlDataReader dataReader = cmd.ExecuteReader();


                AxisGroup = new List<Axis>();

                while (dataReader.Read())
                {
                    string tempstr = dataReader.GetValue(1).ToString();
                    AxisPulseOutMode PoutMode = dataReader.GetInt32(3) == 0
                              ? AxisPulseOutMode.PM_PLDL
                              : AxisPulseOutMode.PM_PHDHPHDH;
                    double pulseOfMilMeter = Convert.ToDouble(dataReader.GetValue(11).ToString());
                    long maxRouterDistance = Convert.ToInt64(dataReader.GetValue(4));
                    long logicOrgPosition = Convert.ToInt64(dataReader.GetValue(5));
                    AxisINPSIG axisInpsig = AxisINPSIG.Enable;

                    double ResetVelocity = Convert.ToDouble(dataReader.GetValue(6));
                    double startVelocity = Convert.ToDouble(dataReader.GetValue(7));
                    double maxVelocity = Convert.ToDouble(dataReader.GetValue(8));
                    double accVelocity = Convert.ToDouble(dataReader.GetValue(9));
                    double decVelocity = Convert.ToDouble(dataReader.GetValue(9));
                    float scale = (float)0.75;

                    if (tempstr.Contains("X_"))
                    {
                        this.XAxis = new Axis(AxisID.XAxis, PoutMode, pulseOfMilMeter, maxRouterDistance, logicOrgPosition, axisInpsig);
                        XAxis.AxisSetResetMoveParameters(ResetVelocity / 2, ResetVelocity, ResetVelocity / 2, ResetVelocity / 2);
                        XAxis.AxisSetTMoveParameters(startVelocity, maxVelocity, accVelocity, decVelocity);
                        XAxis.AxisSetSPMoveParameters(startVelocity, maxVelocity, accVelocity, decVelocity, scale);
                        XAxis.AxisSetSTMoveParameters(startVelocity, maxVelocity, accVelocity, decVelocity, scale);
                        // XAxis.AxisSetVectorMoveParameters(startVelocity, maxVelocity, accVelocity, decVelocity, (float)0.6);
                        AxisGroup.Add(XAxis);
                    }
                    if (tempstr.Contains("Y_"))
                    {
                        this.YAxis = new Axis(AxisID.YAxis, PoutMode, pulseOfMilMeter, maxRouterDistance, logicOrgPosition, axisInpsig);
                        YAxis.AxisSetResetMoveParameters(ResetVelocity / 2, ResetVelocity, ResetVelocity / 2, ResetVelocity / 2);
                        YAxis.AxisSetTMoveParameters(startVelocity, maxVelocity, accVelocity, decVelocity);
                        YAxis.AxisSetSPMoveParameters(startVelocity, maxVelocity, accVelocity, decVelocity, scale);
                        YAxis.AxisSetSTMoveParameters(startVelocity, maxVelocity, accVelocity, decVelocity, scale);
                        // YAxis.AxisSetVectorMoveParameters(startVelocity, maxVelocity, accVelocity, decVelocity, (float)0.6);
                        AxisGroup.Add(YAxis);
                    }
                    if (tempstr.Contains("C_"))
                    {
                        this.CAxis = new Axis(AxisID.ZAxis, PoutMode, pulseOfMilMeter, maxRouterDistance, logicOrgPosition, axisInpsig);
                        CAxis.AxisSetResetMoveParameters(ResetVelocity / 2, ResetVelocity, ResetVelocity / 2, ResetVelocity / 2);
                        CAxis.AxisSetTMoveParameters(startVelocity, maxVelocity, accVelocity, decVelocity);
                        CAxis.AxisSetSPMoveParameters(startVelocity, maxVelocity, accVelocity, decVelocity, scale);
                        CAxis.AxisSetSTMoveParameters(startVelocity, maxVelocity, accVelocity, decVelocity, scale);
                        //CAxis.AxisSetVectorMoveParameters(startVelocity, maxVelocity, accVelocity, decVelocity, (float)0.6);
                        AxisGroup.Add(CAxis);
                    }
                    if (tempstr.Contains("L_"))
                    {
                        this.LAxis = new Axis(AxisID.UAxis, PoutMode, pulseOfMilMeter, maxRouterDistance, logicOrgPosition, axisInpsig);
                        LAxis.AxisSetResetMoveParameters(ResetVelocity / 2, ResetVelocity, ResetVelocity / 2, ResetVelocity / 2);
                        LAxis.AxisSetTMoveParameters(startVelocity, maxVelocity, accVelocity, decVelocity);
                        LAxis.AxisSetSPMoveParameters(startVelocity, maxVelocity, accVelocity, decVelocity, scale);
                        LAxis.AxisSetSTMoveParameters(startVelocity, maxVelocity, accVelocity, decVelocity, scale);
                        // LAxis.AxisSetVectorMoveParameters(startVelocity, maxVelocity, accVelocity, decVelocity, (float)0.6);
                        AxisGroup.Add(LAxis);
                    }
                }
                timer1.Enabled = true;


            }
            catch (DataException dataException)
            {
                MessageBox.Show(dataException.ToString());
            }
            finally
            {
                connection.Close();
                this.btnLoadAxisPara.Enabled = false;
            }
        }

        private void btnInitialization_Click(object sender, EventArgs e)
        {


            updateBtn = new Updatebtn(UpdateHomebtnMethod);


            //objThread = new Thread(new ThreadStart(delegate { AxiseHomeUseThread(XAxis); })
            //  );
            //objThread.Start();

            foreach (Axis axis in AxisGroup)
            {

                objThread = new Thread(new ThreadStart(delegate { AxiseHomeUseThread(axis); }));

                objThread.Start();
            }
            this.btnInitialization.Enabled = false;

        }
        public void UpdateHomebtnMethod()
        {
           int count = 0;
            do
            {
                count = 0;
                foreach (Axis axis in AxisGroup)
                {
                    if (Motion2610Control.GetAxisIsDoWell(axis))
                    {
                        count++;

                        Thread.Sleep(100);
                    }

                }
            } while (count != 4);

            btnInitialization.Enabled = true;

        }

        public void UpdateRunbtnMethod()
        {
            if (RunedorRunAbort)
            {
                this.btnRun.Enabled = true;
            }
        }

        private void AxiseHomeUseThread(Axis axis)
        {
            Motion2610Control.HomeMove(axis);
            BeginInvoke(updateBtn);

        }

        private void XYMotion()
        {
            updateBtn = UpdateRunbtnMethod;
            uint count = 0;
            bool isCompleted = true;
            float xCoordinate, yCoordinate;
            foreach (DrillTAPE.HoleShape holeShape in drill1.HoleList)
            {
                if (isCompleted)
                {
                    for (int i = 0; i < holeShape.XYCoordinateGroup.GetCoordinateCount(); i++)
                    {
                        xCoordinate = holeShape.XYCoordinateGroup.Pointfs[i].X;
                        yCoordinate = holeShape.XYCoordinateGroup.Pointfs[i].Y;

                        picBox1.Image = DrawCurrentHitHole1(xCoordinate, yCoordinate);

                        if (!Motion2610Control.XYPMoveAbsolutUseTMode(XAxis, YAxis, xCoordinate, yCoordinate))
                        {
                            isCompleted = false;
                            break;
                        }
                        else
                        {
                            Thread.Sleep(50);
                            count++;
                        }
                        while ((!Motion2610Control.GetAxisIsDoWell(XAxis)) && (!Motion2610Control.GetAxisIsDoWell(YAxis)))
                        {
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Some wrong has Happend!!!");
                    RunedorRunAbort= true;
                    BeginInvoke(updateBtn);
                    return;
                }
            }
            RunedorRunAbort = true;
            BeginInvoke(updateBtn);
        }

     

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            long pos, pos2;
            int checkStauts;
            string str_DisplayPos;

            pos = Dmc2610.d2610_get_position(0);//读取指定轴的当前位置
            str_DisplayPos = "X=" + Convert.ToString(pos) + "     " + (!Convert.ToBoolean(Dmc2610.d2610_check_done((ushort)AxisID.XAxis)) ? "...Run..." : "...Stop...");
            pos = Dmc2610.d2610_get_position(1);
            str_DisplayPos = str_DisplayPos + "   Y=" + Convert.ToString(pos) + "     " + (!Convert.ToBoolean(Dmc2610.d2610_check_done((ushort)AxisID.YAxis)) ? "...Run..." : "...Stop...");

            str_DisplayPos += "\n";

            pos2 = Dmc2610.d2610_get_position(2);
            str_DisplayPos = str_DisplayPos + "Z=" + Convert.ToString(pos2) + "     " + (!Convert.ToBoolean(Dmc2610.d2610_check_done((ushort)AxisID.ZAxis)) ? "...Run..." : "...Stop...");
            pos2 = Dmc2610.d2610_get_position(3);
            str_DisplayPos = str_DisplayPos + "   U=" + Convert.ToString(pos2) + "     " + (!Convert.ToBoolean(Dmc2610.d2610_check_done((ushort)AxisID.UAxis)) ? "...Run..." : "...Stop...");


            //str_DisplayPos += "\n"  + ((Motion2610Control.GetAxisIsORGON(XAxis)) ? "X ORG IS ON" : "X ORG IS OFF");
            str_DisplayPos += "\n" + ((Motion2610Control.GetAxisIsORGON(XAxis)) ? "X ORG IS ON" : "X ORG IS OFF") + "   " + ((Motion2610Control.GetAxisIsORGON(YAxis)) ? "Y ORG IS ON" : "Y ORG IS OFF") + "   " + ((Motion2610Control.GetAxisIsORGON(CAxis)) ? "C ORG IS ON" : "C ORG IS OFF") + "   " + ((Motion2610Control.GetAxisIsORGON(LAxis)) ? "L ORG IS ON" : "L ORG IS OFF");

            str_DisplayPos += "\n" + ((Motion2610Control.GetAxisIsNELON(XAxis)) ? "X EL- IS ON" : "X EL- IS OFF") + "   " + ((Motion2610Control.GetAxisIsNELON(YAxis)) ? "Y EL- IS ON" : "Y EL- IS OFF") + "   " + ((Motion2610Control.GetAxisIsNELON(CAxis)) ? "C EL- IS ON" : "C EL- IS OFF") + "   " + ((Motion2610Control.GetAxisIsNELON(LAxis)) ? "L EL- IS ON" : "L EL- IS OFF");

            str_DisplayPos += "\n" + ((Motion2610Control.GetAxisIsPELON(XAxis)) ? "X EL+ IS ON" : "X EL+ IS OFF") + "   " + ((Motion2610Control.GetAxisIsPELON(YAxis)) ? "Y EL+ IS ON" : "Y EL+ IS OFF") + "   " + ((Motion2610Control.GetAxisIsPELON(CAxis)) ? "C EL+ IS ON" : "C EL+ IS OFF") + "   " + ((Motion2610Control.GetAxisIsPELON(LAxis)) ? "L EL+ IS ON" : "L EL+ IS OFF");

            str_DisplayPos += "\n\n" + ((Motion2610Control.GetAxisIsINPON(XAxis)) ? "X INP IS ON" : "X INP IS OFF") +
                              "   " + ((Motion2610Control.GetAxisIsINPON(YAxis)) ? "Y INP IS ON" : "Y INP IS OFF");
            
            Label_POSITION.Text = str_DisplayPos;//显示位置信

            StringBuilder axisStautsDetail = new StringBuilder();
            foreach (Axis axis in AxisGroup)
            {
                if (!Motion2610Control.AxisQueryStatus(axis))
                {
                    while (axis.AxisStatusStack.Count > 0)
                    {
                        axisStautsDetail.Append(axis.AxisStatusStack.Pop());
                    }

                }
            }
            if (axisStautsDetail.Length <= 0)
            {
                lbAxisStatus.Text = "Axis Status : \n" + "Every Axis is OK!";
            }
            else
            {
                lbAxisStatus.Text = "Axis Status : \n" + axisStautsDetail;
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            timer1.Enabled = false;

            if (AxisGroup!=null)
            {
                Dmc2610.d2610_board_close();
            }
            if (objThread!=null)
            {
                if (objThread.IsAlive)
                {
                    objThread.Abort();
                }
            }
        }
        private void btnStop_Click(object sender, EventArgs e)
        {
           //Motion2610Control.AllAxisEMGStop();
            if (objThread != null)
            {
                if (objThread.IsAlive)
                {
                    objThread.Abort();
                }
            }
           this.btnRun.Enabled = true;
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            objThread = new Thread(new ThreadStart(delegate { XYMotion(); }));

            objThread.Start();

            this.btnRun.Enabled = false;

            //objThread = new Thread(new ThreadStart(delegate { XYDrawingaCorssHatch(); }));

            //objThread.Start();

            //this.btnRun.Enabled = false;

        }
        private void XYDrawingaCorssHatch()
        {
            updateBtn = UpdateRunbtnMethod;
            uint count = 0;
            bool isCompleted = true;
            float xCoordinate, yCoordinate;
            foreach (DrillTAPE.HoleShape holeShape in drill1.HoleList)
            {
                if (isCompleted)
                {
                    for (int i = 0; i < holeShape.XYCoordinateGroup.GetCoordinateCount(); i++)
                    {
                        xCoordinate = holeShape.XYCoordinateGroup.Pointfs[i].X;
                        yCoordinate = holeShape.XYCoordinateGroup.Pointfs[i].Y;

                        picBox1.Image = DrawCurrentHitHole1(xCoordinate, yCoordinate);
                        Thread.Sleep(50);
                        count++;
                    }
                }

            }
            RunedorRunAbort = true;
            BeginInvoke(updateBtn);
        }

        private Bitmap DrawCurrentHitHole1(float x, float y)
        {
            float xscale = Convert.ToSingle(numUDbox.Text);

            var bmap = new Bitmap(OrigImage);
             Graphics gHole = Graphics.FromImage(bmap);

            var p = new Pen(Color.Gold, 2);

           float xPositionafterScale,
                yPositionafterScale;
            xPositionafterScale = x*xscale;
            yPositionafterScale = y*xscale;
                  

            gHole.DrawLine(p,xPositionafterScale,0,xPositionafterScale,bmap.Width);
            gHole.DrawLine(p,0,yPositionafterScale,bmap.Height+10,yPositionafterScale);
            gHole.Dispose();
            return (Bitmap)bmap;
        }
       
    }
}