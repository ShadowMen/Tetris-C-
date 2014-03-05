using System;
using System.Windows.Forms;

namespace Win_Tetris
{
    class DrawPanel : Panel
    {
        public DrawPanel()
        {
            this.DoubleBuffered = true;
            this.ResizeRedraw = true;
        }
    }
}
