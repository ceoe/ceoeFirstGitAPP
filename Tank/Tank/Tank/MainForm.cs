using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using Tank.Properties;
using System.Media;
using System.Diagnostics;

namespace Tank
{
    public partial class MainForm : Form
    {

        public MainForm()
        {
            InitializeComponent();
            InitGame();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.ResizeRedraw | ControlStyles.OptimizedDoubleBuffer, true);
        }

        private Image minTank = Resources.mintank;
        private Image p1Tank = Resources.p1tankU;
        private Image p2Tank = Resources.p2tankU;
     //   private StartForm startFrm;         //开始窗口的对象
        private Graphics g = null;         
        private Graphics gp = null;
        private Random rdm = new Random();      //随机数
        private bool isStart = false;
        private int enemyNum = 24;         //敌人坦克数量
        private int count;            //敌人剩下的坦克数量
        private int n = 0;
        private Font font = new Font("Tahoma", 15, FontStyle.Bold);
        private SolidBrush sbrush = new SolidBrush(Color.Black);
        /// <summary>
        /// 初始化游戏
        /// </summary>
        private void InitGame()
        {
            Singleton.Instance.AddElement(new Born(100, 100));
            InitMap();      //初始化地图            
            Singleton.Instance.AddElement(new P1Tank(200, 600, 5, 1, directions.U));      //创建玩家1坦克
            if (StartForm.isMultiplayer)           //如果是双人游戏
            {
                Singleton.Instance.AddElement(new P2Tank(400, 600, 5, 1, directions.U));   //创建玩家2坦克
            }
        }

        private void InitUI(Graphics gp)       //初始化用户界面
        {
            #region 画敌人坦克的缩略图
            count = enemyNum;
            switch ((count - 1) / 3)
            {
                case 0:
                    for (int i = 0; i < count; i++)
                    {
                        gp.DrawImage(minTank, 665 + i * 32, 3);
                    }
                    break;
                case 1:
                    for (int i = 0; i < 3; i++)
                    {
                        gp.DrawImage(minTank, 665 + i * 32, 3);
                    }
                    for (int i = 0; i < count - 3; i++)
                    {
                        gp.DrawImage(minTank, 665 + i * 32, 3 + 32);
                    }
                    break;
                case 2:
                    for (int i = 0; i < 3; i++)
                    {
                        for (int j = 0; j < 2; j++)
                        {
                            gp.DrawImage(minTank, 665 + i * 32, 3 + j * 32);
                        }
                    }
                    for (int i = 0; i < count - 6; i++)
                    {
                        gp.DrawImage(minTank, 665 + i * 32, 3 + 2 * 32);
                    }
                    break;
                case 3:
                    for (int i = 0; i < 3; i++)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            gp.DrawImage(minTank, 665 + i * 32, 3 + j * 32);
                        }
                    }
                    for (int i = 0; i < count - 9; i++)
                    {
                        gp.DrawImage(minTank, 665 + i * 32, 3 + 3 * 32);
                    }
                    break;
                case 4:
                    for (int i = 0; i < 3; i++)
                    {
                        for (int j = 0; j < 4; j++)
                        {
                            gp.DrawImage(minTank, 665 + i * 32, 3 + j * 32);
                        }
                    }
                    for (int i = 0; i < count - 12; i++)
                    {
                        gp.DrawImage(minTank, 665 + i * 32, 3 + 4 * 32);
                    }
                    break;
                case 5:
                    for (int i = 0; i < 3; i++)
                    {
                        for (int j = 0; j < 5; j++)
                        {
                            gp.DrawImage(minTank, 665 + i * 32, 3 + j * 32);
                        }
                    }
                    for (int i = 0; i < count - 15; i++)
                    {
                        gp.DrawImage(minTank, 665 + i * 32, 3 + 5 * 32);
                    }
                    break;
                case 6:
                    for (int i = 0; i < 3; i++)
                    {
                        for (int j = 0; j < 6; j++)
                        {
                            gp.DrawImage(minTank, 665 + i * 32, 3 + j * 32);
                        }
                    }
                    for (int i = 0; i < count - 18; i++)
                    {
                        gp.DrawImage(minTank, 665 + i * 32, 3 + 6 * 32);
                    }
                    break;
                case 7:
                    for (int i = 0; i < 3; i++)
                    {
                        for (int j = 0; j < 7; j++)
                        {
                            gp.DrawImage(minTank, 665 + i * 32, 3 + j * 32);
                        }
                    }
                    for (int i = 0; i < count - 21; i++)
                    {
                        gp.DrawImage(minTank, 665 + i * 32, 3 + 7 * 32);
                    }
                    break;
            }
            #endregion
            #region 画玩家坦克的缩略图
            gp.DrawImage(p1Tank, 665, 500, 50, 50);
            gp.DrawImage(p2Tank, 665, 600, 50, 50);
            string s1 = Singleton.Instance.P1Tank.Live.ToString();
            if (s1 == "-1")
            {
                s1 = "0";
            }
            gp.DrawString(s1, font, sbrush, 720, 520);
            if (StartForm.isMultiplayer)
            {
                string s2 = Singleton.Instance.P2Tank.Live.ToString();

                if (s2 == "-1")
                {
                    s2 = "0";
                }
                gp.DrawString(s2, font, sbrush, 720, 620);
            }
            #endregion
        }
        /// <summary>
        /// 初始化地图
        /// </summary>
        private void InitMap()
        {
            if (!StartForm.isEdit)           //如果没用自定义地图
            {
                for (int i = 0; i < 10; i++)
                {
                    Singleton.Instance.AddElement(new Wall(i * 15 + 30, 100));   //字母T的横
                    Singleton.Instance.AddElement(new Wall(95, 100 + 15 * i));   //字母T的竖

                    Singleton.Instance.AddElement(new Wall(245 - i * 7, 100 + 15 * i));      //字母A的撇
                    Singleton.Instance.AddElement(new Wall(245 + i * 7, 100 + 15 * i));  //字母A的捺
                    Singleton.Instance.AddElement(new Wall(215 + i * 15 / 2, 185));     //字母A的横

                    Singleton.Instance.AddElement(new Wall(390 - i * 5, 100 + 15 * i));   //字母N的撇
                    Singleton.Instance.AddElement(new Wall(390 + i * 5, 100 + 15 * i));  //字母N的捺
                    Singleton.Instance.AddElement(new Wall(480 - i * 5, 100 + 15 * i));   //字母N的撇

                    Singleton.Instance.AddElement(new Wall(515, 100 + 15 * i));          //字母K的竖
                    Singleton.Instance.AddElement(new Wall(595 - i * 8, 100 + 15 * i / 2));      //字母N的撇
                    Singleton.Instance.AddElement(new Wall(530 + i * 8, 165 + 15 * i / 2));    //字母N的捺
                }
            }

            for (int i = 0; i < 4; i++)                //画出标志边上的墙
            {
                Singleton.Instance.AddElement(new Wall(285, 600 + i * 15));
                Singleton.Instance.AddElement(new Wall(360, 600 + i * 15));
                Singleton.Instance.AddElement(new Wall(300 + i * 15, 600));
            }
            Singleton.Instance.AddElement(new Symbol(300, 615));    //画出标志
        }

        private void MainForm_Paint(object sender, PaintEventArgs e)
        {
            gp = e.Graphics;
            InitUI(gp);
        }

        private void panel_Paint(object sender, PaintEventArgs e)    //panel的Paint事件
        {
            g = e.Graphics;    
            Singleton.Instance.Draw(g);   //画出图象
        }

        private void timer_Tick(object sender, EventArgs e)    //记时器
        {
            Singleton.Instance.CreateThread();
            SetEnemy();
            panel.Invalidate();              //使panel重画
            Invalidate();
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)         //键盘按下事件
        {
            if (!Singleton.Instance.P1Tank.Enable)
            {
                return;
            }
            Singleton.Instance.P1Tank.KeyDown(e);                 //调用MyTank类的按键方法
            if (StartForm.isMultiplayer)                 //如果是双人游戏
            {
                Singleton.Instance.P2Tank.KeyDown(e);              //调用P2Tank类的按键方法
            }
        }

        private void MainForm_KeyUp(object sender, KeyEventArgs e)          //键盘弹起
        {
            if (!Singleton.Instance.P1Tank.Enable)
            {
                return;
            }
            Singleton.Instance.P1Tank.KeyUp(e);             //调用MyTank类的按键弹起方法
            if (StartForm.isMultiplayer)                  //如果是双人游戏
            {
                Singleton.Instance.P2Tank.KeyUp(e);   //调用P2Tank类的按键弹起方法
            }
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)      //窗体关闭事件
        {
            Application.Exit();
            Thread thtmp = new Thread(new ParameterizedThreadStart(Run));
            object appName = Application.ExecutablePath;
            thtmp.Start(appName);
            
        }

        private void Run(Object obj)         //重新启动程序
        {
            Process ps = new Process();
            ps.StartInfo.FileName = obj.ToString();
            ps.Start();
        }

        private void SetEnemy()       //设置敌人
        {
            if (!isStart)
            {
                if (n < 6)
                {
                    Singleton.Instance.AddElement(new Enemy(rdm.Next(0, 640), rdm.Next(0, 640), rdm.Next(0, 3), directions.U));
                    n++;
                }
                else
                {
                    isStart = true;
                }
            }
            else
            {
                if (Singleton.Instance.count < 6 && enemyNum > 0)
                {
                    Singleton.Instance.AddElement(new Enemy(rdm.Next(0, 640), rdm.Next(0, 640), rdm.Next(0, 3), directions.U));
                    enemyNum--;
                }
            }
        }


    }
}
