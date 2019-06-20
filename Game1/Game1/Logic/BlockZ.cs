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
        public BlockZ(Board board_, Color color) : base(board_,color)
        {
        }
        public BlockZ(Figure f) : base(f) { }
        public override SingleBlock[] SetBlocks(Board board_)
        {
            SingleBlock[] blocks = new SingleBlock[4];
            blocks[0] = new SingleBlock(board_, new Point(1, 0) + position);
            blocks[1] = new SingleBlock(board_, new Point(1, 1) + position);
            blocks[2] = new SingleBlock(board_, new Point(2, 1) + position);
            blocks[3] = new SingleBlock(board_, new Point(2, 2) + position);
            return blocks;
        }
        public override Figure RightRotation()
        {
            BlockZRotated90ToRight RotatedFigure = new BlockZRotated90ToRight(this);
            return RotatedFigure;
        }
        public override Figure LeftRotation()
        {
            return RightRotation();             //left and right rotations are the same
        }
    }
    class BlockZRotated90ToRight : BlockZ
    {
        public BlockZRotated90ToRight(Figure f) : base(f) { }
        //public BlockZRotated90ToRight(Board board) : base(board)
        //{
        //}
        public override SingleBlock[] SetBlocks(Board board_)
        {
            SingleBlock[] blocks = new SingleBlock[4];
            blocks[0] = new SingleBlock(board_, new Point(2, 1) + position);
            blocks[1] = new SingleBlock(board_, new Point(1, 1) + position);
            blocks[2] = new SingleBlock(board_, new Point(1, 2) + position);
            blocks[3] = new SingleBlock(board_, new Point(0, 2) + position);
            return blocks;
        }
        public override Figure RightRotation()
        {
            BlockZ RotatedFigure = new BlockZ(this);
            return RotatedFigure;
        }
        public override Figure LeftRotation()
        {
            return RightRotation();      //left and right rotations are the same
        }
    }
}
