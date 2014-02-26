using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Win_Tetris
{
    class Block
    {
        //Variabeln
        int[,] block;
        int posX, posY;
        int size = 0;

        //Properties
        public int Size
        {
            get { return size; }
            protected set { size = value; }
        }

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

        public int[,] Blocks
        {
            get { return block; }
            protected set { block = value; }
        }

        //Methoden
        public virtual void TurnLeft()
        {
        }

        public virtual void TurnRight()
        {
        }

        public void MoveRight()
        {
            if(posX < 10 - size) posX++;
        }

        public void MoveLeft()
        {
            if(posX > 0) posX--;
        }

        public void MoveDown()
        {
            posY++;
        }
    }
}
