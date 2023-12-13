
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Court {

    

    private int nbSpectators;
    private bool covered;
    private Tournament tournament;
    private static Queue<Court> courts;

    public Court(int nbSpectators, bool covered, Tournament tournament)
    {
        this.nbSpectators = nbSpectators;
        this.covered = covered;
        this.tournament = tournament;
    }

    public static Court Available() {
        if(courts.Count > 0)
        {
            return courts.Dequeue();
        }
        else
        {
            return null;
        }


    }
    public void Release() {
        courts.Enqueue(this);
    }

}