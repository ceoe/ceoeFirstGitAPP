using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetirs
{
    class Block
    {
        protected Point[] structArr;  //存放砖块信息组成的数组;
        private int _xPos;  //砖块中心对应的x,y坐标
        private int _yPos;  //砖块中心对应的x,y坐标
        private Color _blockColor;  //砖块的颜色和擦除砖块的颜色
        protected Color _disapperColor;  //砖块的颜色和擦除砖块的颜色
        protected int rectPix;  //每个砖块所占的像素数量

        //声明默认的构造函数,目的是方便子类能够方便的重写默认构造函数
        public Block()
        {
        }

        public Block(Point[] point, Color bColor, Color dColor, int pix)
        {
            this.structArr = point;
            this._blockColor = bColor;
            this._disapperColor = dColor;
            this.rectPix = pix;
        }

        public Point this[int index]
        {
            get { return structArr[index]; }

        }



        public int Length
        {
           get {return  structArr.Length;}
        }

        public int XPos
        {
            get { return _xPos; }
            set { _xPos = value; }
        }

        public int YPos
        {
            get { return _yPos; }
            set { _yPos = value; }
        }

        public Color BlockColor
        {
            get { return _blockColor; }
        }

        //顺时针旋转操作
        public void RotCW()
        {

            int temp;
            for (int i = 0; i < structArr.Length; i++)
            {
                temp = structArr[i].X;
                structArr[i].X=structArr[i].Y;
                structArr[i].Y=-temp;
            }

        }

        //逆时针旋转操作
        public void RotCCW()
        {

            int temp;
            for (int i = 0; i < structArr.Length; i++)
            {
                temp = structArr[i].X;
                structArr[i].X = -structArr[i].Y;
                structArr[i].Y = temp;
            }

        }

        private Rectangle PointToRectangle(Point p)
        {
            // 显示图形上下镜像了,问题就出在这条语句上.
            return new Rectangle((_xPos+p.X)*rectPix+1,
                                              (_yPos-p.Y)*rectPix+1,rectPix-2,rectPix-2);
        }

        //遍历整个方块点绘制方块
        public virtual void Paint(Graphics gp)
        {
            SolidBrush sb=new SolidBrush(_blockColor);
            for (int i = 0; i < structArr.Length; i++)
            {
                lock (gp)
                {
                    gp.FillRectangle(sb,PointToRectangle(structArr[i]));
                }
            }
        }

        //遍历整个方块点擦除方块
        public virtual void DisPaint(Graphics gp)
        {
            SolidBrush sb = new SolidBrush(_disapperColor);
            for (int i = 0; i < structArr.Length; i++)
            {
                lock (gp)
                {
                    gp.FillRectangle(sb, PointToRectangle(structArr[i]));
                }
            }
        }


        public string ListAllElement()
        {
            StringBuilder sb=new StringBuilder();
            for (int i = 0; i < structArr.Length; i++)
            {
                sb.Append(structArr[i].ToString()+"\r\n");
            }

            //返回方块坐标,并显示方块中心坐标所处的位置
            return sb.ToString() +"\r\n"+"\\"+ XPos.ToString()+"\\"+YPos.ToString();

        }

    }

}
