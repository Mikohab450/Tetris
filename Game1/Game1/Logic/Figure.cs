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
        private Color color;
        public Color Color
        {
            get { return color; }
            set
            {
                color = value;
                for (int i = 0; i < 4; i++)
                    blocks[i].Color = color;
            }
        }

        protected Board board;
        internal protected Point position;
        //public Figure() { }
        private SingleBlock[] blocks;
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
        public void FigureDropeed()
        {
            board.AddToPile();
            board.CheckLines();
            board.CheckGameOver();
        }
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
        /// Generates a random color and sets it to all of blocks
        /// </summary>
        public void SetColor()
        {
            Random r = new Random();
            Color c = new Color(r.Next(255), r.Next(255), r.Next(255));
            color = c;
            for (int i = 0; i < 4; i++)
                blocks[i].Color = c;
        }


        /// <summary>
        /// Obraca figure o 90 stopni w prawo
        /// </summary>
        abstract public Figure RightRotation();
        /// <summary>
        /// Obraca figure o 90 stopni w prawo
        /// </summary>
        abstract public Figure LeftRotation();

        public virtual SingleBlock[] SetBlocks(Board board_)
        {
            return null;//new SingleBlock[4];
        }
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
    }
}
