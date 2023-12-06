
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

public class SuperTieBreak : Set {
    int scoreOp1;
    int scoreOp2;
    
    public SuperTieBreak()
    {
        scoreOp1 = 0;
        scoreOp2 = 0;
    }
   
    Random rnd = new Random();
    public int Play() {
        do
        {
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
        if (scoreOp1 == 10 && scoreOp2 < 9)
        {

            return 1;
        }
        else if (scoreOp1 < 9 && scoreOp2 == 10)
        {

            return 2;
        }
        while (scoreOp1 > scoreOp2 + 1 && scoreOp1 < scoreOp2 + 1)
        {
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
        if (scoreOp1 > scoreOp2)
        {
            scoreOp1++;
            return 1;
        }
        else
        {
            scoreOp2++;
            return 2;
        }

    }

}

}