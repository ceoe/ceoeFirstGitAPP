using System;
using System.Collections;
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
    public enum DrlUnit
    {
        Metric,Inch
    }

    public enum ZeroCompress
    {
        Leading,Trail,None
    }

   public class DrillTAPE
    {
        private DrlUnit drlUnit;
        private ZeroCompress zeroCompress;
        private short integerField;
        private short decimalDiatal;

        private float[] _toolslist;
        private int _totalNumofhole;

       private PointF minPointF;
       private PointF maxPointF;


       public List<HoleShape>  HoleList=new List<HoleShape>();
       public List<SlotShape>  SlotList=new List<SlotShape>();
       public List<CircleShape> CircleList = new List<CircleShape>();

        public HoleShape[] holeshape;
        public SlotShape[] slotshape;
        public CircleShape[] circleShapes;



        public DrillTAPE(string readTapepath)
        {

            GetFileFormateAndToolOrder(readTapepath);
            GetCoordinateAndShape(readTapepath);
            totalhit();
            GetMinMaxPointF();
        }
       public  class CoordinateGroup
        {
            private PointF[] pointfs;

            public PointF[] Pointfs
            {
                get { return pointfs; }
                set { pointfs = value; }
            }

           public PointF MinCoordPointF
           {
               get
               {
                   float minX=0, minY=0;
                   if (pointfs.Length>0)
                   {
                       minX = pointfs[0].X;
                       minY = pointfs[0].Y;

                       for (int i = 0; i < pointfs.Length; i++)
                       {
                           if (pointfs[i].X < minX)
                           {
                               minX = pointfs[i].X;
                           }
                           if (pointfs[i].Y < minY)
                           {
                               minY = pointfs[i].Y;
                           }
                       }
                   }
                   
                   return new PointF(minX,minY);
               }
           }

           public PointF MaxCoordPointF
           {
               get
               {
                   float maxX = 0, maxY = 0;
                   if (pointfs.Length > 0)
                   {
                       maxX = pointfs[0].X;
                       maxY = pointfs[0].Y;

                       for (int i = 0; i < pointfs.Length; i++)
                       {
                           if (pointfs[i].X > maxX)
                           {
                               maxX = pointfs[i].X;
                           }
                           if (pointfs[i].Y > maxY)
                           {
                               maxY = pointfs[i].Y;
                           }
                       }
                   }
                   return new PointF(maxX, maxY);
               }
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

       public int TotalNumofhole
       {
           get { return _totalNumofhole; }
       }

       public int KindofTools
       {
           get { return _toolslist.Length-1; }
       }

       public DrlUnit DrlUnit
       {
           get { return drlUnit; }
       }

       public ZeroCompress ZeroCompress
       {
           get { return zeroCompress; }
       }

       public PointF MinPointF
       {
           get { return minPointF; }
       }

       public PointF MaxPointF
       {
           get { return maxPointF; }
       }

       public void totalhit()
       {
           int _totalhit=0;
           foreach (HoleShape holeShape in HoleList)
           {
              _totalhit+= holeShape.Count;
           }
           foreach (var circleShape in CircleList)
           {
               _totalhit += circleShape.Count;
           }
           foreach (var slotShape in SlotList)
           {
               _totalhit += slotShape.Count;
           }
           this._totalNumofhole = _totalhit;
       }

       public void GetMinMaxPointF()
       {
           if (HoleList[0].Count>0)
           {
               minPointF = HoleList[0].XYCoordinateGroup.Pointfs[0];
               maxPointF = HoleList[0].XYCoordinateGroup.Pointfs[0];
           }
           foreach (HoleShape holeShape in HoleList)
           {
               if (maxPointF.X<holeShape.XYCoordinateGroup.MaxCoordPointF.X)
               {
                   maxPointF.X = holeShape.XYCoordinateGroup.MaxCoordPointF.X;
               }
               if (maxPointF.Y < holeShape.XYCoordinateGroup.MaxCoordPointF.Y)
               {
                   maxPointF.Y = holeShape.XYCoordinateGroup.MaxCoordPointF.Y;
               }

               if (minPointF.X > holeShape.XYCoordinateGroup.MinCoordPointF.X)
               {
                   minPointF.X = holeShape.XYCoordinateGroup.MinCoordPointF.X;
               }
               if (minPointF.Y > holeShape.XYCoordinateGroup.MinCoordPointF.Y)
               {
                   minPointF.Y = holeShape.XYCoordinateGroup.MinCoordPointF.Y;
               }
           }
           foreach (var circleShape in CircleList)
           {
               if (maxPointF.X < circleShape.CircleCoordinateGroup.MaxCoordPointF.X)
               {
                   maxPointF.X = circleShape.CircleCoordinateGroup.MaxCoordPointF.X;
               }
               if (maxPointF.Y < circleShape.CircleCoordinateGroup.MaxCoordPointF.Y)
               {
                   maxPointF.Y = circleShape.CircleCoordinateGroup.MaxCoordPointF.Y;
               }

               if (minPointF.X > circleShape.CircleCoordinateGroup.MinCoordPointF.X)
               {
                   minPointF.X = circleShape.CircleCoordinateGroup.MinCoordPointF.X;
               }
               if (minPointF.Y > circleShape.CircleCoordinateGroup.MinCoordPointF.Y)
               {
                   minPointF.Y = circleShape.CircleCoordinateGroup.MinCoordPointF.Y;
               }
           }
           foreach (var slotShape in SlotList)
           {
               if (maxPointF.X < slotShape.StartCoordinateGroup.MaxCoordPointF.X)
               {
                   maxPointF.X = slotShape.StartCoordinateGroup.MaxCoordPointF.X;
               }
               if (maxPointF.Y < slotShape.StartCoordinateGroup.MaxCoordPointF.Y)
               {
                   maxPointF.Y = slotShape.StartCoordinateGroup.MaxCoordPointF.Y;
               }

               if (minPointF.X > slotShape.StartCoordinateGroup.MinCoordPointF.X)
               {
                   minPointF.X = slotShape.StartCoordinateGroup.MinCoordPointF.X;
               }
               if (minPointF.Y > slotShape.StartCoordinateGroup.MinCoordPointF.Y)
               {
                   minPointF.Y = slotShape.StartCoordinateGroup.MinCoordPointF.Y;
               }
           }
          
       }

       public class CircleCoordinateGroup
        {
            private PointF[] _pointfs;

            private float[] _drlcircleDia;

            private int count;


            public PointF[] Pointfs
            {
                get { return _pointfs; }
              
            }

            public float[] CircleDia
            {
                get { return _drlcircleDia; }
            }

           public int Count
           {
               get { return count; }
           }


           public CircleCoordinateGroup(PointF[] pointf,float[] circleDia)
            {
                this._pointfs = pointf;
                this._drlcircleDia = circleDia;
               this.count = _pointfs.Count();
            }

            public int GetCoordinateCount()
            {
                return this.Pointfs.Count();
            }

            public PointF MinCoordPointF
            {
                get
                {
                    float minX = 0, minY = 0;
                    if (_pointfs.Length > 0)
                    {
                        minX = _pointfs[0].X;
                        minY = _pointfs[0].X;
                        for (int i = 0; i < _pointfs.Length; i++)
                        {
                            if (_pointfs[i].X < minX)
                            {
                                minX = _pointfs[i].X;
                            }
                            if (_pointfs[i].Y < minY)
                            {
                                minY = _pointfs[i].Y;
                            }
                        }
                    }
                    return new PointF(minX, minY);
                }
            }

            public PointF MaxCoordPointF
            {
                get
                {
                    float maxX = 0, maxY = 0;
                    if (_pointfs.Length > 0)
                    {
                        maxX = _pointfs[0].X;
                        maxY = _pointfs[0].X;
                        for (int i = 0; i < _pointfs.Length; i++)
                        {
                            if (_pointfs[i].X > maxX)
                            {
                                maxX = _pointfs[i].X;
                            }
                            if (_pointfs[i].Y > maxY)
                            {
                                maxY = _pointfs[i].Y;
                            }
                        }
                    }
                    return new PointF(maxX, maxY);
                }
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
            private float _driBitDia;

            private int _tOrder;

            private CoordinateGroup _startCoordinateGroup;

            private CoordinateGroup _endCoordinateGroup;

           public SlotShape(float Dia,int Torder,CoordinateGroup startpointGP,CoordinateGroup endpointGP)
           {
               this._driBitDia = Dia;
               this._tOrder = Torder;
               this._startCoordinateGroup = startpointGP;
               this._endCoordinateGroup = endpointGP;
           }

            public int TOrder
            {
                get { return _tOrder; }
                set { _tOrder = value; }
            }

            public float DriBitDia
            {
                get { return _driBitDia; }
                set { _driBitDia = value; }
            }

            public CoordinateGroup StartCoordinateGroup
            {
                get { return _startCoordinateGroup; }
                set { _startCoordinateGroup = value; }
            }

            private int count;

            public int Count
            {
                get
                {
                    count = _startCoordinateGroup.GetCoordinateCount();
                    return count;
                }
            }

           public CoordinateGroup EndCoordinateGroup
           {
               get { return _endCoordinateGroup; }
               set { _endCoordinateGroup = value; }
           }
        }


       public class CircleShape
       {
           private float _driBitDia;

           private int tOrder;

           private int count;

           private CircleCoordinateGroup _circleCoordinateGroup;

           public CircleShape(float Dia,int Torder,CircleCoordinateGroup circleCooodgp)
           {
               this._driBitDia = Dia;
               this.tOrder = Torder;
               this._circleCoordinateGroup = circleCooodgp;
               this.count = _circleCoordinateGroup.Count;
           }

           public int TOrder
           {
               get { return tOrder; }
               set { tOrder = value; }
           }

           public int Count
           {
               get { return this.count; }
           }

           public float DriBitDia
           {
               get { return _driBitDia; }
               set { _driBitDia = value; }
           }

           public CircleCoordinateGroup CircleCoordinateGroup
           {
               get { return _circleCoordinateGroup; }
               set { _circleCoordinateGroup = value; }
           }

           }

       public void GetFileFormateAndToolOrder(string readTapepath)
       {

           float [] tOrderList=new float[256];
           Stack<float> tDiaStack=new Stack<float>();
           Stack<int> tordStack=new Stack<int>();
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
                       Regex rgUnit = new Regex(@"METRIC|INCH");
                       Regex rgZeroCompress = new Regex(@"TZ|LZ|NONE");
                       Match unitmatchs = rgUnit.Match(tempstr1);
                       if (unitmatchs.Success)
                       {
                           if (unitmatchs.Value.ToUpper().Equals("METRIC"))
                           {
                               this.drlUnit = DrlUnit.Metric;
                           }
                           if (unitmatchs.Value.ToUpper().Equals("INCH"))
                           {
                               this.drlUnit = DrlUnit.Inch;
                           }
                       }
                       Match zeroMatch = rgZeroCompress.Match(tempstr1);
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
                       Regex rgTorderstr = new Regex(@"T(?<Torder>\d{1,2})C(?<Diameter>\d{1,2}\.\d*)", RegexOptions.IgnoreCase | RegexOptions.Singleline | RegexOptions.IgnorePatternWhitespace);
                       Match tOrdermatches = rgTorderstr.Match(tempstr1);
                       if (tOrdermatches.Length > 0)
                       {
                          
                           tOrderList[(Convert.ToInt32(tOrdermatches.Result("${Torder}")))] = (Convert.ToSingle(tOrdermatches.Result("${Diameter}")));
                           //Toolslist[Convert.ToInt32(tOrdermatches.Result("${Torder}"))] = Convert.ToSingle(tOrdermatches.Result("${Diameter}"));
                       }
                   }
               } while (tempstr1 != null);
           }
           catch (IOException ex)
           {

               MessageBox.Show("This is a IO Exception :" + ex.Message);
           }
           if (tOrderList.Count() > 0)
           {
               int listcount = 0;
               for (int i = tOrderList.Count()-1; i > 0; i--)
               {
                   if (tOrderList[i].CompareTo(0)!=0)
                   {
                       listcount = i+1;
                       break;
                   }
               }
               
               _toolslist = new float[listcount];

               for (int i = 0; i < listcount; i++)
               {
                   _toolslist[i] = tOrderList[i];
               }
           }

       }

       public void GetCoordinateAndShape(string readTapepath)
       {

           Regex rgx = new Regex(@"[X](\d{3}\.\d{3})", RegexOptions.IgnoreCase | RegexOptions.Singleline);
           Regex rgy = new Regex(@"[Y](\d{3}\.\d{3})", RegexOptions.IgnoreCase | RegexOptions.Singleline);

           List<Single> xFloats = new List<Single>();
           List<Single> yFloats = new List<Single>();
           string tempstr1;

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


               Stack<PointF>  coordinateStack=new Stack<PointF>();

               Stack<PointF> startPointStack = new Stack<PointF>();
               Stack<PointF> endPointStack = new Stack<PointF>();

               Stack<PointF> circleCoordStack = new Stack<PointF>();
               Stack<float>  circleDiaStack=new Stack<float>();


               float size = 0;
               int tOrder = 0;
               var pointFArray = new List<PointF>();

               PointF[] slotstartPoint;
               PointF[] slotEndPoint;

              //格式化T序串 用于识别T序
               Regex rgTorderstr = new Regex(@"T(?<Torder>\d{1,2})", RegexOptions.IgnoreCase | RegexOptions.Singleline | RegexOptions.IgnorePatternWhitespace);

               do
               {
                   tempstr1 = m_SW.ReadLine();
                   Match toolsOrdermatchs = rgTorderstr.Match(tempstr1);

                 //若是T序字串匹配成功 
                   if (toolsOrdermatchs.Success)
                   {
                       //若是还是处于刚开始的T序，则只是简单赋值给  Torder和Size
                       if (tOrder == 0)
                         {
                           tOrder = Convert.ToInt32(toolsOrdermatchs.Result("${Torder}"));
                           size = _toolslist[tOrder];
                         }
                       else  //否则则需要先将前面T序中的形状和坐标保存 
                       {
                           if (pointFArray.Count > 0)
                           {
                               GeneratorHoleGroup(size, tOrder, pointFArray);
                           }

                           if (circleCoordStack.Count > 0)
                           {

                               GeneratorCircleHoleGroup(size, tOrder, circleCoordStack, circleDiaStack);
                           }
                           if (startPointStack.Count > 0)
                           {
                               GeneratorSlotHoleGroup(size, tOrder, startPointStack, endPointStack);
                           }
                           // 再将当前新T序值和T直径改写。
                           tOrder = Convert.ToInt32(toolsOrdermatchs.Result("${Torder}"));
                           size = _toolslist[tOrder];
                       }
                  }
                   //T序字串匹配不成功，则进行XY坐标格式匹配
                   Regex rg = new Regex(@"([xyXY]\d+)");
                   if (rg.IsMatch(tempstr1))
                   {

                       //格式化坐标串
                       Regex rg2 = new Regex(@"([xyXY]\d{6})0*");
                       Regex rg3 = new Regex(@"([xyXY]\d{3})(\d{3})");

                       string tempstr2 = FormattiongModleXYCoordinateToMetric3d3(tempstr1);
                       if (tempstr2.Contains("G84")||tempstr2.Contains("G85"))
                       {
                           if (tempstr2.Contains("G84"))
                           {
                               //G84 Circle Shape 坐标及 Circle Diameter 识别。
                               Regex rgG84Code =
                                   new Regex(@"X(?<xCoord>\d{3}.\d{3})Y(?<yCoord>\d{3}.\d{3})G84X(?<Diameter>\d{3}.\d{3})",
                                       RegexOptions.IgnoreCase | RegexOptions.Singleline |
                                       RegexOptions.IgnorePatternWhitespace);

                               Match G84Match = rgG84Code.Match(tempstr2);
                               if (G84Match.Success)
                               {
                                   PointF temPointF = new PointF(Convert.ToSingle(G84Match.Groups[1].ToString()),
                                       Convert.ToSingle(G84Match.Groups[2].ToString()));
                                   circleCoordStack.Push(temPointF);
                                   circleDiaStack.Push(Convert.ToSingle(G84Match.Groups[3].ToString()));
                               }
                           }

                           if (tempstr2.Contains("G85"))
                           {
                               //G85 SLOT Shape Start End  坐标识别。
                               Regex rgG85Code =
                                   new Regex(@"X(?<stxCoord>\d{3}.\d{3})Y(?<styCoord>\d{3}.\d{3})G85X(?<endxCoord>\d{3}.\d{3})Y(?<endyCoord>\d{3}.\d{3})",
                                       RegexOptions.IgnoreCase | RegexOptions.Singleline | RegexOptions.IgnorePatternWhitespace);

                               Match G85Match = rgG85Code.Match(tempstr2);
                               if (G85Match.Success)
                               {
                                   var stPointF = new PointF(Convert.ToSingle(G85Match.Groups[1].ToString()), Convert.ToSingle(G85Match.Groups[2].ToString()));
                                   var endPointF = new PointF(Convert.ToSingle(G85Match.Groups[3].ToString()), Convert.ToSingle(G85Match.Groups[4].ToString()));
                                   startPointStack.Push(stPointF);
                                   endPointStack.Push(endPointF);
                               }
                           }
                       }else
                       {
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
                           //coordinateStack.Push(temPointF); //入坐标栈·
                           pointFArray.Add(temPointF);
                       }

                   }
               } while (!tempstr1.Equals("M30"));

               if (pointFArray.Count > 0)
               {
                   GeneratorHoleGroup(size, tOrder, pointFArray);
               }

               if (circleCoordStack.Count > 0)
               {

                   GeneratorCircleHoleGroup(size, tOrder, circleCoordStack, circleDiaStack);
               }
               if (startPointStack.Count>0)
               {
                   GeneratorSlotHoleGroup(size,tOrder,startPointStack,endPointStack);
               }
           }
           catch (IOException ex)
           {

               MessageBox.Show("This is a IO Exception :" + ex.Message);
           }

       }

       protected void GeneratorSlotHoleGroup(float size, int tOrder, Stack<PointF> startPointFs,Stack<PointF> endPointFs)
       {
           var startP = new PointF[startPointFs.Count];
           var endP = new PointF[endPointFs.Count];
           int k = startPointFs.Count;
           for (int i = 0; i < k; i++)
           {
               startP[i] = startPointFs.Pop();
               endP[i] = endPointFs.Pop();
           }

           var SlotShape = new SlotShape(size, tOrder, new CoordinateGroup(startP), new CoordinateGroup(endP));
           SlotList.Add(SlotShape);
       }

       protected void GeneratorHoleGroup(float size,int tOrder,List<PointF> pointFArray)
       {
           PointF [] temPointFs = pointFArray.ToArray();
           CoordinateGroup xyCoordgp = new CoordinateGroup(temPointFs);
           HoleShape hs = new HoleShape(size, tOrder, xyCoordgp);
           HoleList.Add(hs);
           pointFArray.Clear();
       }

       protected void GeneratorCircleHoleGroup(float size, int tOrder, Stack<PointF> circleCoordStack, Stack<float> circleDiaStack)
       {
                           var temp = new PointF[circleCoordStack.Count];
                           var tempCircleDia = new float[circleCoordStack.Count];
                            int k = circleCoordStack.Count;
                           for (int i = 0; i < k; i++)
                           {
                               temp[i] = circleCoordStack.Pop();
                               tempCircleDia[i] = circleDiaStack.Pop();
                           }

                          var circleShape=new CircleShape(size,tOrder,new CircleCoordinateGroup(temp,tempCircleDia));
                          CircleList.Add(circleShape);
       }

       protected string FormattiongModleXYCoordinateToMetric3d3(string str1)
       {
           //格式化坐标串
           Regex rg = new Regex(@"([xyXY]\d+)");
           Regex rg2 = new Regex(@"([xyXY]\d{6})0*");
           Regex rg3 = new Regex(@"([xyXY]\d{3})(\d{3})");

           string tempstr2 = rg.Replace(str1, @"${1}00000");
           tempstr2 = rg2.Replace(tempstr2, @"${1}");
           tempstr2 = rg3.Replace(tempstr2, @"${1}.${2}");

           return tempstr2;
       }
    }
}

    