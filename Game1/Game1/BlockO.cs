using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Game1
{
    class BlockO : Figure
    {
        public BlockO()//int x, int y, Color color)
        {
            blockArray[1, 1] = true;
            blockArray[1, 2] = true;
            blockArray[2, 1] = true;
            blockArray[2, 2] = true;
            //block1.posx = x;
            //block1.posy = y;
            //block1.color = color;
            //Block2.posx = x+1;
            //Block2.posy = y;
            //Block2.color = color;

            //Block3.posx = x;
            //Block3.posy = y+1;
            //Block3.color = color;

            //Block4.posx = x+1;
            //Block4.posy = y+1;
            //Block4.color = color;
        }
        /// <summary>
        /// Rotation of this block doesn't change anything
        /// </summary>
        /// <returns>The same block</returns>
        public override Figure RightRotation()
        {
            return this;
        }
        public override Figure LeftRotation()
        {
  
            return this;
        }
    }
  
}
