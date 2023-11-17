
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Court {

    

    private int nbSpectators;
    private bool covered;
    private Tournament tournament;

    public Court(int nbSpectators, bool covered, Tournament tournament)
    {
        this.nbSpectators = nbSpectators;
        this.covered = covered;
        this.tournament = tournament;
    }

    public void Available() {
        // TODO implement here
    }

    public void Release() {
        // TODO implement here
    }

}