using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Tetris
{
    [Serializable]
    public class KeyConfig
    {
        public Keys KeyLeft = Keys.Left;
        public Keys KeyRight = Keys.Right;
        public Keys KeyRotate = Keys.Up;
        public Keys KeyDown = Keys.Down;
        public Keys KeyDrop = Keys.D;
    }
}
