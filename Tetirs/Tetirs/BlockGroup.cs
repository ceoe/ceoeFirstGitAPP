using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetirs
{
    class BlockGroup
    {
        private InfoArr info;
        private Color disapperColor;
        private int rectPix;

        
        //声明默认构造方法
        public BlockGroup()
        {
            Config  config=new Config();
            config.LoadFromXmlFile();
            

            info = config.Info;
            disapperColor = config.BackColor;
               rectPix = config.RectPix;

        }

     

        public Block GetABlock(out string curinfo)
        {
            Random rd=new Random();
            int KeyOrder = rd.Next(0, info.Length);
            BitArray ba = info[KeyOrder].ID;
            curinfo = info[KeyOrder].GetIDStr();
           
            int struNum = 0;
            foreach (bool 位判断 in ba)
            {
                if (位判断)
                {
                    struNum++;
                }
            }
            Point  [] structArr=new Point[struNum]; //新建一个Point数组,用于存储每一个有颜色块的坐标


            //遍历整个BitArray  遇到模型中有颜色的方块就记录下这个方块在矩阵中的位置
            //k的作用等同于Point 数组的最大长度.
            int k = 0;
            for (int i = 0; i < ba.Length; i++)
            {
                if (ba[i])
                {
                    structArr[k].X = i/5 - 2;
                    structArr[k].Y = 2 - i%5;
                    k++;
                }
            }

            return new Block(structArr, info[KeyOrder].BColor,disapperColor,rectPix);

        }

    }
}
