using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using Tank.Properties;

namespace Tank
{
    /// <summary>
    ///  草地类
    /// </summary>
    class Grass : Module        
    {
        private static Image imgGrass = Resources.grass;    //草地的图象

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="x">草地的x座标</param>
        /// <param name="y">草地的y座标</param>
        /// <param name="life">草地的生命</param>
        public Grass(int x, int y)
            : base(x, y,imgGrass.Width, imgGrass.Height)
        {
        }

        public override void Draw(Graphics g)
        {
              g.DrawImage(imgGrass, this.X, this.Y);         
        }
    }
}
