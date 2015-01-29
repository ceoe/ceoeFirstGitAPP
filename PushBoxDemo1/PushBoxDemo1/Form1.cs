using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PushBoxDemo1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Label  [,]  _arrLabel=new Label[3,3];
        private int unCol = 0;
        private int unRow = 0;
        private int coverNum = 0;
        private bool playing = false;
        private bool isFinish = true;

        private void Form1_Load(object sender, EventArgs e)
        {
           
            int countNum = 8;
            foreach (Control label in panel1.Controls)
            {

                if (label is Label)
                {
                    Label templab = label as Label;
                    _arrLabel[countNum / 3, countNum % 3] = templab;
                    countNum--;
                }
            }

        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            int[] _arrNum = {1,2,3,4,5,6,7,8,9};
            Random  rd=new Random();
            for (int i = 8; i > 0; i--)
            {
                int rdnum=rd.Next(0, i + 1);
                int temprd = _arrNum[rdnum];
                _arrNum[rdnum] = _arrNum[i];
                _arrNum[i]=temprd;
            }

            int k = 0;
            for (int i = 0; i < _arrLabel.GetLength(0); i++)
            {
                for (int j = 0; j < _arrLabel.GetLength(1); j++)
                {
                    _arrLabel[i, j].Text = _arrNum[k].ToString();
                    k++;
                }
            }

            _arrLabel[unRow, unCol].Visible = true;
            Random rdc = new Random();
            coverNum = rdc.Next(0, 9);
            unCol = coverNum % 3;
            unRow = coverNum / 3;
            _arrLabel[unRow, unCol].Visible = false;
            playing = true;


        }

        private void label1_Click(object sender, EventArgs e)
        {
            if (!playing)
            {
                return; 
            }
            int nextRow = ((Label) sender).Top/80;
            int nextCol = ((Label)sender).Left / 80;

           // if (Math.Abs(nextRow-unRow)+Math.Abs(nextCol-unCol)==1)
            {
                string tempstr = _arrLabel[unRow, unCol].Text;
                _arrLabel[unRow, unCol].Text = _arrLabel[nextRow, nextCol].Text;
                _arrLabel[nextRow, nextCol].Text = tempstr;
               
                _arrLabel[unRow, unCol].Visible = true;
                unCol = nextCol;
                unRow = nextRow;
                _arrLabel[unRow, unCol].Visible = false;
               
            }

            int inc = 1;
            for (int i = 0; i < _arrLabel.GetLength(0); i++)
            {
                for (int j = 0; j < _arrLabel.GetLength(1); j++)
                {
                    if (_arrLabel[i,j].Text!=inc.ToString())
                    {
                        isFinish = false;
                        break;
                    }
                    inc++;
                    if (i==(_arrLabel.GetLength(0)-1)&&j==(_arrLabel.GetLength(1)-1))
                    {
                        isFinish = true;
                        MessageBox.Show("顺利过关了!");
                    }
                }
            }
          
        }

        



    }
}
