using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using Tank.Properties;
namespace Tank
{
    public class EnemyMissile : Missile       //敌人子弹类
    {
        private static Image imgEnemyMissile = Resources.enemymissile;         //子弹的图片

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="role">发子弹的角色</param>
        /// <param name="life">子弹的生命</param>
        /// <param name="speed">子弹的速度</param>
        /// <param name="power">子弹的威力</param>
        public EnemyMissile(Roles role, int life, int speed, int power)
            : base(role, life, imgEnemyMissile.Width, imgEnemyMissile.Height, speed, power)
        {
        }

        public override void Draw(Graphics g)  //画出子弹
        {
            base.Move();        //调用基类的移动方法
            g.DrawImage(imgEnemyMissile, this.X, this.Y);        //在指定的位置画出子弹
        }
    }
}
