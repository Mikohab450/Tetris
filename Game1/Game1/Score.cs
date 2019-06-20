using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    class Score
    {
        static private int score = 0;

        /// <summary>
        /// Returns current score 
        /// </summary>
        static public int getScore()
        {
            return score;
        }
        /// <summary>
        /// Sets current score to 0
        /// </summary>
        public void ClearScore()
        {
            score = 0;
        }

        /// <summary>
        /// Add certain amount of points depending on count of erased lines
        /// </summary>
        ///    /// <param name="_lines">Provides amount of erased lines.</param>
        public void addScore(int _lines) {
        
            addPoints(_lines);
         }

        /// <summary>
        /// Calculates amount of poinds that should be added depending on count of lines
        /// </summary>
        private void addPoints(int _lines)
        {
            switch (_lines)
            {
                case 1: score += 40;
                    break;
                case 2: score += 100;
                    break;
                case 3: score += 300;
                    break;
                case 4: score += 1200;
                    break;
            }
        }
    }
}
