using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
//using System.Drawing.Drawing2D;

namespace gray
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            curFacTrBar.Value = 8;
            handleBmpTrbar.Value = 5;
            myTimer = new HiPerfTimer();
        }

        private void open_Click(object sender, EventArgs e)
        {
            OpenFileDialog opnDlg = new OpenFileDialog();
            opnDlg.Filter = "所有图像文件 | *.bmp; *.pcx; *.png; *.jpg; *.gif;"+ 
                "*.tif; *.ico; *.dxf; *.cgm; *.cdr; *.wmf; *.eps; *.emf|" +
                "位图( *.bmp; *.jpg; *.png;...) | *.bmp; *.pcx; *.png; *.jpg; *.gif; *.tif; *.ico|" +
                "矢量图( *.wmf; *.eps; *.emf;...) | *.dxf; *.cgm; *.cdr; *.wmf; *.eps; *.emf";
            opnDlg.Title = "打开图像文件";
            opnDlg.ShowHelp = true;
            if (opnDlg.ShowDialog() == DialogResult.OK)
            {
                curFileName = opnDlg.FileName;
                try
                {
                    curBitmap = (Bitmap)Image.FromFile(curFileName);
                    BitmapByHandle=(Bitmap)curBitmap.Clone();
                }
                catch (Exception exp)
                {
                    MessageBox.Show(exp.Message);
                }
            }
            Invalidate();
        }

        private void save_Click(object sender, EventArgs e)
        {
            if (BitmapByHandle == null)
            {
                return;
            }
            SaveFileDialog saveDlg = new SaveFileDialog();
            saveDlg.Title = "保存为";
            saveDlg.OverwritePrompt = true;
            saveDlg.Filter =
                "BMP文件 (*.bmp) | *.bmp|" +
                "Gif文件 (*.gif) | *.gif|" +
                "JPEG文件 (*.jpg) | *.jpg|" +
                "PNG文件 (*.png) | *.png";
            saveDlg.ShowHelp = true;
            if(saveDlg.ShowDialog() == DialogResult.OK)
            {
                string fileName = saveDlg.FileName;
                string strFilExtn = fileName.Remove(0, fileName.Length - 3);
                switch (strFilExtn)
                {
                    case "bmp":
                        BitmapByHandle.Save(fileName, System.Drawing.Imaging.ImageFormat.Bmp);
                        break;
                    case "jpg":
                        BitmapByHandle.Save(fileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                        break;
                    case "gif":
                        BitmapByHandle.Save(fileName, System.Drawing.Imaging.ImageFormat.Gif);
                        break;
                    case "tif":
                        BitmapByHandle.Save(fileName, System.Drawing.Imaging.ImageFormat.Tiff);
                        break;
                    case "png":
                        BitmapByHandle.Save(fileName, System.Drawing.Imaging.ImageFormat.Png);
                        break;
                    default:
                        break;
                }
            }
        }

        private void close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            if (BitmapByHandle != null)
            {

                g.DrawImage(BitmapByHandle, 350, 80, BitmapByHandle.Width / handleBmpTrbar.Value * 2, BitmapByHandle.Height / handleBmpTrbar.Value * 2);
            }
            if (curBitmap != null)
            {

                g.DrawImage(curBitmap, 136, 80, curBitmap.Width / curFacTrBar.Value * 2, curBitmap.Height / curFacTrBar.Value * 2);
            }
        }

        private void pixel_Click(object sender, EventArgs e)
        {
            if(curBitmap != null)
            {
                BitmapByHandle = (Bitmap)curBitmap.Clone();
                myTimer.ClearTimer();
                myTimer.Start();
                Color curColor;
                int ret;
                for (int i = 0; i < BitmapByHandle.Width; i++)
                {
                    for (int j = 0; j < BitmapByHandle.Height; j++)
                    {
                        curColor = BitmapByHandle.GetPixel(i, j);
                        ret = (int)(curColor.R * 0.299 + curColor.G * 0.587 + curColor.B * 0.114);
                        BitmapByHandle.SetPixel(i, j, Color.FromArgb(ret, ret, ret));
                    }
                }
                myTimer.Stop();
                timeBox.Text = myTimer.Duration.ToString("####.##") + " 毫秒"; 
                Invalidate();
            }
        }

        private void memory_Click(object sender, EventArgs e)
        {
            if (curBitmap != null)
            {
                BitmapByHandle = (Bitmap)curBitmap.Clone();
                myTimer.ClearTimer();
                myTimer.Start();
                Rectangle rect = new Rectangle(0, 0, BitmapByHandle.Width, BitmapByHandle.Height);

                //将bitmap对象占用的内存锁定(将这块内存划为非托管)，返回一个BitmapData对象。
                System.Drawing.Imaging.BitmapData bmpData = BitmapByHandle.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadWrite, BitmapByHandle.PixelFormat);
                
                //使用IntPtr (IntPtr是类型安全的指针，用在托管模式)指针 ptr 得到Bitmap内存锁定的的首指针。
                IntPtr ptr = bmpData.Scan0;

                //将ptr指向的Bitmap内存数据复制到rgbValues数组中。
                int bytes = BitmapByHandle.Width * BitmapByHandle.Height * 3;
                byte[] rgbValues = new byte[bytes];

                //使用Marshal.Copy方法进行内存拷贝， source(ptr), target(rgbValues), start(0), length(bytes)
                System.Runtime.InteropServices.Marshal.Copy(ptr, rgbValues, 0, bytes);
                double colorTemp = 0;

                //循环迭代赋值，步进为3， 
                for (int i = 0; i < rgbValues.Length; i += 3)
                {
                    colorTemp = rgbValues[i + 2] * 0.299 + rgbValues[i + 1] * 0.587 + rgbValues[i] * 0.114;
                    //rgbValues数组里面每三个为一组，赋值为相同。
                    rgbValues[i] = rgbValues[i + 1] = rgbValues[i + 2] = (byte)colorTemp;
                }

                //使用Marshal.Copy方法进行内存拷贝， 将数据拷贝回BitmapData ptr 指针，注意方法的签名变换了： source=rgbValues, start=(0), Target =(ptr), length=(bytes)
                System.Runtime.InteropServices.Marshal.Copy(rgbValues, 0, ptr, bytes);
                
                //BitmapbyHandle 重新变成托管对象。
                BitmapByHandle.UnlockBits(bmpData);
                
                //计数器停止。
                myTimer.Stop();


                timeBox.Text = myTimer.Duration.ToString("####.##") + " 毫秒"; 
                Invalidate();
            }
        }

        private void pointer_Click(object sender, EventArgs e)
        {
            if (curBitmap != null)
            {
                BitmapByHandle = (Bitmap)curBitmap.Clone();
                myTimer.ClearTimer();
                myTimer.Start();
                Rectangle rect = new Rectangle(0, 0, BitmapByHandle.Width, BitmapByHandle.Height);
                System.Drawing.Imaging.BitmapData bmpData = BitmapByHandle.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadWrite, BitmapByHandle.PixelFormat);
                byte temp = 0;

                //进入非托管代码模式
                unsafe
                {
                    //声明一个byte 指针（byte* 属于不安全的指针，只能用在非托管代码中） ptr ，并获得BitmapData对象的首地址值
                    byte* ptr = (byte*)(bmpData.Scan0);
                    int increased = bmpData.Stride - bmpData.Width * 3;

                    //不进行内存法的复制过程，直接操作内存。循环迭代图像的宽高二维数组
                    for (int i = 0; i < bmpData.Height; i++)
                    {
                        for (int j = 0; j < bmpData.Width; j++)
                        {
                            temp = (byte)(0.299 * ptr[2] + 0.587 * ptr[1] + 0.114 * ptr[0]);
                            ptr[0] = ptr[1] = ptr[2] = temp;
                            ptr += 3;
                        }

                        //下面这句很重要，但完成一次Width方向的内循环时，ptr指针该如何增加？Width应该是4的整数倍，否则将会被舍入到4的整数倍
                        //例如： 1024*3=3072 可以被4整除 ptr+0即可， 但1023*3=3069不能被4整除，这时候其实需要使用BitmapData.stride 属性获得被4除的跨距宽度,减去实际图像的字节宽度。
                        //下面的计算表达式对于实际图像像宽为4的整数倍的图片来说，结果为0.
                        ptr += increased;

                    }
                }
                //非托管代码执行完毕后，BitmapData对象需要切换回托管模式
                BitmapByHandle.UnlockBits(bmpData);

                //计数器停止。
                myTimer.Stop();

                timeBox.Text = myTimer.Duration.ToString("####.##") + " 毫秒"; 
                Invalidate();
            }
        }

        private void curFacTrBar_ValueChanged(object sender, EventArgs e)
        {
            Invalidate();
        }
    }
}