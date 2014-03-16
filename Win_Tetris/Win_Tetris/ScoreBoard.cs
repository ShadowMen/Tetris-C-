using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Win_Tetris
{
    class ScoreBoard
    {
        //Variabeln
        long score = 0;
        int level = 0;
        int lines = 0;
        int posX = 100, posY = 100;
        int size = 10;

        //Properties
        public long Score
        {
            get { return score; }
            set { if (value >= 0) score = value; }
        }

        public int Level
        {
            get { return level; }
            set { if (value >= 0) level = value; }
        }

        public int Lines
        {
            get { return lines; }
            set { if (value >= 0) lines = value; }
        }

        public int PosX
        {
            get { return posX; }
            set { if(value > 0) posX = value; }
        }

        public int PosY
        {
            get { return posY; }
            set { if (value > 0) posY = value; }
        }

        public int Size
        {
            get { return size; }
            set { if (value > 0) size = value; } 
        }

        //Draw Methode
        public void draw(Graphics gfx)
        {
            Font font = new Font("Arial", size);
            Pen pen = new Pen(Color.Black);

            string text = string.Format("Score: {0}\nLevel: {1}", this.score, this.level);
            gfx.DrawString(text, font, pen.Brush, posX, posY);
        }
    }
}
