
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Referee : Person {
    bool available;
    static Queue<Referee> referees;

    

    public Referee(string firstname, string lastname, string nationality) : base(firstname, lastname, nationality)
    {
    }

    public static Referee Available() {
        if(referees.Count > 0)
        {
            return referees.Dequeue();
        }
        else
        {
            return null;
        }
       
    }

    public void Release() {
       referees.Enqueue(this);
    }

}