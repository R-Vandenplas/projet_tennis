
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

public class Schedule {

    

    private ScheduleType Type;

    private int actualRound;
    private Tournament tournament;
    private Queue<Opponent> opponentsW;
    public ScheduleType GetScheduleType()
    {
        return Type;
    }

    public Schedule(ScheduleType type, Tournament tournament)
    {
        Type = type;
        this.actualRound = 0;
        this.tournament = tournament;
    }

    public void NbWinningSets() {
        // TODO implement here
    }

    public void PlayNextRound() {
        for (int i = 0; i <(64/2^actualRound); i++)
        {
            Opponent opponent1 = opponentsW.Dequeue();
            Opponent opponent2 = opponentsW.Dequeue();
            Referee referee = Referee.Available();
            Court court = Court.Available();
            Match match = new Match(actualRound,referee,court,opponent1, opponent2,this);
            match.Play();
            referee.Release();
            court.Release();
            opponentsW.Enqueue(match.GetWinner());
        }

    }

    


    public Opponent GetWinner() {
        if(opponentsW.Count == 1)
        {
            return opponentsW.Dequeue();
        }
        else
        {
            return null;
        }
        
        
    }

}