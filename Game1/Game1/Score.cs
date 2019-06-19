using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    class Score
    {
        private int score = 0;

        public int getScore()
        {
            return score;
        }

        public void addScore(int _lines) {
        
            addPoints(_lines);
         }
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
