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
        public BlockL(Board board):base(board)
        {
        }
        public override SingleBlock[] SetBlocks(Board board_)
        {
            SingleBlock[] blocks = new SingleBlock[4];
            blocks[0] = new SingleBlock(board_, new Point(0, 1));
            blocks[1] = new SingleBlock(board_, new Point(1, 1));
            blocks[2] = new SingleBlock(board_, new Point(2, 1));
            blocks[3] = new SingleBlock(board_, new Point(2, 2));
            return blocks;
        }
        public override Figure RightRotation()
        {
            BlockLRotated90ToRight RotatedFigure = new BlockLRotated90ToRight(board);
            return RotatedFigure;
        }
        public override Figure LeftRotation()
        {
            BlockLRotated270ToRight RotatedFigure = new BlockLRotated270ToRight(board);
            return RotatedFigure;
        }
    }
    class BlockLRotated90ToRight : BlockL
    {
        public BlockLRotated90ToRight(Board board):base(board)
        {

        }
        public override SingleBlock[] SetBlocks(Board board_)
        {
            SingleBlock[] blocks = new SingleBlock[4];
            blocks[0] = new SingleBlock(board_, new Point(2, 0));
            blocks[1] = new SingleBlock(board_, new Point(1, 0));
            blocks[2] = new SingleBlock(board_, new Point(1, 1));
            blocks[3] = new SingleBlock(board_, new Point(1, 2));
            return blocks;
        }
        public override Figure RightRotation()
        {
            BlockLRotated180ToRight RotatedFigure = new BlockLRotated180ToRight(board);
            return RotatedFigure;
        }
        public override Figure LeftRotation()
        {
            BlockL RotatedFigure = new BlockL(board);
            return RotatedFigure;
        }
    }
    class BlockLRotated180ToRight : BlockL
    {
        public BlockLRotated180ToRight(Board board):base(board)
        {
        }
        public override SingleBlock[] SetBlocks(Board board_)
        {
            SingleBlock[] blocks = new SingleBlock[4];
            blocks[0] = new SingleBlock(board_, new Point(0, 1));
            blocks[1] = new SingleBlock(board_, new Point(1, 1));
            blocks[2] = new SingleBlock(board_, new Point(2, 1));
            blocks[3] = new SingleBlock(board_, new Point(0, 2));
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
        public BlockLRotated270ToRight(Board board):base(board)
        {
        }
        public override SingleBlock[] SetBlocks(Board board_)
        {
            SingleBlock[] blocks = new SingleBlock[4];
            blocks[0] = new SingleBlock(board_, new Point(1, 0));
            blocks[1] = new SingleBlock(board_, new Point(1, 1));
            blocks[2] = new SingleBlock(board_, new Point(2, 3));
            blocks[3] = new SingleBlock(board_, new Point(2, 2));
            return blocks;
        }
        public override Figure RightRotation()
        {
            BlockL RotatedFigure = new BlockL(board);
            return RotatedFigure;
        }
        public override Figure LeftRotation()
        {
            BlockLRotated180ToRight RotatedFigure = new BlockLRotated180ToRight(board);
            return RotatedFigure;
        }
    }


}
