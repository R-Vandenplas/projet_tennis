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

        Random rnd = new Random();
        // <------- getters and setters -------->

        public int ScoreOp1
        {
            get { return scoreOp1; }
        }
        public int ScoreOp2
        {
            get { return scoreOp2; }
        }
        // <------- constructors -------->
        public Game(Set set)
        {
            scoreOp1 = 0;
            scoreOp2 = 0;
            this.set = set; 
        }
      // <------- methods -------->
        public int Play()
        {
            // this.set.Match.Duration += new TimeSpan(0, 0, 20); is use to simulate the time of a game by adding 20 seconds per point
            // play a point until one of the player reach 30 points
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
            // if the player who reach 30 points win this point he goes to 40 points 
            // if the player who reach 30 points lose this point the other player gain 15 points 
            // until one of the player reach 40 points or the two players have 30 points
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
            // if the two players have 30 points and one of them win the point he goes to 40 points
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
            // if one of the player reach 40 points and the other has less than 40 points if he win this point he win the game
            // if the other player win this point gain 10 points or 15 points if he has less than 30 points
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
            // if the two players have 40 points and one of them win the point he goes to avantage
            // then if the player who has avantage win the point he win the game
            // if the player who has avantage lose the point the two players go back to 40 points
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
