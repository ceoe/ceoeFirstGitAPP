using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tetirs
{
    public partial class FrmTetirs : Form
    {

        private Keys downKey;

        private Keys dropDownKey;

        private Keys moveLeftKey;

        private Keys moveRightKey;

        private Keys rotCWKey;

        private Keys rotCCWKey;


        private int runPanleWidth;

        private int runPanelHeight;

        private Color runPanelbackColor;

        private int rectPix;



        public FrmTetirs()
        {
            InitializeComponent();
        }

        private Palette p;
        private void btnStart_Click(object sender, EventArgs e)
        {
            //这句实例化语句很重要, 将PictureBox产生的Graphic对象, 传递给了p实例.  同时Label标签的Graphic对象也传递给了p.
            //p = new Palette(14, 15, 25, Color.Black, pbRun.CreateGraphics(), lblReady.CreateGraphics());
            //p.Start();

            if (p!=null)
            {
                p.ResetGame();
            }

            p=new Palette(runPanleWidth,runPanelHeight,rectPix,runPanelbackColor,Graphics.FromHwnd(pbRun.Handle),
                Graphics.FromHwnd(lblReady.Handle));
            p.Start();


            #region  对生成的串ID进行处理,截取按列组成的数组,返回字符串,保存在字符串引用ss中.

            string aa = p.RunBlockInfoId;
            StringBuilder ss = new StringBuilder();

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    ss.Append(aa[j * 5 + i]);
                }
                ss.Append("\r\n");
            }

            txtRunBlockList.Text = ss.ToString();
            txtRunReadyBlock.Text = aa;
            txtRunBlockStyle.Text = p.RunBlock.ListAllElement();


            #endregion


        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            p.Down();
        }

        private void btnCallCfg_Click(object sender, EventArgs e)
        {
            if (btnPause.Text == "暂停")
            {
              btnPause.PerformClick();
            }
            using (FrmConfig  frmConfig=new FrmConfig())
            {
                frmConfig.ShowDialog();
            }
          
        }



        private void btnLeft_Click(object sender, EventArgs e)
        {
            p.MoveLeft();
        }

        private void btnRight_Click(object sender, EventArgs e)
        {
            p.MoveRight();
        }

        private void btnRotCW_Click(object sender, EventArgs e)
        {
            p.RotCW();
        }

        private void btnRotCCW_Click(object sender, EventArgs e)
        {
            p.RotCCW();
        }

        private void pbRun_Paint(object sender, PaintEventArgs e)
        {
            if (p != null)
            {
                p.PaintPalette(e.Graphics);
            }
        }

        private void lblReady_Paint(object sender, PaintEventArgs e)
        {
            if (p != null)
            {
                p.PaintReadyBlock(e.Graphics);
            }
        }

        private void btnCheckOver_Click(object sender, EventArgs e)
        {
            if (p != null)
            {
                p.CheckOverAndRenewBlock();
                #region  对生成的串ID进行处理,截取按列组成的数组,返回字符串,保存在字符串引用ss中.

                string aa = p.RunBlockInfoId;
                StringBuilder ss = new StringBuilder();

                for (int i = 0; i < 5; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        ss.Append(aa[j * 5 + i]);
                    }
                    ss.Append("\r\n");
                }

                txtRunBlockList.Text = ss.ToString();
                txtRunReadyBlock.Text = aa;
                txtRunBlockStyle.Text = p.RunBlock.ListAllElement();


                #endregion
            }
        }

        private void btnDrop_Click(object sender, EventArgs e)
        {
            if (p != null)
            {
                p.DropDwon();
            }
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            if (p != null)
            {
                if (btnPause.Text == "暂停")
                {
                    p.GamePause();
                    btnPause.Text = "继续";
                }
                else
                {
                    p.EndPause();
                    btnPause.Text = "暂停";
                }
            }
        }

        private void FrmTetirs_Load(object sender, EventArgs e)
        {
            Config config = new Config();
            config.LoadFromXmlFile();

            downKey = config.DownKey;
            dropDownKey = config.DropDownKey;
            moveLeftKey = config.MoveLeftKey;
            moveRightKey = config.MoveRightKey;
            rotCWKey = config.RotCwKey;
            rotCCWKey = config.RotCcwKey;
            runPanleWidth = config.CoorWidth;
            runPanelHeight = config.CoorHeight;
            runPanelbackColor = config.BackColor;
            rectPix = config.RectPix;

            this.Width = runPanleWidth * rectPix + 234;
            this.Height = runPanelHeight * rectPix + 50;
            pbRun.Width = runPanleWidth * rectPix;
            pbRun.Height = runPanelHeight * rectPix;
        }

        private void FrmTetirs_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 32)
            {
                e.Handled = true;
            }
            else if (e.KeyCode == downKey)
            {
                p.Down();
            }
            else if (e.KeyCode == moveLeftKey)
            {
                p.MoveLeft();
             }
            else if (e.KeyCode==moveRightKey)
            {
                p.MoveRight();
            }
            else if (e.KeyCode==dropDownKey)
            {
                p.DropDwon(); 
            }
            else if (e.KeyCode==rotCWKey)
            {
                p.RotCW();
            }
            else if (e.KeyCode==rotCCWKey)
            {
                p.RotCCW();
            }
        }

        private void FrmTetirs_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (p!=null)
            {
                p.ResetGame();
            }
        }
    }
}

