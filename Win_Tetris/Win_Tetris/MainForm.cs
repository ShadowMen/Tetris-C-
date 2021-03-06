﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Win_Tetris
{
    public partial class MainForm : Form
    {
        Game game = new Game();

        public MainForm()
        {
            InitializeComponent();
        }

        private void updateTimer_Tick(object sender, EventArgs e)
        {
            game.update();
            drawBox.Invalidate();
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            game.handleInput(e.KeyCode);
        }

        private void drawBox_Resize(object sender, EventArgs e)
        {
            game.resize(drawBox.Width, drawBox.Height);
        }

        private void drawBox_Paint(object sender, PaintEventArgs e)
        {
            game.draw(e.Graphics);
        }

        private void barBtnStart_Click(object sender, EventArgs e)
        {
            if (!game.IsRunning)
            {
                game.run();
                barBtnStart.Text = "Pause";
            }
            else
            {
                game.pause();
                barBtnStart.Text = "Start";
            }
        }

        private void barBtnRestart_Click(object sender, EventArgs e)
        {
            game.Restart();
            barBtnStart.Text = "Start";
        }
    }
}
