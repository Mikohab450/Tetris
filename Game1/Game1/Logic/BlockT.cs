using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Game1
{
    class BlockT : Figure
    {
        public BlockT(Board board) : base(board)
        {
        }
        public BlockT(Figure f) : base(f) { }
        public override SingleBlock[] SetBlocks(Board board_)
        {
            SingleBlock[] blocks = new SingleBlock[4];
            blocks[0] = new SingleBlock(board_, new Point(1, 0) + position);
            blocks[1] = new SingleBlock(board_, new Point(1, 1) + position);
            blocks[2] = new SingleBlock(board_, new Point(1, 2) + position);
            blocks[3] = new SingleBlock(board_, new Point(2, 1) + position);
            return blocks;
        }
        public override Figure RightRotation()
        {
            BlockTRotated90ToRight RotatedFigure = new BlockTRotated90ToRight(this);
            return RotatedFigure;
        }
        public override Figure LeftRotation()
        {
            BlockTRotated270ToRight RotatedFigure = new BlockTRotated270ToRight(this);
            return RotatedFigure;
        }
    }
    class BlockTRotated90ToRight : BlockT
    {
        public BlockTRotated90ToRight(Figure f) : base(f) { }
        public BlockTRotated90ToRight(Board board) : base(board)
        {
        }
        public override SingleBlock[] SetBlocks(Board board_)
        {
            SingleBlock[] blocks = new SingleBlock[4];
            blocks[0] = new SingleBlock(board_, new Point(0, 1) + position);
            blocks[1] = new SingleBlock(board_, new Point(1, 1) + position);
            blocks[2] = new SingleBlock(board_, new Point(1, 0) + position);
            blocks[3] = new SingleBlock(board_, new Point(2, 1) + position);
            return blocks;
        }
        public override Figure RightRotation()
        {

            BlockTRotated180ToRight RotatedFigure = new BlockTRotated180ToRight(this);
            return RotatedFigure;
        }
        public override Figure LeftRotation()
        {
            BlockT RotatedFigure = new BlockT(this);
            return RotatedFigure;
        }
    }
    class BlockTRotated180ToRight : BlockT
    {
        public BlockTRotated180ToRight(Figure f) : base(f) { }
        public BlockTRotated180ToRight(Board board) : base(board)
        {
        }
        public override SingleBlock[] SetBlocks(Board board_)
        {
            SingleBlock[] blocks = new SingleBlock[4];
            blocks[0] = new SingleBlock(board_, new Point(2, 0) + position);
            blocks[1] = new SingleBlock(board_, new Point(2, 1) + position);
            blocks[2] = new SingleBlock(board_, new Point(2, 2) + position);
            blocks[3] = new SingleBlock(board_, new Point(1, 1) + position);
            return blocks;
        }
        public override Figure RightRotation()
        {
            return base.LeftRotation();         //right roatation for 180 degree is the same as left rotation for the 0 degree
        }
        public override Figure LeftRotation()
        {
            return base.RightRotation();         //left roatation for 180 degree is the same as right rotation for the 0 degree
        }
    }
    class BlockTRotated270ToRight : BlockT
    {
        public BlockTRotated270ToRight(Figure f) : base(f) { }
        public BlockTRotated270ToRight(Board board) : base(board)
        {
        }
        public override SingleBlock[] SetBlocks(Board board_)
        {
            SingleBlock[] blocks = new SingleBlock[4];
            blocks[0] = new SingleBlock(board_, new Point(0, 1) + position);
            blocks[1] = new SingleBlock(board_, new Point(1, 1) + position);
            blocks[2] = new SingleBlock(board_, new Point(1, 2) + position);
            blocks[3] = new SingleBlock(board_, new Point(2, 1) + position);
            return blocks;
        }
        public override Figure RightRotation()
        {
            BlockT RotatedFigure = new BlockT(this);
            return RotatedFigure;
        }
        public override Figure LeftRotation()
        {
            BlockTRotated180ToRight RotatedFigure = new BlockTRotated180ToRight(this);
            return RotatedFigure;
        }
    }
}
