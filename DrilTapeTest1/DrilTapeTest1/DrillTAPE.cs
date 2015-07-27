using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace DrilTapeTest1
{
    public enum DrlUnit
    {
        Metric,
        Inch
    }

    public enum ZeroCompress
    {
        Leading,
        Trail,
        None
    }

    public class DrillTAPE
    {
        public List<CircleShapeCollections> CircleList = new List<CircleShapeCollections>();
        public List<HoleShapeCollections> HoleList = new List<HoleShapeCollections>();
        public List<SlotShapeCollections> SlotList = new List<SlotShapeCollections>();
        private float[] _toolslist;
        private int _totalNumofhole;
        public CircleShapeCollections[] CircleShapesCollections;
        private short decimalDiatal;
        private DrlUnit drlUnit;

        public HoleShapeCollections[] holeshape;
        private short integerField;
        private PointF maxPointF;
        private PointF minPointF;
        public SlotShapeCollections[] slotshape;
        private ZeroCompress zeroCompress;

        //粗糙度定义
        private static double _roughnessTol = 0.002;



        public DrillTAPE(string readTapepath)
        {
            GetFileFormateAndToolOrder(readTapepath);
            GetCoordinateAndShape(readTapepath);
            totalhit();
            GetMinMaxPointF();
        }

        public int TotalNumofhole
        {
            get { return _totalNumofhole; }
        }

        public int KindofTools
        {
            get { return _toolslist.Length - 1; }
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

        public double RoughnessTol
        {
            get { return _roughnessTol; }
            set { _roughnessTol = value; }
        }

        public void totalhit()
        {
            int _totalhit = 0;
            foreach (HoleShapeCollections holeShape in HoleList)
            {
                _totalhit += holeShape.Count;
            }
            foreach (CircleShapeCollections circleShape in CircleList)
            {
                _totalhit += circleShape.Count;
            }
            foreach (SlotShapeCollections slotShape in SlotList)
            {
                _totalhit += slotShape.Count;
            }
            _totalNumofhole = _totalhit;
        }

        public void GetMinMaxPointF()
        {
            if (HoleList[0].Count > 0)
            {
                minPointF = HoleList[0].XYCoordinateGroup.Pointfs[0];
                maxPointF = HoleList[0].XYCoordinateGroup.Pointfs[0];
            }
            foreach (HoleShapeCollections holeShape in HoleList)
            {
                if (maxPointF.X < holeShape.XYCoordinateGroup.MaxCoordPointF.X)
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
            foreach (CircleShapeCollections circleShape in CircleList)
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
            foreach (SlotShapeCollections slotShape in SlotList)
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

        public void GetFileFormateAndToolOrder(string readTapepath)
        {
            var tOrderList = new float[256];
            var tDiaStack = new Stack<float>();
            var tordStack = new Stack<int>();
            string tempstr1;

            try
            {
                var m_SW = new StreamReader(readTapepath);

                do
                {
                    tempstr1 = m_SW.ReadLine();
                    if (tempstr1 != null)
                    {
                        if (tempstr1.Contains("%"))
                        {
                            break;
                        }
                        var rgUnit = new Regex(@"METRIC|INCH");
                        var rgZeroCompress = new Regex(@"TZ|LZ|NONE");
                        Match unitmatchs = rgUnit.Match(tempstr1);
                        if (unitmatchs.Success)
                        {
                            if (unitmatchs.Value.ToUpper().Equals("METRIC"))
                            {
                                drlUnit = DrlUnit.Metric;
                            }
                            if (unitmatchs.Value.ToUpper().Equals("INCH"))
                            {
                                drlUnit = DrlUnit.Inch;
                            }
                        }
                        Match zeroMatch = rgZeroCompress.Match(tempstr1);
                        if (zeroMatch.Success)
                        {
                            if (zeroMatch.Value.ToUpper().Equals("LT"))
                            {
                                zeroCompress = ZeroCompress.Leading;
                            }
                            if (zeroMatch.Value.ToUpper().Equals("INCH"))
                            {
                                zeroCompress = ZeroCompress.Trail;
                            }
                            if (zeroMatch.Value.ToUpper().Equals("NONE"))
                            {
                                zeroCompress = ZeroCompress.Leading;
                            }
                        }
                        var rgTorderstr = new Regex(@"T(?<Torder>\d{1,2})C(?<Diameter>\d{1,2}\.\d*)",
                            RegexOptions.IgnoreCase | RegexOptions.Singleline | RegexOptions.IgnorePatternWhitespace);
                        Match tOrdermatches = rgTorderstr.Match(tempstr1);
                        if (tOrdermatches.Length > 0)
                        {
                            tOrderList[(Convert.ToInt32(tOrdermatches.Result("${Torder}")))] =
                                (Convert.ToSingle(tOrdermatches.Result("${Diameter}")));
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
                for (int i = tOrderList.Count() - 1; i > 0; i--)
                {
                    if (tOrderList[i].CompareTo(0) != 0)
                    {
                        listcount = i + 1;
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
            var rgx = new Regex(@"[X](\d{3}\.\d{3})", RegexOptions.IgnoreCase | RegexOptions.Singleline);
            var rgy = new Regex(@"[Y](\d{3}\.\d{3})", RegexOptions.IgnoreCase | RegexOptions.Singleline);

            var xFloats = new List<Single>();
            var yFloats = new List<Single>();
            string tempstr1;

            try
            {
                var m_SW = new StreamReader(readTapepath);


                do
                {
                    tempstr1 = m_SW.ReadLine();
                    if (tempstr1.Contains("%"))
                    {
                        break;
                    }
                } while (tempstr1 != null);


                var coordinateStack = new Stack<PointF>();

                var startPointStack = new Stack<PointF>();
                var endPointStack = new Stack<PointF>();

                var circleCoordStack = new Stack<PointF>();
                var circleDiaStack = new Stack<float>();


                float size = 0;
                int tOrder = 0;
                var pointFArray = new List<PointF>();

                PointF[] slotstartPoint;
                PointF[] slotEndPoint;

                //格式化T序串 用于识别T序
                var rgTorderstr = new Regex(@"T(?<Torder>\d{1,2})",
                    RegexOptions.IgnoreCase | RegexOptions.Singleline | RegexOptions.IgnorePatternWhitespace);

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
                        else //否则则需要先将前面T序中的形状和坐标保存 
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
                    var rg = new Regex(@"([xyXY]\d+)");
                    if (rg.IsMatch(tempstr1))
                    {
                        //格式化坐标串
                        var rg2 = new Regex(@"([xyXY]\d{6})0*");
                        var rg3 = new Regex(@"([xyXY]\d{3})(\d{3})");

                        string tempstr2 = FormattiongModleXYCoordinateToMetric3d3(tempstr1);
                        if (tempstr2.Contains("G84") || tempstr2.Contains("G85"))
                        {
                            if (tempstr2.Contains("G84"))
                            {
                                //G84 Circle Shape 坐标及 Circle Diameter 识别。
                                var rgG84Code =
                                    new Regex(
                                        @"X(?<xCoord>\d{3}.\d{3})Y(?<yCoord>\d{3}.\d{3})G84X(?<Diameter>\d{3}.\d{3})",
                                        RegexOptions.IgnoreCase | RegexOptions.Singleline |
                                        RegexOptions.IgnorePatternWhitespace);

                                Match G84Match = rgG84Code.Match(tempstr2);
                                if (G84Match.Success)
                                {
                                    var temPointF = new PointF(Convert.ToSingle(G84Match.Groups[1].ToString()),
                                        Convert.ToSingle(G84Match.Groups[2].ToString()));
                                    circleCoordStack.Push(temPointF);
                                    circleDiaStack.Push(Convert.ToSingle(G84Match.Groups[3].ToString()));
                                }
                            }

                            if (tempstr2.Contains("G85"))
                            {
                                //G85 SLOT Shape Start End  坐标识别。
                                var rgG85Code =
                                    new Regex(
                                        @"X(?<stxCoord>\d{3}.\d{3})Y(?<styCoord>\d{3}.\d{3})G85X(?<endxCoord>\d{3}.\d{3})Y(?<endyCoord>\d{3}.\d{3})",
                                        RegexOptions.IgnoreCase | RegexOptions.Singleline |
                                        RegexOptions.IgnorePatternWhitespace);

                                Match G85Match = rgG85Code.Match(tempstr2);
                                if (G85Match.Success)
                                {
                                    var stPointF = new PointF(Convert.ToSingle(G85Match.Groups[1].ToString()),
                                        Convert.ToSingle(G85Match.Groups[2].ToString()));
                                    var endPointF = new PointF(Convert.ToSingle(G85Match.Groups[3].ToString()),
                                        Convert.ToSingle(G85Match.Groups[4].ToString()));
                                    startPointStack.Push(stPointF);
                                    endPointStack.Push(endPointF);
                                }
                            }
                        }
                        else
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
                            var temPointF = new PointF(xFloats[xFloats.Count - 1], yFloats[yFloats.Count - 1]);
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
                if (startPointStack.Count > 0)
                {
                    GeneratorSlotHoleGroup(size, tOrder, startPointStack, endPointStack);
                }
            }
            catch (IOException ex)
            {
                MessageBox.Show("This is a IO Exception :" + ex.Message);
            }
        }

        protected void GeneratorSlotHoleGroup(float size, int tOrder, Stack<PointF> startPointFs,
            Stack<PointF> endPointFs)
        {
            var startP = new PointF[startPointFs.Count];
            var endP = new PointF[endPointFs.Count];
            int k = startPointFs.Count;
            for (int i = 0; i < k; i++)
            {
                startP[i] = startPointFs.Pop();
                endP[i] = endPointFs.Pop();
            }

            var SlotShape = new SlotShapeCollections(size, tOrder, new CoordinateGroup(startP), new CoordinateGroup(endP));
            SlotList.Add(SlotShape);
        }

        protected void GeneratorHoleGroup(float size, int tOrder, List<PointF> pointFArray)
        {
            PointF[] temPointFs = pointFArray.ToArray();
            var xyCoordgp = new CoordinateGroup(temPointFs);
            var hs = new HoleShapeCollections(size, tOrder, xyCoordgp);
            HoleList.Add(hs);
            pointFArray.Clear();
        }

        protected void GeneratorCircleHoleGroup(float size, int tOrder, Stack<PointF> circleCoordStack,
            Stack<float> circleDiaStack)
        {
            var temp = new PointF[circleCoordStack.Count];
            var tempCircleDia = new float[circleCoordStack.Count];
            int k = circleCoordStack.Count;
            for (int i = 0; i < k; i++)
            {
                temp[i] = circleCoordStack.Pop();
                tempCircleDia[i] = circleDiaStack.Pop();
            }

            var circleShape = new CircleShapeCollections(size, tOrder, new CircleCoordinateGroup(temp, tempCircleDia));
            CircleList.Add(circleShape);
        }

        protected string FormattiongModleXYCoordinateToMetric3d3(string str1)
        {
            //格式化坐标串
            var rg = new Regex(@"([xyXY]\d+)");
            var rg2 = new Regex(@"([xyXY]\d{6})0*");
            var rg3 = new Regex(@"([xyXY]\d{3})(\d{3})");

            string tempstr2 = rg.Replace(str1, @"${1}00000");
            tempstr2 = rg2.Replace(tempstr2, @"${1}");
            tempstr2 = rg3.Replace(tempstr2, @"${1}.${2}");

            return tempstr2;
        }

        public class CircleCoordinateGroup
        {
            private readonly float[] _drlcircleDia;
            private readonly PointF[] _pointfs;

            private readonly int count;

            public CircleCoordinateGroup(PointF[] pointf, float[] circleDia)
            {
                _pointfs = pointf;
                _drlcircleDia = circleDia;
                count = _pointfs.Count();
            }


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

            public int GetCoordinateCount()
            {
                return Pointfs.Count();
            }
        }
        public class CoordinateGroup
        {
            private PointF[] pointfs;

            public CoordinateGroup(PointF[] pointf)
            {
                pointfs = pointf;
            }

            public PointF[] Pointfs
            {
                get { return pointfs; }
                set { pointfs = value; }
            }

            public PointF MinCoordPointF
            {
                get
                {
                    float minX = 0, minY = 0;
                    if (pointfs.Length > 0)
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

                    return new PointF(minX, minY);
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


            public int GetCoordinateCount()
            {
                return pointfs.Count();
            }
        }
        public class CircleShapeCollections
        {
            private readonly int count;

            private CircleCoordinateGroup _circleCoordinateGroup;

            public CircleShapeCollections(float Dia, int Torder, CircleCoordinateGroup circleCooodgp)
            {
                DriBitDia = Dia;
                TOrder = Torder;
                _circleCoordinateGroup = circleCooodgp;
                count = _circleCoordinateGroup.Count;
            }

            public int TOrder { get; set; }

            public int Count
            {
                get { return count; }
            }

            public float DriBitDia { get; set; }

            public CircleCoordinateGroup CircleCoordinateGroup
            {
                get { return _circleCoordinateGroup; }
                set { _circleCoordinateGroup = value; }
            }
        }

        public class HoleShapeCollections
        {
            private int count;
            private CoordinateGroup xyCoordinateGroup;

            public HoleShapeCollections(float dia, int tOrder, CoordinateGroup coordgp)
            {
                HoleSize = dia;
                this.TOrder = tOrder;
                xyCoordinateGroup = coordgp;
                count = xyCoordinateGroup.GetCoordinateCount();
            }

            public float HoleSize { get; set; }

            public int TOrder { get; set; }

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
        }

        public class SignelSlotCoordinatesGroup
        {
           
            private List<PointF> SequenceyListPointF;

            private SlotDriTree slotDriTree;

            private class Node
            {
                private PointF _data;
                private Node _left;
                private Node _right;

                public PointF Data
                {
                    get { return _data; }
                }

                public Node Left
                {
                    get { return _left; }
                    set { _left = value; }
                }

                public Node Right
                {
                    get { return _right; }
                    set { _right = value; }
                }

                public Node(PointF pointf)
                {
                    this._data = pointf;
                }
            }

            private class SlotDriTree
            {
               
                private List<PointF> orgList;
                private Node _head;

                private List<PointF> _pointFListByOrder = new List<PointF>();

                public Node Head
                {
                    get { return _head; }
                }

                public List<PointF> PointFListByOrder
                {
                    get { return _pointFListByOrder; }
                }

                public SlotDriTree(List<PointF> pointfList)
                {
                    orgList = pointfList;
                    _head=new Node(pointfList[0]);
                }
                private void AddNode(Node parent, int index)
                {
                    int leftindex = 2*index + 1;
                    if (leftindex<orgList.Count)
                    {
                       parent.Left=new Node(orgList[leftindex]);
                        AddNode(parent.Left,leftindex);
                    }

                    int rightindex = 2*index + 2;
                    if (rightindex<orgList.Count)
                    {
                        parent.Right=new Node(orgList[rightindex]);
                        AddNode(parent.Right,rightindex);
                    }
                }

                public void PreOrder(Node node)
                {
                    if (node!=null)
                    {
                        PointFListByOrder.Add(node.Data);

                        PreOrder(node.Left);
                        PreOrder(node.Right);
                       
                    }
                }

                public void MidOrder(Node node)
                {
                    if (node != null)
                    {
                        MidOrder(node.Left);

                        PointFListByOrder.Add(node.Data);
                        MidOrder(node.Right);

                    }
                }
                public void AfterOrder(Node node)
                {
                    if (node != null)
                    {
                       AfterOrder(node.Left);
                        AfterOrder(node.Right);
                        PointFListByOrder.Add(node.Data);


                    }
                }
            }


            //构造函数 给予起点和终点  自行生成一个原始list，一个二叉树，之后实现这个二叉树的先，中，后序遍历，遍历的结果存储在
            //另外一个list中。
          
            public SignelSlotCoordinatesGroup(PointF startPointF, PointF endPointF)
            {
               #region  处理孔位重在一起的slot（特殊情况）
                if ((startPointF.X.Equals(endPointF.X)) && (startPointF.Y.Equals(endPointF.Y)))
                {
                    SequenceyListPointF[0] = startPointF;
                    SequenceyListPointF[1] = endPointF;
                }
                #endregion

                #region 处理在X轴不变上的Slot

                if ((startPointF.X.Equals(endPointF.X)) && (!(startPointF.Y.Equals(endPointF.Y))))
                {

                    double eventimes = (startPointF.Y - endPointF.Y) / _roughnessTol;
                    int divby = (int)Math.Ceiling(eventimes);

                    divby = (Convert.ToBoolean(divby % 2) )? (divby + 1) : divby;
                    double optRoughnessStep = (startPointF.Y - endPointF.Y) / divby;
                    PointF p = new PointF();

                    for (int i = 0; i < divby; i++)
                    {
                        p.X = startPointF.X;
                        p.Y = startPointF.Y + Convert.ToSingle(optRoughnessStep * i);
                        SequenceyListPointF.Add(p);
                    }
                }

                #endregion

                #region 处理在Y轴不变上的Slot

                if ((startPointF.Y.Equals(endPointF.Y)) && (!(startPointF.X.Equals(endPointF.X))))
                {

                    double eventimes = (startPointF.X - endPointF.X) / _roughnessTol;
                    int divby =(int) Math.Ceiling(eventimes);
                    divby = Convert.ToBoolean(divby % 2) ? (divby + 1) : divby;
                    double optRoughnessStep = (startPointF.X - endPointF.X) / divby;
                    PointF p = new PointF();

                    for (int i = 0; i < divby; i++)
                    {
                        p.Y = startPointF.Y;
                        p.X = startPointF.X + Convert.ToSingle(optRoughnessStep * i);
                        SequenceyListPointF.Add(p);
                    }
                }

                #endregion

                slotDriTree = new SlotDriTree(SequenceyListPointF);
                slotDriTree.PreOrder(slotDriTree.Head);
            }

            public List<PointF> GetTreebyOrder()
            {
                if (slotDriTree!=null)
                {
                    slotDriTree.PreOrder(slotDriTree.Head);
                    return slotDriTree.PointFListByOrder;
                }
                return null;

            }


        }

        public class SlotShapeCollections
        {
            private CoordinateGroup _startCoordinateGroup;
            private int count;
            
          
            public SlotShapeCollections(float Dia, int Torder, CoordinateGroup startpointGP, CoordinateGroup endpointGP)
            {
                DriBitDia = Dia;
                TOrder = Torder;
                _startCoordinateGroup = startpointGP;
                EndCoordinateGroup = endpointGP;
            }


            public int TOrder { get; set; }

            public float DriBitDia { get; set; }

            public CoordinateGroup StartCoordinateGroup
            {
                get { return _startCoordinateGroup; }
                set { _startCoordinateGroup = value; }
            }

            public int Count
            {
                get
                {
                    count = _startCoordinateGroup.GetCoordinateCount();
                    return count;
                }
            }

            public CoordinateGroup EndCoordinateGroup { get; set; }
        }


        public class Testemgu
        {
            public unsafe Bitmap ToThinner(Bitmap srcImg)
            {
                int iw = srcImg.Width;
                int ih = srcImg.Height;
                bool bModified;    //二值图像修改标志 
                bool bCondition1;   //细化条件1标志
                bool bCondition2;   //细化条件2标志
                bool bCondition3;   //细化条件3标志
                bool bCondition4;   //细化条件4标志
                int nCount;

                //5X5像素块
                byte[,] neighbour = new byte[5, 5];
                //新建临时存储图像
                Bitmap NImg = new Bitmap(iw, ih, srcImg.PixelFormat);

                bModified = true; //细化修改标志, 用作循环条件
                BitmapData dstData = srcImg.LockBits(new Rectangle(0, 0, iw, ih), ImageLockMode.ReadWrite,
                    srcImg.PixelFormat);
                var data = (byte*)(dstData.Scan0);
                //将图像转换为0,1二值得图像;            
                int step = dstData.Stride;
                for (int i = 0; i < dstData.Height; i++)
                {
                    for (int j = 0; j < dstData.Width; j++)
                    {
                        if (data[i * step + j] > 128)
                            data[i * step + j] = 0;
                        else
                            data[i * step + j] = 1;
                    }
                }

                BitmapData dstData1 = NImg.LockBits(new Rectangle(0, 0, iw, ih), ImageLockMode.ReadWrite, NImg.PixelFormat);

                var data1 = (byte*)(dstData1.Scan0);

                int step1 = dstData1.Stride;
                //细化循环开始
                while (bModified)
                {
                    bModified = false;
                    //初始化临时二值图像NImg
                    for (int i = 0; i < dstData1.Height; i++)
                    {
                        for (int j = 0; j < dstData1.Width; j++)
                        {
                            data1[i * step1 + j] = 0;
                        }
                    }
                    for (int i = 2; i < ih - 2; i++)
                    {
                        for (int j = 2; j < iw - 2; j++)
                        {
                            bCondition1 = false;
                            bCondition2 = false;
                            bCondition3 = false;
                            bCondition4 = false;
                            if (data[i * step + j] == 0)
                                //若图像的当前点为白色，则跳过
                                continue;
                            for (int k = 0; k < 5; k++)
                            {
                                //取以当前点为中心的5X5块
                                for (int l = 0; l < 5; l++)
                                {
                                    //1代表黑色, 0代表白色
                                    //neighbour[k, l] = bw[i + k - 2, j + l - 2];
                                    neighbour[k, l] = data[(i + k - 2) * step + (j + l - 2)];
                                }
                            }

                            //(1)判断条件2<=n(p)<=6
                            nCount = neighbour[1, 1] + neighbour[1, 2] + neighbour[1, 3] + neighbour[2, 1] + neighbour[2, 3] + neighbour[3, 1] + neighbour[3, 2] + neighbour[3, 3];
                            
                            if (nCount >= 2 && nCount <= 6)
                                bCondition1 = true;
                            else
                            {
                                data1[i * step1 + j] = 1;
                                continue;
                                //跳过, 加快速度
                            }

                            //(2)判断s(p)=1 
                            nCount = 0;
                            if (neighbour[2, 3] == 0 && neighbour[1, 3] == 1)
                                nCount++;
                            if (neighbour[1, 3] == 0 && neighbour[1, 2] == 1)
                                nCount++;
                            if (neighbour[1, 2] == 0 && neighbour[1, 1] == 1)
                                nCount++;
                            if (neighbour[1, 1] == 0 && neighbour[2, 1] == 1)
                                nCount++;
                            if (neighbour[2, 1] == 0 && neighbour[3, 1] == 1)
                                nCount++;
                            if (neighbour[3, 1] == 0 && neighbour[3, 2] == 1)
                                nCount++;
                            if (neighbour[3, 2] == 0 && neighbour[3, 3] == 1)
                                nCount++;
                            if (neighbour[3, 3] == 0 && neighbour[2, 3] == 1)
                                nCount++;
                            if (nCount == 1)
                                bCondition2 = true;
                            else
                            {
                                data1[i * step1 + j] = 1;
                                continue;
                            }

                            //(3)判断p0*p2*p4=0 or s(p2)!=1

                            if (neighbour[2, 3] * neighbour[1, 2] * neighbour[2, 1] == 0)
                                bCondition3 = true;
                            else
                            {
                                nCount = 0;
                                if (neighbour[0, 2] == 0 && neighbour[0, 1] == 1)
                                    nCount++;
                                if (neighbour[0, 1] == 0 && neighbour[1, 1] == 1)
                                    nCount++;
                                if (neighbour[1, 1] == 0 && neighbour[2, 1] == 1)
                                    nCount++;
                                if (neighbour[2, 1] == 0 && neighbour[2, 2] == 1)
                                    nCount++;
                                if (neighbour[2, 2] == 0 && neighbour[2, 3] == 1)
                                    nCount++;
                                if (neighbour[2, 3] == 0 && neighbour[1, 3] == 1)
                                    nCount++;
                                if (neighbour[1, 3] == 0 && neighbour[0, 3] == 1)
                                    nCount++;
                                if (neighbour[0, 3] == 0 && neighbour[0, 2] == 1)
                                    nCount++;
                                if (nCount != 1)

                                    //s(p2)!=1
                                    bCondition3 = true;
                                else
                                {
                                    data1[i * step1 + j] = 1;
                                    continue;
                                }
                            }
                            //(4)判断p2*p4*p6=0 or s(p4)!=1
                            if (neighbour[1, 2] * neighbour[2, 1] * neighbour[3, 2] == 0)
                                bCondition4 = true;
                            else
                            {
                                nCount = 0;
                                if (neighbour[1, 1] == 0 && neighbour[1, 0] == 1)
                                    nCount++;
                                if (neighbour[1, 0] == 0 && neighbour[2, 0] == 1)
                                    nCount++;
                                if (neighbour[2, 0] == 0 && neighbour[3, 0] == 1)
                                    nCount++;
                                if (neighbour[3, 0] == 0 && neighbour[3, 1] == 1)
                                    nCount++;
                                if (neighbour[3, 1] == 0 && neighbour[3, 2] == 1)
                                    nCount++;
                                if (neighbour[3, 2] == 0 && neighbour[2, 2] == 1)
                                    nCount++;
                                if (neighbour[2, 2] == 0 && neighbour[1, 2] == 1)
                                    nCount++;
                                if (neighbour[1, 2] == 0 && neighbour[1, 1] == 1)
                                    nCount++;
                                if (nCount != 1)
                                    //s(p4)!=1
                                    bCondition4 = true;
                            }
                            if (bCondition1 && bCondition2 && bCondition3 && bCondition4)
                            {
                                data1[i * step1 + j] = 0;
                                bModified = true;
                            }
                            else
                            {
                                data1[i * step1 + j] = 1;
                            }
                        }
                    }

                    //将细化了的临时图像bw_tem[w,h]copy到bw[w,h],完成一次细化

                    for (int i = 2; i < ih - 2; i++)
                        for (int j = 2; j < iw - 2; j++)
                            data[i * step + j] = data1[i * step1 + j];
                }

                for (int i = 2; i < ih - 2; i++)
                {
                    for (int j = 2; j < iw - 2; j++)
                    {
                        if (data[i * step + j] == 1)
                            data[i * step + j] = 0;
                        else
                            data[i * step + j] = 255;
                    }
                }
                srcImg.UnlockBits(dstData);
                NImg.UnlockBits(dstData1);
                return (srcImg);
            }


        }

    }
}