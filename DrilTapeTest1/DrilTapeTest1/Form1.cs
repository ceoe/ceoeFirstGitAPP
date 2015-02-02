using System;
using System.Collections.Generic;
using System.Data;
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
        public List<string> str3;


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
                var m_SW = new StreamReader(@"E:\aoi4-p\02a0450186b1\02a0450186b1-newtest.drl");

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
                var m_SW = new StreamReader(@"E:\aoi4-p\02a0450186b1\02a0450186b1-newtest.drl");

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

            tb_CoordinateXY.Text = sb.ToString();
            tb_CoordinateXY.Text += str3.Capacity;

            SearchMinMaxPoint(str3);
            XYCoordinate = GetCoordinatesArray(str3);
        }

        private void btnDrawDrl_Click(object sender, EventArgs e)
        {
            float DriltapeWidth = drill1.MaxPointF.X - drill1.MinPointF.X;
            float DriltapeHeight = drill1.MaxPointF.Y - drill1.MinPointF.Y;

            float xscale = (picBox1.Width - 20)/DriltapeWidth;
            numUDbox.Text = xscale.ToString();

            var drilltapeRectangleF = new RectangleF(0, 0, DriltapeWidth, DriltapeHeight);

            float DrilTapeDiagonalSize =
                Convert.ToSingle(Math.Sqrt(Convert.ToDouble(DriltapeWidth*DriltapeWidth + DriltapeHeight*DriltapeHeight)));


            picBox1.Image = DrawDrillBitmap(xscale);
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

                DiameterafterScale = holeShape.HoleSize*xscale;

                EllipseWidth = DiameterafterScale;
                EllipseHeight = DiameterafterScale;

                //Random rand1 = new Random(32);
                //Color Colorset = GetRandomColor();
                // p = new Pen(Colorset, 1);
                brushpen = new SolidBrush(colorList[colorindex++]);
                for (int i = 0; i < holeShape.XYCoordinateGroup.GetCoordinateCount(); i++)
                {
                    xPositionafterScale = holeShape.XYCoordinateGroup.Pointfs[i].X*xscale;
                    yPositionafterScale = holeShape.XYCoordinateGroup.Pointfs[i].Y*xscale;

                    // g2.DrawEllipse(p, xPositionafterScale, yPositionafterScale, DiameterafterScale, DiameterafterScale);
                    g2.FillEllipse(brushpen, xPositionafterScale - EllipseWidth/2, yPositionafterScale - EllipseHeight/2,
                        EllipseWidth, EllipseHeight);
                }
            }
            return bmap;
        }

        public Color GetRandomColor()
        {
            var RandomNum_First = new Random((int) DateTime.Now.Ticks); // 对于C#的随机数，没什么好说的 
            Thread.Sleep(RandomNum_First.Next(50));
            var RandomNum_Sencond = new Random((int) DateTime.Now.Ticks); // 为了在白色背景上显示，尽量生成深色 
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
            dt.Columns.Add("Line", typeof (int));
            dt.Columns.Add("X", typeof (float));
            dt.Columns.Add("Y", typeof (float));

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
            drill1 = new DrillTAPE(@"E:\aoi4-p\02a0450186b1\test2.drl");
            lbTotalNumofHole.Text += drill1.TotalNumofhole;
            lbKindofTools.Text += drill1.KindofTools;
            lbMinCoordXY.Text += " X:" + drill1.MinPointF.X + " Y:" + drill1.MinPointF.Y;
            lbMaxCoordXY.Text += " X:" + drill1.MaxPointF.X + " Y:" + drill1.MaxPointF.Y;
        }

        private void picBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
        }

        private void numUDbox_ValueChanged(object sender, EventArgs e)
        {
            picBox1.Image = DrawDrillBitmap(Convert.ToSingle(numUDbox.Value));
        }
    }
}