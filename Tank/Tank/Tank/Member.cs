using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Tank
{
    public abstract class Member : Element
    {
        public directions dir;      //对象的方向

        private int life;
        public int Life
        {
            get { return life; }
            set { life = value; }
        }

        private int speed;      //对象的速度
        public int Speed
        {
            get { return speed; }
            set { speed = value; }
        }

        private int width;            //对象的长
        public int Width
        {
            get { return width; }
            set { width = value; }
        }

        private int height;          //对象的宽
        public int Height
        {
            get { return height; }
            set { height = value; }
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="x">对象的x座标</param>
        /// <param name="y">对象的y座标</param>
        /// <param name="life">对象的生命</param>
        /// <param name="width">对象的长</param>
        /// <param name="height">对象的宽</param>
        /// <param name="speed">对象的速度</param>
        /// <param name="dir">对象的方向</param>
        public Member(int x, int y, int life, int width, int height, int speed, directions dir)
            : base(x, y)
        {
            this.dir = dir;
            this.life = life;
            this.speed = speed;
            this.width = width;
            this.height = height;
        }

        public abstract void Move();

        /// <summary>
        /// 获得对象的大小
        /// </summary>
        /// <returns></returns>
        public Rectangle GetRectangle() 
        {
            return new Rectangle(this.X, this.Y, Width, Height);
        }

        /// <summary>
        /// 调整对象的方向
        /// </summary>
        public virtual void Adjustdirection()
        {
            switch (dir)
            {
                case directions.U:
                    this.Y -= Speed;
                    break;
                case directions.L:
                    this.X -= Speed;
                    break;
                case directions.R:
                    this.X += Speed;
                    break;
                case directions.D:
                    this.Y += Speed;
                    break;
            }
        }
        
    }
}
