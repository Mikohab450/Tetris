using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Game1
{
    class BlockL : Figure
    {
        public BlockL(Board board,Color color) : base(board,color)
        {
        }
        public BlockL(Figure f) : base(f) { }
        public override SingleBlock[] SetBlocks(Board board_)
        {
            SingleBlock[] blocks = new SingleBlock[4];
            blocks[0] = new SingleBlock(board_, new Point(0, 1) + position);
            blocks[1] = new SingleBlock(board_, new Point(1, 1) + position);
            blocks[2] = new SingleBlock(board_, new Point(2, 1) + position);
            blocks[3] = new SingleBlock(board_, new Point(2, 2) + position);
            return blocks;
        }
        public override Figure RightRotation()
        {
            BlockLRotated90ToRight RotatedFigure = new BlockLRotated90ToRight(this);
            return RotatedFigure;
        }
        public override Figure LeftRotation()
        {
            BlockLRotated270ToRight RotatedFigure = new BlockLRotated270ToRight(this);
            return RotatedFigure;
        }
    }
    class BlockLRotated90ToRight : BlockL
    {
        //public BlockLRotated90ToRight(Board board) : base(board)
        //{

        //}
        public BlockLRotated90ToRight(Figure f) : base(f) { }
        public override SingleBlock[] SetBlocks(Board board_)
        {
            SingleBlock[] blocks = new SingleBlock[4];
            blocks[0] = new SingleBlock(board_, new Point(0, 2) + position);
            blocks[1] = new SingleBlock(board_, new Point(1, 0) + position);
            blocks[2] = new SingleBlock(board_, new Point(1, 1) + position);
            blocks[3] = new SingleBlock(board_, new Point(1, 2) + position);
            return blocks;
        }
        public override Figure RightRotation()
        {
            BlockLRotated180ToRight RotatedFigure = new BlockLRotated180ToRight(this);
            return RotatedFigure;
        }
        public override Figure LeftRotation()
        {
            BlockL RotatedFigure = new BlockL(this);
            return RotatedFigure;
        }
    }
    class BlockLRotated180ToRight : BlockL
    {
        public BlockLRotated180ToRight(Figure f) : base(f) { }
        //public BlockLRotated180ToRight(Board board) : base(board)
        //{
        //}
        public override SingleBlock[] SetBlocks(Board board_)
        {
            SingleBlock[] blocks = new SingleBlock[4];
            blocks[0] = new SingleBlock(board_, new Point(0, 1) + position);
            blocks[1] = new SingleBlock(board_, new Point(1, 1) + position);
            blocks[2] = new SingleBlock(board_, new Point(2, 1) + position);
            blocks[3] = new SingleBlock(board_, new Point(0, 0) + position);
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
    class BlockLRotated270ToRight : BlockL
    {
        public BlockLRotated270ToRight(Figure f) : base(f) { }
        //public BlockLRotated270ToRight(Board board) : base(board)
        //{
        //}
        public override SingleBlock[] SetBlocks(Board board_)
        {
            SingleBlock[] blocks = new SingleBlock[4];
            blocks[0] = new SingleBlock(board_, new Point(1, 0) + position);
            blocks[1] = new SingleBlock(board_, new Point(2, 0) + position);
            blocks[2] = new SingleBlock(board_, new Point(1, 1) + position);
            blocks[3] = new SingleBlock(board_, new Point(1, 2) + position);
            return blocks;
        }
        public override Figure RightRotation()
        {
            BlockL RotatedFigure = new BlockL(this);
            return RotatedFigure;
        }
        public override Figure LeftRotation()
        {
            BlockLRotated180ToRight RotatedFigure = new BlockLRotated180ToRight(this);
            return RotatedFigure;
        }
    }


}