using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Win_Tetris
{
    class Collision
    {
        public static bool isCollision(Block currentBlock, int[,] grid)
        {
            for (int y = 0; y < currentBlock.Size; y++)
            {
                for (int x = 0; x < currentBlock.Size; x++)
                {
                    if (currentBlock.Blocks[y, x] != 0)
                    {
                        if (x + currentBlock.PositionX >= 10 || x + currentBlock.PositionX < 0) return true;
                        else if (y + currentBlock.PositionY >= 22 || y + currentBlock.PositionY < 0) return true;
                        else if (grid[y + currentBlock.PositionY, x + currentBlock.PositionX] != 0) return true;
                    }
                    //if ((y >= 22 || x >= 10) && currentBlock.Blocks[y - currentBlock.PositionY, x - currentBlock.PositionX] != 0) return true;
                    //if ((y < 0 || x < 0) && currentBlock.Blocks[y - currentBlock.PositionY, x - currentBlock.PositionX] != 0) return true;
                    //if (grid[y, x] != 0 && currentBlock.Blocks[y - currentBlock.PositionY, x - currentBlock.PositionX] != 0) return true;
                }
            }

            return false;
        }
    }
}
