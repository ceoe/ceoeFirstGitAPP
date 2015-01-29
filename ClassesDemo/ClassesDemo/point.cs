using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassesDemo
{
    class Point
    {
        private int x=-1;
        public int X {
            get { return x; }
            private set { x = value; } 
        }
        private int y=-1;
        public int Y
        {
            get { return y; }
            private set { y = value; }
        }

        public Point()
        {
            X = -1;
            Y = -1;

        }
        public Point(int x, int y)
        {
            X = x;
            Y = y;

        }

        
        public double Distance(Point p2)
        {
                //int diffx=(x2-x1)*(x2-x1);
                //int diffy = (y2 - y1) * (y2 - y1);

            int diffx = p2.x - x;
            int diffy = p2.y - y;
               return Math.Sqrt(diffx*diffx + diffy*diffy);

            
        }


    }
}
