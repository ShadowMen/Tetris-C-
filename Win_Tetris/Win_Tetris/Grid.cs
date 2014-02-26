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
        int[,] field = new int[22, 10];
        Block flyingBlock = new TBlock();
        int blockSize = 10;

        //Properties
        public int[,] Field
        {
            get { return field; }
        }

        public Block FlyingBlock
        {
            get { return flyingBlock; }
            set { flyingBlock = value; }
        }

        public int BlockSize
        {
            get { return blockSize; }
            set { if (value > 0) blockSize = value; }
        }

        //Methoden
        public void draw(Graphics gfx)
        {
            Pen pen = new Pen(Color.LightGray);
            for (int y = 0; y < 22; y++)
            {
                for (int x = 0; x < 10; x++)
                {
                    switch (field[y, x])
                    {
                        case 0:
                            pen.Color = Color.LightGray;
                            break;
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

            for (int y = 0; y < flyingBlock.Size; y++)
            {
                for (int x = 0; x < flyingBlock.Size; x++)
                {
                    switch (flyingBlock.Blocks[y, x])
                    {
                        case 0:
                            pen.Color = Color.LightGray;
                            break;
                        case 1:
                            pen.Color = Color.Blue;
                            break;
                        case 2:
                            pen.Color = Color.Red;
                            break;
                    }

                    gfx.FillRectangle(pen.Brush, (x + flyingBlock.PositionX) * blockSize + 1, (y + flyingBlock.PositionY) * blockSize + 1, blockSize - 1, blockSize - 1);
                }
            }
        }
    }
}
