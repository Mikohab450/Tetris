﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Game1
{
    class BlockI : Figure
    {
        public BlockI(Board board_):base(board_)
        {         
            //blocks=SetBlocks
        }
        public override SingleBlock[] SetBlocks(Board board)
        {
            SingleBlock[] blocks = new SingleBlock[4];
            for (int i = 0; i < 4; i++)
            { 
                blocks[i] = new SingleBlock(board, new Point(i, 2) );
            }
            return blocks;
        }
 
        public override Figure RightRotation()
        {
            BlockIRotated RotatedFigure= new BlockIRotated(board);
            return RotatedFigure;
        }
        public override Figure LeftRotation()
        {
            return RightRotation();     //left and right rotation are the same
        }
    }
    class BlockIRotated : BlockI
    { 
        public BlockIRotated(Board board_):base(board_)
        { 
        }
        public override SingleBlock[] SetBlocks(Board board_)
        {
            SingleBlock[] blocks = new SingleBlock[4];
            for (int i = 0; i < 4; i++)
                blocks[i] = new SingleBlock(board_, new Point(1, i));
            return blocks;
        }
        public override Figure RightRotation()
        {
            BlockI RotatedFigure = new BlockI(board);
            return RotatedFigure;
        }
        public override Figure LeftRotation()
        {
            return RightRotation();     //left and right rotation are the same
        }
    }
}