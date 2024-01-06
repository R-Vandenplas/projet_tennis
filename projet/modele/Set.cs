
using projet.modele;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;

public class Set {
    public int idSet;
    private int scoreOp1;
    private int scoreOp2;

    private Match match;
    public bool LastSet;

    public int IdSet
    {
        get
        {
            return idSet;
        }
        set
        {
            idSet = value;
        }
    }
    public int ScoreOp1
    {
        get
        {
            return scoreOp1;
        }
    }
    public int ScoreOp2
    {
        get
        {
            return scoreOp2;
        }
    }
    public Match Match
    {
        get
        {
            return match;
        }
    }
    public Set( Match match ,bool isLastSet) {
        this.match = match;
        scoreOp1= 0;
        scoreOp2= 0;
        LastSet = isLastSet; 
    }
    public Set(Match match)
    {
        this.match = match;
        scoreOp1 = 0;
        scoreOp2 = 0;
        LastSet = false;
    }
    
    
    Random rnd = new Random();
    public int Play() {
        do
        {
            Game game = new Game(this);
            int winner = game.Play();
            if( winner == 0)
            {
                throw new Exception("Game error");
            }
            if (winner == 1)
            {
                scoreOp1 ++;
            }
            else if (winner == 2)
            {
                scoreOp2 ++ ;
            }
            
            
        } while((scoreOp1<6 || scoreOp2<5) && (scoreOp2<6 || scoreOp1<5) && !(scoreOp1 == 6 || scoreOp2 == 6));
        
        if (scoreOp1 == 6 && scoreOp2<5)
        {
            return 1;
        }
        else if(scoreOp1 ==6 && scoreOp2 == 5)
        {

            Game game = new Game(this);
            int winner = game.Play();
            if (winner == 0)
            {
                scoreOp1++;
                return 1;
            }
            else
            {
                scoreOp2++;
            }
        }
        if (scoreOp1 < 5 && scoreOp2 == 6)
        {
            return 2;
        }

        if (scoreOp1 == 6 && scoreOp2 == 6 && !LastSet)
        {
            int winner = TieBreak();
            if (winner == 0)
            {
                throw new Exception("TieBreak error");
            }
            if (winner == 1)
            {
                scoreOp1++;
            }
            else if (winner == 2)
            {
                scoreOp2++;
            }
            return winner;
        }
        else if(scoreOp1 == 6 && scoreOp2 == 6 && LastSet)
        {
            SuperTieBreak superTieBreak = new SuperTieBreak(this.match);
            int winner = superTieBreak.Play();
            if (winner == 0)
            {
                throw new Exception("SuperTieBreak error");
            }
            if (winner == 1)
            {
                scoreOp1++;
            }
            else if (winner == 2)
            {
                scoreOp2++;
            }
            return winner;
        }
        return 0;
    }
    private int TieBreak()
    {
        int scoreOp1 = 0;
        int scoreOp2 = 0;
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
        while (scoreOp1 < 7 && scoreOp2 < 7);
        if(scoreOp1 == 7 && scoreOp2 < 6)
        {
            
            return 1;
        }
        else if(scoreOp2 == 7 && scoreOp1 < 6)
        {
           
            return 2;
        }
        while(scoreOp1 > scoreOp2 + 1 && scoreOp2 > scoreOp1 + 1)
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
        if(scoreOp1 > scoreOp2)
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