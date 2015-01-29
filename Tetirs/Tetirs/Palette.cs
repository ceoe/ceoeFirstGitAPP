using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;



namespace Tetirs
{
    internal class Palette
    {
        //二维数组的第一维最大下标
        private int _width = 14;
        //二维数组的第二维最大下标
        private int _height = 25;
        //数组可以在类中先声明,但不赋值
        private Color[,] coorArr;
        private Color disapperColor;
        private Graphics gpPalette, gpReady;
        private BlockGroup bGroup;
        private Block runBlock;
        private Block readyBlock;
        private int rectPix;

        private System.Timers.Timer timerBlock;
        private int  timeSpans=800 ;

        public string id;

        private String runBlockInfoID;
        private string readyBlockInfoID;

        public int TimeSpans
        {
            get { return timeSpans; }
            set { timeSpans = value; }
        }

        //声明一个构造函数
        public Palette(int x, int y, int pix, Color dColor, Graphics gp, Graphics gr)
        {
            _width = x;
            _height = y;
            rectPix = pix;
            disapperColor = dColor;

            // 这个数组是按照先 width 后Height,(先列后行)的方式来定义的,那么遍历时就应该按照先列后行来循环.
            coorArr = new Color[_width, _height];
            gpPalette = gp;
            gpReady = gr;
        }

        public Block RunBlock
        {
            get { return runBlock; }
        }

        public Block ReadyBlock
        {
            get { return readyBlock; }
        }

        public string RunBlockInfoId
        {
            get { return runBlockInfoID; }
        }

        public string ReadyBlockInfoId
        {
            get { return readyBlockInfoID; }
        }

       public void Start()
        {

            bGroup = new BlockGroup();
            runBlock = bGroup.GetABlock(out id);
            runBlockInfoID = id;

            // 输出runBlock对象到txtRunReady.text中.


            RunBlock.XPos = _width / 2;
            // runBlock.YPos = 2;
            int y = -2;
            for (int i = 0; i < RunBlock.Length; i++)
            {
                if (RunBlock[i].Y > y)
                {
                    y = RunBlock[i].Y;
                }
            }
            RunBlock.YPos = y;
            gpPalette.Clear(disapperColor);
            RunBlock.Paint(gpPalette);
            //时间间隔20ms,以便随机数再次产生.
            Thread.Sleep(20);
            readyBlock = bGroup.GetABlock(out id);
            readyBlockInfoID = id;
            ReadyBlock.XPos = 2;
            ReadyBlock.YPos = 2;
            gpReady.Clear(disapperColor);
            ReadyBlock.Paint(gpReady);

           timerBlock=new System.Timers.Timer(timeSpans);
           timerBlock.Elapsed += new System.Timers.ElapsedEventHandler(OnTimedEvent);
           timerBlock.AutoReset = true;
           timerBlock.Start();


        }

        public void OnTimedEvent(object sender,ElapsedEventArgs e)
        {
            CheckOverAndRenewBlock();
            Down();
        }



        public bool Down()
        {
            int xPos, yPos;
            yPos = RunBlock.YPos + 1;
            xPos = RunBlock.XPos;
            for (int i = 0; i < RunBlock.Length; i++)
            {
                if (yPos - RunBlock[i].Y > _height - 1)//若是运行的方块有Y轴坐标超出了预先定义的二维数组的下标,则直接退出该方法,并返回False
                {
                    return false;
                }
                if (!coorArr[xPos + runBlock[i].X, yPos - runBlock[i].Y].IsEmpty)
                {
                    return false;
                }
            }

            RunBlock.DisPaint(gpPalette);
            RunBlock.YPos++;
            RunBlock.Paint(gpPalette);
            return true;
        }

        public void DropDwon()
        {
            timerBlock.Stop();
            while (Down()) ;
            timerBlock.Start();
        }

        public bool MoveLeft()
        {

            int xPos = runBlock.XPos - 1;
            int yPos = runBlock.YPos;
            for (int i = 0; i < runBlock.Length; i++)
            {
                if (xPos + runBlock[i].X < 0)
                {
                    return false;
                }
                if (!coorArr[xPos + runBlock[i].X, yPos - runBlock[i].Y].IsEmpty)
                {
                    return false;
                }
            }

            runBlock.DisPaint(gpPalette);
            runBlock.XPos--;
            runBlock.Paint(gpPalette);
            return true;
        }

        public bool MoveRight()
        {

            int xPos = runBlock.XPos + 1;
            int yPos = runBlock.YPos;
            for (int i = 0; i < runBlock.Length; i++)
            {
                if (xPos + runBlock[i].X > _width - 1)
                {
                    return false;
                }
                if (!coorArr[xPos + runBlock[i].X, yPos - runBlock[i].Y].IsEmpty)
                {
                    return false;
                }
            }

            runBlock.DisPaint(gpPalette);
            runBlock.XPos++;
            runBlock.Paint(gpPalette);
            return true;
        }

        public bool RotCW()
        {
            for (int i = 0; i < runBlock.Length; i++)
            {
                int xPos = runBlock.XPos + runBlock[i].Y;
                int yPos = runBlock.YPos + runBlock[i].X;
                if (xPos < 0 || xPos > _width - 1)
                {
                    return false;
                }

                if (yPos < 0 || yPos > _height - 1)
                {
                    return false;
                }
                if (!coorArr[xPos, yPos].IsEmpty)
                {
                    return false;
                }
            }

            runBlock.DisPaint(gpPalette);
            runBlock.RotCW();
            runBlock.Paint(gpPalette);
            return true;

        }

        public bool RotCCW()
        {
            for (int i = 0; i < runBlock.Length; i++)
            {
                int xPos = runBlock.XPos - runBlock[i].Y;
                int yPos = runBlock.YPos - runBlock[i].X;
                if (xPos < 0 || xPos > _width - 1)
                {
                    return false;
                }

                if (yPos < 0 || yPos > _height - 1)
                {
                    return false;
                }
                if (!coorArr[xPos, yPos].IsEmpty)
                {
                    return false;
                }
            }

            runBlock.DisPaint(gpPalette);
            runBlock.RotCCW();
            runBlock.Paint(gpPalette);
            return true;

        }

        private void PaintBackGroudLayer(Graphics gp)
        {
            gp.Clear(Color.Black);

            // 数组coorArr是按照先 width 后Height,(先列后行)的方式来定义的,那么遍历时就应该按照先列后行来循环.
            for (int i = 0; i < _height; i++)
            {
                for (int j = 0; j < _width; j++)
                {
                    if (!coorArr[j, i].IsEmpty)
                    {
                        lock (gp)
                        {
                            SolidBrush sb = new SolidBrush(coorArr[j, i]);
                            gp.FillRectangle(sb, j * rectPix + 1, i * rectPix + 1, rectPix - 2, rectPix - 2);
                        }
                    }
                }
            }

        }

        public void PaintPalette(Graphics gp)
        {
            PaintBackGroudLayer(gp);
            if (runBlock != null)
            {
                runBlock.Paint(gp);
            }
        }

        public void PaintReadyBlock(Graphics gp)
        {
            if (readyBlock != null)
            {
                readyBlock.Paint(gp);
            }
        }

        public void CheckOverAndRenewBlock()
        {
            bool over = false;
            for (int i = 0; i < runBlock.Length; i++)
            {
                int x = runBlock[i].X + runBlock.XPos;
                int y = runBlock.YPos - runBlock[i].Y;
                if (y == _height - 1)
                {
                    over = true;
                    break;
                }
                if (!coorArr[x, y + 1].IsEmpty)
                {
                    over = true;
                    break;
                }

            }
            if (over)
            {
                for (int i = 0; i < runBlock.Length; i++)
                {
                    coorArr[runBlock.XPos + runBlock[i].X, runBlock.YPos - runBlock[i].Y] = runBlock.BlockColor;

                }

                CheckFullRow();

                runBlock = readyBlock;
                runBlockInfoID = readyBlockInfoID;
                RunBlock.XPos = _width / 2;
                // runBlock.YPos = 2;
                int y = -2;
                for (int i = 0; i < RunBlock.Length; i++)
                {
                    if (RunBlock[i].Y > y)
                    {
                        y = RunBlock[i].Y;
                    }
                }
                RunBlock.YPos = y;

                //判断新的方块所处的位置是否已经被其他固定砖块所占用,若被占用则直接显示GameOver 退出return.
                for (int i = 0; i < runBlock.Length; i++)
                {
                    if (!coorArr[runBlock.XPos + runBlock[i].X, runBlock.YPos - runBlock[i].Y].IsEmpty)
                    {
                        StringFormat strformat = new StringFormat();
                        strformat.Alignment = StringAlignment.Center;
                        gpPalette.DrawString("GAME   OVER!", new Font("Arial,Black", 48f), new SolidBrush(Color.LawnGreen), new RectangleF(8, _height * rectPix - 512, _width * rectPix, 200), strformat);
                        timerBlock.Stop();
                        return;
                    }
                }


                RunBlock.Paint(gpPalette);

                readyBlock = bGroup.GetABlock(out id);
                readyBlockInfoID = id;
                ReadyBlock.XPos = 2;
                ReadyBlock.YPos = 2;
                gpReady.Clear(disapperColor);
                ReadyBlock.Paint(gpReady);

            }

        }

        public void CheckFullRow()
        {
             //先将当前方块模型的Y MAX - MIN范围计算出来
            int RunBlockHighRow = runBlock.YPos - runBlock[0].Y;
            int RunBlockLowRow = RunBlockHighRow;
            for (int i = 0; i < runBlock.Length; i++)
            {
                int y = runBlock.YPos - runBlock[i].Y;
                if (y<RunBlockLowRow)
                {
                    RunBlockLowRow = y;
                }
                if (y>RunBlockHighRow)
                {
                    RunBlockHighRow = y;
                }
            }

           
            for (int i = RunBlockLowRow; i <=RunBlockHighRow; i++)
            {
                bool isRowFull = true;
                for (int j = 0; j < _width; j++)
                {
                    if (coorArr[j,i].IsEmpty)
                    {
                        isRowFull = false;
                        break;
                    }
                }
             if (isRowFull)
            {
                for (int k = i; k > 0; k--)
                {
                     for (int j = 0; j < _width; j++)
                     {
                         coorArr[j, k] = coorArr[j,k - 1];
                     }
                }

                         for (int j = 0; j < _width; j++)
                         {
                             coorArr[j, 0] = Color.Empty;
                         }

                        PaintBackGroudLayer(gpPalette);
            }
            }

        

        }

        public void GamePause()
        {
            if (timerBlock.Enabled==true)
            {
                timerBlock.Enabled = false;
            }
        }

        public void EndPause()
        {
            if (timerBlock.Enabled == false)
            {
                timerBlock.Enabled = true;
            }
        }


        public void ResetGame()
        {
            timerBlock.Close();
            gpPalette.Dispose();
            gpReady.Dispose();
        }

    }
}
