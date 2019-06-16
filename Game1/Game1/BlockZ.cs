using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Game1
{
    class BlockZ : Figure
    {
        public BlockZ(Board board):base(board)
        {
        }
        public override SingleBlock[] SetBlocks(Board board_)
        {
            SingleBlock[] blocks = new SingleBlock[4];
            blocks[0] = new SingleBlock(board_, new Point(1, 0));
            blocks[1] = new SingleBlock(board_, new Point(1, 1));
            blocks[2] = new SingleBlock(board_, new Point(2, 1));
            blocks[3] = new SingleBlock(board_, new Point(2, 2));
            return blocks;
        }
        public override Figure RightRotation()
        {
            BlockZRotated90ToRight RotatedFigure = new BlockZRotated90ToRight(board);
            return RotatedFigure;
        }
        public override Figure LeftRotation()
        {
            return RightRotation();             //left and right rotations are the same
        }
    }
    class BlockZRotated90ToRight : BlockZ
    {
        public BlockZRotated90ToRight(Board board):base(board)
        { 
        }
        public override SingleBlock[] SetBlocks(Board board_)
        {
            SingleBlock[] blocks = new SingleBlock[4];
            blocks[0] = new SingleBlock(board_, new Point(2, 1));
            blocks[1] = new SingleBlock(board_, new Point(1, 1));
            blocks[2] = new SingleBlock(board_, new Point(1, 2));
            blocks[3] = new SingleBlock(board_, new Point(0, 2));
            return blocks;
        }
        public override Figure RightRotation()
        {
            BlockZ RotatedFigure = new BlockZ(board);
            return RotatedFigure;
        }
        public override Figure LeftRotation()
        {
            return RightRotation();      //left and right rotations are the same
        }
    }
}
