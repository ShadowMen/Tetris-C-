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
        Random rnd = new Random();
        Grid grid = new Grid();
        Block nextBlock;
        bool isRunnig = false;

        //Methoden
        public void run()
        {
            this.isRunnig = true;

            this.newNextBlock();
            this.changeBlock();
        }

        public void pause()
        {
            this.isRunnig = false;
        }

        public void gameOver()
        {
            this.pause();
            //To-Do
            // * Die MessageBox entfernen
            System.Windows.Forms.MessageBox.Show("Game Over!");
        }

        public void update()
        {
            if (!this.isRunnig) return;
            if (!this.tryGoDown()) //Wenn der Block ein hinderniss erreicht hat
            {
                grid.insertBlock();
                this.changeBlock();
                if (grid.CheckStartBlock()) this.gameOver();
                grid.CheckFullRows();
            }
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
                case System.Windows.Forms.Keys.Up:
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

            Pen pen = new Pen(Color.Transparent);

            //Nextblock am Rand zeichnen
            if (nextBlock != null)
            {
                for (int y = 0; y < nextBlock.Size; y++)
                {
                    for (int x = 0; x < nextBlock.Size; x++)
                    {
                        switch (nextBlock.Blocks[y, x])
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

                        gfx.FillRectangle(pen.Brush, (x + 12) * grid.BlockSize + 1, (y + 5) * grid.BlockSize + 1, grid.BlockSize - 1, grid.BlockSize - 1);
                    }
                }
            }
        }

        public bool tryGoDown()
        {
            grid.FlyingBlock.MoveDown();
            if (Collision.isCollision(grid.FlyingBlock, grid.Field))
            {
                grid.FlyingBlock.MoveUp();
                return false;
            }
            return true;
        }

        public void changeBlock()
        {
            grid.FlyingBlock = nextBlock;
            this.newNextBlock();
        }

        public void newNextBlock()
        {
            switch (rnd.Next(1, 8))
            {
                case 1:
                    nextBlock = new TBlock();
                    break;
                case 2:
                    nextBlock = new LBlock();
                    break;
                case 3:
                    nextBlock = new JBlock();
                    break;
                case 4:
                    nextBlock = new SBlock();
                    break;
                case 5:
                    nextBlock = new ZBlock();
                    break;
                case 6:
                    nextBlock = new OBlock();
                    break;
                case 7:
                    nextBlock = new IBlock();
                    break;
            }
        }

        public void Restart()
        {
            grid.Clear();
            this.run();
        }
    }
}
