
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

public class SuperTieBreak : Set {
    int scoreOp1;
    int scoreOp2;
    Match match;

    Random rnd = new Random();

    // <------ constructors ------>
    public SuperTieBreak(Match match):base(match)
    {
        
    }
   
    //<------ methods ------>
    public int Play() {
        //play a game until one of the players has 10 points
        do
        {
            this.Match.Duration += new TimeSpan(0, 0, 20);
            int winner = rnd.Next(0, 2);
            if (winner == 0)
            {
                scoreOp1 += 1;
            }
            else
            {
                scoreOp2 += 1;
            }
        }
        while (scoreOp1 < 10 && scoreOp2 < 10);
        //if one of the players has 10 points and the other has less than 9 points, the player with 10 points wins the set
        if (scoreOp1 == 10 && scoreOp2 < 9)
        {

            return 1;
        }
        else if (scoreOp1 < 9 && scoreOp2 == 10)
        {

            return 2;
        }
        //if one player have 10 points and the other one have 9 or 10, the game continues until one of the players has 2 points more than the other
        while (scoreOp1 > scoreOp2 + 1 && scoreOp1 < scoreOp2 + 1)
        {
            this.Match.Duration += new TimeSpan(0, 0, 20);
            int winner = rnd.Next(0, 2);
            if (winner == 0)
            {
                scoreOp1 += 1;
            }
            else
            {
                scoreOp2 += 1;
            }
        }
        //the player with 2 points more than the other wins the set
        if (scoreOp1 > scoreOp2)
        {
            
            return 1;
        }
        else
        {
            
            return 2;
        }

    }

}

