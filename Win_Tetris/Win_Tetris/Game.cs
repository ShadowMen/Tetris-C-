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
        ScoreBoard scoreBoard = new ScoreBoard();
        bool isRunnig = false;
        int FallDownTimer = 0;
        bool fastDown = false;

        //Properties
        public bool IsRunning
        {
            get { return this.isRunnig; }
        }

        //Methoden
        public void run()
        {
            if (this.isRunnig) return;

            this.isRunnig = true;

            if (this.nextBlock == null || grid.FlyingBlock == null)
            {
                this.newNextBlock();
                this.changeBlock();
            }
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

            //Level setzen
            scoreBoard.Level = (int)(scoreBoard.Lines / 10);

            //Block fallen lassen
            if (this.FallDownTimer <= 0)
            {
                if (!this.tryGoDown()) //Wenn der Block ein Hinderniss erreicht hat
                {
                    this.BlockEnd();
                }

                this.FallDownTimer = 50 / (scoreBoard.Level + 1);
            }
            else if (this.fastDown)
            {
                this.FallDownTimer = 0;
                scoreBoard.Score++;
                this.fastDown = false;
            }
            else this.FallDownTimer--;
        }

        public void handleInput(System.Windows.Forms.Keys key)
        {
            if (!this.isRunnig) return;
            if (grid.FlyingBlock == null) return;
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
                case System.Windows.Forms.Keys.Down:
                    this.fastDown = true;
                    break;
                case System.Windows.Forms.Keys.Space:
                    this.HardDrop();
                    break;
            }
        }

        public void resize(int width, int height)
        {
            if (width < height)
            {
                grid.BlockSize = (width / 2) / 10;
            }
            else
            {
                grid.BlockSize = height / 22;
            }

            scoreBoard.Size = grid.BlockSize;
            scoreBoard.PosX = grid.BlockSize * 11;
            scoreBoard.PosY = ((grid.BlockSize * 22) - scoreBoard.Size * 2) / 2;
        }

        public void draw(Graphics gfx)
        {
            gfx.Clear(Color.Gray);
            grid.draw(gfx);
            scoreBoard.draw(gfx);

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
            scoreBoard.Score = 0;
            scoreBoard.Level = 0;
            scoreBoard.Lines = 0;
            grid.Clear();
            this.newNextBlock();
            this.changeBlock();
            this.pause();
        }

        private void BlockEnd()
        {
            int lines = 0;
            int scorePerLine = 0;

            grid.insertBlock();
            this.changeBlock();
            if (grid.CheckStartBlock()) this.gameOver();
            
            lines = grid.CheckFullRows();
            if (lines > 0)
            {
                scoreBoard.Lines += lines;
                switch (lines)
                {
                    case 1:
                        scorePerLine = 40;
                        break;
                    case 2:
                        scorePerLine = 100;
                        break;
                    case 3:
                        scorePerLine = 300;
                        break;
                    case 4:
                        scorePerLine = 1200;
                        break;
                }
                scoreBoard.Score += lines * scorePerLine * (scoreBoard.Level + 1);
            }
        }

        private void HardDrop()
        {
            int count = 0;
            while (this.tryGoDown()) { count++; } //Gehe solange nach unte, bis der Boden oder ein erreicht ist

            scoreBoard.Score += count * 2;
            this.BlockEnd();
        }
    }
}
