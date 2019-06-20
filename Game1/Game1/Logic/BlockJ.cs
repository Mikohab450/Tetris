using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Game1
{
    class BlockJ : Figure
    {
        public BlockJ(Board board_, Color color) : base(board_, color)
        {

        }
        public BlockJ(Figure f) : base(f) { }
        public override SingleBlock[] SetBlocks(Board board_)
        {
            SingleBlock[] blocks = new SingleBlock[4];
            blocks[0] = new SingleBlock(board_, new Point(0, 1) + position);
            blocks[1] = new SingleBlock(board_, new Point(1, 1) + position);
            blocks[2] = new SingleBlock(board_, new Point(2, 1) + position);
            blocks[3] = new SingleBlock(board_, new Point(2, 0) + position);
            return blocks;
        }
        public override Figure RightRotation()
        {
            BlockJRotated90ToRight RotatedFigure = new BlockJRotated90ToRight(this);
            return RotatedFigure;
        }
        public override Figure LeftRotation()
        {
            BlockJRotated270ToRight RotatedFigure = new BlockJRotated270ToRight(this);
            return RotatedFigure;
        }
    }
    class BlockJRotated90ToRight : BlockJ
    {
        //public BlockJRotated90ToRight(Board board_) : base(board_)
        //{
        //}
        public BlockJRotated90ToRight(Figure f) : base(f) { }
        public override SingleBlock[] SetBlocks(Board board_)
        {
            SingleBlock[] blocks = new SingleBlock[4];
            blocks[0] = new SingleBlock(board_, new Point(1, 0) + position);
            blocks[1] = new SingleBlock(board_, new Point(1, 1) + position);
            blocks[2] = new SingleBlock(board_, new Point(1, 2) + position);
            blocks[3] = new SingleBlock(board_, new Point(2, 2) + position);
            return blocks;
        }
        public override Figure RightRotation()
        {
            BlockJRotated180ToRight RotatedFigure = new BlockJRotated180ToRight(this);
            return RotatedFigure;
        }
        public override Figure LeftRotation()
        {

            BlockJ RotatedFigure = new BlockJ(this);
            return RotatedFigure;
        }

    }
    class BlockJRotated180ToRight : BlockJ
    {
        //public BlockJRotated180ToRight(Board board_) : base(board_)
        //{

        //}
        public BlockJRotated180ToRight(Figure f) : base(f) { }
        public override SingleBlock[] SetBlocks(Board board_)
        {
            SingleBlock[] blocks = new SingleBlock[4];
            blocks[0] = new SingleBlock(board_, new Point(0, 1) + position);
            blocks[1] = new SingleBlock(board_, new Point(1, 1) + position);
            blocks[2] = new SingleBlock(board_, new Point(2, 1) + position);
            blocks[3] = new SingleBlock(board_, new Point(0, 2) + position);
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

    class BlockJRotated270ToRight : BlockJ
    {
        public BlockJRotated270ToRight(Figure f) : base(f) { }
        //public BlockJRotated270ToRight(Board board_) : base(board_)
        //{

        //}
        public override SingleBlock[] SetBlocks(Board board_)
        {
            SingleBlock[] blocks = new SingleBlock[4];
            blocks[0] = new SingleBlock(board_, new Point(1, 0) + position);
            blocks[1] = new SingleBlock(board_, new Point(2, 1) + position);
            blocks[2] = new SingleBlock(board_, new Point(2, 2) + position);
            blocks[3] = new SingleBlock(board_, new Point(2, 0) + position);
            return blocks;
        }
        public override Figure RightRotation()
        {
            BlockJ RotatedFigure = new BlockJ(this);
            return RotatedFigure;
        }
        public override Figure LeftRotation()
        {

            BlockJRotated180ToRight RotatedFigure = new BlockJRotated180ToRight(this);
            return RotatedFigure;
        }
    }
}
