using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClockOnScreenDemo
{
    public partial class MainForm : Form
    {
        private const int Radius = 150;
        private int hour, min, sec;
        private PointF centrolPoint;
        private int ShirkSize = 50;
        private int AllShirkSize;



        public MainForm()
        {
            InitializeComponent();
            centrolPoint.X = ClientSize.Width / 2;
            centrolPoint.Y = ClientSize.Height / 2;
            AllShirkSize = ShirkSize + ShirkSize;

        }

        protected PointF AngleToPoint(int angle, float lengthPercent)
        {
            PointF pos = new PointF();
            Double rad = angle * Math.PI / 180;
            pos.X = centrolPoint.X + (float)(Radius * lengthPercent * Math.Cos(rad));
            pos.Y = centrolPoint.Y - (float)(Radius * lengthPercent * Math.Sin(rad));
            return pos;

        }


        protected PointF AngleToPoint(int angle, int radii, Point centrolDot, float lengthPercent)
        {
            PointF pos = new PointF();
            Double rad = angle * Math.PI / 180;
            pos.X = centrolDot.X + (float)(radii * lengthPercent * Math.Cos(rad));
            pos.Y = centrolDot.Y - (float)(radii * lengthPercent * Math.Sin(rad));
            return pos;

        }

        private void DrawIndicator(Graphics g)
        {
            DateTime dt = DateTime.Now;
            hour = dt.Hour;
            min = dt.Minute;
            sec = dt.Second;

            PointF endHour = AngleToPoint(hour >= 12 ? 90 - (hour - 12) * 30 - min / 2 : 90 - hour * 30 - min / 2, 0.5f);
            g.DrawLine(new Pen(Color.LimeGreen, 7), centrolPoint, endHour);

            PointF endMin = AngleToPoint(90 - min * 6, 0.7f);
            g.DrawLine(new Pen(Color.Firebrick, 4), centrolPoint, endMin);

            PointF endSec = AngleToPoint(90 - sec * 6, 0.88f);
            g.DrawLine(new Pen(Color.Maroon, 1), centrolPoint, endSec);



        }

        public void DrawScaleAndDisk(Graphics g)
        {
            // 画圆盘
            g.DrawEllipse(new Pen(Color.OrangeRed, 10), 25 + (ClientSize.Width - ClientSize.Height) / 2, 25, ClientSize.Width - 50 - (ClientSize.Width - ClientSize.Height), ClientSize.Height - 50);

            for (int i = 0; i < 360; i += 6)
            {
                Pen tempPen = (i % 30 == 0) ? new Pen(Color.DarkViolet, 6) : new Pen(Color.LimeGreen, 3);
                PointF startPoint = AngleToPoint(i, 0.82f);
                PointF endPoint = AngleToPoint(i, 0.95f);
                g.DrawLine(tempPen, startPoint, endPoint);
            }
            //
            g.FillEllipse(new SolidBrush(Color.Black), centrolPoint.X - 8, centrolPoint.Y - 8, 16, 16);

        }

        private void menuStripItemClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void menuStripItemHide_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void menuStripItemShow_Click(object sender, EventArgs e)
        {
            this.Visible = true;
        }

        private void MainForm_Paint(object sender, PaintEventArgs e)
        {
            //DrawIndicator(e.Graphics);
            //DrawScaleAndDisk(e.Graphics);
            Graphics g = e.Graphics;

            Bitmap bp = new Bitmap(ClientSize.Width, ClientSize.Height);
            GeneratorClockBmp(bp);

            g.DrawImage(bp, 0, 0);
            //g.Dispose();
            //bp.Dispose();



        }

        private void GeneratorClockBmp(Bitmap bp)
        {
            Pen  diskPen=new Pen(Color.Fuchsia,8);
            Pen  scalePen=new Pen(Color.Green,4);
            Pen  bigscalePen=new Pen(Color.DarkOrange,6);
            Point  centrolDot =new Point(bp.Width/2,bp.Height/2);
            int radii;

            DateTime dt = DateTime.Now;
            hour = dt.Hour;
            min = dt.Minute;
            sec = dt.Second;

            Rectangle diskrect;
            if (bp.Width>=bp.Height)
            {
                diskrect = new Rectangle(ShirkSize, ShirkSize, bp.Height - AllShirkSize, bp.Height - AllShirkSize);
                diskrect.X = diskrect.X + (bp.Width - bp.Height)/2;
                radii = (int)((bp.Height - AllShirkSize)/2*0.85);

            }
            else
            {
                diskrect = new Rectangle(ShirkSize, ShirkSize, bp.Width - AllShirkSize, bp.Width - AllShirkSize);
                diskrect.Y = diskrect.Y + (bp.Height - bp.Width) / 2;
                radii = (int)((bp.Width - AllShirkSize) / 2 * 0.9);
            }

           //Rectangle  diskrect=new Rectangle((bp.Width>=bp.Height)?(10,10,bp.Height-10,bp.Height-10):(10,10,bp.Width-10,bp.Width-10));
            
            //画圆盘
            Graphics gg = Graphics.FromImage(bp);
            gg.DrawEllipse(diskPen,diskrect);

          

            //画刻度
            for (int i = 0; i < 360; i+=6)
            {
                Pen tempPen =( i%30 == 0) ? bigscalePen : scalePen;
                PointF startp, endp;

                if (i % 30 == 0)
                {
                    tempPen = bigscalePen;
                     startp = AngleToPoint(i, radii, centrolDot, 1f);
                    endp = AngleToPoint(i, radii, centrolDot, 0.75f);
                }
                else
                {
                    tempPen = scalePen;
                    startp = AngleToPoint(i, radii, centrolDot, 1f);
                    endp = AngleToPoint(i, radii, centrolDot, 0.85f);
                }
               
                gg.DrawLine(tempPen,startp,endp);
            }

            // 画时,分,秒

            PointF endHour = AngleToPoint(hour >= 12 ? 90 - (hour - 12) * 30 - min / 2 : 90 - hour * 30 - min / 2, radii, centrolDot, 0.5f);
            gg.DrawLine(new Pen(Color.LimeGreen, 7), centrolDot, endHour);

            PointF endMin = AngleToPoint(90 - min * 6, radii, centrolDot, 0.7f);
            gg.DrawLine(new Pen(Color.Firebrick, 4), centrolDot, endMin);

            PointF endSec = AngleToPoint(90 - sec * 6, radii, centrolDot, 0.88f);
            gg.DrawLine(new Pen(Color.Maroon, 1), centrolDot, endSec);

            //画中心点
            gg.FillEllipse(new SolidBrush(Color.DarkRed), centrolDot.X - 8, centrolDot.Y - 8, 16, 16);

            //  画时间:
            gg.DrawString(dt.ToLongTimeString(),new Font("Verdana",20),  
new SolidBrush(Color.Tomato),40,40);  
gg.DrawRectangle(new Pen(Color.Pink,3),20,20,180,80);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Refresh();

        }

    }
}
