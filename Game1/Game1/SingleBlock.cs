using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Game1
{
    public class SingleBlock : Game
    {
        public SingleBlock(int x, int y, Color _color)
        {
            this.posx = x;
            this.posy = y;
            this.color = _color;
        }
        public int posx { get; set; }
        public int posy { get; set; }
        public Color color { get; set; }
    }
}
