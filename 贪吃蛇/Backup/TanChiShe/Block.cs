using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


namespace TanChiShe
{
     class Block
    {
        public Block()
        {

        }

        private int number;
        private Point origin;
        public int Number
        {
            get { return number; }
            set { number = value; }

        }

        public Point Origin
        {
            get { return origin; }
            set { origin = value; }
        }
        public void Display(Graphics g)
        {
            Pen p = new Pen(Color.RoyalBlue);
            g.DrawRectangle(p, origin.X, origin.Y, 5, 5);
        }
        public void UnDisplay(Graphics g)
        {
            Pen p = new Pen(Color.Ivory);
            g.DrawRectangle(p, origin.X, origin.Y, 5, 5);
        }

    }

}
