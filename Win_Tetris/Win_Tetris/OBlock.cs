using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Win_Tetris
{
    class OBlock : Block
    {
        public OBlock()
        {
            base.Blocks = new int[2, 2] {{6, 6},
                                         {6, 6}};
            base.PositionX = 0;
            base.PositionY = 0;
            base.Size = 2;
        }
    }
}
