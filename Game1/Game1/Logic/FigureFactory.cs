using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    class FigureFactory
    {
        private Figure newFigure;
        private LinkedList<Figure> Figury;
        Dictionary<int,Color> ColorMap = new Dictionary<int, Color> { { 0, Color.Blue }, {1,Color.Crimson } ,{2,Color.Orange }, {3,Color.White },
            {4, Color.Yellow }, {5,Color.DeepPink }, {6,Color.Green }, {7,Color.LightBlue } ,{8,Color.Purple }, {9,Color.DarkCyan} };
        private int[] set;
        private Random rnd;
        private Board board;


        

        public FigureFactory(Board board)
        {
            set = new int[7];
            for (int i = 0; i < 7; i++)
                set[i] = i;
            Figury = new LinkedList<Figure>();
            rnd = new Random();
            this.board = board;
      

        }
        /// <summary>
        /// Genrates list of a random permutation of 14-element set of figures
        /// </summary>
        private void GenerateSequenceOfFigures()
        {
            for (int i = 0; i < 7; i++)
            {
                int random_index = rnd.Next(0, 6 - i);
                int random_color_index = rnd.Next(0,9-i);
                  Color temp = ColorMap[random_color_index];
                 switch (set[random_index])
                {
                     
                    case 0:
                        Figury.AddFirst(new BlockI(board,temp));
                        break;
                    case 1:
                        Figury.AddFirst(new BlockL(board,temp));
                        break;
                    case 2:
                        Figury.AddFirst(new BlockJ(board,temp));
                        break;
                    case 3:
                        Figury.AddFirst(new BlockS(board,temp));
                        break;
                    case 4:
                        Figury.AddFirst(new BlockZ(board,temp));
                        break;
                    case 5:
                        Figury.AddFirst(new BlockO(board,temp));
                        break;
                    default:
                        Figury.AddFirst(new BlockT(board,temp));
                        break;
                }

                ColorMap[random_color_index] = ColorMap[9 - i];
                ColorMap[9 - i]= temp;
                int swap = set[random_index];
                set[random_index] = set[6 - i];
                set[6 - i] = swap;
            }
        }
        /// <summary>
        /// Generates a randomly generated figure
        /// </summary>
        /// <returns>Randomly generated figure</returns>
        public Figure GetFigure()
        {
            if (Figury.Count()==0)//!Figury.Any())
            {
                GenerateSequenceOfFigures();
            }
            newFigure = Figury.First();
            Figury.RemoveFirst();
            return newFigure;
        }
    }
}
