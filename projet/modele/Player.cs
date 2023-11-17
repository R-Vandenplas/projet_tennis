
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Player : Person {
    private int rank;
    private string gender;

    public Player(string firstname, string lastname, string nationality,int rank,string gender) : base(firstname, lastname, nationality)
    {
        this.rank=rank;
        this.gender = gender;
    }
}