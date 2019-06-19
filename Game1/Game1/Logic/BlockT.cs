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
        public BlockT(Board board):base(board)
        { 
        }
        public override SingleBlock[] SetBlocks(Board board_)
        {
            SingleBlock[] blocks = new SingleBlock[4];
            blocks[0] = new SingleBlock(board_, new Point(1, 0));
            blocks[1] = new SingleBlock(board_, new Point(1, 1));
            blocks[2] = new SingleBlock(board_, new Point(1, 2));
            blocks[3] = new SingleBlock(board_, new Point(2, 1));
            return blocks;
        }
        public override Figure RightRotation()
        {
            BlockTRotated90ToRight RotatedFigure = new BlockTRotated90ToRight(board);
            return RotatedFigure;
        }
        public override Figure LeftRotation()
        {
            BlockTRotated270ToRight RotatedFigure = new BlockTRotated270ToRight(board);
            return RotatedFigure;
        }
    }
    class BlockTRotated90ToRight : BlockT
    {
        public BlockTRotated90ToRight(Board board):base(board)
        {
        }
        public override SingleBlock[] SetBlocks(Board board_)
        {
            SingleBlock[] blocks = new SingleBlock[4];
            blocks[0] = new SingleBlock(board_, new Point(0, 1));
            blocks[1] = new SingleBlock(board_, new Point(1, 1));
            blocks[2] = new SingleBlock(board_, new Point(1, 0));
            blocks[3] = new SingleBlock(board_, new Point(2, 1));
            return blocks;
        }
        public override Figure RightRotation()
        {
            BlockTRotated180ToRight RotatedFigure = new BlockTRotated180ToRight(board);
            return RotatedFigure;
        }
        public override Figure LeftRotation()
        {
            BlockT RotatedFigure = new BlockT(board);
            return RotatedFigure;
        }
    }
    class BlockTRotated180ToRight : BlockT
    { 
        public BlockTRotated180ToRight(Board board):base(board)
        {
        }
        public override SingleBlock[] SetBlocks(Board board_)
        {
            SingleBlock[] blocks = new SingleBlock[4];
            blocks[0] = new SingleBlock(board_, new Point(2, 0));
            blocks[1] = new SingleBlock(board_, new Point(2, 1));
            blocks[2] = new SingleBlock(board_, new Point(2, 2));
            blocks[3] = new SingleBlock(board_, new Point(1, 1));
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
        public BlockTRotated270ToRight(Board board):base(board)
        {
        }
        public override SingleBlock[] SetBlocks(Board board_)
        {
            SingleBlock[] blocks = new SingleBlock[4];
            blocks[0] = new SingleBlock(board_, new Point(0, 1));
            blocks[1] = new SingleBlock(board_, new Point(1, 1));
            blocks[2] = new SingleBlock(board_, new Point(1, 2));
            blocks[3] = new SingleBlock(board_, new Point(2, 1));
            return blocks;
        }
        public override Figure RightRotation()
        {
            BlockJ RotatedFigure = new BlockJ(board);
            return RotatedFigure;
        }
        public override Figure LeftRotation()
        {
            BlockJRotated180ToRight RotatedFigure = new BlockJRotated180ToRight(board);
            return RotatedFigure;
        }
    }
}
