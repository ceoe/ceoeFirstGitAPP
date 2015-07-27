using System;
using System.Collections.Generic;
using System.Text;

namespace Tank
{
    public abstract class Missile : Member
    {
        public int power;   //子弹的威力

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="role">发子弹的角色</param>
        /// <param name="life">子弹的生命</param>
        /// <param name="width">子弹的长</param>
        /// <param name="height">子弹的宽</param>
        /// <param name="speed">子弹的速度</param>
        /// <param name="power">子弹的威力</param>
        public Missile(Roles role, int life,int width,int height,int speed ,int power)
            : base(role.X+role.Width/2-6,role.Y+role.Height/2-6,life,width,height,speed,role.dir)
        {
            this.power = power;
        }

        public override void Move()      //子弹的移动方法
        {
            if (this.X < 0 || this.Y < 0 || this.X > 660 || this.Y > 660)   //当子弹出了边界
            {
                this.Life = 0;     //生命为0;
            }
            Adjustdirection();        //调整子弹的移动
        }
    }
}
