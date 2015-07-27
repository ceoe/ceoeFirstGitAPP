using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using Tank.Properties;
namespace Tank
{
    public class myMissile : Missile
    {
        private static Image imgMyMissile=Resources.mymissile;

        public myMissile(Roles role, int life, int speed, int power)
            : base(role, life, imgMyMissile.Width, imgMyMissile.Height, speed, power)
        {
        }

        public override void Draw(Graphics g)
        {
           
            base.Move();
            g.DrawImage(imgMyMissile,this.X, this.Y);
        }
    }
}
