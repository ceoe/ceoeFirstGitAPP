using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using Tank.Properties;

namespace Tank
{
    class Equipment : Module
    {
        private static Image imgStar = Resources.star;
        private static Image imgBomb = Resources.bomb;
        private static Image imgTimer = Resources.timer;
        private int flag;
        public int Flag
        {
            get { return flag; }
            set { flag = value; }
        }
        public Equipment(int x,int y,int flag)
            : base(x, y, imgStar.Width, imgStar.Height)
        {
            this.flag = flag;
        }

        public override void Draw(Graphics g)
        {
            switch (flag)
            {
                case 0:
                    g.DrawImage(imgStar, this.X, this.Y);
                    break;
                case 1:
                    g.DrawImage(imgBomb, this.X, this.Y);
                    break;
                case 2:
                    g.DrawImage(imgTimer, this.X, this.Y);
                    break;
                default: break;
            }
         //   g.DrawImage(imgStar, this.X, this.Y);
        }
    }
}
