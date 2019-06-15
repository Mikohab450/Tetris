using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Game1
{
    public class SingleBlock : Game
    {
        
        private Board board;
        public Point position;
        //this might be unnecessary//
        /// <summary>
        /// Adds given value to the parameter x of the position
        /// </summary>
        /// <param name="value">Value, that will be added to the x coordiante</param>
        public void AddTo_X_Posistion(int value)
        {
            if (board.CheckCoords(value, 0))
                position.X += value;
            else throw new IndexOutOfRangeException("Cannot change the x coordinate!");
        }
        /// <summary>
        /// Adds given value to the parameter y of the position
        /// </summary>
        /// <param name="value">Value, that will be added to the y coordiante</param>
        public void AddTo_Y_Posistion(int value)
        {
            if (board.CheckCoords(0, value))
                position.Y += value;
            else throw new IndexOutOfRangeException("Cannot change the y coordinate!");
        }
        /// <summary>
        /// Constructor of a single block
        /// </summary>
        /// <param name="_board_">The board that the block will be created in</param>
        /// <param name="p">Coordinates of the block</param>
        public SingleBlock(Board board_,Point p)
        {
            if (board_.CheckCoords(p))
                position = p;
            else throw new IndexOutOfRangeException("Given coordinates are incorrect!");
            board = board_;
            //Color = _color;
        }
        /// <summary>
        /// Checks if single block can be moved to the left
        /// </summary>
        /// <returns>True if the block can be moved, false otherwise</returns>
        public bool CanMoveLeft()
        {
            if (position.X-1 < 0 || board[position.X-1, position.Y])
                return false;
            return true;
        }
        /// <summary>
        /// Checks if single block can be moved to the right
        /// </summary>
        /// <returns>True if the block can be moved, false otherwise</returns>
        public bool CanMoveRight()
        {
            if (position.X + 1 < 0 || board[position.X + 1, position.Y])
                return false;
            return true;
        }        
        /// <summary>
        /// Checks if single block can be moved down
        /// </summary>
        /// <returns>True if the block can be moved, false otherwise</returns>
        public bool CanMoveDown()
        {
            if (board[position.X, position.Y+1] || position.Y+1<0)
                return false;
            return true;
        }
        /// <summary>
        ///Moves the block to the left 
        /// </summary>
        public void MoveLeft()
        {
            position.X--;

        }
        /// <summary>
        ///Moves the block to the right
        /// </summary>
        public void MoveRight()
        {
            position.X++;

        }
        //public int Posx { get; set; }
        //public int Posy { get; set; }
        public Color Color { get; set; }
    }
}
