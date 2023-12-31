using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projet.modele
{
    internal class Game
    {
        private int scoreOp1;
        private int scoreOp2;
        Set set;
        public Game(Set set)
        {
            scoreOp1 = 0;
            scoreOp2 = 0;
            this.set = set; 
        }
        public int ScoreOp1 { 
            get { return scoreOp1; }
        }
        public int ScoreOp2
        {
            get { return scoreOp2; } 
        }
        Random rnd = new Random();
        public int Play()
        {
            do
            {
                this.set.Match.Duration += new TimeSpan(0, 0, 20);
                int winner = rnd.Next(0, 2);
                if (winner == 0)
                {
                    scoreOp1 += 15;
                }
                else
                {
                    scoreOp2 += 15;
                }
                
            }
            while (scoreOp1 < 30 && scoreOp2 < 30);
            while (scoreOp1 == 30 && scoreOp2 < 30)
            {
                this.set.Match.Duration += new TimeSpan(0, 0, 20);
                int winner = rnd.Next(0, 2);
                if (winner == 0)
                {
                    scoreOp1 += 10;
                }
                else
                {
                    scoreOp2 += 15;
                }
                
            }
            while (scoreOp2 == 30 && scoreOp1 < 30)
            {
                this.set.Match.Duration += new TimeSpan(0, 0, 20);
                int winner = rnd.Next(0, 2);
                if (winner == 0)
                {
                    scoreOp1 += 15;
                }
                else
                {
                    scoreOp2 += 10;
                }
                
            }
            if(scoreOp1 ==30 && scoreOp2 == 30)
            {
                this.set.Match.Duration += new TimeSpan(0, 0, 20);
                int winner = rnd.Next(0, 2);
                if (winner == 0)
                {
                    scoreOp1 += 10;
                }
                else
                {
                    scoreOp2 += 10;
                }
                
            }
            while (scoreOp1 == 40 && scoreOp2 < 40)
            {
                this.set.Match.Duration += new TimeSpan(0, 0, 20);
                int winner = rnd.Next(0, 2);
                if (winner == 0)
                {
                    return 1;
                }
                else
                {
                    if (scoreOp2 < 30)
                    {
                        scoreOp2 += 15;
                    }
                    else
                    {
                        scoreOp2 += 10;
                    }
                }
                
            }
            while (scoreOp2 == 40 && scoreOp1 < 40)
            {
                this.set.Match.Duration += new TimeSpan(0, 0, 20);
                int winner = rnd.Next(0, 2);
                if (winner == 0)
                {
                    if (scoreOp1 < 30)
                    {
                        scoreOp1 += 15;
                    }
                    else
                    {
                        scoreOp1 += 10;
                    }
                }
                else
                {
                    return 2;
                }
            }
            int avantage = 0;
            while (scoreOp1 == 40 && scoreOp2 == 40)
            {
                this.set.Match.Duration += new TimeSpan(0, 0, 20);
                int winner = rnd.Next(0, 2);
                
                if (winner == 0)
                {
                    if(avantage == 1)
                    {
                        return 1;
                    }
                    else
                    {
                        avantage = 1;
                    }
                    
                }
                else
                {
                    if (avantage == 2)
                    {
                        return 2;
                    }
                    else
                    {
                        avantage = 2;
                    }
                    
                }
            }
            return 0;
        }
    }
}
