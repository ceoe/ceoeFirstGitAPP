using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


namespace TanChiShe
{
    class Bean
    {
        public Bean()
        {

        }

        private Point origin;
        public Point Origin
        {
            get { return origin; }
            set { origin = value; }

        }
        public void Display(Graphics g)
        {
            SolidBrush b = new SolidBrush(Color.Red);
            g.FillRectangle(b, origin.X, origin.Y, 5, 5);

        }
        public void UnDisplay(Graphics g)
        {
            SolidBrush b = new SolidBrush(Color.Ivory);
            g.FillRectangle(b, origin.X, origin.Y, 5, 5);
        }
    }

}
