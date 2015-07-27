using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using Tank.Properties;

namespace Tank
{
    public class Wall : Module
    {
        private static Image imgWall = Resources.wall;

        public Wall(int x, int y)
            : base(x,y,imgWall.Width,imgWall.Height)
        {
        }

        public override void Draw(Graphics g)
        {
              g.DrawImage(imgWall, this.X, this.Y);         
        }
  
    }
}
