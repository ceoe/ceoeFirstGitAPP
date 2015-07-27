using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace geometry_operations
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
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

        private void close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            if (curBitmap != null)
            {
                g.DrawImage(curBitmap, 160, 20, curBitmap.Width, curBitmap.Height);
            }
        }

        private void translation_Click(object sender, EventArgs e)
        {
            if (curBitmap != null)
            {
                translation traForm = new translation();
                if (traForm.ShowDialog() == DialogResult.OK)
                {
                    Rectangle rect = new Rectangle(0, 0, curBitmap.Width, curBitmap.Height);
                    System.Drawing.Imaging.BitmapData bmpData = curBitmap.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadWrite, curBitmap.PixelFormat);
                    IntPtr ptr = bmpData.Scan0;
                    int bytes = curBitmap.Width * curBitmap.Height;
                    byte[] grayValues = new byte[bytes];
                    System.Runtime.InteropServices.Marshal.Copy(ptr, grayValues, 0, bytes);

                    int x = Convert.ToInt32(traForm.GetXOffset);
                    int y = Convert.ToInt32(traForm.GetYOffset);

                    byte[] tempArray = new byte[bytes];
                    //Array.Clear(tempArray, 0, bytes);
                    for (int i = 0; i < bytes; i++)
                    {
                        tempArray[i] = 255;
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

                Invalidate();
            }
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
                    Rectangle rect = new Rectangle(0, 0, curBitmap.Width, curBitmap.Height);
                    System.Drawing.Imaging.BitmapData bmpData = curBitmap.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadWrite, curBitmap.PixelFormat);
                    IntPtr ptr = bmpData.Scan0;
                    int bytes = curBitmap.Width * curBitmap.Height;
                    byte[] grayValues = new byte[bytes];
                    System.Runtime.InteropServices.Marshal.Copy(ptr, grayValues, 0, bytes);

                    int degree = Convert.ToInt32(rotForm.GetDegree);
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
                    curBitmap.UnlockBits(bmpData);
                }

                Invalidate();
            }
        }
    }
}