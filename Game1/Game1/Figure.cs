using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Game1
{
    abstract class Figure
    {
        public bool[,] blockArray = new bool[4, 4]
        {
            {false,false,false,false },
            {false,false,false,false },
            {false,false,false,false },
            {false,false,false,false }
        };

        public SingleBlock Block1 { get; set; }
        public SingleBlock Block2 { get; set; }
        public SingleBlock Block3 { get; set; }
        public SingleBlock Block4 { get; set; }
        /// <summary>
        /// Moves the figure to the left
        /// </summary>
        public void MoveLeft()
        {
            
        }
        /// <summary>
        ///  Moves the figure to the right
        /// </summary>
        public void MoveRight()
        {
        }
        //public void BlockMoveLeft()
        //{
        //    block1.posx--;
        //    Block2.Posx--;
        //    Block3.Posx--;
        //    Block4.Posx--;
        //}

        //public void BlockMoveRight()
        //{
        //    block1.posx++;
        //    Block2.Posx++;
        //    Block3.Posx++;
        //    Block4.Posx++;
        //}
        /// <summary>
        /// Obraca figure o 90 stopni w prawo
        /// </summary>
        public Figure RightRotation()
        {
            return this;
        }  
        /// <summary>
        /// Obraca figure o 90 stopni w prawo
        /// </summary>
        public Figure LeftRotation()
        {
            return this;
        }
        /// <summary>
        /// Chcks if the figure can be rotated
        /// </summary>
        /// <returns></returns>
        public bool CanBeRotated() {
            Figure next_pos ;
            return true;
        }


    }
}
