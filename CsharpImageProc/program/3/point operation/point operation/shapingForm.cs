using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace point_operation
{
    public partial class shapingForm : Form
    {
        public shapingForm()
        {
            InitializeComponent();
            shapingPixel = new int[256];
            cumHist = new double[256];
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
                shapingFileName = opnDlg.FileName;
                try
                {
                    shapingBitmap = (Bitmap)Image.FromFile(shapingFileName);
                }
                catch (Exception exp)
                {
                    MessageBox.Show(exp.Message);
                }

                Rectangle rect = new Rectangle(0, 0, shapingBitmap.Width, shapingBitmap.Height);
                System.Drawing.Imaging.BitmapData bmpData = shapingBitmap.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadWrite, shapingBitmap.PixelFormat);
                IntPtr ptr = bmpData.Scan0;
                shapingSize = shapingBitmap.Width * shapingBitmap.Height;
                byte[] grayValues = new byte[shapingSize];
                System.Runtime.InteropServices.Marshal.Copy(ptr, grayValues, 0, shapingSize);

                byte temp = 0;
                maxPixel = 0;
                
                Array.Clear(shapingPixel,0,256);


                for (int i = 0; i < shapingSize; i++)
                {
                    temp = grayValues[i];
                    shapingPixel[temp]++;
                    if (shapingPixel[temp] > maxPixel)
                    {
                        maxPixel = shapingPixel[temp];
                    }
                }
                System.Runtime.InteropServices.Marshal.Copy(grayValues, 0, ptr, shapingSize);
                shapingBitmap.UnlockBits(bmpData);
            }
            Invalidate();
        }

        private void startShaping_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void shapingForm_Paint(object sender, PaintEventArgs e)
        {
            if (shapingBitmap != null)
            {
                Pen curPen = new Pen(Brushes.Black, 1);
                Graphics g = e.Graphics;
                g.DrawLine(curPen, 50, 240, 320, 240);
                g.DrawLine(curPen, 50, 240, 50, 30);

                g.DrawLine(curPen, 100, 240, 100, 242);
                g.DrawLine(curPen, 150, 240, 150, 242);
                g.DrawLine(curPen, 200, 240, 200, 242);
                g.DrawLine(curPen, 250, 240, 250, 242);
                g.DrawLine(curPen, 300, 240, 300, 242);

                g.DrawString("0", new Font("New Timer", 8), Brushes.Black, new PointF(46, 242));
                g.DrawString("50", new Font("New Timer", 8), Brushes.Black, new PointF(92, 242));
                g.DrawString("100", new Font("New Timer", 8), Brushes.Black, new PointF(139, 242));
                g.DrawString("150", new Font("New Timer", 8), Brushes.Black, new PointF(189, 242));
                g.DrawString("200", new Font("New Timer", 8), Brushes.Black, new PointF(239, 242));
                g.DrawString("250", new Font("New Timer", 8), Brushes.Black, new PointF(289, 242));

                g.DrawLine(curPen, 48, 40, 50, 40);
                g.DrawString("0", new Font("New Timer", 8), Brushes.Black, new PointF(34, 234));
                g.DrawString(maxPixel.ToString(), new Font("New Timer", 8), Brushes.Black, new PointF(18, 34));

                double temp = 0;
                int[] tempArray = new int[256];
                for (int i = 0; i < 256; i++)
                {
                    temp = 200 * (double)shapingPixel[i] / (double)maxPixel;
                    g.DrawLine(curPen, 50 + i, 240, 50 + i, 240 - (int)temp);

                    if (i != 0)
                    {
                        tempArray[i] = tempArray[i - 1] + shapingPixel[i];
                    }
                    else
                    {
                        tempArray[0] = shapingPixel[0];
                    }

                    cumHist[i] = (double)tempArray[i] / (double)shapingSize;

                }

                curPen.Dispose();
            }
        }

        public double[] ApplicationP
        {
            get
            {
                return cumHist;
            }
        }
    }
}