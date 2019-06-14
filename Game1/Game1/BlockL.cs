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
        public BlockL()//int x, int y, Color color)
        {
            blockArray[0, 1] = true;
            blockArray[1, 1] = true;
            blockArray[2, 1] = true;
            blockArray[2, 2] = true;

            //Block1.posx = x;
            //Block1.posy = y;
            //Block1.color = color;

            //Block2.posx = x + 1;
            //Block2.posy = y;
            //Block2.color = color;

            //Block3.posx = x + 2;
            //Block3.posy = y;
            //Block3.color = color;

            //Block4.posx = x;
            //Block4.posy = y + 1;
            //Block4.color = color;
        }
        public override Figure RightRotation()
        {
            BlockLRotated90ToRight RotatedFigure = new BlockLRotated90ToRight();
            return RotatedFigure;
        }
        public override Figure LeftRotation()
        {
            BlockLRotated270ToRight RotatedFigure = new BlockLRotated270ToRight();
            return RotatedFigure;
        }
    }
    class BlockLRotated90ToRight : BlockL
    {
        public BlockLRotated90ToRight()
        {
            blockArray[1, 1] = true;
            blockArray[1, 2] = true;
            blockArray[1, 3] = true;
            blockArray[2, 1] = true;
        }
        public override Figure RightRotation()
        {
            BlockLRotated180ToRight RotatedFigure = new BlockLRotated180ToRight();
            return RotatedFigure;
        }
        public override Figure LeftRotation()
        {
            BlockL RotatedFigure = new BlockL();
            return RotatedFigure;
        }
    }
    class BlockLRotated180ToRight : BlockL
    {
        public BlockLRotated180ToRight()
        {
            blockArray[3, 2] = true;
            blockArray[1, 1] = true;
            blockArray[1, 2] = true;
            blockArray[2, 2] = true;
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
        public BlockLRotated270ToRight()
        {
            blockArray[1, 2] = true;
            blockArray[2, 0] = true;
            blockArray[2, 1] = true;
            blockArray[2, 2] = true;
        }
        public override Figure RightRotation()
        {
            BlockL RotatedFigure = new BlockL();
            return RotatedFigure;
        }
        public override Figure LeftRotation()
        {
            BlockLRotated180ToRight RotatedFigure = new BlockLRotated180ToRight();
            return RotatedFigure;
        }
    }


}
