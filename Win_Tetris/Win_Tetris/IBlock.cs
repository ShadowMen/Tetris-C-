using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Win_Tetris
{
    class IBlock : Block
    {
        public IBlock()
        {
            base.Blocks = new int[4, 4] {{0, 0, 7, 0},
                                         {0, 0, 7, 0},
                                         {0, 0, 7, 0},
                                         {0, 0, 7, 0}};
            base.PositionX = 0;
            base.PositionY = 0;
            base.Size = 4;
        }

        public override void TurnLeft()
        {
            int[,] oldBlock = new int[4, 4];

            for (int y = 0; y < 4; y++)
            {
                for (int x = 0; x < 4; x++)
                {
                    oldBlock[y, x] = base.Blocks[y, x];
                }
            }

            for (int y = 0; y < 4; y++)
            {
                for (int x = 0; x < 4; x++)
                {
                    base.Blocks[y, x] = oldBlock[3 - x, y];
                }
            }
        }

        public override void TurnRight()
        {
            int[,] oldBlock = new int[4, 4];

            for (int y = 0; y < 4; y++)
            {
                for (int x = 0; x < 4; x++)
                {
                    oldBlock[y, x] = base.Blocks[y, x];
                }
            }

            for (int y = 0; y < 4; y++)
            {
                for (int x = 0; x < 4; x++)
                {
                    base.Blocks[y, x] = oldBlock[x, 3 - y];
                }
            }
        }
    }
}
