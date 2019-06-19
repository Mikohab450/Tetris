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
        private Figure[] set =new Figure[7];
 
        Random rnd;
      

        public FigureFactory(Board board)
        {
           Figury = new List<Figure>();
            rnd = new Random();
            set[0] = new BlockI(board);
            set[1] = new BlockO(board);
            set[2] = new BlockJ(board);
            set[3] = new BlockL(board);
            set[4] = new BlockS(board);
            set[5] = new BlockZ(board);
            set[6] = new BlockT(board);

        }
        /// <summary>
        /// Genrates list of a random permutation of 7-element set of figures
        /// </summary>
        private void GenerateSequenceOfFigures()
        {
            for(int i=0; i<7; i++)
            {
                int random_index = rnd.Next(0, 6-i);
                Figury.Add(set[random_index]);
                Figury[i].SetColor();
                Figure temp = set[random_index];
                set[random_index] = set[6 - i];
                set[6 - i] = temp;
;            }
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
