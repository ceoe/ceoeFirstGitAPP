using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace geometry_operations
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            timercount = new HiPerfTimer();
            

        }

        private void open_Click(object sender, EventArgs e)
        {
            OpenFileDialog opnDlg = new OpenFileDialog();
            opnDlg.Filter = "所有图像文件 | *.bmp; *.pcx; *.png; *.jpg; *.gif;" +
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
                    handleBitmap = (Bitmap) curBitmap.Clone();
                }
                catch (Exception exp)
                {
                    MessageBox.Show(exp.Message);
                }
            }

            Invalidate();

            CheckBitmapFormat();
            if (pixeldepth == 0)
            {
                MessageBox.Show(string.Format("像素格式有误！ 实际的图片像素格式为：{0}" , handleBitmap.PixelFormat.ToString()));
               
            }
            else
            {
                MessageBox.Show(string.Format("实际的图片像素格式为：{0}", handleBitmap.PixelFormat.ToString()));
            }

        }


        private void CheckBitmapFormat()
        {
            PixelFormat pixelFormat = handleBitmap.PixelFormat;

            if (pixelFormat == PixelFormat.Format24bppRgb)
            {
                pixeldepth = 3;
            }
            if (pixelFormat == PixelFormat.Format32bppArgb || pixelFormat == PixelFormat.Format32bppPArgb || pixelFormat == PixelFormat.Format32bppRgb)
            {
                pixeldepth = 4;
            }
            if (pixelFormat == PixelFormat.Format8bppIndexed)
            {
                pixeldepth = 1;
            }
           
        }

        private void close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
        
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            if (handleBitmap != null)
            {

                g.DrawImage(handleBitmap, 350, 80, handleBitmap.Width / handletrabar.Value * 2, handleBitmap.Height / handletrabar.Value * 2);
            }
            if (curBitmap != null)
            {

                g.DrawImage(curBitmap, 136, 80, curBitmap.Width / orgtrabar.Value * 2, curBitmap.Height / orgtrabar.Value * 2);
            }
        }

        private void translation_Click(object sender, EventArgs e)
        {
            if (curBitmap != null)
            {
                translation traForm = new translation();

                #region 简单方法--像素法

                //if (traForm.ShowDialog() == DialogResult.OK)
                //{

                //   // handleBitmap = (Bitmap) curBitmap.Clone();

                //    Color curColor;
                //    int ret;
                //    for (int i = 0; i < handleBitmap.Width; i++)
                //    {
                //        for (int j = 0; j < handleBitmap.Height; j++)
                //        {
                //            curColor = handleBitmap.GetPixel(i, j);
                //            //ret = (int) (curColor.R*0.299 + curColor.G*0.587 + curColor.B*0.114);
                //            ret = Convert.ToInt32(tb_FillColor.Text);
                //            handleBitmap.SetPixel(i, j, Color.FromArgb(ret, ret, ret));
                //        }
                //    }
                //}
                //Invalidate();

                //return;
               

                #endregion

                #region 原始方法
                if (traForm.ShowDialog() == DialogResult.OK)
                {

                 //  offsetOPbyMemory(traForm);

                    offsetOPbyPointer(traForm);

                }
                Invalidate();
               

                #endregion

                tb_timer.Text = timercount.Duration.ToString("####.##") + " 毫秒"; 

               
            }
        }

        private void offsetOPbyMemory(translation traForm)
        {
            Rectangle rect = new Rectangle(0, 0, curBitmap.Width, curBitmap.Height);
            System.Drawing.Imaging.BitmapData bmpData = curBitmap.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadWrite, curBitmap.PixelFormat);

            System.Drawing.Imaging.BitmapData handlebmpData = handleBitmap.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadWrite, curBitmap.PixelFormat);

            IntPtr ptr = bmpData.Scan0;

            IntPtr ptrhandle = handlebmpData.Scan0;

            int bytes = curBitmap.Width * curBitmap.Height;
            byte[] grayValues = new byte[bytes];
            System.Runtime.InteropServices.Marshal.Copy(ptr, grayValues, 0, bytes);

            int x = Convert.ToInt32(traForm.GetXOffset);
            int y = Convert.ToInt32(traForm.GetYOffset);

            byte[] tempArray = new byte[bytes];
            //Array.Clear(tempArray, 0, bytes);
            for (int i = 0; i < bytes; i++)
            {
                tempArray[i] = 195;
            }

            for (int i = 0; i < curBitmap.Height; i++)
            {
                if ((i + y) < curBitmap.Height && (i + y) > 0)
                {

                    for (int j = 0; j < curBitmap.Width; j++)
                    {
                        if ((j + x) < curBitmap.Width && (j + x) > 0)
                        {
                            tempArray[(j + x) + (i + y) * curBitmap.Width] = grayValues[j + i * curBitmap.Width];
                        }
                    }
                }
            }

            grayValues = (byte[])tempArray.Clone();

            System.Runtime.InteropServices.Marshal.Copy(grayValues, 0, ptr, bytes);
            curBitmap.UnlockBits(bmpData);
        }

        private void offsetOPbyPointer(translation traForm)
        {
            #region  使用指针法来操作

            handleBitmap = (Bitmap)curBitmap.Clone();
           

            Rectangle rect = new Rectangle(0, 0, handleBitmap.Width, handleBitmap.Height);
            System.Drawing.Imaging.BitmapData handlebmpData = handleBitmap.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadWrite, handleBitmap.PixelFormat);

            byte valueColor = Convert.ToByte(tb_FillColor.Text);
            int tempbytelength = handlebmpData.Stride*handlebmpData.Height;
           

            int x = Convert.ToInt32(traForm.GetXOffset);
            int y = Convert.ToInt32(traForm.GetYOffset);

            timercount.ClearTimer();
            timercount.Start();

            //进入非托管代码模式
            unsafe
            {
                //tempbyte属于C#中标准的字节数组，属于安全的代码。
                byte[] tempbyte = new byte[tempbytelength];

                for (int i = 0; i < tempbytelength; i++)
                {
                    tempbyte[i] = valueColor;
                }

                //声明一个byte 指针（byte* 属于不安全的指针，只能用在非托管代码中） ptr ，并获得BitmapData对象的首地址值
                
                byte* ptr = (byte*)(handlebmpData.Scan0);
                //不进行内存法的复制过程，直接操作内存。循环迭代图像的宽高二维数组

                int count = 0;
                int startP = y* handlebmpData.Stride+ x*pixeldepth;
                //背景已经准备好，进行复制
                for (int i = y; i < handlebmpData.Height; i++)
                {
                        for (int j = x; j < handlebmpData.Width; j++)
                        {
                            for (int k = 0; k < pixeldepth; k++)
                            {
                                tempbyte[startP + count + k] = ptr[k];
                               
                            }
                            ptr += pixeldepth;
                            count += pixeldepth;

                            #region 简单的方法
                            //if (pixeldepth==1)
                            //{
                            //    tempbyte[startP + count] = ptr[0];
                            //    ptr += 1;
                            //    count += 1;
                            //}
                            //if (pixeldepth == 3)
                            //{
                            //    tempbyte[startP + count] = ptr[0];
                            //    tempbyte[startP + count + 1] = ptr[1];
                            //    tempbyte[startP + count + 2] = ptr[2];
                            //    ptr += 3;
                            //    count += 3;
                            //}
                            //if (pixeldepth == 4)
                            //{
                            //    tempbyte[startP + count] = ptr[0];
                            //    tempbyte[startP + count + 1] = ptr[1];
                            //    tempbyte[startP + count + 2] = ptr[2];
                            //    tempbyte[startP + count + 3] = ptr[3];
                            //    ptr += 4;
                            //    count += 4;
                            //}
                                
                            
                            #endregion
                         }
                    ptr = (byte*)(handlebmpData.Scan0);
                    ptr += handlebmpData.Stride*(i - y+1);
                    count = handlebmpData.Stride * (i - y+1);

                    //下面这句很重要，但完成一次Width方向的内循环时，ptr指针该如何增加？Width应该是4的整数倍，否则将会被舍入到4的整数倍
                    //例如： 1024*3=3072 可以被4整除 ptr+0即可， 但1023*3=3069不能被4整除，这时候其实需要使用BitmapData.stride 属性获得被4除的跨距宽度,减去实际图像的字节宽度。
                    //下面的计算表达式对于实际图像像宽为4的整数倍的图片来说，结果为0.
                }

                //将背景部分再复制回来
                count = 0;
                ptr = (byte*)(handlebmpData.Scan0);
                for (int i = 0; i < tempbyte.Length; i++)
                {
                    ptr[i] = tempbyte[i];
                }

                //for (int i = 0; i < handlebmpData.Height; i++)
                //{
                //        for (int j = 0; j < handlebmpData.Width; j++)
                //        {
                //            ptr[0] = tempbyte[count];
                //            ptr[1] = tempbyte[count+1];
                //            ptr[2] = tempbyte[count+2];
                //            ptr += 3;
                //            count = +3;

                //            //byte temp = (byte)(0.299 * ptr[2] + 0.587 * ptr[1] + 0.114 * ptr[0]);
                //            //ptr[0] = ptr[1] = ptr[2] = temp;
                //            //ptr += 3;
                //        }
                //        ptr += increased;
                   
                //    //下面这句很重要，但完成一次Width方向的内循环时，ptr指针该如何增加？Width应该是4的整数倍，否则将会被舍入到4的整数倍
                //    //例如： 1024*3=3072 可以被4整除 ptr+0即可， 但1023*3=3069不能被4整除，这时候其实需要使用BitmapData.stride 属性获得被4除的跨距宽度,减去实际图像的字节宽度。
                //    //下面的计算表达式对于实际图像像宽为4的整数倍的图片来说，结果为0.

                //}
            }

            //非托管代码执行完毕后，BitmapData对象需要切换回托管模式
            handleBitmap.UnlockBits(handlebmpData);

            timercount.Stop();
            #endregion

        }

        private void offsetXOP(int offsetx)
        {
            #region  使用指针法来操作

            handleBitmap = (Bitmap)curBitmap.Clone();


            Rectangle rect = new Rectangle(0, 0, handleBitmap.Width, handleBitmap.Height);
            System.Drawing.Imaging.BitmapData handlebmpData = handleBitmap.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadWrite, handleBitmap.PixelFormat);

            byte valueColor = Convert.ToByte(tb_FillColor.Text);
            int tempbytelength = handlebmpData.Stride * handlebmpData.Height;

            int x = offsetx;
            //int x = Convert.ToInt32(traForm.GetXOffset);
            //int y = Convert.ToInt32(traForm.GetYOffset);

            timercount.ClearTimer();
            timercount.Start();

            //进入非托管代码模式
            unsafe
            {
                //tempbyte属于C#中标准的字节数组，属于安全的代码。
                byte[] tempbyte = new byte[tempbytelength];

                for (int i = 0; i < tempbytelength; i++)
                {
                    tempbyte[i] = valueColor;
                }

                //声明一个byte 指针（byte* 属于不安全的指针，只能用在非托管代码中） ptr ，并获得BitmapData对象的首地址值

                byte* ptr = (byte*)(handlebmpData.Scan0);
                //不进行内存法的复制过程，直接操作内存。循环迭代图像的宽高二维数组

                int count = 0;

                //对于水平偏移只要考虑x方向即可。
                int offsetxP =  x * pixeldepth;
                int overP = handlebmpData.Stride - offsetxP;
                //int startP = y * handlebmpData.Stride + x * pixeldepth;
                //背景已经准备好，进行复制
                for (int i = 0; i < handlebmpData.Height; i++)
                {
                    var jcount = 0;
                    for (int j = 0; j < handlebmpData.Width; j++)
                    {
                        if ((jcount < overP))
                        {
                            for (int k = 0; k < pixeldepth; k++)
                            {
                                tempbyte[count + offsetxP + jcount + k] = ptr[jcount+k];

                            }
                            jcount += pixeldepth;
                        }
                        else
                        {
                            for (int k = 0; k < pixeldepth; k++)
                            {
                                tempbyte[count+( jcount -overP + k)] = ptr[jcount + k];
                            } 
                             jcount += pixeldepth;
                        }

                       
                        #region 简单的方法
                        //if (pixeldepth==1)
                        //{
                        //    tempbyte[startP + count] = ptr[0];
                        //    ptr += 1;
                        //    count += 1;
                        //}
                        //if (pixeldepth == 3)
                        //{
                        //    tempbyte[startP + count] = ptr[0];
                        //    tempbyte[startP + count + 1] = ptr[1];
                        //    tempbyte[startP + count + 2] = ptr[2];
                        //    ptr += 3;
                        //    count += 3;
                        //}
                        //if (pixeldepth == 4)
                        //{
                        //    tempbyte[startP + count] = ptr[0];
                        //    tempbyte[startP + count + 1] = ptr[1];
                        //    tempbyte[startP + count + 2] = ptr[2];
                        //    tempbyte[startP + count + 3] = ptr[3];
                        //    ptr += 4;
                        //    count += 4;
                        //}


                        #endregion
                    }
                    ptr = (byte*)(handlebmpData.Scan0);
                    ptr += handlebmpData.Stride * (i  + 1);
                    count = handlebmpData.Stride * (i  + 1);

                    //下面这句很重要，但完成一次Width方向的内循环时，ptr指针该如何增加？Width应该是4的整数倍，否则将会被舍入到4的整数倍
                    //例如： 1024*3=3072 可以被4整除 ptr+0即可， 但1023*3=3069不能被4整除，这时候其实需要使用BitmapData.stride 属性获得被4除的跨距宽度,减去实际图像的字节宽度。
                    //下面的计算表达式对于实际图像像宽为4的整数倍的图片来说，结果为0.
                }

                //将背景部分再复制回来
                count = 0;
                ptr = (byte*)(handlebmpData.Scan0);
                for (int i = 0; i < tempbyte.Length; i++)
                {
                    ptr[i] = tempbyte[i];
                }

                //for (int i = 0; i < handlebmpData.Height; i++)
                //{
                //        for (int j = 0; j < handlebmpData.Width; j++)
                //        {
                //            ptr[0] = tempbyte[count];
                //            ptr[1] = tempbyte[count+1];
                //            ptr[2] = tempbyte[count+2];
                //            ptr += 3;
                //            count = +3;

                //            //byte temp = (byte)(0.299 * ptr[2] + 0.587 * ptr[1] + 0.114 * ptr[0]);
                //            //ptr[0] = ptr[1] = ptr[2] = temp;
                //            //ptr += 3;
                //        }
                //        ptr += increased;

                //    //下面这句很重要，但完成一次Width方向的内循环时，ptr指针该如何增加？Width应该是4的整数倍，否则将会被舍入到4的整数倍
                //    //例如： 1024*3=3072 可以被4整除 ptr+0即可， 但1023*3=3069不能被4整除，这时候其实需要使用BitmapData.stride 属性获得被4除的跨距宽度,减去实际图像的字节宽度。
                //    //下面的计算表达式对于实际图像像宽为4的整数倍的图片来说，结果为0.

                //}
            }

            //非托管代码执行完毕后，BitmapData对象需要切换回托管模式
            handleBitmap.UnlockBits(handlebmpData);

           timercount.Stop();
            #endregion

        }

        private void mirror_Click(object sender, EventArgs e)
        {
            if (curBitmap != null)
            {
                mirror mirForm = new mirror();
                if (mirForm.ShowDialog() == DialogResult.OK)
                {
                    Rectangle rect = new Rectangle(0, 0, curBitmap.Width, curBitmap.Height);
                    System.Drawing.Imaging.BitmapData bmpData = curBitmap.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadWrite, curBitmap.PixelFormat);
                    IntPtr ptr = bmpData.Scan0;
                    int bytes = curBitmap.Width * curBitmap.Height;
                    byte[] grayValues = new byte[bytes];
                    System.Runtime.InteropServices.Marshal.Copy(ptr, grayValues, 0, bytes);

                    int halfWidth = curBitmap.Width / 2;
                    int halfHeight = curBitmap.Height / 2;
                    byte temp;

                    if (mirForm.GetMirror)
                    {
                        for (int i = 0; i < curBitmap.Height; i++)
                        {
                            for (int j = 0; j < halfWidth; j++)
                            {
                                temp = grayValues[i * curBitmap.Width + j];
                                grayValues[i * curBitmap.Width + j] = grayValues[(i + 1) * curBitmap.Width - 1 - j];
                                grayValues[(i + 1) * curBitmap.Width - 1 - j] = temp;
                            }
                        }
                    }
                    else
                    {
                        for (int i = 0; i < curBitmap.Width; i++)
                        {
                            for (int j = 0; j < halfHeight; j++)
                            {
                                temp = grayValues[j * curBitmap.Width + i];
                                grayValues[j * curBitmap.Height + i] = grayValues[(curBitmap.Height - j - 1) * curBitmap.Width + i];
                                grayValues[(curBitmap.Height - j - 1) * curBitmap.Width + i] = temp;
                            }
                        }
                    }
                    
                    System.Runtime.InteropServices.Marshal.Copy(grayValues, 0, ptr, bytes);
                    curBitmap.UnlockBits(bmpData);
                }

                Invalidate();
            }
        }

        private void zoom_Click(object sender, EventArgs e)
        {
            if (curBitmap != null)
            {
                zoom zoomForm = new zoom();
                if (zoomForm.ShowDialog() == DialogResult.OK)
                {
                    Rectangle rect = new Rectangle(0, 0, curBitmap.Width, curBitmap.Height);
                    System.Drawing.Imaging.BitmapData bmpData = curBitmap.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadWrite, curBitmap.PixelFormat);
                    IntPtr ptr = bmpData.Scan0;
                    int bytes = curBitmap.Width * curBitmap.Height;
                    byte[] grayValues = new byte[bytes];
                    System.Runtime.InteropServices.Marshal.Copy(ptr, grayValues, 0, bytes);
                    
                    double x = Convert.ToDouble(zoomForm.GetXZoom);
                    double y = Convert.ToDouble(zoomForm.GetYZoom);

                    int halfWidth = (int)(curBitmap.Width / 2);
                    int halfHeight = (int)(curBitmap.Height / 2);

                    int xz = 0;
                    int yz = 0;
                    int tempWidth = 0;
                    int tempHeight = 0;

                    byte[] tempArray = new byte[bytes];

                    if (zoomForm.GetNearOrBil == true)
                    {
                        for (int i = 0; i < curBitmap.Height; i++)
                        {
                            for (int j = 0; j < curBitmap.Width; j++)
                            {
                                tempHeight = i - halfHeight;
                                tempWidth = j - halfWidth;
                                if (tempWidth > 0)
                                {
                                    xz = (int)(tempWidth / x + 0.5);
                                }
                                else
                                {
                                    xz = (int)(tempWidth / x - 0.5);
                                }
                                if (tempHeight > 0)
                                {
                                    yz = (int)(tempHeight / y + 0.5);
                                }
                                else
                                {
                                    yz = (int)(tempHeight / y - 0.5);
                                }

                                tempWidth = xz + halfWidth;
                                tempHeight = yz + halfHeight;
                                if (tempWidth < 0 || tempWidth >= curBitmap.Width || tempHeight < 0 || tempHeight >= curBitmap.Height)
                                {
                                    tempArray[i * curBitmap.Width + j] = 255;
                                }
                                else
                                {
                                    tempArray[i * curBitmap.Width + j] = grayValues[tempHeight * curBitmap.Width + tempWidth];
                                }
                            }
                        }
                    }
                    else
                    {
                        double tempX, tempY, p, q;
                        for (int i = 0; i < curBitmap.Height; i++)
                        {
                            for (int j = 0; j < curBitmap.Width; j++)
                            {
                                tempHeight = i - halfHeight;
                                tempWidth = j - halfWidth;
                                tempX = tempWidth / x;
                                tempY = tempHeight / y;
                                if (tempWidth > 0)
                                {
                                    xz = (int)tempX;
                                }
                                else
                                {
                                    xz = (int)(tempX - 1);
                                }
                                if (tempHeight > 0)
                                {
                                    yz = (int)tempY;
                                }
                                else
                                {
                                    yz = (int)(tempY - 1);
                                }

                                p = tempX - xz;
                                q = tempY - yz;
                                tempWidth = xz + halfWidth;
                                tempHeight = yz + halfHeight;
                                if (tempWidth < 0 || (tempWidth + 1) >= curBitmap.Width || tempHeight < 0 || (tempHeight + 1) >= curBitmap.Height)
                                {
                                    tempArray[i * curBitmap.Width + j] = 255;
                                }
                                else
                                {
                                    tempArray[i * curBitmap.Width + j] = (byte)((1.0 - q) * ((1.0 - p) * grayValues[tempHeight * curBitmap.Width + tempWidth] + p * grayValues[tempHeight * curBitmap.Width + tempWidth + 1]) + 
                                        q * ((1.0 - p) * grayValues[(tempHeight + 1) * curBitmap.Width + tempWidth] + p * grayValues[(tempHeight + 1) * curBitmap.Width + 1 + tempWidth]));
                                }
                            }
                        }

                    }

                    grayValues = (byte[])tempArray.Clone();

                    System.Runtime.InteropServices.Marshal.Copy(grayValues, 0, ptr, bytes);
                    curBitmap.UnlockBits(bmpData);
                }

                Invalidate();

            }
        }

        private void rotation_Click(object sender, EventArgs e)
        {
            if (curBitmap != null)
            {
                rotation rotForm = new rotation();
                if (rotForm.ShowDialog() == DialogResult.OK)
                {
                    int degree = Convert.ToInt32(rotForm.GetDegree);
                    rotateImage(degree);
                }
                Invalidate();
            }
        }

        private void rotateImage(int degree)
        {
                   Rectangle rect = new Rectangle(0, 0, curBitmap.Width, curBitmap.Height);

                    handleBitmap = (Bitmap)curBitmap.Clone();
                    Rectangle recthandle = new Rectangle(0, 0, handleBitmap.Width, handleBitmap.Height);

                    System.Drawing.Imaging.BitmapData handlebmpData = handleBitmap.LockBits(recthandle, System.Drawing.Imaging.ImageLockMode.ReadWrite, handleBitmap.PixelFormat);

                   // System.Drawing.Imaging.BitmapData bmpData = curBitmap.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadWrite, curBitmap.PixelFormat);

                    //IntPtr ptr = bmpData.Scan0;
                    IntPtr ptr = handlebmpData.Scan0;

                    int bytes = curBitmap.Width * curBitmap.Height;
                    byte[] grayValues = new byte[bytes];
                    System.Runtime.InteropServices.Marshal.Copy(ptr, grayValues, 0, bytes);

                    //int degree = Convert.ToInt32(rotForm.GetDegree);

                    double radian = degree * Math.PI / 180.0;
                    double mySin = Math.Sin(radian);
                    double myCos = Math.Cos(radian);
                    int halfWidth = (int)(curBitmap.Width / 2);
                    int halfHeight = (int)(curBitmap.Height / 2);
                    int xr = 0;
                    int yr = 0;
                    int tempWidth = 0;
                    int tempHeight = 0;

                    byte[] tempArray = new byte[bytes];
                   
                    double tempX, tempY, p, q;
                    for (int i = 0; i < curBitmap.Height; i++)
                    {
                        for (int j = 0; j < curBitmap.Width; j++)
                        {
                            tempHeight = i - halfHeight;
                            tempWidth = j - halfWidth;
                            tempX = tempWidth * myCos - tempHeight * mySin;
                            tempY = tempHeight * myCos + tempWidth * mySin;
                            if (tempWidth > 0)
                            {
                                xr = (int)tempX;
                            }
                            else
                            {
                                xr = (int)(tempX - 1);
                            }
                            if (tempHeight > 0)
                            {
                                yr = (int)tempY;
                            }
                            else
                            {
                                yr = (int)(tempY - 1);
                            }

                            p = tempX - xr;
                            q = tempY - yr;
                            tempWidth = xr + halfWidth;
                            tempHeight = yr + halfHeight;
                            if (tempWidth < 0 || (tempWidth + 1) >= curBitmap.Width || tempHeight < 0 || (tempHeight + 1) >= curBitmap.Height)
                            {
                                tempArray[i * curBitmap.Width + j] = 255;
                            }
                            else
                            {
                                tempArray[i * curBitmap.Width + j] = (byte)((1.0 - q) * ((1.0 - p) * grayValues[tempHeight * curBitmap.Width + tempWidth] + p * grayValues[tempHeight * curBitmap.Width + tempWidth + 1]) +
                                    q * ((1.0 - p) * grayValues[(tempHeight + 1) * curBitmap.Width + tempWidth] + p * grayValues[(tempHeight + 1) * curBitmap.Width + 1 + tempWidth]));
                            }

                        }
                    }

                    grayValues = (byte[])tempArray.Clone();

                    System.Runtime.InteropServices.Marshal.Copy(grayValues, 0, ptr, bytes);
                   
                    handleBitmap.UnlockBits(handlebmpData);

                    //curBitmap.UnlockBits(bmpData);
                }
        

        private void orgtrabar_ValueChanged(object sender, EventArgs e)
        {
            Invalidate();
        }

        private void BmpValuerichBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnLoopX_Click(object sender, EventArgs e)
        {
            if (Timeroffsetx.Enabled)
            {
                Timeroffsetx.Enabled = false;  
            }
            else
            {
                Timeroffsetx.Enabled = true;
            }
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Timercountbtn++;
            offsetXOP(Timercountbtn%curBitmap.Width);
            this.Refresh();
            //Invalidate();
            tb_timer.Text = timercount.Duration.ToString("####.##") + " 毫秒"; 
            

        }

        private void traBrotate_ValueChanged(object sender, EventArgs e)
        {
            
             int degree = Convert.ToInt32(this.traBrotate.Value * 15);
             rotateImage(degree);
             Invalidate();
        }

       
    }
}