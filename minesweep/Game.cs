using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace minesweep
{
    /*******************************************************************************
    * Game Class
    * Sets up the game board based on the user selection in MyMenu
    * Contains all gameplay logic
    *******************************************************************************/
    public partial class Game : Form
    {
        MyMenu mainMenu;
        private MyButton[,] board;
        private int rows;
        private int cols;
        private int bombLimit;
        private int numberOfBombs;
        private int numberOfFlags;
        private int unveiledSquares;
        private string type;
        private bool gameOver;
        private int buttonHeight;
        private int buttonWidth;
        private double seconds;
        private Timer stopwatch;
        private TextBox clock;

        /*******************************************************************************
        * NON-DEFAULT CONSTRUCTOR
        * Parameters
        *   type - the game mode selected (easy, medium, hard, super)
        *   mainMenu - references the main form
        * 
        *******************************************************************************/
        public Game(string type, MyMenu mainMenu)
        {
            InitializeComponent();
            this.type = type;
            this.mainMenu = mainMenu;
            gameOver = false;
            
            // Set up the clock that counts the seconds it takes the user to play
            stopwatch = new Timer();
            stopwatch.Start();
            stopwatch.Interval = 1000;
            stopwatch.Tick += new EventHandler(timer_Tick);
            seconds = 0;

            // clock is the textbox for the timer
            clock = Clock1;
            clock.Text = seconds.ToString();
            
            // Each of the following sets up the game based on the game
            // mode selected

            // Easy Game
            // 9 x 9 board with 10 bombs
            if (type == "easy")
            {
                this.Size = new System.Drawing.Size(390, 500);

                buttonHeight = 40;
                buttonWidth = 40;

                bombLimit = 10;
                rows = 9;
                cols = 9;
                PrepareGame();
            }
            // Medium Game
            // 16 x 16 board with 40 bombs
            else if (type == "medium")
            {
                this.Size = new System.Drawing.Size(670, 750);

                buttonHeight = 40;
                buttonWidth = 40;

                bombLimit = 40;
                rows = 16;
                cols = 16;
                PrepareGame();
            }
            // Hard Game
            // 16 x 30 board with 99 bombs
            else if (type == "hard")
            {
                this.Size = new System.Drawing.Size(1250, 750);

                buttonHeight = 40;
                buttonWidth = 40;

                bombLimit = 99;
                rows = 16;
                cols = 30;
                PrepareGame();
            }
            // Super Hard Game
            // 40 x 50 board with 300 bombs
            else if (type == "super")
            {
                // full size window
                this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
                //this.Size = new System.Drawing.Size(1600, 750);

                buttonHeight = 30;
                buttonWidth = 30;

                bombLimit = 300;
                rows = 40;
                cols = 50;
                PrepareGame();
                this.AutoScroll = true;
            }
        }

        /*******************************************************************************
        * timer_Tick
        * Update the clock each second
        *******************************************************************************/
        private void timer_Tick(object sender, EventArgs e)
        {
            if (!gameOver)
                seconds++;
            clock.Text = seconds.ToString();
        }

        /*******************************************************************************
        * PrepareGame
        * Main function to set up the board.
        * 1. initialize the buttons in the board
        * 2. randomly assigns buttons to have bombs until bomb limit
        *    is reached
        * 3. set the numbers for the non-bomb squares
        * 4. set bomb attributes and add to the form.
        *******************************************************************************/
        private void PrepareGame()
        {
            board = new MyButton[rows, cols];
            menu.Visible = true;
            numberOfBombs = 0;
            unveiledSquares = 0;
            Random rnd = new Random();

            for (int r = 0; r < board.GetLength(0); r++)
            {
                for (int c = 0; c < board.GetLength(1); c++)
                {
                    board[r, c] = new MyButton();
                    board[r, c].SetRow(r);
                    board[r, c].SetCol(c);
                }
            }

            while (numberOfBombs < bombLimit)
            {
                int rw = rnd.Next(rows);
                int cl = rnd.Next(cols);
                if (!board[rw, cl].GetIsBomb())
                {
                    board[rw, cl].SetBomb(true);
                    numberOfBombs++;
                }
            }

            SetNumBombsNear();

            for (int r = 0; r < board.GetLength(0); r++)
            {
                for (int c = 0; c < board.GetLength(1); c++)
                {
                    var button = board[r, c];

                    button.MouseUp += button_Click;
                    button.Height = buttonHeight;
                    button.Width = buttonWidth;
                    button.SetRow(r);
                    button.SetCol(c);
                    button.Location = new Point(button.Width * c + 4, button.Height * r + 50);
                    Controls.Add(button);
                }
            }
        }

        /*******************************************************************************
        * SetNumBombsNear
        * Sets the number value for each of the squares in the board.
        *******************************************************************************/
        private void SetNumBombsNear()
        {
            for (int r = 0; r < board.GetLength(0); r++)
            {
                for (int c = 0; c < board.GetLength(1); c++)
                {
                    CheckSurroundingSquares(r, c);
                }
            }
        }

        /*******************************************************************************
        * GetSquare
        * Parameters
        *    row, col - refer to the row and column of this square
        * Checks to see if the square is within the bounds of the board
        * and if it is return whether the square has a bomb. Otherwise 
        * returns false because if its not on the board it can't have a bomb
        * Used in CheckSurroundingSquares.
        *******************************************************************************/
        private bool GetSquare(int row, int col)
        {
            if (row < rows && row > -1 && col < cols && col > -1)
            {
                return (board[row, col].GetIsBomb());
            }
            return false;
        }

        /*******************************************************************************
        * ValidSquare
        * Parameters
        *    row, col - refer to the row and column of this square
        * Checks to see if the row and column are within the bounds of the 
        * board. Used in ClearSurroundingSquares
        *******************************************************************************/
        private bool ValidSquare(int row, int col)
        {
            if (row < rows && row > -1 && col < cols && col > -1)
            {
                return true;
            }
            return false;
        }

        /*******************************************************************************
        * CheckSurroundingSquares
        * Parameters
        *    row, col - refer to the row and column of the current square on the 
        *    board
        * Checks all the squares around the current square to determine how many
        * bombs surround it.
        * Updates the current squares numBombsNear variable
        *******************************************************************************/
        private void CheckSurroundingSquares(int row, int col)
        {
            // up
            if (GetSquare(row + 1, col))
                board[row, col].numBombsNear += 1;
            // down
            if (GetSquare(row - 1, col))
                board[row, col].numBombsNear += 1;
            // left
            if (GetSquare(row, col - 1))
                board[row, col].numBombsNear += 1;
            // right
            if (GetSquare(row, col + 1))
                board[row, col].numBombsNear += 1;
            // up-left
            if (GetSquare(row + 1, col - 1))
                board[row, col].numBombsNear += 1;
            // up-right
            if (GetSquare(row + 1, col + 1))
                board[row, col].numBombsNear += 1;
            // down-left
            if (GetSquare(row - 1, col - 1))
                board[row, col].numBombsNear += 1;
            // down-right
            if (GetSquare(row - 1, col + 1))
                board[row, col].numBombsNear += 1;
        }

        /*******************************************************************************
        * button_Click
        * Handles the clicking of every square. Left and Right Clicks
        * Only registers clicks if the game isn't over.
        *******************************************************************************/
        public void button_Click(object sender, MouseEventArgs e)
        {
            MyButton thisButton = ((MyButton)sender);
            int row = ((MyButton)sender).GetRow();
            int col = ((MyButton)sender).GetCol();

            if (!gameOver)
            {
                // Here we check to see if it is a right mouse button click
                // if so we toggle a flag on the square
                if (e.Button == MouseButtons.Right && !thisButton.GetIsUnveiled())
                {
                    thisButton.FlagSquare();
                    if (thisButton.GetIsFlagged())
                    {
                        numberOfFlags++;
                    }
                    else
                    {
                        numberOfFlags--;
                    }
                }
                // otherwise we know its a left mouse button click
                else
                {
                    // we only register left button clicks if the square isn't flagged.
                    if (!thisButton.GetIsFlagged())
                    {
                        // if its a bomb we display the bomb picture, end game message, and set
                        // gameOver to true
                        if (thisButton.GetIsBomb())
                        {
                            thisButton.BackgroundImage = minesweep.Properties.Resources.bomb;
                            thisButton.BackgroundImageLayout = ImageLayout.Stretch;
                            endMessage.Text = "You Lose!";
                            endMessage.BackColor = Color.Black;
                            endMessage.ForeColor = Color.Red;
                            endMessage.Visible = true;
                            
                            gameOver = true;
                        }
                        // not a bomb so we reveal the number of empty space
                        else
                        {
                            UnveilSquare(row, col); 
                        }
                        
                    }
                }

                // if we have used the same number of flags as bombs and the remaining non-flag 
                // spaces have all been unveiled then we win
                // display end game message and set gameOver to true
                if (unveiledSquares == rows * cols - numberOfBombs && numberOfBombs == numberOfFlags)
                {
                    endMessage.Text = "You Win!";
                    endMessage.BackColor = Color.White;
                    endMessage.ForeColor = Color.Green;
                    endMessage.Visible = true;
                    gameOver = true;
                }
            }
        }

        /*******************************************************************************
        * UnveilSquare
        * Parameters
        *    row, col - refer to the row and column of this square in the board
        * Reveals the number of bombs surrounding this square.
        * If there are none then we call ClearEmptySpots to call this function
        * on all the surrounding squares
        *******************************************************************************/
        public void UnveilSquare(int row, int col)
        {
            // square is easier than board[row, col]
            MyButton square = board[row, col];

            // if the square was already clicked we have nothing to do
            if (square.GetWasClicked())
                return;
            else
            {
                // get rid of the unclicked square image
                square.SetUnveiled(true);
                unveiledSquares++;
                square.SetWasClicked(true);
                square.BackColor = Color.White;
                square.BackgroundImage = null;
                
                // if its an empty square we unveil the surrounding squares
                if (square.numBombsNear == 0)
                {
                    ClearEmptySpots(row, col);
                }
                // otherwise we just show how many bombs surround this square
                else
                {
                    square.TextAlign = ContentAlignment.MiddleCenter;
                    square.Text = square.numBombsNear.ToString();
                }
               
            }
        }

        /*******************************************************************************
        * ClearEmptySpots
        * Parameters
        *    row, col - refer to the row and column of this square in the board
        * The current square was empty (no nearby bombs) so we must unveil all 
        * the surrounding squares (but we check if they're valid first)
        *******************************************************************************/
        public void ClearEmptySpots(int row, int col)
        {
            // up
            if (ValidSquare(row + 1, col))
                UnveilSquare(row + 1, col);
            // down
            if (ValidSquare(row - 1, col))
                UnveilSquare(row - 1, col);
            // left
            if (ValidSquare(row, col - 1))
                UnveilSquare(row, col - 1);
            // right
            if (ValidSquare(row, col + 1))
                UnveilSquare(row, col + 1);
            // up-left
            if (ValidSquare(row + 1, col - 1))
                UnveilSquare(row + 1, col - 1);
            // up-right
            if (ValidSquare(row + 1, col + 1))
                UnveilSquare(row + 1, col + 1);
            // down-left
            if (ValidSquare(row - 1, col - 1))
                UnveilSquare(row - 1, col - 1);
            // down-right
            if (ValidSquare(row - 1, col + 1))
                UnveilSquare(row - 1, col + 1);
        }

        /*******************************************************************************
        * menu_Click
        * Return to Menu button
        * closes game and reopens main menu
        *******************************************************************************/
        private void menu_Click(object sender, EventArgs e)
        {
            mainMenu.Show();
            this.Close();
        }

        /*******************************************************************************
        * Program freaks out if i delete these...
        *******************************************************************************/
        private void timer1_Tick(object sender, EventArgs e)
        {
            //seconds++;
            clock.Text = seconds.ToString();
        }

        private void Clock1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
