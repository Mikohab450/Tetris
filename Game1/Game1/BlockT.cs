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
        public BlockT()//int x, int y, Color color)
        {
            blockArray[1, 0] = true;
            blockArray[0, 1] = true;
            blockArray[1, 2] = true;
            blockArray[1, 1] = true;
            //Block1.posx = x;
            //Block1.posy = y;
            //Block1.color = color;

            //Block2.posx = x - 1;
            //Block2.posy = y + 1;
            //Block2.color = color;

            //Block3.posx = x;
            //Block3.posy = y + 1;
            //Block3.color = color;

            //Block4.posx = x + 1;
            //Block4.posy = y + 1;
            //Block4.color = color;
        }
        public override Figure RightRotation()
        {
            BlockTRotated90ToRight RotatedFigure = new BlockTRotated90ToRight();
            return RotatedFigure;
        }
        public override Figure LeftRotation()
        {
            BlockTRotated270ToRight RotatedFigure = new BlockTRotated270ToRight();
            return RotatedFigure;
        }
    }
    class BlockTRotated90ToRight : BlockT
    {
        public BlockTRotated90ToRight()
        {
            blockArray[0, 1] = true;
            blockArray[1, 1] = true;
            blockArray[1, 2] = true;
            blockArray[2, 1] = true;
        }
        public override Figure RightRotation()
        {
            BlockTRotated180ToRight RotatedFigure = new BlockTRotated180ToRight();
            return RotatedFigure;
        }
        public override Figure LeftRotation()
        {
            BlockT RotatedFigure = new BlockT();
            return RotatedFigure;
        }
    }
    class BlockTRotated180ToRight : BlockT
    { 
        public BlockTRotated180ToRight()
        {
            blockArray[1, 0] = true;
            blockArray[1, 1] = true;
            blockArray[1, 2] = true;
            blockArray[2, 1] = true;
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
        public BlockTRotated270ToRight()
        {
            blockArray[0, 1] = true;
            blockArray[1, 1] = true;
            blockArray[2, 1] = true;
            blockArray[1, 0] = true;
        }
        public override Figure RightRotation()
        {
            BlockJ RotatedFigure = new BlockJ();
            return RotatedFigure;
        }
        public override Figure LeftRotation()
        {
            BlockJRotated180ToRight RotatedFigure = new BlockJRotated180ToRight();
            return RotatedFigure;
        }
    }
}
