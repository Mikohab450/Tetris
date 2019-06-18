using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Game1
{
    class Board
    {
        protected bool gameOver=false;
        protected const int width = 10;
        private const int lenght = 23;  //the first line serves as a buffer for new figures
        private SingleBlock[,] board = new SingleBlock[lenght, width];
        private FigureFactory create;
        public Figure current_figure;
        public Figure next_figure;
        //constructor of a board
        public Board()
        {
            create = new FigureFactory(this);
            for (int i = 0; i < width; i++)
                for (int j = 0; j < lenght; j++)
                    board[j, i] = null;
            current_figure = create.GetFigure();
            next_figure = create.GetFigure();
        }
        public void EndTheGame() { gameOver = true; }
        public int GetWidth() { return width; }
        public int GetLenght() { return lenght; }
        /// <summary>
        /// Indexer that allows to get the value from the board.
        /// Indexes of cols and rows are counted from 0
        /// </summary>
        /// <param name="i">Number of the row</param>
        /// <param name="j">Number of the column</param>
        /// <returns>The value of pointed cell the board</returns>
        public SingleBlock this[int i, int j]
        {
            get
            {
                if (CheckCoords(i, j))
                    return board[i, j];
                else
                    throw new IndexOutOfRangeException("Given coordinates are incorrect!");
            }
        }
        /// <summary>
        /// Indexer that allows to get the value from the board.
        /// </summary>
        /// <param name="p">The point on the board</param>
        /// <returns>The value of pointed cell the board</returns>
        public SingleBlock this[Point p]
        {
            get
            {
                if (CheckCoords(p))
                    return board[p.X, p.Y];
                else
                    throw new IndexOutOfRangeException("Given coordinates are incorrect!");
            }
        }
        /// <summary>
        /// Checks if given coordinates are correct
        /// </summary>
        /// <param name="y">The x coordinate</param>
        /// <param name="x">The y coordinate</param>
        /// <returns>True if the coordinates are correct, false otherwise</returns>
        public bool CheckCoords(int x, int y)
        {
            if (y < 0 || x < 0 || y >= width || x >= lenght)
                return false;
            return true;
        }
        /// <summary>
        /// Checks if given point has a correct coordinates
        /// </summary>
        /// <param name="p">The point to be checked</param>
        /// <returns>True if the coordinates are correct, false otherwise</returns>
        public bool CheckCoords(Point p)
        {
            if (p.Y < 0 || p.X < 0 || p.Y >= width || p.X >= lenght)
                return false;
            return true;
        }
        /// <summary>
        /// Checks if any lines are full, and if there are any, clears them
        /// </summary>
        /// <returns>The number of full lines</returns>
        public int CheckLines()
        {
            bool line_found = true;
            int lines=0;
            int current_x;
            for (int i = 0; i < 4; i++)
            {
                current_x = current_figure[i].position.X;
                for (int j = 0; j < width && line_found; j++)
                {
                    if (board[current_x, j] == null)
                        line_found = false;
                }
                if (line_found)
                {
                    ClearLine(current_x);
                    lines++;
                }
                else
                    line_found = true;
               
            }
            return lines;
        }
        public void ClearLine(int line) {
            for (int i = line; i >0; i--)
            {
                for (int j = 0; j < width; j++)
                    board[i, j] = board[i -1, j];
            }
        }
        public void AddToPile()
        {
            for (int i = 0; i < 4; i++)
            {
                SingleBlock blockToAdd = current_figure[i];
                board[blockToAdd.position.X, blockToAdd.position.Y] = new SingleBlock(this, blockToAdd.position);
            }
        }
        /// <summary>
        /// If the game is over, it raises the gameOverFlag
        /// if it isn't, it creates the next figures
        /// </summary>
        public void CheckGameOver()
        {
            for (int i = 0; i < 4; i++)
                if (current_figure[i].position.X > lenght - 1)
                    EndTheGame();
            if (!gameOver)
            {
                current_figure = next_figure;
                next_figure = create.GetFigure();
            }
        }
       
    }
   
}
