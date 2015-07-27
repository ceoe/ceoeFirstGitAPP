using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Tank.Properties;
using System.Threading;
using System.Media;
namespace Tank
{
    public partial class StartForm : Form
    {
        public StartForm()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.ResizeRedraw | ControlStyles.OptimizedDoubleBuffer, true);
        }
        private Graphics g;
        private static Image imgTitle = Resources.title;
        private static Image imgSelect = Resources.select;
        private static Image imgtank = Resources.selecttank;
        private int xPos = 205, yPos = 290;
        private int roll = 500;
        public static bool isMultiplayer;
        public  static bool isEdit=false;
        public static bool editing = false;
        public bool[,] arr = new bool[43, 43];

        private static volatile StartForm instance;
        public static StartForm Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new StartForm();
                }
                return instance;
            }
        }

        private void RollThread()
        {
            if (roll > 0)
            {
                roll -= 3;
                Thread.Sleep(10);
            }
            else
            {
                return;
            }
            Invalidate();
        }

        private void StartForm_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;
            g.DrawImage(imgTitle, 65, 50 + roll);
            g.DrawImage(imgSelect, 305, 300 + roll);
            g.DrawImage(imgtank, xPos, yPos + roll);
            if (roll < 0)
            {
                g.DrawString("BY峰峰哥 @ 2010", new Font("Tahoma", 15, FontStyle.Bold), new SolidBrush(Color.White), 385, 500);
                btnState.Visible = true;
                btnBug.Visible = true;
            }
            RollThread();
        }

        private void StartForm_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.W | e.KeyCode == Keys.Up) && yPos > 290)
            {
                yPos -= 70;
            }
            if ((e.KeyCode == Keys.S | e.KeyCode == Keys.Down) && yPos < 430)
            {
                yPos += 70;
            }
           
            if (e.KeyCode == Keys.Enter || e.KeyCode==Keys.Space)
            {
                Start();
            }
            Invalidate();
        }

        private void Start()
        {
            if (yPos == 290)
            {               
                isMultiplayer = false;
            }
            else if (yPos == 360)
            {
                isMultiplayer = true;
            }
            else if (yPos == 430)
            {
                EditForm editFrm = new EditForm(this);
                StartForm.editing = true;
                this.Hide();
                editFrm.ShowDialog();
                return;
            }
            this.Hide();
            //SoundPlayer spStart = new SoundPlayer(Resources.start);
            //spStart.Play();
            Sound soundStart = new Sound(Resources.start);
            soundStart.Play();
            MainForm frm = new MainForm();
            frm.ShowDialog();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            MessageBox.Show("游戏说明:\r    玩家1:WASD上左下右,K键发子弹.\r    玩家2:方向键上下左右,小键盘2发子弹.\r\t  游戏快乐!  BY峰峰哥");
        }


        private void StartForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.X > btnState.Bounds.X && e.X < btnState.Bounds.X + btnState.Width && e.Y > btnState.Bounds.Y && e.Y < btnState.Bounds.Y + btnState.Width)
            {
                btnState.Enabled = true;
            }
            else
            {
                btnState.Enabled = false;
                this.Focus();
            }

            if (e.X > btnBug.Bounds.X && e.X < btnBug.Bounds.X + btnBug.Width && e.Y > btnBug.Bounds.Y && e.Y < btnBug.Bounds.Y + btnBug.Width)
            {
                btnBug.Enabled = true;
            }
            else
            {
                btnBug.Enabled = false;
                this.Focus();
            }

            if (e.X > 305 && e.X < 305 + imgSelect.Width && e.Y > 300 && e.Y < 330)
            {
                yPos = 290;
                Invalidate();
            }

            if (e.X > 305 && e.X < 305 + imgSelect.Width && e.Y > 370 && e.Y < 400)
            {
                yPos = 360;
                Invalidate();
            }

            if (e.X > 305 && e.X < 305 + imgSelect.Width && e.Y > 430 && e.Y < 460)
            {
                yPos = 430;
                Invalidate();
            }
        }

        private void btnBug_Click(object sender, EventArgs e)
        {
            MailForm frm = new MailForm();
            frm.ShowDialog();
        }

        private void StartForm_MouseDown(object sender, MouseEventArgs e)
        {
            if ((e.X > 305 && e.X < 305 + imgSelect.Width && e.Y > 300 && e.Y < 330)
                ||(e.X > 305 && e.X < 305 + imgSelect.Width && e.Y > 370 && e.Y < 400)
                    ||(e.X > 305 && e.X < 305 + imgSelect.Width && e.Y > 430 && e.Y < 460))
            {
                Start();
            }

        }

        private void StartForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
