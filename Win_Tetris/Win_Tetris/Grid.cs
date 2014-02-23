using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Win_Tetris
{
    class Grid
    {
        //Variabeln
        int[,] field = new int[10, 22];
        int blockSize = 10;

        //Properties
        public int[,] Field
        {
            get { return field; }
        }

        public int BlockSize
        {
            get { return blockSize; }
            set { if (value > 0) blockSize = value; }
        }

        //Methoden
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

                    gfx.FillRectangle(pen.Brush, x * blockSize + 1, y * blockSize + 1, blockSize - 1, blockSize - 1);
                }
            }
        }
    }
}
