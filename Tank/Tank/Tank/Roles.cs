using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Tank
{
    public abstract class Roles : Member
    {

        public Roles(int x, int y, int life, int width, int height, int speed, directions dir)
            : base(x, y, life, width, height, speed, dir)
        {
        }

        private bool enable = true;       //是否可动
        public bool Enable
        {
            get { return enable; }
            set { enable = value; }
        }
        private int bornTimer=0;    //出生时间
        public int BornTimer
        {
            get { return bornTimer; }
            set { bornTimer = value; }
        }

        public override void Move()
        {
            base.Adjustdirection();
            if (this.X > 600) this.X = 600;
            if (this.X < 0) this.X = 0;
            if (this.Y > 600) this.Y = 600;
            if (this.Y < 0) this.Y = 0;

            if (this.X > 240 && this.X < 300 && this.Y >= 555)
            {
                this.X = 240;
            }
            else if (this.X < 360 && this.X > 300 && this.Y >= 555)
            {
                this.X = 360;
            }
            else if (this.X > 240 && this.X < 360 && this.Y >= 555)
            {
                this.Y = 555;
            }
        }
        public abstract void BeBorn();
        public abstract void Fire();
    }
}
