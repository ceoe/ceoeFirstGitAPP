using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Tank
{
    public abstract class Element
    {
        private  int x;  

        public int X
        {
            get { return x; }
            set { x = value; }
        }
        private  int y;

        public int Y
        {
            get { return y; }
            set { y = value; }
        }

        public Element(int x, int y)
        {
            this.x= x;
            this.y = y;
        }

        public abstract void Draw(Graphics g);
    }
}
