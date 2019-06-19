using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Game1
{
    class SingleBlock
    {
        
        private Board board;
        public Point position;

        /// <summary>
        /// Constructor of a single block
        /// </summary>
        /// <param name="_board_">The board that the block will be created in</param>
        /// <param name="p">Coordinates of the block</param>
        public SingleBlock(Board board_,Point p)
        {
           // if (board_.CheckCoords(p))
                position = p;
           // else throw new IndexOutOfRangeException("Given coordinates are incorrect!");
            board = board_;
        }
        /// <summary>
        /// Checks if single block can be moved to the left
        /// </summary>
        /// <returns>True if the block can be moved, false otherwise</returns>
        public bool CanMoveLeft()
        {
            if (position.Y-1 < 0 || board[position.X, position.Y-1]!=null)
                return false;
            return true;
        }
        /// <summary>
        /// Checks if single block can be moved to the right
        /// </summary>
        /// <returns>True if the block can be moved, false otherwise</returns>
        public bool CanMoveRight()
        {
            if (position.Y + 1 >= board.GetWidth() || board[position.X, position.Y+1] != null)
                return false;
            return true;
        }        
        /// <summary>
        /// Checks if single block can be moved down
        /// </summary>
        /// <returns>True if the block can be moved, false otherwise</returns>
        public bool CanMoveDown()
        {
            if (position.X + 1 >= board.GetLenght() || board[position.X+1, position.Y] != null )
                return false;
            return true;
        }
        /// <summary>
        ///Moves the block to the left 
        /// </summary>
        public void MoveLeft()
        {
            position.Y--;

        }
        /// <summary>
        ///Moves the block to the right
        /// </summary>
        public void MoveRight()
        {
            position.Y++;

        }

        public void MoveDown()
        {
                position.X++;
        }
        public Color Color {
            get;
            set;
        }
    }
}
