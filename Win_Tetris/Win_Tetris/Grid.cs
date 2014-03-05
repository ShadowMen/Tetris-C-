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
        Block flyingBlock;
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
                        case 3:
                            pen.Color = Color.Green;
                            break;
                        case 4:
                            pen.Color = Color.Yellow;
                            break;
                        case 5:
                            pen.Color = Color.Orange;
                            break;
                        case 6:
                            pen.Color = Color.Violet;
                            break;
                        case 7:
                            pen.Color = Color.Gold;
                            break;
                    }

                    gfx.FillRectangle(pen.Brush, x * blockSize + 1, y * blockSize + 1, blockSize - 1, blockSize - 1);
                }
            }

            if (flyingBlock != null)
            {
                for (int y = 0; y < flyingBlock.Size; y++)
                {
                    for (int x = 0; x < flyingBlock.Size; x++)
                    {
                        switch (flyingBlock.Blocks[y, x])
                        {
                            case 0:
                                pen.Color = Color.Transparent;
                                break;
                            case 1:
                                pen.Color = Color.Blue;
                                break;
                            case 2:
                                pen.Color = Color.Red;
                                break;
                            case 3:
                                pen.Color = Color.Green;
                                break;
                            case 4:
                                pen.Color = Color.Yellow;
                                break;
                            case 5:
                                pen.Color = Color.Orange;
                                break;
                            case 6:
                                pen.Color = Color.Violet;
                                break;
                            case 7:
                                pen.Color = Color.Gold;
                                break;
                        }

                        gfx.FillRectangle(pen.Brush, (x + flyingBlock.PositionX) * blockSize + 1, (y + flyingBlock.PositionY) * blockSize + 1, blockSize - 1, blockSize - 1);
                    }
                }
            }
        }

        public void insertBlock()
        {
            for (int y = 0; y < flyingBlock.Size; y++)
            {
                for (int x = 0; x < flyingBlock.Size; x++)
                {
                    if (flyingBlock.Blocks[y, x] != 0) field[y + flyingBlock.PositionY, x + flyingBlock.PositionX] = flyingBlock.Blocks[y, x];
                }
            }            
        }

        public bool CheckStartBlock()
        {
            for (int y = 0; y < flyingBlock.Size; y++)
            {
                for (int x = 0; x < flyingBlock.Size; x++)
                {
                    //Ist ein Block auf dem Feld unter einem Block vom Fliegenden Block, so ist eine Kollision vorhanden
                    if (field[y + flyingBlock.PositionY, x + flyingBlock.PositionX] != 0 && flyingBlock.Blocks[y, x] != 0)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public int CheckFullRows()
        {
            int countRows = 0;
            int count = 0;

            for (int y = 0; y < 22; y++)
            {
                for (int x = 0; x < 10; x++)
                {
                    //Ist ein Block im Feld counter erhöhen
                    if (field[y, x] != 0) count++;
                }

                //Ist eine volle Reihe vorhanden
                if (count >= 10)
                {
                    countRows++;    //gesamtanzahl der Reihen erhöhen

                    //Reihe leeren
                    for (int x = 0; x < 10; x++)
                    {
                        field[y, x] = 0;
                    }

                    //Felder von oben nachrücken
                    for (int i = y; i > 0; i--)
                    {
                        for (int x = 0; x < 10; x++)
                        {
                            field[i, x] = field[i - 1, x];
                        }
                    }
                }

                count = 0;  //counter zurücksetzen
            }

            return countRows; //Gesamtanzahl der vollen Reihen zurückgeben. (Nützlich für Punktesystem)
        }

        public void Clear()
        {
            for (int y = 0; y < 22; y++)
            {
                for (int x = 0; x < 10; x++)
                {
                    field[y, x] = 0;
                }
            }
        }
    }
}
