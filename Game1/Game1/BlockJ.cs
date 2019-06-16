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
        public BlockJ(Board board)//int x, int y, Color color)
        {
            blockArray[0, 2] = true;
            blockArray[1, 2] = true;
            blockArray[2, 2] = true;
            blockArray[2, 1] = true;
            //Block1.posx = x;
            //Block1.posy = y;
            //Block1.color = color;

            //Block2.posx = x - 1;
            //Block2.posy = y;
            //Block2.color = color;

            //Block3.posx = x + 1;
            //Block3.posy = y;
            //Block3.color = color;

            //Block4.posx = x - 1;
            //Block4.posy = y - 1;
            //Block4.color = color;
        }
        public override Figure RightRotation()
        {
            BlockJRotated90ToRight RotatedFigure = new BlockJRotated90ToRight(board);
            return RotatedFigure;
        }
        public override Figure LeftRotation()
        {
            BlockJRotated270ToRight RotatedFigure = new BlockJRotated270ToRight(board);
            return RotatedFigure;     
        }
    }
    class BlockJRotated90ToRight : BlockJ
    {
        public BlockJRotated90ToRight(Board board_):base(board_)
        {
            blockArray[1, 1] = true;
            blockArray[2, 2] = true;
            blockArray[2, 3] = true;
            blockArray[2, 1] = true;
        }
        public override Figure RightRotation()
        {
            BlockJRotated180ToRight RotatedFigure = new BlockJRotated180ToRight(board);
            return RotatedFigure;
        }
        public override Figure LeftRotation()
        {
            BlockJ RotatedFigure = new BlockJ(board);
            return RotatedFigure;
        }
    }

    class BlockJRotated180ToRight : BlockJ
    {
        public BlockJRotated180ToRight(Board board_):base(board_)
        {
            blockArray[3, 1] = true;
            blockArray[2, 1] = true;
            blockArray[1, 1] = true;
            blockArray[1, 2] = true;
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
        public BlockJRotated270ToRight(Board board_):base(board_)
        {
            blockArray[1, 0] = true;
            blockArray[1, 1] = true;
            blockArray[1, 2] = true;
            blockArray[2, 2] = true;
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

