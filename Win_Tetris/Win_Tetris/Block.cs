using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Win_Tetris
{
    class Block
    {
        //Variabeln
        int[,] block = new int[4, 4];
        int posX, posY;

        //Properties
        public int PositionX
        {
            get { return posX; }
            protected set { posX = value; }
        }

        public int PositionY
        {
            get { return posY; }
            protected set { posY = value; }
        }

        public int[,] Block
        {
            get { return block; }
            protected set { block = value; }
        }

        //Methoden
        public void TurnLeft()
        {
        }

        public void TurnRight()
        {
        }

        public void MoveRight()
        {
            posX++;
        }

        public void MoveLeft()
        {
            posX--;
        }

        public void MoveDown()
        {
            posY++;
        }
    }
}
