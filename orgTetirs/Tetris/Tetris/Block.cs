using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;


namespace Tetris
{
    class Block             
    //这个类用来表示砖块样式
    {
        Point[] blockStyle;//砖块的样式
        Point pos;          ////记录（0,0）砖块在游戏背景中的坐标
        Color[,] bgColors;//砖块背景
        SolidBrush blockBrush;//绘制砖块的画刷
        SolidBrush bgBrush=new SolidBrush(Color.Black);//擦出砖块的画刷
        Graphics bgGraphics;//游戏背景画板
        int serial;//砖块编号
        int rotateNum;//当前旋转编号
        Label lblBg;
        public static int count = 0;


        public Block() { }//无参构造函数
        public Block(int s,int mode, Color c)//带参构造函数
        {
            blockBrush = new SolidBrush(c);
            blockStyle = ModeToStyle(mode);
            serial = s;
        }
        //指定砖块所在位置
        public bool setBlockPos(int x, int y)
        {
            foreach (Point p in blockStyle)
            {
                if (!bgColors[p.Y + y, p.X + x].IsEmpty)
                {
                    return false;
                }
            }
            pos = new Point(y, x);//Point 数组可以很好的表示坐标
            Paint();
            return true;
        }

        public int GetIniXPos()
        {
            return -blockStyle[0].X;
        }

        public void PaintGameOver()
        {
            Font font = new Font("Times New Roman", 20,FontStyle.Bold);
            SolidBrush sb = new SolidBrush(Color.White);
            bgGraphics.DrawString("GAME OVER!!", font, sb, new PointF(10, 100));
            
            Erase();
 
        }


        public Label LblBg
        {
            set
            {
                lblBg = value;
                bgGraphics = lblBg.CreateGraphics();
            }
        }

        public Color[,] BgColors
        {
            set
            {
                bgColors = value;
            }
 
        }
        public void MoveLeft()
        {
            foreach (Point p in blockStyle)
            {
                if ((pos.Y + p.Y) <= 0 || !bgColors[pos.X + p.X, pos.Y + p.Y - 1].IsEmpty)
                {
                    return; 
                }
            } 
            Erase();
            pos.Y--;
            Paint();        
        }
        public void MoveRight()
        {
            foreach (Point p in blockStyle)
            {
                if ((pos.Y + p.Y) >= 9 || !bgColors[pos.X + p.X, pos.Y + p.Y  +1].IsEmpty)
                {
                    return;
                }
            }
            Erase();
            pos.Y++;
            Paint();
        }
        public bool MoveDown()
        {
            if (!CanDown())
            {
                foreach (Point p in blockStyle)
                {
                    bgColors[p.X + pos.X, p.Y + pos.Y] = blockBrush.Color;
                }
                if (EraseFullRow())
                {
                    lblBg.Invalidate();
                }
                return false;
            }
            Erase();
            pos.X++;
            Paint();
            return true;
        }

        public void Drop()
        {
            while (CanDown())
            {
                MoveDown();
            }
        }

        public void Rotate()
        {
            Point[] tempStyle = ModeToStyle(BlockFactory.GetNextRotateMode(serial, rotateNum));
            foreach (Point p in tempStyle)
            {
                int x = p.X + pos.X;
                int y = p.Y + pos.Y;
                if (x < 0 || x > 14 || y < 0 || y > 9 || !bgColors[pos.X + p.X, pos.Y + p.Y ].IsEmpty)
                {
                    return; 
                }
            }
            Erase();
            blockStyle = tempStyle;
            rotateNum++;
            Paint();
        }

        private Point[] ModeToStyle(int mode)
        {
            int length=0;
            for(int i=0;i<16;i++)
            {
                if((mode & (1<<i) ) != 0)
                {
                    length++;
                }
            }
            Point[] style=new Point[length];
            length=0;
            for(int i=0;i<16;i++)
            {
                if((mode&(1<<i))!=0)
                {
                    style[length++]=new Point(i/4,i%4);
                }
            }
            return style;
        }

        public void Paint() //绘制自己
        {
            foreach (Point p in blockStyle)
            {
                Rectangle rect = new Rectangle((pos.Y + p.Y) * 21 +1, (pos.X + p.X) * 21 +1, 20, 20);
                bgGraphics.FillRectangle(blockBrush, rect);
            }
        }
        private void Erase()
        {
            foreach (Point p in blockStyle)
            {
                Rectangle rect = new Rectangle((pos.Y + p.Y) * 21 + 1, (pos.X + p.X) * 21 + 1, 20, 20);
                bgGraphics.FillRectangle(bgBrush, rect);
            } 
        }
        private bool CanDown()
        {
            foreach (Point p in blockStyle)
            {
                if ((pos.X + p.X) >= 14 || !bgColors[pos.X + p.X + 1, pos.Y + p.Y].IsEmpty)//防止前面一个砖块被覆盖   -----这句要多看看
                {
                    return false;
                }
            }
            return true;
        }

        //消除满行  ***
        public bool EraseFullRow()
        {
            count = 0;
            bool nullRow = false;
            bool fullRow = false;
            for (int j = 14; j >= 0 && nullRow == false; j--)
            {
                if (fullRow) count++;
                nullRow = fullRow = true;
                for (int i = 0; i < 10; i++)
                {
                    if (bgColors[j, i].IsEmpty)
                    {
                        fullRow = false;
                    }
                    else
                    {
                        nullRow = false;
                    }
                    if (count > 0)
                    {
                        bgColors[j + count, i] = bgColors[j, i];
                        bgColors[j, i] = Color.Empty;
                    }
                }
            }
            return count > 0 ? true : false;
        }
        
    }
}
