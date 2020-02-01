using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace minesweep
{
    /*******************************************************************************
    * MyButton Class
    * Similar to the normal Button but with more attributes for a square
    * in minesweeper
    *******************************************************************************/
    class MyButton : Button
    {
        private int row;
        private int col;
        private bool wasClicked;
        private bool isUnveiled;
        private bool isFlagged;
        private bool isBomb;
        public int numBombsNear;

        /*******************************************************************************
        * DEFAULT CONSTRUCTOR
        *******************************************************************************/
        public MyButton()
        {
            wasClicked = false;
            this.BackColor = Color.Gray;
            isUnveiled = false;
            isFlagged = false;
            isBomb = false;
            numBombsNear = 0;
        }

        // getter and setter for unveiled and flagged.
        public bool GetIsUnveiled() { return isUnveiled; }
        public void SetUnveiled(bool unveiled) { isUnveiled = unveiled; }
        public bool GetIsFlagged() { return isFlagged; }

        /*******************************************************************************
        * FlagSquare
        * Sets whether the square is flagged.
        * Toggles flag image
        *******************************************************************************/
        public void FlagSquare()
        {
            if (this.BackgroundImage == null)
            {
                this.BackgroundImage = minesweep.Properties.Resources.flag;
                isFlagged = true;
            }
            else
            {
                this.BackgroundImage = null;
                isFlagged = false;
            }

            this.BackgroundImageLayout = ImageLayout.Stretch;
        }

        // getter and setter for wasClicked
        public bool GetWasClicked() { return wasClicked; }
        public void SetWasClicked(bool was) { wasClicked = was; }
        
        // getter and setter for row
        public int GetRow() { return row; }
        public void SetRow(int row) { this.row = row; }

        // getter and setter for col
        public int GetCol() { return col; }
        public void SetCol(int col) { this.col = col; }

        // getter and setter for isBomb
        public void SetBomb(bool bomb) { isBomb = bomb; }
        public bool GetIsBomb() { return isBomb; }
    }
}
