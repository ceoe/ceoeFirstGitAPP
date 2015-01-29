using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrilTapeTest1
{
    enum DrlUnit
    {
        Metric,Inch
    }

    enum ZeroCompress
    {
        Leading,Trail,None
    }

   internal class DrillTAPE
    {
        private DrlUnit unit;
        private ZeroCompress zeroCompress;
        private short integerField;
        private short decimalDiatal;

        private float[] Toolslist;

        List<HoleShape>  HoleList=new List<HoleShape>();
        List<SlotShape> SlotList=new List<SlotShape>();
        

        private HoleShape[] holeshape;
        private SlotShape[] slotshape;

        public DrillTAPE(string readTapepath)
        {

           getFileFormate(readTapepath);
           getCoordinate(readTapepath);

        }


        public void getFileFormate(string readTapepath)
        {
          
            Regex rgUnit = new Regex(@"METRIC|INCH");
            Regex rgZeroCompress = new Regex(@"TZ|LZ|NONE");
            Regex rgTorderstr = new Regex(@"T(?<Torder>\d{1,2})C(?<Diameter>\d{1,2}\.\d*)", RegexOptions.IgnoreCase | RegexOptions.Singleline | RegexOptions.IgnorePatternWhitespace);
            List<float> tOrderList=new List<float>();
            string tempstr1;


            try
            {
                StreamReader m_SW = new StreamReader(readTapepath);

                do
                {
                    tempstr1 = m_SW.ReadLine();
                    if (tempstr1 != null)
                    {
                        if (tempstr1.Contains("%"))
                        {
                            break;
                        }
                        Match unitmatchs = rgUnit.Match(tempstr1);
                        if (unitmatchs.Success)
                        {
                            if (unitmatchs.Value.ToUpper().Equals("METRIC"))
                            {
                                this.unit = DrlUnit.Metric; 
                            }
                            if (unitmatchs.Value.ToUpper().Equals("INCH"))
                            {
                                this.unit = DrlUnit.Inch;
                            }
                            
                        }
                        Match zeroMatch= rgZeroCompress.Match(tempstr1);
                        if (zeroMatch.Success)
                        {

                            if (zeroMatch.Value.ToUpper().Equals("LT"))
                            {
                                this.zeroCompress = ZeroCompress.Leading;
                            }
                            if (zeroMatch.Value.ToUpper().Equals("INCH"))
                            {
                                this.zeroCompress = ZeroCompress.Trail;
                            }
                            if (zeroMatch.Value.ToUpper().Equals("NONE"))
                            {
                                this.zeroCompress = ZeroCompress.Leading;
                            }
                
                        }
                        Match tOrdermatches = rgTorderstr.Match(tempstr1);
                        if (tOrdermatches.Length > 0)
                        {
                            tOrderList.Add(Convert.ToSingle(tOrdermatches.Result("${Diameter}")));
                            //Toolslist[Convert.ToInt32(tOrdermatches.Result("${Torder}"))] = Convert.ToSingle(tOrdermatches.Result("${Diameter}"));
                        }
                    }
                }while (tempstr1 != null);
            }
            catch (IOException ex)
            {

                MessageBox.Show("This is a IO Exception :" + ex.Message);
            }
            if (tOrderList.Count>0)
            {
                Toolslist=new float[tOrderList.Count];
                for (int i = 0; i < tOrderList.Count; i++)
                {
                    Toolslist[i] = tOrderList[i];
                }
            }

        }

        public void getCoordinate(string readTapepath)

        {
            
            Regex rgx = new Regex(@"[X](\d{3}\.\d{3})", RegexOptions.IgnoreCase | RegexOptions.Singleline);
            Regex rgy = new Regex(@"[Y](\d{3}\.\d{3})", RegexOptions.IgnoreCase | RegexOptions.Singleline);

            List<Single> xFloats = new List<Single>();
            List<Single> yFloats = new List<Single>();


            Regex rg = new Regex(@"([xyXY]\d+)");
            Regex rg2 = new Regex(@"([xyXY]\d{6})0*");
            Regex rg3 = new Regex(@"([xyXY]\d{3})(\d{3})");
            Regex rgTorderstr = new Regex(@"T(?<Torder>\d{1,2})",RegexOptions.IgnoreCase | RegexOptions.Singleline | RegexOptions.IgnorePatternWhitespace);

            string tempstr1, tempstr2;


            try
            {
                StreamReader m_SW = new StreamReader(readTapepath);

                do
                {
                    tempstr1 = m_SW.ReadLine();
                    if (tempstr1.Contains("%"))
                    {
                        break;
                    }

                } while (tempstr1 != null);

                float size=0;
                int tOrder=0;
                List<PointF>  pointFArray=new List<PointF>();
                PointF[] temPointFs;
                do
                {
                    tempstr1 = m_SW.ReadLine();
                    if (tempstr1.Contains("M30"))
                    {
                      if (pointFArray.Count > 0)
                        {
                            temPointFs = pointFArray.ToArray();
                            CoordinateGroup tempCoordgp = new CoordinateGroup(temPointFs);
                            HoleShape hs = new HoleShape(size, tOrder - 1, tempCoordgp);
                            HoleList.Add(hs);
                            pointFArray.Clear();
                        }
                      break;
                    }

                    Match toolsOrdermatchs = rgTorderstr.Match(tempstr1);
                    if (toolsOrdermatchs.Success)
                    {
                        if (tOrder==0)
                        {
                            tOrder = Convert.ToInt32(toolsOrdermatchs.Result("${Torder}"));
                            size = Toolslist[tOrder - 1];
                        }
                        else
                        {
                            if (pointFArray.Count > 0)
                            {
                                temPointFs = pointFArray.ToArray();
                                CoordinateGroup tempCoordgp = new CoordinateGroup(temPointFs);
                                HoleShape hs = new HoleShape(size, tOrder - 1, tempCoordgp);
                                HoleList.Add(hs);
                                pointFArray.Clear();
                                tOrder = Convert.ToInt32(toolsOrdermatchs.Result("${Torder}"));
                                size = Toolslist[tOrder - 1];
                            }

                        }
                       
                       
                       
                        continue;
                    }

                    if (rg.IsMatch(tempstr1))
                    {


                        tempstr2 = rg.Replace(tempstr1, @"${1}00000");
                        tempstr2 = rg2.Replace(tempstr2, @"${1}");
                        tempstr2 = rg3.Replace(tempstr2, @"${1}.${2}");

                        Match mmMatch = rgx.Match(tempstr2);
                        if (mmMatch.Success)
                        {

                            xFloats.Add(Convert.ToSingle(mmMatch.Groups[1].ToString()));
                        }

                        mmMatch = rgy.Match(tempstr2);
                        if (mmMatch.Success)
                        {
                            yFloats.Add(Convert.ToSingle(mmMatch.Groups[1].ToString()));
                        }
                        PointF temPointF = new PointF(xFloats[xFloats.Count - 1], yFloats[yFloats.Count - 1]);
                        pointFArray.Add(temPointF);

                    }
                }while (tempstr1 != null);

            }
            catch (IOException ex)
            {

                MessageBox.Show("This is a IO Exception :" + ex.Message);
            }

        }


        public  class CoordinateGroup
        {
            private PointF[] pointfs;

            public PointF[] Pointfs
            {
                get { return pointfs; }
                set { pointfs = value; }
            }

            public PointF this[int index]
            {
                get { return Pointfs[index]; }
                set { Pointfs[index] = value; }
            }

            public CoordinateGroup(PointF[] pointf)
            {
                this.pointfs = pointf;
            }

            public int GetCoordinateCount()
            {
                return this.pointfs.Count();
            }
        }

        public class HoleShape
        {
            private float holeSize;

            private int tOrder;

            private CoordinateGroup xyCoordinateGroup;

            private int count;

            public float HoleSize
            {
                get { return holeSize; }
                set { holeSize = value; }
            }

            public int TOrder
            {
                get { return tOrder; }
                set { tOrder = value; }
            }

            public CoordinateGroup XYCoordinateGroup
            {
                get { return xyCoordinateGroup; }
                set { xyCoordinateGroup = value; }
            }

            public int Count
            {
                get
                {
                    count = xyCoordinateGroup.GetCoordinateCount();
                    return count;
                }
            }

            public HoleShape(float dia,int tOrder,CoordinateGroup coordgp)
            {
                this.holeSize = dia;
                this.tOrder = tOrder;
                this.xyCoordinateGroup = coordgp;
                this.count = xyCoordinateGroup.GetCoordinateCount();
            }

        }

       public class SlotShape
        {
            private float slotWidth;

            private int tOrder;

            private CoordinateGroup xyCoordinateGroup;

            public int TOrder
            {
                get { return tOrder; }
                set { tOrder = value; }
            }

            public float SlotWidth
            {
                get { return slotWidth; }
                set { slotWidth = value; }
            }

            public CoordinateGroup XYCoordinateGroup
            {
                get { return xyCoordinateGroup; }
                set { xyCoordinateGroup = value; }
            }

            private int count;

            public int Count
            {
                get
                {
                    count = xyCoordinateGroup.GetCoordinateCount();
                    return count;
                }
            }
        }
    }
}

    