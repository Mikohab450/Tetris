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
        private Score s;
        private const int width = 10;
        private const int height = 23;  
        private SingleBlock[,] board = new SingleBlock[height, width];
        private FigureFactory create;
        private Figure current_figure;
        public Figure next_figure;
        //constructor of a board
        public Board()
        {
            s = new Score();
            create = new FigureFactory(this);
            for (int i = 0; i < width; i++)
                for (int j = 0; j < height; j++)
                    board[j, i] = null;

            current_figure = create.GetFigure();
            next_figure = create.GetFigure();

        }
        /// <summary>
        /// If its possible, moves the currently displayed figure down
        /// </summary>
        public void MoveFigureDown() { current_figure.MoveDown(); }
        /// <summary>
        /// If its possible, moves the currently displayed figure left
        /// </summary>
        public void MoveFigureLeft() { current_figure.MoveLeft(); }
        /// <summary>
        /// If its possible, moves the currently displayed figure right
        /// </summary>
        public void MoveFigureRight() { current_figure.MoveRight(); }
        /// <summary>
        /// If its possible, rotates the currently displayed figure left
        /// </summary>
        public void FigureLeftRotation()
        {
            if (current_figure.CanBeRotatedTo(current_figure.LeftRotation()))
                current_figure = current_figure.LeftRotation();
        }
        /// <summary>
        /// If its possible, drops the currently displayed figure to the bottom
        /// </summary>
        public void DropFigure() { current_figure.Drop(); }
        /// <summary>
        /// If its possible, rotates the currently displayed figure left
        /// </summary>
        public void FigureRightRotation()
        {
            if (current_figure.CanBeRotatedTo(current_figure.RightRotation()))
                current_figure = current_figure.RightRotation();
        }
        /// <summary>
        /// Accesor of a current figure
        /// </summary>
        /// <returns>Currently displayed figure</returns>
        public Figure GetFigure() { return current_figure; }
        /// <summary>
        /// Accesor of a next figure
        /// </summary>
        /// <returns>Figure, that will be used next</returns>
        public Figure GetNext() { return next_figure; }

        /// <summary>
        /// Function that raises flag that the game is ended and clears the board
        /// </summary>
        public void EndTheGame()
        {
            MenuState.IsShowGameOverScene = true;
            for (int i = 0; i < width; i++)
            for (int j = 0; j < height; j++)
                board[j, i] = null;
        }


     
        public int GetWidth() { return width; }         // Accesor of the boards width
        public int GeHeight() { return height; }         // Accesor of the boards height
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
            if (y < 0 || x < 0 || y > width || x > height)
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
            if (p.Y < 0 || p.X < 0 || p.Y >= width || p.X > height)
                return false;
            return true;
        }
        /// <summary>
        /// Checks if any lines are full, and if there are any, clears them
        /// </summary>
        /// <returns>The number of full lines</returns>
        public void CheckLines()
        {
            bool line_found = true;
            int lines = 0;
            int current_x= current_figure[0].position.X;
            int indexes_to_check;   //number of rows to be checked,depending on what figure was dropped
            if (current_figure is BlockLRotated180ToRight || current_figure is BlockJRotated180ToRight || current_figure is BlockZRotated90ToRight || current_figure is BlockSRotated90ToRight
                || current_figure is BlockTRotated90ToRight || current_figure is BlockTRotated270ToRight)
                indexes_to_check = 3;
            else if (current_figure is BlockLRotated90ToRight || current_figure is BlockJRotated90ToRight || current_figure is BlockTRotated180ToRight
                || current_figure is BlockJRotated270ToRight ||  current_figure is BlockJRotated270ToRight)
                indexes_to_check = 2;
            else if (current_figure is BlockIRotated)
                indexes_to_check = 1;
            else if (current_figure is BlockI)
                indexes_to_check = 4;
            else if (current_figure is BlockJ || current_figure is BlockL || current_figure is BlockZRotated90ToRight || current_figure is BlockSRotated90ToRight)
                indexes_to_check = 3;
            else
                indexes_to_check = 2;
            for (int i = 0; i <indexes_to_check ; i++)      //for all the rows
            {
                for (int j = 0; j < width && line_found; j++)
                {
                    if (board[current_x, j] == null)
                        line_found = false;
                }
                if (line_found)
                {
                    ClearLine(current_x);
                    lines++;        //increments number of lines found
 
                }
                else
                {
                    line_found = true;
                }
                current_x++;            //move down


            }
            s.addScore(lines);          //add to score
        }
        /// <summary>
        /// Clears the line
        /// </summary>
        /// <param name="line">Index of a row to be cleaned</param>
        public void ClearLine(int line)
        {
            for (int i = line; i > 0; i--)
            {
                for (int j = 0; j < width; j++)
                    board[i, j] = board[i - 1, j];
            }
        }
        /// <summary>
        /// Adds a figure to a board
        /// </summary>
        public void AddToPile()
        {
            for (int i = 0; i < 4; i++)
            {
                SingleBlock blockToAdd = current_figure[i];
                board[blockToAdd.position.X, blockToAdd.position.Y] = new SingleBlock(this, blockToAdd.position)
                {
                    Color = current_figure[i].Color
                };
            }
        }
        /// <summary>
        /// If the game is over, performs EndTheGame method
        /// if it isn't, it creates the next figures
        /// </summary>
        public void CheckGameOver()
        {
            for (int i = 0; i < 4; i++)
                if (current_figure[i].position.X <=1 || !next_figure.CanSpawn())
                    EndTheGame();

           current_figure = next_figure;
           next_figure = create.GetFigure();
        }
        /// <summary>
        /// Clears the score
        /// </summary>

        public void ClearScore()
        {
            s.ClearScore();
        }
    }

}
