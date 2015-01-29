using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PuzzlePictureGameDemo1
{
    public partial class Main_Form : Form
    {
        public Main_Form()
        {
            InitializeComponent();
        }

        private Label[,] arrlbl = new Label[3,3];
        private int unRow = 0, unCol = 0;
        private bool playing = false;

        private void Form1_Load(object sender, EventArgs e)
        {
            this.SuspendLayout();
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Label lbl = new Label();
                    lbl.Text = "";
                    lbl.AutoSize = false;
                    lbl.Size = new Size(80, 80);
                    lbl.Location = new Point(j*80, i*80);
                    lbl.ImageList = imgLst;
                    lbl.Click += new System.EventHandler(this.lblPic_Click);
                    panel1.Controls.Add(lbl);
                    arrlbl[i, j] = lbl;
                }
            }
            this.ResumeLayout();
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            //if (playing == true && btnPlay.Text == "暂停")
            //{
            //    DialogResult dr = MessageBox.Show("游戏暂停,是否继续!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Question);
            //    if (dr == DialogResult.Yes)
            //    {
            //        btnPlay.Text = "暂停";
            //    }
            //}
            arrlbl[unRow, unCol].Visible = true;
            int[] arrNum = { 0, 1, 2, 3, 4, 5, 6, 7, 8 };
            Random rd = new Random();
            for (int i = 0; i < arrNum.GetUpperBound(0); i++)
            {
                //int rdNum = rd.Next(i, arrNum.Length);
                int rdNum = i;
                int temp = arrNum[i];
                arrNum[i] = arrNum[rdNum];
                arrNum[rdNum] = temp;

            }
            for (int i = 0; i < arrNum.Length; i++)
            {
                arrlbl[i / 3, i % 3].ImageIndex = arrNum[i];
                arrlbl[i / 3, i % 3].BorderStyle = BorderStyle.FixedSingle;
            }

            int Cover = rd.Next(0, 9);
            arrlbl[unRow, unCol].Visible = true;
            unRow = Cover / 3;
            unCol = Cover % 3;
            arrlbl[unRow, unCol].Visible = false;
            playing = true;
            btnPlay.Text = "暂停";
        }

        private void lblPic_Click(object sender, EventArgs e)
        {
            if (!playing)
            {
                return;
            }
            int row = ((Label) sender).Top/80;
            int col = ((Label) sender).Left/80;
            if (Math.Abs(unCol-col)+Math.Abs(unRow-row)==1)
            {
                int temp = arrlbl[row, col].ImageIndex;
                arrlbl[row, col].ImageIndex = arrlbl[unRow, unCol].ImageIndex;
                arrlbl[unRow, unCol].ImageIndex = temp;
                arrlbl[row, col].Visible = false;
                arrlbl[unRow, unCol].Visible = true;
                unCol = col;
                unRow = row;
            }

            for (int i = 0; i < 9; i++)
            {
                if (arrlbl[i/3,i%3].ImageIndex!=i)
                {
                    break;
                }
                if (i==8)
                {
                    arrlbl[unRow, unCol].Visible = true;
                    foreach (Label lb in arrlbl)
                    {
                        lb.BorderStyle=BorderStyle.None;
                    }
                    playing = false;
                    MessageBox.Show("恭喜你过关了!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

       
        }
    }

