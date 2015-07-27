using System;
using System.Collections.Generic;
using System.Text;
using Tank.Properties;
using System.Drawing;
namespace Tank
{
    class Born : Element
    {
        private int bornTimer = 0;
        private static Image[] imgBorn = new Image[]
        {
            Resources.born1,
            Resources.born2,
            Resources.born3,
            Resources.born4
        };
        public Born(int x, int y)
            : base(x, y)
        {
        }
        public override void Draw(Graphics g)
        {
            if (bornTimer < 48)
            {
                switch (bornTimer % 8)
                {
                    case 0:
                    case 1:
                        g.DrawImage(imgBorn[0],this.X,this.Y);
                        break;
                    case 2:                       
                    case 3:
                        g.DrawImage(imgBorn[1], this.X, this.Y);
                        break;
                    case 4:
                    case 5:
                        g.DrawImage(imgBorn[2], this.X, this.Y);
                        break;
                    case 6:
                    case 7:
                        g.DrawImage(imgBorn[3], this.X, this.Y);
                        break;
                    default: break;
                }
                bornTimer++;
            }
        }
    }
}
