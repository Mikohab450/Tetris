using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Game1
{
    class BlockI : Figure
    {
        public BlockI()//int x, int y, Color color)
        {
            blockArray[0, 1] = true;
            blockArray[1, 1] = true;
            blockArray[2, 1] = true;
            blockArray[3, 1] = true;
            //Block1.posx = x;
            //Block1.posy = y;
            //Block1.color = color;

            //Block2.posx = x + 1;
            //Block2.posy = y;
            //Block2.color = color;

            //Block3.posx = x + 2;
            //Block3.posy = y;
            //Block3.color = color;

            //Block4.posx = x - 1;
            //Block4.posy = y;
            //Block4.color = color;
        }
        public override Figure RightRotation()
        {
            BlockIRotated RotatedFigure= new BlockIRotated();
            return RotatedFigure;
        }
        public override Figure LeftRotation()
        {
            return RightRotation();     //left and right rotation are the same
        }
    }
    class BlockIRotated : BlockI
    { 
        public BlockIRotated()
        {
            blockArray[1, 0] = true;
            blockArray[1, 1] = true;
            blockArray[1, 2] = true;
            blockArray[1, 3] = true;
        }
        public override Figure RightRotation()
        {
            BlockI RotatedFigure = new BlockI();
            return RotatedFigure;
        }
        public override Figure LeftRotation()
        {
            return RightRotation();     //left and right rotation are the same
        }
    }
}
