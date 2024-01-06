
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

    Random rnd = new Random();
    // <------- getters and setters -------->
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
   // <------- constructors -------->
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

    // <------- methods -------->

    public int Play()
    {
        // play a game until one player has 6 points and the other has 4 or less or the score is 6-6
        do
        {
            Game game = new Game(this);
            int winner = game.Play();
            if (winner == 0)
            {
                throw new Exception("Game error");
            }
            if (winner == 1)
            {
                scoreOp1++;
            }
            else if (winner == 2)
            {
                scoreOp2++;
            }


        } while ((scoreOp1 < 6 || scoreOp2 < 5) && (scoreOp2 < 6 || scoreOp1 < 5) && !(scoreOp1 == 6 || scoreOp2 == 6));

        // if one player has 6 points and the other has 4 or less, the player with 6 points wins the set
        if (scoreOp1 == 6 && scoreOp2 < 5)
        {
            return 1;
        }
        // if the score is 6-5 play a game and if the player who has 6 points wins the game, he wins the set
        else if (scoreOp1 == 6 && scoreOp2 == 5)
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
        else if (scoreOp1 == 5 && scoreOp2 == 6)
        {
            Game game = new Game(this);
            int winner = game.Play();
            if (winner == 0)
            {
                scoreOp1++;
            }
            else
            {
                scoreOp2++;
                return 2;
            }
        }
        // if the set is not the last one and the score is 6-6 play a tie break
        
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
        // if the set is the last one and the score is 6-6 play a super tie break
        else if (scoreOp1 == 6 && scoreOp2 == 6 && LastSet)
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
        // play a point until one player has 7 points 
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
        // if one player has 7 points and the other has 5 or less, the player with 7 points wins the set
        if(scoreOp1 == 7 && scoreOp2 < 6)
        {
            
            return 1;
        }
        else if(scoreOp2 == 7 && scoreOp1 < 6)
        {
           
            return 2;
        }
        while(!(scoreOp1 > scoreOp2 + 1 || scoreOp2 > scoreOp1 + 1))
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
            
            return 1;
        }
        else
        {
            
            return 2;
        }
        
    }

}