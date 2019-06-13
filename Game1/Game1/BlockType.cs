using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Game1
{
    class BlockType
    {
        public SingleBlock block1 { get; set; }
        public SingleBlock block2 { get; set; }
        public SingleBlock block3 { get; set; }
        public SingleBlock block4 { get; set; }

        public BlockType()
        {
            block1 = new SingleBlock(0,0,Color.Blue);
        }

        public void BlockMoveLeft()
        {
            block1.posx--;
            block2.posx--;
            block3.posx--;
            block4.posx--;
        }

        public void BlockMoveRight()
        {
            block1.posx++;
            block2.posx++;
            block3.posx++;
            block4.posx++;
        }

        public void BlockRotate()
        {

        }

    }
}
