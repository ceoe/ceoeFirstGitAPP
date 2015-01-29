using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;


namespace Tetris
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        Color[,] bgColors = new Color[15, 10];
        Block block;
        BlockFactory bf = new BlockFactory();
        KeyConfig config = new KeyConfig();
        private bool i = false;
        private int score;

        private void MainForm_Load(object sender, EventArgs e)
        {//把Key.tet文件反序列化为KeyConfig对象
            if (File.Exists("Key.tet"))
            {
                IFormatter formatter = new BinaryFormatter();
                Stream stream = new FileStream("Key.tet", FileMode.Open,
                    FileAccess.Read, FileShare.None);
                config = (KeyConfig)formatter.Deserialize(stream);
                stream.Close();
            }
            
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            Array.Clear(bgColors, 0, bgColors.Length);
            lblBg.Invalidate();
            CreateNewBlock();
            i = true;
            timer1.Start();
            btnPause.Enabled = true;
            btnStart.Text = "重新开始";
        }

        private void CreateNewBlock()
        {
            block = bf.GetABlock();
            block.LblBg = lblBg;
            block.BgColors = bgColors;
            score += (Block.count*Block.count);
            lblScore.Text = Convert.ToString(score);
            if (!block.setBlockPos(3, block.GetIniXPos()))
            {
                timer1.Stop();
                i = false;
                block.PaintGameOver();
                MessageBox.Show("少年，你行不行啊？  你才得了 "+Convert.ToString(score)+" 分",
                    "GAME OVER!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnPause.Enabled = false;
                btnStart.Text = "开始游戏";
            }

        }

        
        
        //防止最小化砖块没有了
        private void lblBg_Paint(object sender, PaintEventArgs e)
        {
            Graphics gp = e.Graphics;
            for (int j = 0; j < 15; j++)
            {
                for (int i = 0; i < 10; i++)
                {
                    if (!bgColors[j, i].IsEmpty)
                    {
                        gp.FillRectangle(new SolidBrush(bgColors[j, i]), i * 21 + 1, j * 21 + 1, 20, 20);
                    }
                }
            }
            if (block != null)
            {
                block.Paint();
            }
            
        }

        

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!block.MoveDown())
            {
                CreateNewBlock();
            }
            
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (i)
            {
                if (e.KeyCode == config.KeyLeft)
                {
                    block.MoveLeft();
                }
                else if (e.KeyCode == config.KeyRight)
                {
                    block.MoveRight();
                }
                else if (e.KeyCode == config.KeyRotate)
                {
                    block.Rotate();
                }
                else if (e.KeyCode == config.KeyDown)
                {
                    block.MoveDown();
                }
                else if (e.KeyCode == config.KeyDrop)
                {
                    block.Drop();
                }
            }
            
        }

        private void btnKeySet_Click(object sender, EventArgs e)
        {
            FrmConfig frmconfig = new FrmConfig(config);
            try
            {
                if (timer1.Enabled)
                {
                    timer1.Stop();
                    btnPause.Text = "继续";
                }
                frmconfig.ShowDialog();
            }
            finally
            {
                frmconfig.Dispose();
            }
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            if (btnPause.Text == "暂停")
            {
                timer1.Stop();
                btnPause.Text = "继续";
                i = false;
            }
            else
            {
                timer1.Start();
                btnPause.Text = "暂停";
                i = true;
            }
        }
    }
}
