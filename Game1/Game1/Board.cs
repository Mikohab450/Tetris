﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Game1
{
     public class Board
    {
        const int width = 10;
        const int lenght = 22;
        bool[,] board = new bool[width, lenght];
        Figure current;
        Figure next_figure;
        public Board()
        {
            for (int i = 0; i < 10; i++)
                for (int j = 0; j < 22; j++)
                    board[i, j] = false;
        }
        public Board(bool p)
        {
            for (int i = 0; i < 10; i++)
                for (int j = 0; j < 22; j++)
                    board[i, j] = p;
        }
        /// <summary>
        /// Indexer that allows to get the value from the board.
        /// Indexes of cols and rows are counted from 0
        /// </summary>
        /// <param name="i">Number of the row</param>
        /// <param name="j">Number of the column</param>
        /// <returns></returns>
        public bool this[int i, int j]
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
        /// Checks if given coordinates are correct
        /// </summary>
        /// <param name="x">The x coordinate</param>
        /// <param name="y">The y coordinate</param>
        /// <returns>True if the coordinates are correct, false otherwise</returns>
        public bool CheckCoords(int x, int y)
        {
            if (x < 0 || y < 0 || x >= width || y >= lenght)
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
            if (p.X < 0 || p.Y < 0 || p.X >= width || p.Y >= lenght)
                return false;
            return true;
        }
    }
}