using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CatchMe_Exp4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCatchMe_Click(object sender, EventArgs e)
        {
            MessageBox.Show("抓住我了,算你反应快!", "抓到了", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private const int BORDER = 20;
        private const int SPACE = 10;

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            int x = e.X;
            int y = e.Y;
            int left = btnCatchMe.Left;
            int right = btnCatchMe.Right;
            int top = btnCatchMe.Top;
            int bot = btnCatchMe.Bottom;
            //鼠标到按钮附近 BORDER个像素时
            if (x>left-BORDER&&x<right+BORDER&&y>top-BORDER&&y<bot+BORDER)
            {
                btnCatchMe.Top += y > top ? -SPACE : SPACE;
                if (btnCatchMe.Top < 0 || btnCatchMe.Bottom > this.Height-30)
                {
                    btnCatchMe.Top = this.Height / 2;
                }
                btnCatchMe.Left += x > left ? -SPACE : SPACE;
                if (btnCatchMe.Left < 0 || btnCatchMe.Right > this.Width)
                {
                    btnCatchMe.Left = this.Width / 2;
                }
            }
            
            
        }



    }
}
