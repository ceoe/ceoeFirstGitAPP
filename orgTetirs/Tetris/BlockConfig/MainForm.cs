using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BlockConfig
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        //private SolidBrush blockBrush = new SolidBrush(Color.Red);
        //private SolidBrush bgBrush = new SolidBrush(Color.Black);
        private bool[,] MatrixArr = new bool[4, 4];
        private Color BlockColor = Color.Red;  //绘制砖块的背景色

        private void lblMatrix_Paint(object sender, PaintEventArgs e)
        {
            Graphics gp = e.Graphics;
            gp.Clear(Color.Black);
            Pen p = new Pen(Color.White);
            for (int i = 21; i < 80; i = i + 21)
            {
                gp.DrawLine(p, 1, i, 84, i);
            }
            for (int j = 21; j < 80; j = j + 21)
            {
                gp.DrawLine(p, j, 1, j, 84);
            }
            //重绘砖块,防止最小化它就没了
            for (int x = 0; x < 4; x++)
            {
                for (int y = 0; y < 4; y++)
                {
                    if (MatrixArr[x, y])
                    {
                        gp.FillRectangle(new SolidBrush(BlockColor),
                            y * 21 + 1, x * 21 + 1,
                            20, 20);
                    }
                }
            }
        }

        private void lblMatrix_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            {
                return;
            }
            int xPos = e.Y / 21;
            int yPos = e.X / 21;
            MatrixArr[xPos, yPos] = !MatrixArr[xPos, yPos];
            Graphics gp = lblMatrix.CreateGraphics();
            SolidBrush sb = new SolidBrush(MatrixArr[xPos, yPos] ? BlockColor : Color.Black);
            gp.FillRectangle(sb, yPos * 21 + 1, xPos * 21 + 1, 20, 20);
            gp.Dispose();
            int mode = 0, i = 1;
            foreach (bool b in MatrixArr)
            {
                if (b)
                {
                    mode = mode | i;
                }
                i=i << 1;
            }
            lblMode.Text = mode.ToString();
        }
    }
}
