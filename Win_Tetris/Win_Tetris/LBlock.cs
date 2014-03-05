﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Win_Tetris
{
    class LBlock : Block
    {
        public LBlock()
        {
            base.Blocks = new int[3, 3] {{0, 2, 0},
                                         {0, 2, 0},
                                         {0, 2, 2}};
            base.PositionX = 0;
            base.PositionY = 4;
            base.Size = 3;
        }

        public override void TurnLeft()
        {
            int[,] oldBlock = new int[3, 3];

            for (int y = 0; y < 3; y++)
            {
                for (int x = 0; x < 3; x++)
                {
                    oldBlock[y, x] = base.Blocks[y, x];
                }
            }

            for (int y = 0; y < 3; y++)
            {
                for (int x = 0; x < 3; x++)
                {
                    base.Blocks[y, x] = oldBlock[2 - x, y];
                }
            }
        }

        public override void TurnRight()
        {
            int[,] oldBlock = new int[3, 3];

            for (int y = 0; y < 3; y++)
            {
                for (int x = 0; x < 3; x++)
                {
                    oldBlock[y, x] = base.Blocks[y, x];
                }
            }

            for (int y = 0; y < 3; y++)
            {
                for (int x = 0; x < 3; x++)
                {
                    base.Blocks[y, x] = oldBlock[x, 2 - y];
                }
            }
        }
    }
}
