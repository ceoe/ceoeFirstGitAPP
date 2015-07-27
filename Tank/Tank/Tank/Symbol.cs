using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using Tank.Properties;

namespace Tank
{
    class Symbol : Module
    {
        private static Image imgSymbol = Resources.symbol;
        private static Image imgDestroy = Resources.destory;
        private static Image imgOver = Resources.overlogo;
        private bool isDestory = false;
        private OverLogo overLogo = new OverLogo(290, 615);
        public bool IsDestory
        {
            get { return isDestory; }
            set { isDestory = value; }
        }

        public Symbol(int x, int y)
            : base(x, y, imgSymbol.Width, imgSymbol.Height)
        {
        }

        public override void Draw(Graphics g)
        {
            if (isDestory)
            {
                g.DrawImage(imgDestroy, this.X, this.Y);
                Singleton.Instance.P1Tank.Enable = false;
                Singleton.Instance.P2Tank.Enable = false;
                overLogo.Draw(g);
                return;
            }
            g.DrawImage(imgSymbol, this.X, this.Y);
        }
    }
}
