using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


namespace TanChiShe
{
    class Snake
    {
        ArrayList blockList;
        private int headNumber;
        private Point headPoint;
        private int direction = 1;

        public Snake()
        {

        }

        public Snake(Point vertex, int Count)
        {
            Block bb;
            Point p = new Point(vertex.X + 25, vertex.Y + 25);
            blockList = new ArrayList(Count);

            for (int i = 0; i < Count; i++)
            {
                p.X = p.X + 5;
                bb = new Block();
                bb.Origin = p;
                bb.Number = i + 1;
                blockList.Add(bb);
                if (i == Count - 1)
                {
                    headPoint = bb.Origin;
                }

                headNumber = Count;


            }
        }
        public Point getHeadPoint
        {
            get { return headPoint; }
        }
        public bool getHitSelf //只读蛇是否碰到墙或碰到自已属性
        {
            get
            {
                IEnumerator myEnumerator = blockList.GetEnumerator();//定义并实例化枚举接口


                try
                {
                    while (myEnumerator.MoveNext())
                    {
                        Block b = (Block)myEnumerator.Current;

                        if (b.Number != headNumber && b.Origin.Equals(headPoint))
                        {
                            return true;
                        }
                    }
                }
                catch (Exception e)
                {
                    System.Console.WriteLine(e.ToString());
                }

                return false;
            }
        }
        public int Direction
        {
            get { return direction; }
            set { direction = value; }
        }

        public void TurnDirection(int pDirection)
        {
            switch (direction)
            {
                case 0:

                    if (pDirection == 3)
                    {
                        direction = 3;
                    }

                    if (pDirection == 1)
                    {
                        direction = 1;
                    }

                    break;

                case 1:

                    if (pDirection == 0)
                    {
                        direction = 0;
                    }

                    if (pDirection == 2)
                    {
                        direction = 2;
                    }
                    break;

                case 2:

                    if (pDirection == 1)
                    {
                        direction = 1;
                    }

                    if (pDirection == 3)
                    {
                        direction = 3;
                    }

                    break;

                case 3:

                    if (pDirection == 0)
                    {
                        direction = 0;
                    }

                    if (pDirection == 2)
                    {
                        direction = 2;
                    }

                    break;
            }
        }

        public void Growth()
        {
            Block bb = new Block();
            Block b = new Block();
            IEnumerator myEnumberator = blockList.GetEnumerator();

            try
            {
                while (myEnumberator.MoveNext())
                {
                     b = (Block)myEnumberator.Current;
                    if (b.Number == headNumber)
                    {
                        int x = b.Origin.X;
                        int y = b.Origin.Y;

                        switch (direction)
                        {
                            case 0:
                                y = y - 5;
                                break;

                            case 1:
                                x = x + 5;
                                break;

                            case 2:
                                y = y + 5;
                                break;

                            case 3:
                                x = x - 5;
                                break;
                        }

                        Point headp = new Point(x, y);

                        bb.Origin = headp;

                        bb.Number = b.Number + 1;

                        blockList.Add(bb);
                        headNumber++;
                        headPoint = headp;
                    }
                }
            }

            catch (Exception e)
            {
                System.Console.WriteLine(e.ToString());
            }

        }

        public void Display(Graphics g)
        {
            try
            {
                Block b = new Block();
                b = (Block)blockList[0];
                b.UnDisplay(g);
                blockList.RemoveAt(0);
                Block bb = new Block();
                IEnumerator myEnumerator = blockList.GetEnumerator();

                while (myEnumerator.MoveNext())
                {
                    b = (Block)myEnumerator.Current;
                    b.Number--;
                    if (b.Number == (headNumber - 1))
                    {
                        int x = b.Origin.X;
                        int y = b.Origin.Y;
                        switch (direction)
                        {
                            case 0:
                                y = y - 5;
                                break;

                            case 1:
                                x = x + 5;
                                break;

                            case 2:
                                y = y + 5;
                                break;

                            case 3:
                                x = x - 5;
                                break;

                        }
                        Point headP = new Point(x, y);
                        bb.Origin = headP;
                        bb.Number = headNumber;
                        bb.Display(g);

                        headPoint = bb.Origin;
                    }
                    b.Display(g);

                }
                blockList.Add(bb);
            }

            catch (Exception e)
            {
                System.Console.WriteLine(e.ToString());
            }


        }

        public void UnDisplay(Graphics g)
        {
            try
            {
                Block bb = new Block();
                IEnumerator myEnumerator = blockList.GetEnumerator();

                while (myEnumerator.MoveNext())
                {
                    Block b = (Block)myEnumerator.Current;
                    b.UnDisplay(g);
                }
            }

            catch (Exception e)
            {
                System.Console.WriteLine(e.ToString());
            }

        }

        public void Reset(Point dian, int count)
        {
            Block bb;
            Point p = new Point(dian.X + 25, dian.Y + 25);
            blockList = new ArrayList(count);

            for (int i = 0; i < count; i++)
            {
                p.X = p.Y + 5;
                bb = new Block();
                bb.Number = i + 1;
                bb.Origin = p;
                blockList.Add(bb);
                if (i == count - 1)
                {
                    headPoint = bb.Origin;
                }
            }

            headNumber = count;
            direction = 1;
        }
    }
}
