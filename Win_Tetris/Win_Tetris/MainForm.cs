using System;
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
            game.handleInput();
            game.update();
            game.draw(drawBox.CreateGraphics());
        }
    }
}
