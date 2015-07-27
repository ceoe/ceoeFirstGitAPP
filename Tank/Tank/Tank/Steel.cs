using System;
using System.Collections.Generic;
using System.Text;
using Tank.Properties;
using System.Drawing;

namespace Tank
{
    class Steel : Module
    {
        private static Image imgSteel = Resources.steel;

        public Steel(int x, int y)
            : base(x, y,imgSteel.Width, imgSteel.Height)
        {
        }

        public override void Draw(Graphics g)
        {
              g.DrawImage(imgSteel, this.X, this.Y);         
        }
    }
}
