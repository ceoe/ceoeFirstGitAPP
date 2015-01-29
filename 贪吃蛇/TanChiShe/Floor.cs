using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


namespace TanChiShe
{
        class Floor
        {
            public Floor(Point d)
            {
                dot = d;
                s=new Snake(d,10);
                bean1 = new Bean();
                bean1.Origin = new Point(d.X + 30, d.Y + 30);
            }
            private static int unit = 5;
            private int length = 80 * unit;
            private int width = 50 * unit;
            private Point dot;
            public  int score;
            private Snake s;
            private Bean bean1;
            public Snake S
            {
                get { return s; }
            }

            public void displaybean(Graphics g)
            {
                bean1.UnDisplay(g);
                bean1 = randombean();
                bean1.UnDisplay(g);
            }

            public void ReSet(Graphics g)
            {
                s.UnDisplay(g);
                s.Reset(dot, 10);
            }

            private Bean randombean()
            {
                Random random = new Random();
                int x = random.Next(length / unit - 2) + 1;
                int y = random.Next(width / unit - 2) + 1;
                Point d = new Point(dot.X + x * 5, dot.Y + y * 5);
                Bean bb = new Bean();
                bb.Origin = d;
                return bb;
            }

            public void Display(Graphics g)
            {
                Pen p = new Pen(Color.Red);
                g.DrawRectangle(p, dot.X, dot.Y, length, width);
                s.Display(g);
                CheckBean(g);
                bean1.Display(g);
            }

            public void CheckBean(Graphics g)
            {
                if (bean1.Origin.Equals(s.getHeadPoint))
                {
                    score = score + 10;
                    this.displaybean(g);
                    s.Growth();
                }
            }

            public bool CheckSnake()
            {
                if ( dot.X < s.getHeadPoint.X && s.getHeadPoint.X < (dot.X + length) - 5
                    && (dot.Y < s.getHeadPoint.Y && s.getHeadPoint.Y < (dot.Y + width) - 5) && !s.getHitSelf )
                {
                    return false;
                }

                else
                {
                    return true;
                }
            }
        }
    
}
