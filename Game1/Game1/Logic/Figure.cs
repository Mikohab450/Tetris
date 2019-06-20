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
        internal protected Point position;
        private SingleBlock[] blocks;
        private Color color;
        /// <summary>
        /// Color of a figure. Setting it will result stting the colors of all the blocks it contains
        /// </summary>
        public Color Color
        {
            get { return color; }
            set
            {
                this.color = value;
                for (int i = 0; i < 4; i++)
                    blocks[i].Color = color;
            }
        }

        //constructor
        public Figure(Board board_,Color color_)
        {
            board = board_;
            position.X = 0;
            position.Y = 3;
            blocks = SetBlocks(board);
            color = color_;
            for (int i = 0; i < 4; i++)
                blocks[i].Color = color;
        }
        /// <summary>
        /// Copying constructor
        /// </summary>
        /// <param name="f"></param>
        public Figure(Figure f)
        {
            this.board = f.board;
            this.position = f.position;
            blocks = SetBlocks(board);
            this.Color = f.Color;
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
                position.Y--;
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
                position.Y++;
            }
        }/// <summary>
         /// Moves the figure down if its possible
         /// </summary>
        public void MoveDown()
        {
            if (CanMoveDown())
            {
                for (int i = 0; i < 4; i++)
                    blocks[i].MoveDown();
                position.X++;
            }
        }
        /// <summary>
        /// Set of actions that are performed when 
        /// the figure cannot move further down
        /// </summary>
        public void FigureDropeed()
        {
            board.AddToPile();
            board.CheckLines();
            board.CheckGameOver();
        }
        /// <summary>
        /// Indexor that enables to access one of the figures block
        /// </summary>
        /// <param name="i">index of the block</param>
        /// <returns>one of the blocks creating figure</returns>
        public SingleBlock this[int i]
        {
            get
            {
                if (i >= 0 && i < 4)
                    return blocks[i];
                else
                    throw new IndexOutOfRangeException("Blocks index is out of range!");
            }

        }
   

  
        /// <summary>
        /// Obraca figure o 90 stopni w prawo
        /// </summary>
        abstract public Figure RightRotation();
        /// <summary>
        /// Obraca figure o 90 stopni w lewo
        /// </summary>
        abstract public Figure LeftRotation();

        /// <summary>
        /// Puts blocks of figure in proper positions
        /// </summary>
        /// <param name="board_">Board where game takes place</param>
        /// <returns>Set of setted blocks</returns>
        abstract public SingleBlock[] SetBlocks(Board board_);
       
        /// <summary>
        /// Chcks if the figure can be rotated
        /// </summary>
        /// <returns></returns>
        public bool CanBeRotatedTo(Figure next)
        {
            for (int i = 0; i < 4; i++)
            {
                Point block_next_position = next[i].position;
                if (!board.CheckCoords(block_next_position) || board[block_next_position] != null)
                    return false;
            }
            return true;
        }

        /// <summary>
        /// Checks if a figure can be moved to the left
        /// </summary>
        /// <returns>True if the fiure can be moved, false otherwise</returns>
        private bool CanMoveLeft()
        {
            for (int i = 0; i < 4; i++)
                if (!blocks[i].CanMoveLeft())
                    return false;
            return true;
        }
        /// <summary>
        /// Moves the figure to the bottom-most position
        /// </summary>
        public void Drop()
        {
            while (CanMoveDown())
                MoveDown();

        }
        /// <summary>
        /// Checks if a figure can be moved to the right
        /// </summary>
        /// <returns>True if a figure can be moved, false otherwise</returns>
        private bool CanMoveRight()
        {
            for (int i = 0; i < 4; i++)
                if (!blocks[i].CanMoveRight())
                    return false;
            return true;
        }
        /// <summary>
        /// Checks if a figure can be moved down
        /// If it can't it 
        /// </summary>
        /// <returns>True if a figure can be moved, false otherwise</returns>
        private bool CanMoveDown()
        {
            for (int i = 0; i < 4; i++)
                if (!blocks[i].CanMoveDown())
                {
                    FigureDropeed();
                    return false;
                }
            return true;
        }
        /// <summary>
        /// Deicides wheter the next figure can be spawn on the board
        /// </summary>
        /// <returns>True if the figure ca be spawn , false otherwise</returns>
        public bool CanSpawn()
        {
            for (int i = 0; i < 4; i++)
                if (board[blocks[i].position] != null)
                    return false;
            return true;

         }
    }
   
}
