
using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Opponent {

    private int idOpponent;
    private Player player1;
    private Player? player2;

    
    DAO<Opponent> opponentDAO = SQLFactory.GetOpponentDAO();
    public Player Player1 
    {
        get
        { 
            return player1; 
        }
    }
    public Player? Player2
    {
        get
        {
            return player2; 
        }
    }
    public int IdOpponent
    {
        get
        {
            return idOpponent;
        }
        set
        {
            idOpponent = value;
        }
    }

    


    public Opponent(Player player1)
    {
        this.player1 = player1;
        this.player2 = null;
        bool creation_verification =opponentDAO.Create(this);
        if (!creation_verification)
        {
            throw new Exception("Opponent creation failed");
        }
    }
    public Opponent(Player player1, Player? player2)
    {
        this.player1 = player1;
        this.player2 = player2;
        bool creation_verification = opponentDAO.Create(this);
        if (!creation_verification)
        {
            throw new Exception("Opponent creation failed");
        }
    }
    public override string ToString()
    {
        if(player2 == null)
        {
            return player1.ToString();
        }
        else
        {
            return $"{player1.ToString()} and {player2.ToString()}";
        }
    }

}