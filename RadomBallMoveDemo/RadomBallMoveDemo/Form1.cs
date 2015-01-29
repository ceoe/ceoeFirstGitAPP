using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RadomBallMoveDemo
{
   
   
    
    
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private Color[] setColor =
            {
                Color.CadetBlue,
                Color.DeepSkyBlue,
                Color.Green,
                Color.Blue,
                Color.Cyan,
                Color.Yellow,
                Color.Brown,
                Color.Olive,
                Color.Orange,
                Color.OrangeRed,
                Color.Orchid,
                Color.BlueViolet,
            };

        private int BallSize = 30;
        private float BallThin = 2.0f;
        int [,]  arrBall=new int[1024,5];



        private int MaxSpeedX =30;
        private int MaxSpeedY = 25;

       

        Random  rd=new Random();

        private bool isPlaying = false;

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
           
            Bitmap bmp=new Bitmap(ClientSize.Width,ClientSize.Height);
            Graphics bmpGraphics = Graphics.FromImage(bmp);
              for (int i = 0; i < arrBall.GetLength(0); i++)
              {
                  bmpGraphics.DrawEllipse(new Pen(Color.FromArgb(arrBall[i, 4]), BallThin),
                      arrBall[i,0],arrBall[i,1],
                      BallSize,BallSize);
              }
            e.Graphics.DrawImage(bmp,0,0);
            bmpGraphics.Dispose();
            bmp.Dispose();

        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            if (!isPlaying)
            {
                timer1.Start();
                isPlaying = true;
                btnPlay.Text = "Stop";
            }
            else
            {
                timer1.Stop();
                isPlaying = false;
                btnPlay.Text = "Play";
            }
            
           
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
            for (int i = 0; i < arrBall.GetLength(0); i++)
            {
                arrBall[i, 0] = rd.Next(0, ClientSize.Width-BallSize);
                arrBall[i, 1] = rd.Next(0, ClientSize.Height-BallSize);
                arrBall[i, 2] = rd.Next(12, MaxSpeedX);
                arrBall[i, 3] = rd.Next(12, MaxSpeedY);
                arrBall[i, 4] = setColor[rd.Next(0, 12)].ToArgb();

            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < arrBall.GetLength(0); i++)
            {
                arrBall[i, 0] += arrBall[i, 2];
                arrBall[i, 1] += arrBall[i, 3];
                if (arrBall[i, 0] < 0 || arrBall[i, 0]+BallSize>ClientSize.Width)
                {
                    arrBall[i, 2] = -arrBall[i, 2];
                    arrBall[i, 4] = setColor[rd.Next(0, 12)].ToArgb();
                }

                if (arrBall[i, 1] < 0 || arrBall[i, 1] + BallSize > ClientSize.Height)
                {
                    arrBall[i, 3] = -arrBall[i, 3];
                    arrBall[i, 4] = setColor[rd.Next(0, 12)].ToArgb();
                }
            }
            this.Refresh();
        }
    }
}
