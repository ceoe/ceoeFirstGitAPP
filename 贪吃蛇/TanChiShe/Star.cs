using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TanChiShe
{

    public partial class Star : Form
    {
        private Floor floor;
        private int jibei;
        private int jisu;
        private bool starue=true;

        public Star()
        {
            InitializeComponent();
            this.floor = new Floor(new Point(30, 50));
        }
        private void star_Click()
        {
            if (starue == true)
            {
                MessageBox.Show("新速度已经选择，但是你还未开始游戏"+"\n"+"请先开始游戏","注意",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
        }



        private void MenuItem2_Click(object sender, EventArgs e)
        {
            if (MenuItem2.Text == "暂停")
            {
                this.timer1.Enabled = false;
                MenuItem2.Text = "继续";
                toolStripStatusLabel1.Text = "游戏暂停中";
            }

            else
            {
                this.timer1.Enabled = true;
                MenuItem2.Text = "暂停";
                toolStripStatusLabel1.Text = "　游戏进行中";
            }
            MenuItem2.Enabled = false;
            MenuItem.Enabled = true;
        }

        private void MenuItem3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MenuItem5_Click(object sender, EventArgs e)
        {
            floor.score = 0;
            timer1.Interval = 500;
            label4.Text = floor.score.ToString();
            label2.Text = "1";
            star_Click();
        }

        private void MenuItem6_Click(object sender, EventArgs e)
        {
            floor.score = 100;
            timer1.Interval = 400;
            label4.Text = floor.score.ToString();
            label2.Text = "3";
            star_Click();
        }

        private void MenuItem7_Click(object sender, EventArgs e)
        {
            floor.score = 200;
            timer1.Interval = 300;
            label4.Text = floor.score.ToString();
            label2.Text = "5";
            star_Click();
        }

        private void MenuItem8_Click(object sender, EventArgs e)
        {
            floor.score = 300;
            timer1.Interval = 200;
            label4.Text = floor.score.ToString();
            label2.Text = "7";
            star_Click();
            
        }

        private void MenuItem9_Click(object sender, EventArgs e)
        {
            floor.score = 400;
            timer1.Interval = 100;
            label4.Text = floor.score.ToString();
            label2.Text = "9";
            star_Click();
            
        }

        private void MenuItem10_Click(object sender, EventArgs e)
        {
            this.timer1.Enabled = false;
            Speed fw = new Speed();
            fw.ShowDialog();
            this.timer1.Interval = PubClass.kk;
            this.timer1.Enabled = true;
            star_Click();
        }

        private void MenuItem11_Click(object sender, EventArgs e)
        {
            this.timer1.Enabled = false;
            MessageBox.Show("F1 开始／重新开始" + "\n" + "F2 暂停／继续\n" + "上下右左键为控制蛇的方向键");
            this.timer1.Enabled = true;
        }

        private void MenuItem_Click(object sender, EventArgs e)
        {
            this.timer1.Enabled = true;
            if (MenuItem.Text == "开始")
            {
                MenuItem.Text = "重新开始";
            }
            else
            {
                floor.ReSet(this.CreateGraphics());
                floor.score = 0;
            }

            MenuItem2.Enabled = true;
            MenuItem.Enabled = false;
            starue = false;
            toolStripStatusLabel1.Text = "　游戏进行中";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            floor.Display(this.CreateGraphics());
            this.label4.Text = floor.score.ToString();
            jibei = floor.score / 50 + 1;
            if (jibei != jisu && PubClass.kk == 0)
            {
                this.timer1.Interval = 560 - jibei * 50;
                jisu = jibei;
                label2.Text = jibei.ToString();
            }
            if (floor.score >= 550)
            {
                this.timer1.Enabled = false;
                MessageBox.Show("恭喜你通关");
                toolStripStatusLabel1.Text = "　游戏通关";
            }
            if (floor.CheckSnake())
            {

                timer1.Enabled = false;
                MessageBox.Show("很遗憾！蛇撞到墙壁或碰到自身", "游戏结束", MessageBoxButtons.OK, MessageBoxIcon.Information);
                statusStrip1.Text = "游戏结束";
            }
        }

        private void Star_KeyDown(object sender, KeyEventArgs e)
        {
            int k, d = 0;
            k = e.KeyValue;
            if (k == 37)
                d = 3;
            else if (k == 40)
                d = 2;
            else if (k == 38)
                d = 0;
            else if (k == 39)
                d = 1;
            floor.S.TurnDirection(d);
        }


     
    }
}