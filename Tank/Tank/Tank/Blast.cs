using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using Tank.Properties;
using System.Media;
namespace Tank
{
    public class Blast : Element       //爆炸类
    {
        private int count = 0;           //用记指定在加载哪张图片
        private static Image[] imgBlast = new Image[]    //图片数组
        {
            Resources.blast1,
            Resources.blast2,
            Resources.blast3,
            Resources.blast4,
            Resources.blast5,
            Resources.blast6,
            Resources.blast7,
            Resources.blast8
        };
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="x">图片的x座标</param>
        /// <param name="y">图片的y座标</param>
        /// <param name="life">图片的生命</param>
        public Blast(int x, int y):base(x,y)
        {
        }

        public override void Draw(Graphics g)      //画图方法
        {
            //SoundPlayer spBlast = new SoundPlayer(Resources.blast);
            //spBlast.Play();
            if (count < imgBlast.Length)         //当记数器小于图片数量时
            {
                g.DrawImage(imgBlast[count], this.X, this.Y);     //在指定的位置画图
                count++;              //记事器自加
            }
            else                  //当图片都画完后
            {
                Singleton.Instance.RemoveElement(this);
            }
        }
    }
}
