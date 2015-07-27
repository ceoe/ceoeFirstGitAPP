using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace point_operation
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void histogram_Click(object sender, EventArgs e)
        {
            if (curBitmap != null)
            {
                histForm histoGram = new histForm(curBitmap);
                histoGram.ShowDialog();
                histoGram.Close();
            }
        }

        private void close_Click(object sender, EventArgs e)
        {
            this.Close();
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
                }
                catch (Exception exp)
                {
                    MessageBox.Show(exp.Message);
                }
            }
            Invalidate();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            if (curBitmap != null)
            {
                g.DrawImage(curBitmap, 160, 20, curBitmap.Width, curBitmap.Height);
            }
        }

        private void linearPO_Click(object sender, EventArgs e)
        {
            if (curBitmap != null)
            {
                linearPOForm linearForm = new linearPOForm();

                if (linearForm.ShowDialog() == DialogResult.OK)
                {
                    Rectangle rect = new Rectangle(0, 0, curBitmap.Width, curBitmap.Height);
                    System.Drawing.Imaging.BitmapData bmpData = curBitmap.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadWrite, curBitmap.PixelFormat);
                    IntPtr ptr = bmpData.Scan0;
                    int bytes = curBitmap.Width * curBitmap.Height;
                    byte[] grayValues = new byte[bytes];
                    System.Runtime.InteropServices.Marshal.Copy(ptr, grayValues, 0, bytes);
                    int temp = 0;
                    double a = Convert.ToDouble(linearForm.GetScaling);
                    double b = Convert.ToDouble(linearForm.GetOffset);
                    for (int i = 0; i < bytes; i++)
                    {
                        temp = (int)(a * grayValues[i] + b + 0.5);

                        if (temp > 255)
                        {
                            grayValues[i] = 255;
                        }
                        else if (temp < 0)
                        {
                            grayValues[i] = 0;
                        }
                        else
                            grayValues[i] = (byte)temp;
                    }
                    System.Runtime.InteropServices.Marshal.Copy(grayValues, 0, ptr, bytes);
                    curBitmap.UnlockBits(bmpData);
                }

                linearForm.Close();
                Invalidate();
            }
        }

        private void stretch_Click(object sender, EventArgs e)
        {
            if (curBitmap != null)
            {

                Rectangle rect = new Rectangle(0, 0, curBitmap.Width, curBitmap.Height);
                System.Drawing.Imaging.BitmapData bmpData = curBitmap.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadWrite, curBitmap.PixelFormat);
                IntPtr ptr = bmpData.Scan0;
                int bytes = curBitmap.Width * curBitmap.Height;
                byte[] grayValues = new byte[bytes];
                System.Runtime.InteropServices.Marshal.Copy(ptr, grayValues, 0, bytes);
                
                byte a = 255, b = 0;
                double p;

                for (int i = 0; i < bytes; i++)
                {
                    if (a > grayValues[i])
                    {
                        a = grayValues[i];
                    }
                    if (b < grayValues[i])
                    {
                        b = grayValues[i];
                    }
                }
                p = 255.0 / (b - a);

                for (int i = 0; i < bytes; i++)
                {
                    grayValues[i] = (byte)(p * (grayValues[i] - a) + 0.5);
                }

                System.Runtime.InteropServices.Marshal.Copy(grayValues, 0, ptr, bytes);
                curBitmap.UnlockBits(bmpData);

                Invalidate();
            }
        }

        private void equalization_Click(object sender, EventArgs e)
        {
            if (curBitmap != null)
            {
                Rectangle rect = new Rectangle(0, 0, curBitmap.Width, curBitmap.Height);
                System.Drawing.Imaging.BitmapData bmpData = curBitmap.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadWrite, curBitmap.PixelFormat);
                IntPtr ptr = bmpData.Scan0;
                int bytes = curBitmap.Width * curBitmap.Height;
                byte[] grayValues = new byte[bytes];
                System.Runtime.InteropServices.Marshal.Copy(ptr, grayValues, 0, bytes);

                byte temp;
                int[] countPixel = new int[256];
                int[] tempArray = new int[256];
                //Array.Clear(tempArray, 0, 256);
                byte[] pixelMap = new byte[256];
                for (int i = 0; i < bytes; i++)
                {
                    temp = grayValues[i];
                    countPixel[temp]++;
                }

                for (int i = 0; i < 256; i++)
                {
                    if (i != 0)
                    {
                        tempArray[i] = tempArray[i - 1] + countPixel[i];
                    }
                    else
                    {
                        tempArray[0] = countPixel[0];
                    }
                    
                    pixelMap[i] = (byte)(255.0 * tempArray[i] / bytes + 0.5);
                }
                
                for (int i = 0; i < bytes; i++)
                {
                    temp = grayValues[i];
                    grayValues[i] = pixelMap[temp];
                }
                System.Runtime.InteropServices.Marshal.Copy(grayValues, 0, ptr, bytes);
                curBitmap.UnlockBits(bmpData);

                Invalidate();
            }
        }

        private void shaping_Click(object sender, EventArgs e)
        {
            if (curBitmap != null)
            {
                shapingForm sForm = new shapingForm();

                if (sForm.ShowDialog() == DialogResult.OK)
                {
                    Rectangle rect = new Rectangle(0, 0, curBitmap.Width, curBitmap.Height);
                    System.Drawing.Imaging.BitmapData bmpData = curBitmap.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadWrite, curBitmap.PixelFormat);
                    IntPtr ptr = bmpData.Scan0;
                    int bytes = curBitmap.Width * curBitmap.Height;
                    byte[] grayValues = new byte[bytes];
                    System.Runtime.InteropServices.Marshal.Copy(ptr, grayValues, 0, bytes);

                    byte temp = 0;
                    double[] PPixel = new double[256];
                    double[] QPixel = new double[256];
                    int[] qPixel = new int[256];
                    int[] tempArray = new int[256];
                    for (int i = 0; i < grayValues.Length; i++)
                    {
                        temp = grayValues[i];
                        qPixel[temp]++;
                    }

                    for (int i = 0; i < 256; i++)
                    {
                        if (i != 0)
                        {
                            tempArray[i] = tempArray[i - 1] + qPixel[i];
                        }
                        else
                        {
                            tempArray[0] = qPixel[0];
                        }

                        QPixel[i] = (double)tempArray[i] / (double)bytes;
                    }

                    PPixel = sForm.ApplicationP;

                    double diffA, diffB;
                    byte k = 0;
                    byte[] mapPixel = new byte[256];
                    for (int i = 0; i < 256; i++)
                    {
                        diffB = 1;
                        for (int j = k; j < 256; j++)
                        {
                            diffA = Math.Abs(QPixel[i] - PPixel[j]);
                            if (diffA - diffB < 1.0E-08)
                            {
                                diffB = diffA;
                                k = (byte)j;
                            }
                            else
                            {
                                k = (byte)(j - 1);
                                break;
                            }
                        }
                        if (k == 255)
                        {
                            for (int l = i; l < 256; l++)
                            {
                                mapPixel[l] = k;

                            }
                            break;
                        }
                        mapPixel[i] = k;
                    }

                    for (int i = 0; i < bytes; i++)
                    {
                        temp = grayValues[i];
                        grayValues[i] = mapPixel[temp];
                    }


                    System.Runtime.InteropServices.Marshal.Copy(grayValues, 0, ptr, bytes);
                    curBitmap.UnlockBits(bmpData);
                }
                Invalidate();
            }
        }
    }
}