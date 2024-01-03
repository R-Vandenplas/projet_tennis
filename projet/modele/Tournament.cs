
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using DAO;

public class Tournament {

    
    private int idTournament;
    private string name;
 
    List<Player> playerMaleList = new List<Player>();
    List<Player> playerFemaleList = new List<Player>();
    List<Schedule> schedules = new List<Schedule>();
    DateTime  date = DateTime.Now;

    public string Name
    {
        get
        {
            return name;
        }
    }
    public int IdTournament
    {
        get
        {
            return idTournament;
        }
    }

    public Tournament(int idTournament, string name) {
        this.idTournament = idTournament;
        this.name = name;

        
    }
    public List<Schedule> Schedules
    {
        get
        {
            return schedules;
        }
    }

    public DateTime Date {
        get
        {
            return date;
        }
        set
        {
            date = value;
        }
       }

    public void Play()
    {
        ChargePlayers();
        Referee.ChargeReferees();
        Court.ChargeCourts();
        Schedule scheduleLadiesDouble = new Schedule(ScheduleType.LadiesDouble, this,GetOpponentsLadiesDouble());
        Schedule scheduleLadiesSingle = new Schedule(ScheduleType.LadiesSingle, this,GetOpponentsLadiesSingle());
        Schedule scheduleGentlemenDouble = new Schedule(ScheduleType.GentlemenDouble, this,GetOpponentsGentlemenDouble());
        Schedule scheduleGentlemenSingle = new Schedule(ScheduleType.GentlemenSingle, this, GetOpponentsGentlemenSingle());
        Schedule scheduleMixedDouble = new Schedule(ScheduleType.MixedDouble, this, GetOpponentsMixedDouble());
        schedules.AddRange(new List<Schedule> { scheduleLadiesDouble, scheduleLadiesSingle, scheduleGentlemenDouble, scheduleGentlemenSingle, scheduleMixedDouble });
        
        for (int i = 0; i < 6; i++)
        {
            scheduleLadiesDouble.PlayNextRound();
            scheduleMixedDouble.PlayNextRound();
            scheduleGentlemenDouble.PlayNextRound();
            scheduleGentlemenSingle.PlayNextRound();
            scheduleLadiesSingle.PlayNextRound();
            this.date = Court.GetDateEndRound();
        }
        scheduleGentlemenSingle.PlayNextRound();
        scheduleLadiesSingle.PlayNextRound();
        this.date = Court.GetDateEndRound();
        

    }
    public void Play(ScheduleType scheduleType)
    {
        ChargePlayers();
        Referee.ChargeReferees();
        Court.ChargeCourts();
        Schedule schedule = new Schedule(scheduleType, this, GetOpponents(scheduleType));
        schedules.Add(schedule);
        do
        {
            schedule.PlayNextRound();
            this.date = Court.GetDateEndRound();

        }while(schedule.GetWinner() == null);
        

    }
    private Queue<Opponent> GetOpponents(ScheduleType scheduleType)
    {
        Queue<Opponent> opponents = new Queue<Opponent>();
        switch (scheduleType)
        {
            case ScheduleType.LadiesDouble:
                opponents = GetOpponentsLadiesDouble();
                break;
            case ScheduleType.LadiesSingle:
                opponents = GetOpponentsLadiesSingle();
                break;
            case ScheduleType.GentlemenDouble:
                opponents = GetOpponentsGentlemenDouble();
                break;
            case ScheduleType.GentlemenSingle:
                opponents = GetOpponentsGentlemenSingle();
                break;
            case ScheduleType.MixedDouble:
                opponents = GetOpponentsMixedDouble();
                break;
        }
        return opponents;
    }
    private Queue<Opponent> GetOpponentsLadiesDouble()
    {
        Queue<Opponent> opponents = new Queue<Opponent>();
        for (int i = 0; i < 128; i++)
        {
            Opponent opponent = new Opponent(playerFemaleList[i], playerFemaleList[++i]);
            opponents.Enqueue(opponent);
        }
        return opponents;
    }
    private Queue<Opponent> GetOpponentsLadiesSingle()
    {
        Queue<Opponent> opponents = new Queue<Opponent>();
        for (int i = 0; i < 128; i++)
        {
            Opponent opponent = new Opponent(playerFemaleList[i]);
            opponents.Enqueue(opponent);
        }
        return opponents;
    }
    private Queue<Opponent> GetOpponentsGentlemenDouble()
    {
        Queue<Opponent> opponents = new Queue<Opponent>();
        for (int i = 0; i < 128; i++)
        {
            Opponent opponent = new Opponent(playerMaleList[i], playerMaleList[++i]);
            opponents.Enqueue(opponent);
        }
        return opponents;
    }
    private Queue<Opponent> GetOpponentsGentlemenSingle()
    {
        Queue<Opponent> opponents = new Queue<Opponent>();
        for (int i = 0; i < 128; i++)
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

    public void ChargePlayers()
    {
        DAO<Player> daoPlayer = SQLFactory.GetPlayerDAO();
        List<Player> playerList = daoPlayer.FindAll();
        playerList.ForEach(player =>
        {
            if (player.Gender == "Male")
            {
                playerMaleList.Add(player);
            }
            else
            {
                playerFemaleList.Add(player);
            }
        });
       
    }
}