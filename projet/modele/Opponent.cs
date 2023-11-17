
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Opponent {

    private Player player1;
    private Player? player2;

    public Opponent(Player player1)
    {
        this.player1 = player1;
        this.player2 = null;
    }
    public Opponent(Player player1, Player? player2)
    {
        this.player1 = player1;
        this.player2 = player2;
    }

}