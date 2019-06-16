﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Game1
{
    class BlockZ : Figure
    {
        public BlockZ(Board board)//int x, int y, Color color)
        {
            blockArray[0, 2] = true;
            blockArray[1, 2] = true;
            blockArray[1, 1] = true;
            blockArray[2, 1] = true;
            //Block1.posx = x;
            //Block1.posy = y;
            //Block1.color = color;

            //Block2.posx = x + 1;
            //Block2.posy = y;
            //Block2.color = color;

            //Block3.posx = x + 1;
            //Block3.posy = y + 1;
            //Block3.color = color;

            //Block4.posx = x + 2;
            //Block4.posy = y + 1;
            //Block4.color = color;
        }
        public override Figure RightRotation()
        {
            BlockZRotated90ToRight RotatedFigure = new BlockZRotated90ToRight(board);
            return RotatedFigure;
        }
        public override Figure LeftRotation()
        {
            return RightRotation();             //left and right rotations are the same
        }
    }
    class BlockZRotated90ToRight : BlockZ
    {
        public BlockZRotated90ToRight(Board board):base(board)
        {
            blockArray[0, 0] = true;
            blockArray[0, 1] = true;
            blockArray[1, 2] = true;
            blockArray[1, 3] = true;
        }
        public override Figure RightRotation()
        {
            BlockZ RotatedFigure = new BlockZ(board);
            return RotatedFigure;
        }
        public override Figure LeftRotation()
        {
            return RightRotation();      //left and right rotations are the same
        }
    }
}
