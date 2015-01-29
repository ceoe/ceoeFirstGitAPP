using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace RabAndTorSpeedRun
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private bool isRun = false;
        private int TorX = 0;
        private int TorVX = 30;
        private int TorPicSn = 0;


        private int rabX = 0;
        private int rabVX = 40;
        private int rabPicSn = 0;

        private void btnStart_Click(object sender, EventArgs e)
        {
            //Graphics bmp=new Graphics();
            if (!isRun)
            {
                timer1.Start();
                btnStart.Text = "Stop";
                isRun = true;
            }
            else
            {
                timer1.Stop();
                btnStart.Text = "Start";
                isRun = false;
            }
            
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            //声明一个bmp对象,该对象的大小使用From.Size中的宽和高来定

            Bitmap bmp = new Bitmap(ClientSize.Width, ClientSize.Height);

            //将新生成的bmp对象实例赋值给Graphic,以便使用Graphic类中的方法进行编辑绘制.
            //这里使用了Graphic的静态方法FromImage来传递一个bmp对象供Graphic 操作.
            Graphics bmpgp = Graphics.FromImage(bmp);
            bmpgp.DrawImage(imgListRab.Images[rabPicSn], rabX, 0);
            bmpgp.DrawImage(imgListTor.Images[TorPicSn], TorX, 110);

            //将内存中已经绘制好的bmp对象传递给窗体事件e
            e.Graphics.DrawImage(bmp, 0, 0);

            //传递完成后,要依次释放绘图资源.
            //先释放内存中的Graphic绘图对象,先释放画家.
            bmpgp.Dispose();
            //再释放内存中的bmp画布对象  bmp犹如一张白纸.  Graphic 犹如一个画家.,再释放画布白纸
            bmp.Dispose();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            TorX += TorVX;
            if (TorX < 0 || TorX + 100 > ClientSize.Width)
            {
                TorVX = -TorVX;
            }
            if (TorVX>0)
            {
                TorPicSn = ++TorPicSn % 4 ;
            }else
            {
                TorPicSn = ++TorPicSn % 4+4;
            }


            rabX += rabVX;
            if (rabX < 0 || rabX + 100 > ClientSize.Width)
            {
                rabVX = -rabVX;
            }
            if (rabVX > 0)
            {
                rabPicSn = ++rabPicSn % 4;
            }else
            {
                rabPicSn = ++rabPicSn % 4 + 4;
            }

            this.Refresh();
        }
    }
}
