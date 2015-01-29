using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net.Security;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.SqlServer.Server;


namespace DrilTapeTest1
{
    public partial class Form1 : Form
    {
        private string m_Data;
        public List<string> str3;

        private PointF[] minMaxPoint = new PointF[2];

        private PointF[] XYCoordinate;

        public Form1()
        {
            InitializeComponent();

        }


        private void filltxtBx()
        {
            try
            {
                StreamReader m_SW = new StreamReader(@"E:\aoi4-p\02a0450186b1\02a0450186b1 - 副本.drl");

                m_Data = m_SW.ReadToEnd();
                this.tb_MiscOP.Text = m_Data;

                //string pData = m_SW.ReadLine();




            }
            catch (IOException ex)
            {

                MessageBox.Show("This is a IO Exception :" + ex.Message);
            }

        }

        private List<string> ConverttxtBx()
        {
            List<string> list1 = new List<string>();

            Regex rg = new Regex(@"([xyXY]\d+)");
            Regex rg2 = new Regex(@"([xyXY]\d{6})0*");
            Regex rg3 = new Regex(@"([xyXY]\d{3})(\d{3})");

            string tempstr1, tempstr2;


            try
            {
                StreamReader m_SW = new StreamReader(@"E:\aoi4-p\02a0450186b1\02a0450186b1 - 副本.drl");

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
           

            Regex rgx = new Regex(@"([X](\d{3}\.\d{3}))", RegexOptions.IgnoreCase | RegexOptions.Singleline);
            Regex rgy = new Regex(@"([Y](\d{3}\.\d{3}))", RegexOptions.IgnoreCase | RegexOptions.Singleline);

            List<Single> xFloats = new List<Single>();
            List<Single> yFloats = new List<Single>();

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
            PointF[] pointArrayFs = new PointF[Instr.Count];

            Regex rgx = new Regex(@"([X](\d{3}\.\d{3}))", RegexOptions.IgnoreCase | RegexOptions.Singleline);
            Regex rgy = new Regex(@"([Y](\d{3}\.\d{3}))", RegexOptions.IgnoreCase | RegexOptions.Singleline);

            List<Single> xFloats = new List<Single>();
            List<Single> yFloats = new List<Single>();

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

            StringBuilder sb = new StringBuilder();

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

            Point pointXY = new Point(50, 100);
            Bitmap bmap = new Bitmap(this.picBox1.Width, this.picBox1.Height, PixelFormat.Format24bppRgb);

            Graphics g2 = Graphics.FromImage(bmap);

            Pen p = new Pen(Color.Gold, 3);

            Regex rg = new Regex(@"([XY](\d{3}\.\d{3}))?", RegexOptions.IgnoreCase | RegexOptions.Singleline);

            Regex rg2 = new Regex(@"([X](\d{3}\.\d{3}))", RegexOptions.IgnoreCase);
            Regex rg3 = new Regex(@"([Y](\d{3}\.\d{3}))", RegexOptions.IgnoreCase);

            for (int i = 0; i < str3.Count - 1; i++)
            {
                string temp = str3[i];

                if (rg2.IsMatch(temp))
                {
                    pointXY.X = Convert.ToInt32(temp.Substring(1, 3));
                }
                else
                {
                    if (rg3.IsMatch(temp))
                    {
                        if (temp.Length > 8)
                        {
                            pointXY.Y = Convert.ToInt32(temp.Substring(8, 3));
                        }
                        else
                        {
                            pointXY.Y = Convert.ToInt32(temp.Substring(1, 3));
                        }


                    }
                }
                g2.DrawEllipse(p, pointXY.X, pointXY.Y, 1, 1);

            }


            this.picBox1.Image = bmap;

        }

        private Bitmap drawReImage()
        {
            int _width  = Convert.ToInt32(Math.Abs((minMaxPoint[1].X - minMaxPoint[0].X)*1000));
            int _height = Convert.ToInt32(Math.Abs((minMaxPoint[1].Y - minMaxPoint[0].Y)*1000));

            //Bitmap bmap = new Bitmap(this.picBox1.Width, this.picBox1.Height, PixelFormat.Format24bppRgb);


            Bitmap bmap1 = new Bitmap(_width/10,_height/10, PixelFormat.Format1bppIndexed);


          //Bitmap bmap=new Bitmap();
            
            //var bmap = new Bitmap(width, height, PixelFormat.Format24bppRgb);

            Graphics g2 = Graphics.FromImage(bmap1);
            Pen p = new Pen(Color.White, 3);

            foreach (PointF pf in XYCoordinate)
            {
                g2.DrawEllipse(p,pf.X,pf.Y,1,1);
            }


            return bmap1;
        }

        private void btnFindMinMax_Click(object sender, EventArgs e)
        {

             string msg = "Min Coordinate is : X" + minMaxPoint[0].X + "  Y " + minMaxPoint[0].Y + " \r\nMax Coordinate is : X" +
                         minMaxPoint[1].X + "  Y" + minMaxPoint[1].Y;

            MessageBox.Show(msg);

        }

        private void btnFillDataGR1_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Line", typeof(int));
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

            this.dataGR1.DataSource = dt;
            //this.dataGR1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            //this.dataGR1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            //this.dataGR1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.dataGR1.Columns[0].Width = 50;
            this.dataGR1.Columns[1].Width = 60;
            this.dataGR1.Columns[2].Width = 60;
            //this.dataGR1.AutoResizeColumn(0);
            //this.dataGR1.AutoResizeColumn(1);
            //this.dataGR1.AutoResizeColumn(2);
            //this.dataGR1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.Fill);
            //this.dataGR1.AutoResizeRows(DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders);
         
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.picBox1.Image = drawReImage();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DrillTAPE drill1 = new DrillTAPE(@"E:\aoi4-p\02a0450186b1\02a0450186b1 - 副本.drl");
         }

 
    }
}