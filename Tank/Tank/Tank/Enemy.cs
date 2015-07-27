using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using Tank.Properties;
using System.Media;
namespace Tank
{
    public class Enemy : Roles      //敌人的类
    {
        private static Image[] imgEnemy1 = new Image[]    //敌人4个方向的图片
        {
            Resources.enemy1U,
            Resources.enemy1D,
            Resources.enemy1L,
            Resources.enemy1R
        };
        private static Image[] imgEnemy2 = new Image[]    //敌人4个方向的图片
        {
            Resources.enemy2U,
            Resources.enemy2D,
            Resources.enemy2L,
            Resources.enemy2R
        };
        private static Image[] imgEnemy3 = new Image[]    //敌人4个方向的图片
        {
            Resources.enemy3U,
            Resources.enemy3D,
            Resources.enemy3L,
            Resources.enemy3R
        };
        private Random rdm = new Random();       //随机数
        private int timer = 0;
        private int type;
        public int Type
        {
            get { return type; }
            set { type = value; }
        }
        private static int speed;
        private static int life;
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="x">敌人的x座标</param>
        /// <param name="y">敌人的y座标</param>
        /// <param name="life">敌人的生命</param>
        /// <param name="speed">敌人的速度</param>
        /// <param name="dir">敌人的方向</param>
        public Enemy(int x, int y, int type, directions dir)
            : base(x, y, SetLife(type), imgEnemy1[0].Width, imgEnemy1[0].Height, SetSpeed(type), dir)
        {
            this.type = type;
            BeBorn();
        }
        private static int SetSpeed(int type)
        {
            switch (type)
            {
                case 0:
                    speed = 2;
                    break;
                case 1:
                    speed = 3;
                    break;
                case 2:
                    speed = 1;
                    break;
            }
            return speed;
        }

        private static int SetLife(int type)
        {
            switch (type)
            {
                case 0:
                    life = 1;
                    break;
                case 1:
                    life = 2;
                    break;
                case 2:
                    life = 3;
                    break;
            }
            return life;
        }

        public override void Move()          //敌人移动方法
        {
            if (!Enable)
            {

                return;
            }
            EnemyAI();         //敌人的AI
            Adjustdirection();          //调整敌人方向
            if (this.X > 600 || this.X < 0 || this.Y > 600 || this.Y < 0)    //如果敌人在panel的边界
            {
                switch (rdm.Next(0, 4))         //随机给敌人一个方向
                {
                    case 0:
                        dir = directions.U;
                        break;
                    case 1:
                        dir = directions.D;
                        break;
                    case 2:
                        dir = directions.L;
                        break;
                    case 3:
                        dir = directions.R;
                        break;
                    default: break;
                }
                base.Move();      //调用基类的移动方法
            }

        }

        public void EnemyAI()      //敌人的AI
        {
            if (rdm.Next(0, 100) < 2)       //当随机数小于2时
            {
                switch (rdm.Next(0, 4))     //随机给敌人一个方向
                {
                    case 0:
                        dir = directions.U;
                        break;
                    case 1:
                        dir = directions.D;
                        break;
                    case 2:
                        dir = directions.L;
                        break;
                    case 3:
                        dir = directions.R;
                        break;
                }
            }
        }

        public override void Draw(Graphics g)     //画出敌人
        {
            if (BornTimer < 48)
            {
                BornTimer++;
                return;
            }
            if (!Enable)
            {
                timer++;
                if (timer == 150)
                {
                    Enable = true;
                }
                if (timer % 10 == 0)
                {
                    return;
                }
            }
            Move();             //敌人的移动方法
            #region 根据类型画出不同的敌人
            switch (type)
            {
                case 0:
                    switch (dir)               //跟据敌人不同的方向加载不同的图片
                    {
                        case directions.U:
                            g.DrawImage(imgEnemy1[0], this.X, this.Y);
                            break;
                        case directions.D:
                            g.DrawImage(imgEnemy1[1], this.X, this.Y);
                            break;
                        case directions.L:
                            g.DrawImage(imgEnemy1[2], this.X, this.Y);
                            break;
                        case directions.R:
                            g.DrawImage(imgEnemy1[3], this.X, this.Y);
                            break;
                    }
                    break;
                case 1:
                    switch (dir)               //跟据敌人不同的方向加载不同的图片
                    {
                        case directions.U:
                            g.DrawImage(imgEnemy2[0], this.X, this.Y);
                            break;
                        case directions.D:
                            g.DrawImage(imgEnemy2[1], this.X, this.Y);
                            break;
                        case directions.L:
                            g.DrawImage(imgEnemy2[2], this.X, this.Y);
                            break;
                        case directions.R:
                            g.DrawImage(imgEnemy2[3], this.X, this.Y);
                            break;
                    }
                    break;
                case 2:
                    switch (dir)               //跟据敌人不同的方向加载不同的图片
                    {
                        case directions.U:
                            g.DrawImage(imgEnemy3[0], this.X, this.Y);
                            break;
                        case directions.D:
                            g.DrawImage(imgEnemy3[1], this.X, this.Y);
                            break;
                        case directions.L:
                            g.DrawImage(imgEnemy3[2], this.X, this.Y);
                            break;
                        case directions.R:
                            g.DrawImage(imgEnemy3[3], this.X, this.Y);
                            break;
                    }
                    break;
            }
            #endregion
            if (rdm.Next(0, 100) < 1)       //如果随机数小于1
            {
                Fire();           //敌人开火
            }
        }

        public void IsDead()
        {
            if (this.Life == 0)
            {

                //Sound soundBlast = new Sound(Resources.blast);
                //soundBlast.Play();
                SoundPlayer spBlast = new SoundPlayer(Resources.blast);
                spBlast.Play();
                Singleton.Instance.AddElement(new Blast(this.X - 25, this.Y - 25));
                Singleton.Instance.RemoveElement(this);
                Singleton.Instance.AddElement(new Equipment(rdm.Next(0, 620), rdm.Next(0, 620), rdm.Next(0, 5)));
            }
        }

        public override void Fire()   //敌人开火的方法
        {
            if (!Enable)
            {
                return;
            }
            Singleton.Instance.AddElement(new EnemyMissile(this, 1, 10, 1));         //创建子弹对象
        }

        public override void BeBorn()
        {
            Singleton.Instance.AddElement(new Born(this.X, this.Y));
        }
    }
}
