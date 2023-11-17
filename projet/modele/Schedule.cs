
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Schedule {

    

    private ScheduleType Type;

    private int actualRound;
    private Tournament tournament;

    public Schedule(ScheduleType type, int actualRound, Tournament tournament)
    {
        Type = type;
        this.actualRound = actualRound;
        this.tournament = tournament;
    }

    public void NbWinningSets() {
        // TODO implement here
    }

    public void PlayNextRound() {
        // TODO implement here
    }

    public void GetWinner() {
        // TODO implement here
    }

}