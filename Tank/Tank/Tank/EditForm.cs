using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Tank.Properties;
using System.IO;
namespace Tank
{
    public partial class EditForm : Form
    {
        StartForm startFrm;
        public EditForm(StartForm frm)
        {

            InitializeComponent();
            this.startFrm = frm;
            panelMap.Cursor = new Cursor("tank.ico");
            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.ResizeRedraw | ControlStyles.OptimizedDoubleBuffer, true);
            //MessageBox.Show("欢迎使用地图编辑器!\r\t\t选取择相应的地形,有地图在拖拽鼠标画出相应的地形,按鼠标右键可以删出相应位置的地形.");
        }
        private int xPos, yPos;
        public static bool[,] arrWall = new bool[44, 44];
        public static bool[,] strArr = new bool[11, 11];
        public static bool[,] arrSteel = new bool[22, 22];
        private Font font = new Font("Tahoma", 9);
        private SolidBrush sbrush = new SolidBrush(Color.Black);
        private void panelMap_Paint(object sender, PaintEventArgs e)
        {
            Singleton.Instance.Draw(e.Graphics);
            Singleton.Instance.RemoveImg();
            panelMap.Invalidate();
            Invalidate();
        }

        private void panelMap_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right)
            {
                return;
            }
            if (radbtnWall.Checked)
            {
                xPos = e.X / 15;
                yPos = e.Y / 15;
                arrWall[xPos, yPos] = !arrWall[xPos, yPos];
            }
            if (radbtnGrass.Checked || radbtnWater.Checked)
            {
                xPos = e.X / 60;
                yPos = e.Y / 60;
                strArr[xPos, yPos] = !strArr[xPos, yPos];
            }
            if (radbtnSteel.Checked)
            {
                xPos = e.X / 30;
                yPos = e.Y / 30;
                arrSteel[xPos, yPos] = !arrSteel[xPos, yPos];
            }
        }

        private void panelMap_MouseMove(object sender, MouseEventArgs e)
        {
            if (radbtnWall.Checked)
            {
                try
                {
                    xPos = e.X / 15;
                    yPos = e.Y / 15;
                    if (e.Button != MouseButtons.Left)
                    {
                        return;
                    }
                    arrWall[xPos, yPos] = true;
                    Singleton.Instance.AddElement(new Wall(xPos * 15, yPos * 15));

                }
                catch
                { }
            }
            if (radbtnGrass.Checked)
            {
                try
                {
                    xPos = e.X / 60;
                    yPos = e.Y / 60;
                    if (e.Button != MouseButtons.Left)
                    {
                        return;
                    }
                    strArr[xPos, yPos] = true;
                    Singleton.Instance.AddElement(new Grass(xPos * 60, yPos * 60));

                }
                catch
                { }
            }
            if (radbtnWater.Checked)
            {
                try
                {
                    xPos = e.X / 60;
                    yPos = e.Y / 60;
                    if (e.Button != MouseButtons.Left)
                    {
                        return;
                    }
                    strArr[xPos, yPos] = true;
                    Singleton.Instance.AddElement(new Water(xPos * 60, yPos * 60));
                }
                catch
                { }
            }
            if (radbtnSteel.Checked)
            {
                try
                {
                    xPos = e.X / 30;
                    yPos = e.Y / 30;
                    if (e.Button != MouseButtons.Left)
                    {
                        return;
                    }
                    arrSteel[xPos, yPos] = true;
                    Singleton.Instance.AddElement(new Steel(xPos * 30, yPos * 30));
                }
                catch
                { }
            }
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            //  MessageBox.Show("afasdf");
            StartForm.isEdit = true;
            startFrm.arr = arrWall;
            this.Close();

        }

        private void EditForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            StartForm.editing = false;
            startFrm.Show();
        }

        private void btnClosed_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void EditForm_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            string str = "X座标: " + xPos.ToString() + "\n" + "Y座标: " + yPos.ToString();
            string info = "使用说明:\n    拖拽鼠标画图,\n右击鼠标删除.";
            g.DrawString(info, font, sbrush, 664, 400);
            g.DrawString(str, font, sbrush, 680, 500);
            //  Invalidate();
        }


    }
}
