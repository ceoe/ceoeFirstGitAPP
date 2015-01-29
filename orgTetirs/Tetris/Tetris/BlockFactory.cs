using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Tetris
{
    class BlockFactory
    {
        struct BlockInfo
        {
            public int[] Modes;
            public Color blockColor;
        }
        static BlockInfo[] blocks;
        public BlockFactory()
        {
            blocks = new BlockInfo[7];
            blocks[0].Modes = new int[1] { 1632 };
            blocks[0].blockColor = Color.Red;
            blocks[1].Modes = new int[4] { 8800,1136,1604,3616 };
            blocks[1].blockColor = Color.Orange;
            blocks[2].Modes = new int[4] { 17504,1856,1570,736 };
            blocks[2].blockColor = Color.Yellow;
            blocks[3].Modes = new int[2] { 612,1584 };
            blocks[3].blockColor = Color.Green;
            blocks[4].Modes = new int[2] { 1122, 864 };
            blocks[4].blockColor = Color.Cyan;
            blocks[5].Modes = new int[4] { 114,610,624,562 };
            blocks[5].blockColor = Color.Blue;
            blocks[6].Modes = new int[2] { 8738, 240 };
            blocks[6].blockColor = Color.Purple;
        }

        //随机获取一个砖块样式
        public Block GetABlock()
        {
            Random r = new Random();
            int n = r.Next(0, 7);
            return new Block(n,blocks[n].Modes[0], blocks[n].blockColor);
            
        }

        //获取某砖块旋转后的样式
        public static int GetNextRotateMode(int serial, int rotateNum)
        {
            int[] modes = blocks[serial].Modes;
            return modes[++rotateNum % modes.Length];
        }
    }
}
