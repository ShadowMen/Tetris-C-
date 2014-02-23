using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Win_Tetris
{
    class Game
    {
        //Objekte
        Grid grid = new Grid();
        bool isRunnig = false;

        //Methoden
        public void run()
        {
            isRunnig = true;
        }

        public void pause()
        {
            isRunnig = false;
        }

        public void update()
        {
            if (!isRunnig) return;
        }

        public void handleInput()
        {

        }

        public void resize(int width, int height)
        {
            if (width < height)
            {
                grid.BlockSize = (width - 200) / 10;
            }
            else
            {
                grid.BlockSize = height / 22;
            }
        }

        public void draw(Graphics gfx)
        {
            gfx.Clear(Color.Gray);
            grid.draw(gfx);
        }
    }
}
