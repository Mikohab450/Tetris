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
        private List<Figure> Figury;
        private  Color[] ColorSet={
            Color.Blue, Color.Crimson ,Color.Cyan, Color.White,
            Color.Yellow, Color.Pink, Color.Green, Color.Teal ,Color.Purple, Color.Orange};

        private int[] set = new int[7] { 0, 1, 2, 3, 4, 5, 6 };
        private Random rnd;
        private Board board;

        

        public FigureFactory(Board board)
        {
            Figury = new List<Figure>();
            rnd = new Random();
            this.board = board;

        }
        /// <summary>
        /// Genrates list of a random permutation of 7-element set of figures
        /// </summary>
        private void GenerateSequenceOfFigures()
        {
            for (int i = 0; i < 7; i++)
            {
                int random_index = rnd.Next(0, 6 - i);
                int random_color_index = rnd.Next(0,8-i);
                Color temp = ColorSet[random_color_index];
                switch (set[random_index])
                {
                     
                    case 0:
                        Figury.Add(new BlockI(board,temp));
                        break;
                    case 1:
                        Figury.Add(new BlockL(board,temp));
                        break;
                    case 2:
                        Figury.Add(new BlockJ(board,temp));
                        break;
                    case 3:
                        Figury.Add(new BlockS(board,temp));
                        break;
                    case 4:
                        Figury.Add(new BlockZ(board,temp));
                        break;
                    case 5:
                        Figury.Add(new BlockO(board,temp));
                        break;
                    default:
                        Figury.Add(new BlockT(board,temp));
                        break;
                }

                ColorSet[random_color_index] = ColorSet[9 - i];
                ColorSet[9 - i]= temp;
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
            if (!Figury.Any())
            {
                GenerateSequenceOfFigures();
            }
            newFigure = Figury[0];
            Figury.RemoveAt(0);
            return newFigure;
        }
    }
}
