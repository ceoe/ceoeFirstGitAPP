using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using Tank.Properties;
using System.Media;
using System.Threading;
namespace Tank
{
    /// <summary>
    /// 玩家1坦克类
    /// </summary>
    public class P1Tank : Player          
    {
        private static Image[] imgTank1 = new Image[]         //坦克4个方向的图片
        {
            Resources.p1tankU,
            Resources.p1tankD,
            Resources.p1tankL,
            Resources.p1tankR
        };

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="x">坦克的x座标</param>
        /// <param name="y">坦克的y座标</param>
        /// <param name="speed">坦克的数速度</param>
        /// <param name="life">坦克的生命</param>
        /// <param name="dir">坦克的方向</param>
        public P1Tank(int x, int y, int speed, int life,directions dir)
            : base(x, y,life, speed,dir,imgTank1)
        {
        }

        public void KeyDown(KeyEventArgs e)     //按键方法
        {
            switch (e.KeyCode)   //WASD对象上左下右4个方向，如果按下，就把相应的值设为true;
            {
                case Keys.W: 
                    dirU = true;
                    break;
                case Keys.S:
                    dirD = true;
                    break;
                case Keys.A: 
                    dirL = true;
                    break;
                case Keys.D: 
                    dirR = true;
                    break;
                default: break;
            }
            if (e.KeyCode == Keys.W | e.KeyCode == Keys.S | e.KeyCode == Keys.A | e.KeyCode == Keys.D)
            {
                isMove = true;       //如果按的是WASD方向键，表示坦克正在移动
            }
            Adjustdirection();        //调整方向
        }

        public void KeyUp(KeyEventArgs e)    //按键松开方法
        {
            switch (e.KeyCode)         //WASD对象上左下右4个方向，如果松开，就把相应的值设为false;
            {
                case Keys.W:
                    dirU = false;
                    break;
                case Keys.S:
                    dirD = false;
                    break;
                case Keys.A:
                    dirL = false;
                    break;
                case Keys.D:
                    dirR = false;
                    break;
                case Keys.K:
                    Fire();
                    break;
                default: break;
            }
            isMove = false;        //不再移动
            Adjustdirection();         //调整方向
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
        public override void BeBorn()
        {
            this.X = 200;
            this.Y = 600;
            Singleton.Instance.AddElement(new Born(this.X, this.Y));
        }
    }
}
