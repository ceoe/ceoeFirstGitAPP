using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RockForfexClothFightExp1
{
    public partial class Main_Form : Form
    {
        public Main_Form()
        {
            InitializeComponent();
        }

        private int rivalScore = 0;
        private int myScore = 0;
        private void btnRock_Click(object sender, EventArgs e)
        {
            //0表示 石头, 1 表示 剪刀  , 2 表示布
            Random  rd=new Random();
            int myNum = lblMy.ImageIndex = ((Button) sender).ImageIndex;
            int rivalNum = lblRival.ImageIndex = rd.Next(0, 3);

            int result = rivalNum - myNum;
            if (result==0)
            {
                lblResult.Text = "平";
            }
            else
            {
                if (result==-1||result==2)
                {
                    lblResult.Text = "输";
                    rivalScore++;
                }
                else
                {
                    lblResult.Text = "赢";
                    myScore++;
                }
            }
            lblMyScore.Text = myScore.ToString();
            lblRivalScore.Text = rivalScore.ToString();
        }
    }
}
