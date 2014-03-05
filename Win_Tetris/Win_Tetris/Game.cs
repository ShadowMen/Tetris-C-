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

        public void gameOver()
        {
            pause();
            System.Windows.Forms.MessageBox.Show("Game Over!");
        }

        public void update()
        {
            if (!isRunnig) return;
            tryGoDown();
        }

        public void handleInput(System.Windows.Forms.Keys key)
        {
            switch (key)
            {
                case System.Windows.Forms.Keys.Left:
                    grid.FlyingBlock.MoveLeft();
                    if (Collision.isCollision(grid.FlyingBlock, grid.Field)) grid.FlyingBlock.MoveRight();
                    break;
                case System.Windows.Forms.Keys.Right:
                    grid.FlyingBlock.MoveRight();
                    if (Collision.isCollision(grid.FlyingBlock, grid.Field)) grid.FlyingBlock.MoveLeft();
                    break;
                case System.Windows.Forms.Keys.A:
                    grid.FlyingBlock.TurnLeft();
                    if (Collision.isCollision(grid.FlyingBlock, grid.Field)) grid.FlyingBlock.TurnRight();
                    break;
            }
        }

        public void resize(int width, int height)
        {
            if (width < height)
            {
                grid.BlockSize = (width - 100) / 10;
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

        public void tryGoDown()
        {
            grid.FlyingBlock.MoveDown();
            if (Collision.isCollision(grid.FlyingBlock, grid.Field))
            {
                grid.FlyingBlock.MoveUp();
                grid.insertBlock();
                if (grid.CheckStartBlock()) this.gameOver();
                grid.CheckFullRows();
            }
        }

        public void Restart()
        {
            grid.Clear();
            this.run();
        }
    }
}
