﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Game1
{
    class BlockO : Figure
    {
        public BlockO(Board board_, Color color) : base(board_, color)
        { }
        public override SingleBlock[] SetBlocks(Board board_)
        {
            SingleBlock[] blocks = new SingleBlock[4];
            blocks[0] = new SingleBlock(board_, new Point(1, 1) + position);
            blocks[1] = new SingleBlock(board_, new Point(1, 2) + position);
            blocks[2] = new SingleBlock(board_, new Point(2, 1) + position);
            blocks[3] = new SingleBlock(board_, new Point(2, 2) + position);
            return blocks;
        }
        /// <summary>
        /// Rotation of this block doesn't change anything
        /// </summary>
        /// <returns>The same block</returns>
        public override Figure RightRotation()
        {
            return this;
        }
        public override Figure LeftRotation()
        {

            return this;
        }
    }

}
