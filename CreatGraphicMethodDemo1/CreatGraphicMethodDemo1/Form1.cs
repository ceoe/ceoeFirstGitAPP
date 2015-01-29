using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace CreatGraphicMethodDemo1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnDrawLine_Click(object sender, EventArgs e)
        {
            Graphics g= this.CreateGraphics();;

            
            Pen p=new Pen(Color.DarkRed,3);
            g.DrawLine(p,20,100,270,100);


             p = new Pen(Color.BlueViolet, 3);
            g.DrawLine(p, 20, 150, 270, 150);


            p = new Pen(Color.Chartreuse, 5);
            g.DrawLine(p, 20, 200, 270, 200);


            p = new Pen(Color.ForestGreen, 8);
            g.DrawLine(p, 20, 250, 270, 250);

            p.Width = 10;
            g.DrawLine(p, 20, 300, 270, 300);

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Pen  BlackPen=new Pen(Color.White,3);
            g.DrawLine(BlackPen, 20, 50, 270, 50);

            
  
            SolidBrush sb=new SolidBrush(Color.Chartreuse);
            g.FillRectangle(sb,20,355,80,80);

            HatchBrush  hb=new HatchBrush(HatchStyle.Cross, Color.LightSeaGreen,Color.SlateGray);
            g.FillRectangle(hb, 105, 355, 80, 80);

            Rectangle  rect=new Rectangle(190,355,80,80);
            LinearGradientBrush lgb=new LinearGradientBrush(rect,Color.Chartreuse,Color.Firebrick,LinearGradientMode.ForwardDiagonal);
            g.FillRectangle(lgb,rect);

            Pen BluePen =new Pen(Color.DeepSkyBlue,3);

            Rectangle  rect2=new Rectangle(290,20,100,100);

            g.DrawRectangle(BluePen,rect2);
            Rectangle [] rects=new Rectangle[3];

       

            rect2.Offset(120,120);
            rects[0] = rect2;
          

            rect2.Inflate(20,10);
            rects[1] = rect2;

            rect2.X = 400;
            rect2.Y = 20;
            rect2.Height = 75;
            rect2.Width = 105;

            rects[2] = rect2;
             BluePen = new Pen(Color.Green, 3);
            BluePen.Width = 4;
            g.DrawRectangles(BluePen,rects);

            Rectangle [] rects3=new Rectangle[10];

            Rectangle arect=new Rectangle(290, 280,20,20);

            for (int i = 0; i < rects3.Length; i++)
            {
              
               // arect.Inflate(i,i);
                //arect.Offset(10, 10);
                //int ox = arect.Top, oy = arect.Left;
                //arect.Inflate(i*4, i*4);
                //int zx = arect.Top, zy = arect.Left;

                rects3[i] = arect;
                rects3[i].Inflate(i*4,i*4);
                //rects3[i].X = rects3[i].X + i * 5 + i * 4;
                //rects3[i].Y = rects3[i].Y + i * 5 + i * 4;
            }

            BluePen.Color = Color.OrangeRed;
            BluePen.Width = 1;
            g.DrawRectangles(BluePen, rects3);

        }


    }
}
