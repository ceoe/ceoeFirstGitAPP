using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Tank
{
    class GamePanel : Panel
    {
        public GamePanel()
        {
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint, true); //使用双缓冲
        }
    }
}
