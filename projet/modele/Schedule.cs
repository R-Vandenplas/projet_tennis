
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

public class Schedule {

    

    private ScheduleType Type;

    private int actualRound;
    private Tournament tournament;
    private Queue<Opponent> opponents;
    public ScheduleType GetScheduleType()
    {
        return Type;
    }

    public Schedule(ScheduleType type, Tournament tournament,Queue<Opponent> opponents)
    {
        Type = type;
        this.actualRound = 0;
        this.tournament = tournament;
        this.opponents = opponents;
    }


    public void PlayNextRound() {
        for (int i = 0; i <(64/2^actualRound); i++)
        {
            Opponent opponent1 = opponents.Dequeue();
            Opponent opponent2 = opponents.Dequeue();
            Referee referee = Referee.Available();
            Court court = Court.Available();
            Match match = new Match(actualRound,referee,court,opponent1, opponent2,this);
            match.Play();
            referee.Release();
            court.Release();
            opponents.Enqueue(match.GetWinner());
        }

    }

    


    public Opponent GetWinner() {
        if(opponents.Count == 1)
        {
            return opponents.Dequeue();
        }
        else
        {
            return null;
        }
        
        
    }

}