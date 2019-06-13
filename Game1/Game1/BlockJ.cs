using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Game1
{
    class BlockJ : BlockType
    {
        public BlockJ(int x, int y, Color color)
        {
            block1.posx = x;
            block1.posy = y;
            block1.color = color;

            block2.posx = x - 1;
            block2.posy = y;
            block2.color = color;

            block3.posx = x + 1;
            block3.posy = y;
            block3.color = color;

            block4.posx = x - 1;
            block4.posy = y - 1;
            block4.color = color;
        }
    }
}
