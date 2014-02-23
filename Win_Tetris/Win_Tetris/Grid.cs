using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Win_Tetris
{
    class Grid
    {
        int[,] field = new int[10, 22];
        int blockSize = 10;

        public int[,] Field
        {
            get { return field; }
        }

        public void draw(Graphics gfx)
        {
            Pen pen = new Pen(Color.Black);
            for (int y = 0; y < 22; y++)
            {
                for (int x = 0; x < 10; x++)
                {
                    switch (field[x, y])
                    {
                        case 1:
                            pen.Color = Color.Blue;
                            break;
                        case 2:
                            pen.Color = Color.Red;
                            break;
                    }

                    gfx.DrawRectangle(pen, x * blockSize, y * blockSize, blockSize, blockSize);
                    gfx.FillRectangle(pen.Brush, x * blockSize, y * blockSize, blockSize, blockSize);
                }
            }
        }
    }
}
