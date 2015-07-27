using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Tank
{
    public abstract class Module : Element
    {
        private int width;            //组件的长
        public int Width
        {
            get { return width; }
            set { width = value; }
        }
        private int height;          //组件的宽

        public int Height
        {
            get { return height; }
            set { height = value; }
        }
        public Module(int x, int y, int width, int height)
            : base(x, y)
        {
            this.Width = width;
            this.Height = height;
        }

        public Rectangle GetRectangle()
        {
            return new Rectangle(this.X, this.Y, this.Width, this.Height);
        }
    }
}
