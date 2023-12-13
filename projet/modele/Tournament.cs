
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Tournament {

    public Tournament() {

    }
    List<Player> playerMaleList;
    List<Player> playerFemaleList;
    private string name;


    private void Play()
    {
        Schedule scheduleLadiesDouble = new Schedule(ScheduleType.LadiesDouble, this,GetOpponentsLadiesDouble());
        Schedule scheduleLadiesSingle = new Schedule(ScheduleType.LadiesSingle, this,GetOpponentsLadiesSingle());
        Schedule scheduleGentlemenDouble = new Schedule(ScheduleType.GentlemenDouble, this,GetOpponentsGentlemenDouble());
        Schedule scheduleGentlemenSingle = new Schedule(ScheduleType.GentlemenSingle, this, GetOpponentsGentlemenSingle());
        Schedule scheduleMixedDouble = new Schedule(ScheduleType.MixedDouble, this, GetOpponentsMixedDouble());
        scheduleGentlemenSingle.PlayNextRound();
        scheduleLadiesSingle.PlayNextRound();
        while(scheduleLadiesSingle.GetWinner() == null)
        {
            scheduleLadiesDouble.PlayNextRound();
            scheduleLadiesSingle.PlayNextRound();
            scheduleGentlemenDouble.PlayNextRound();
            scheduleGentlemenSingle.PlayNextRound();
            scheduleMixedDouble.PlayNextRound();
        }
    }
    private Queue<Opponent> GetOpponentsLadiesDouble()
    {
        Queue<Opponent> opponents = new Queue<Opponent>();
        for (int i = 0; i < 64; i++)
        {
            Opponent opponent = new Opponent(playerFemaleList[i], playerFemaleList[++i]);
            opponents.Enqueue(opponent);
        }
        return opponents;
    }
    private Queue<Opponent> GetOpponentsLadiesSingle()
    {
        Queue<Opponent> opponents = new Queue<Opponent>();
        for (int i = 0; i < 64; i++)
        {
            Opponent opponent = new Opponent(playerFemaleList[i]);
            opponents.Enqueue(opponent);
        }
        return opponents;
    }
    private Queue<Opponent> GetOpponentsGentlemenDouble()
    {
        Queue<Opponent> opponents = new Queue<Opponent>();
        for (int i = 0; i < 64; i++)
        {
            Opponent opponent = new Opponent(playerMaleList[i], playerMaleList[++i]);
            opponents.Enqueue(opponent);
        }
        return opponents;
    }
    private Queue<Opponent> GetOpponentsGentlemenSingle()
    {
        Queue<Opponent> opponents = new Queue<Opponent>();
        for (int i = 0; i < 64; i++)
        {
            Opponent opponent = new Opponent(playerMaleList[i]);
            opponents.Enqueue(opponent);
        }
        return opponents;
    }
    private Queue<Opponent> GetOpponentsMixedDouble()
    {
        Queue<Opponent> opponents = new Queue<Opponent>();
        for (int i = 0; i < 64; i++)
        {
            Opponent opponent = new Opponent(playerFemaleList[i], playerMaleList[i]);
            opponents.Enqueue(opponent);
        }
        return opponents;
    }

}