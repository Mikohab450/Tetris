using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Game1
{
    abstract class Figure
    {
        protected Board board;
        private Point position; 
        public bool[,] blockArray = new bool[4, 4]
        {
            {false,false,false,false },
            {false,false,false,false },
            {false,false,false,false },
            {false,false,false,false }
        };
        public Figure() { }
        private SingleBlock[] blocks;
        public Figure(Board board_)
        {
           board = board_;
           blocks =SetBlocks(board);
        }
        /// <summary>
        /// If it is possible, moves the figure to the left
        /// </summary>
        public void MoveLeft()
        {
            if (CanMoveLeft())
            {
                for (int i = 0; i < 4; i++)
                    blocks[i].MoveLeft();
                position.X++;
            }
        }
        /// <summary>
        /// If it is possible, moves the figure to the right
        /// </summary>
        public void MoveRight()
        {
            if (CanMoveRight())
            {
                for (int i = 0; i < 4; i++)
                    blocks[i].MoveRight();
                position.X--;
            }
        }
        public void MoveDown()
        {
            if (CanMoveDown())
            {
                for (int i = 0; i < 4; i++)
                    blocks[i].MoveDown();
                position.Y++;
            }
        }



        /// <summary>
        /// Obraca figure o 90 stopni w prawo
        /// </summary>
        public virtual Figure RightRotation()
        {
            return this;
        }  
        /// <summary>
        /// Obraca figure o 90 stopni w prawo
        /// </summary>
        public virtual Figure LeftRotation()
        {
            return this;
        }
        public virtual SingleBlock[] SetBlocks(Board board_)
        {
            return null;// new SingleBlock[4];
        }
        /// <summary>
        /// Chcks if the figure can be rotated
        /// </summary>
        /// <returns></returns>
        public bool CanBeRotated() {
            Figure next_pos ;
            return true;
        }
        /// <summary>
        /// Checks if a figure can be moved to the left
        /// </summary>
        /// <returns>True if the fiure can be moved, false otherwise</returns>
        public bool CanMoveLeft()
        {
            for(int i=0;i<4;i++)
                if(!blocks[i].CanMoveLeft())
                    return false;
            return true;
        }
        /// <summary>
        /// Checks if a figure can be moved to the right
        /// </summary>
        /// <returns>True if a figure can be moved, false otherwise</returns>
        public bool CanMoveRight()
        {
            for(int i = 0; i < 4; i++)
                if (!blocks[i].CanMoveRight())
                    return false;
            return true;
        }
        /// <summary>
        /// Checks if a figure can be moved down
        /// </summary>
        /// <returns>True if a figure can be moved, false otherwise</returns>
        public bool CanMoveDown()
        {
            for (int i = 0; i < 4; i++)
                if (!blocks[i].CanMoveDown())
                    return false;
            return true;
        }
    }
}
