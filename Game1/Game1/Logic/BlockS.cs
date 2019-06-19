using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Game1
{
    class BlockS : Figure
    {
        public BlockS(Board board) : base(board)
        {
        }
        public BlockS(Figure f) : base(f) { }
        public override SingleBlock[] SetBlocks(Board board_)
        {
            SingleBlock[] blocks = new SingleBlock[4];
            blocks[0] = new SingleBlock(board_, new Point(2, 0) + position);
            blocks[1] = new SingleBlock(board_, new Point(2, 1) + position);
            blocks[2] = new SingleBlock(board_, new Point(1, 1) + position);
            blocks[3] = new SingleBlock(board_, new Point(1, 2) + position);
            return blocks;
        }
        public override Figure RightRotation()
        {
            BlockSRotated90ToRight RotatedFigure = new BlockSRotated90ToRight(this);
            return RotatedFigure;
        }
        public override Figure LeftRotation()
        {
            return RightRotation();             //left and right rotations are the same
        }
    }
    class BlockSRotated90ToRight : BlockS
    {
        public BlockSRotated90ToRight(Board board) : base(board)
        { }
        public BlockSRotated90ToRight(Figure f) : base(f) { }
        public override SingleBlock[] SetBlocks(Board board_)
        {
            SingleBlock[] blocks = new SingleBlock[4];
            blocks[0] = new SingleBlock(board_, new Point(0, 0) + position);
            blocks[1] = new SingleBlock(board_, new Point(1, 0) + position);
            blocks[2] = new SingleBlock(board_, new Point(1, 1) + position);
            blocks[3] = new SingleBlock(board_, new Point(2, 1) + position);
            return blocks;
        }
        public override Figure RightRotation()
        {
            BlockS RotatedFigure = new BlockS(this);
            return RotatedFigure;
        }
        public override Figure LeftRotation()
        {
            return RightRotation();      //left and right rotations are the same
        }
    }
}
