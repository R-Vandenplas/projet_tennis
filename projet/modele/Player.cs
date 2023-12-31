
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Player : Person {
    private int idPlayer;
    private int rank;
    private string gender;
    
    public int IdPlayer
    {
        get
        {
            return idPlayer;
        }
        set
        {
            idPlayer = value;
        }
    }
    public int Rank
    {
        get
        {
            return rank;
        }
    }
    public string Gender
    {
        get 
        { 
            return gender; 
        }
    }

    public Player(int idPlayer, string firstname, string lastname, string nationality,int rank,string gender) : base(firstname, lastname, nationality)
    {
        this.idPlayer = idPlayer;
        this.rank=rank;
        this.gender = gender;
    }

    public override string ToString()
    {
        return $"{Firstname} {Lastname} from {Nationality}";
    }

}