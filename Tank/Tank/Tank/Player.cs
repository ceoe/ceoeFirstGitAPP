using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using Tank.Properties;
namespace Tank
{
    public abstract class Player : Roles
    {
        protected bool dirU = false, dirD = false, dirL = false, dirR = false;   //分别用来表是上下左右4个方向
        protected bool isMove = false;      //是否在移动
        private int live = 2;      //坦克的数量
        public int Live
        {
            get { return live; }
            set { live = value; }
        }
        private int misLv = 0;    //子弹等级
        public int MisLv
        {
            get { return misLv; }
            set { misLv = value; }
        }
        private Image[] img = new Image[] { };
        public Player(int x,int y,int life,int speed,directions dir,Image [] img)
            : base(x, y, life, img[0].Width, img[0].Height, speed, dir)
        {
            this.img = img;
            BeBorn();
        }

        public override void Adjustdirection()        //调整方向
        {                                                                 //哪个方向的值为true,就设dir为哪个方向                  

            if (dirU && !dirD && !dirL && !dirR)
            {
                dir = directions.U;
            }

            else if (!dirU && dirD && !dirL && !dirR)
            {
                dir = directions.D;
            }

            else if (!dirU && !dirD && dirL && !dirR)
            {
                dir = directions.L;
            }

            else if (!dirU && !dirD && !dirL && dirR)
            {
                dir = directions.R;
            }
        }

        public override void Move()   //移动方法
        {
            
            if (!isMove)
            {
                return;      //如果没按方向键就返回,防止坦克自动移动
            }
            base.Move();
        }

        public override void Draw(Graphics g)    //画出坦克
        {
            if (BornTimer < 48)
            {
                BornTimer++;
                return;
            }
            if (live < 0)       //如果坦克数量没了把坦克移出可视区
            {
         
                return;
            }
            Move();
            switch (dir)              //按不同的方向在载不同的坦克图
            {
                case directions.U:
                    g.DrawImage(img[0], this.X, this.Y);
                    break;
                case directions.D:
                    g.DrawImage(img[1], this.X, this.Y);
                    break;
                case directions.L:
                    g.DrawImage(img[2], this.X, this.Y);
                    break;
                case directions.R:
                    g.DrawImage(img[3], this.X, this.Y);
                    break;
                default: break;
            }
        }

        public override void Fire()        //坦克开火
        {
            if (live >= 0)
            {
                Sound soundFire = new Sound(Resources.fire);
                soundFire.Play();
                switch (misLv)
                {
                    case 0:
                        Singleton.Instance.AddElement(new myMissile(this, 1, 10, 1));
                        break;
                    case 1:
                        Singleton.Instance.AddElement(new myMissile(this, 1, 15, 1));
                        break;
                    case 2:
                        Singleton.Instance.AddElement(new myMissile(this, 1, 20, 1));
                        break;
                }
            }
        }

        public void IsDead()
        {
            if (live == 0)
            {
                //spBlast.Play();
                Sound soundBlast = new Sound(Resources.blast);
                soundBlast.Play();
                Singleton.Instance.AddElement(new Blast(this.X - 25, this.Y - 25));       //加载爆炸图象
                live = -1;
                return;
            }
            if (this.Life <= 0 && live != 0)             //坦克死亡
            {
                //spBlast.Play();
                Sound soundBlast = new Sound(Resources.blast);
                soundBlast.Play();
                Singleton.Instance.AddElement(new Blast(this.X - 25, this.Y - 25));    //加载爆炸图象
                BornTimer = 0;
                BeBorn();
                live--;          //数量自减
                if (live > 1)
                {
                    this.Life++;
                }
            }
            
        }
        
        
    }
}
