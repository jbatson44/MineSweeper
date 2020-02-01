using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace minesweep
{
    /*******************************************************************************
    * MyMenu
    *   This is the main menu form with the following buttons:
    *     Easy Game
    *     Medium Game
    *     Hard Game
    *   These all start the different game modes.
    *   There is also a quit game menu.
    *******************************************************************************/
    public partial class MyMenu : Form
    {
        private MyMenu myMenu;
        private Game game;

        /*******************************************************************************
        * DEFAULT CONSTRUCTOR
        *   Start the menu.
        *******************************************************************************/
        public MyMenu()
        {
            InitializeComponent();
            myMenu = this;
        }

        /*******************************************************************************
        * Quit the game.
        *******************************************************************************/
        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        
        /*******************************************************************************
        * Easy game
        *******************************************************************************/
        private void NinebyNine_Click(object sender, EventArgs e)
        {
            game = new Game("easy", myMenu);
            game.Show();
            this.Hide();
            game.FormClosed += new FormClosedEventHandler(GameClosed);
        }

        /*******************************************************************************
        * Medium game
        *******************************************************************************/
        private void SixteenbySixteen_Click(object sender, EventArgs e)
        {
            game = new Game("medium", myMenu);
            game.Show();
            this.Hide();
            game.FormClosed += new FormClosedEventHandler(GameClosed);
        }

        /*******************************************************************************
        * Hard game
        *******************************************************************************/
        private void SixteenbyThirty_Click(object sender, EventArgs e)
        {
            game = new Game("hard", myMenu);
            game.Show();
            this.Hide();
            game.FormClosed += new FormClosedEventHandler(GameClosed);
        }

        /*******************************************************************************
        * Super Hard game
        *******************************************************************************/
        private void SuperHard_Click(object sender, EventArgs e)
        {
            game = new Game("super", myMenu);
            game.Show();
            this.Hide();
            game.FormClosed += new FormClosedEventHandler(GameClosed);
        }

        /*******************************************************************************
        * GameClosed
        *   If the game form is closed bring this menu back.
        *******************************************************************************/
        private void GameClosed(object sender, FormClosedEventArgs e)
        {
            myMenu.Show();
        }

    }
}
