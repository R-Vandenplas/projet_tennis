
using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

public class Schedule {

    private ScheduleType type;
    private int idSchedule;
    private int actualRound;
    private Tournament tournament;
    private Queue<Opponent> opponents;
    private Stack<Opponent> opponentsStanding = new Stack<Opponent>();

    private Opponent winner = null;
    
    DAO<Schedule> scheduleDAO = SQLFactory.GetScheduleDAO();

    public int IdSchedule
    {
        get
        {
            return idSchedule;
        }
        set
        {
            idSchedule = value;
        }
    }
    public Tournament Tournament
    {
        get
        {
            return tournament;
        }
    }
    public ScheduleType Type
    {
        get
        {
            return type;
        }
        
    }
    

    public Schedule(ScheduleType type, Tournament tournament,Queue<Opponent> opponents)
    {
        this.type = type;
        this.actualRound = 1;
        this.tournament = tournament;
        this.opponents = opponents;
        bool creation_verifications =  scheduleDAO.Create(this);
        if (!creation_verifications)
        {
            throw new Exception("Schedule creation failed");
        }
    }


    public void PlayNextRound() {
        if (type < ScheduleType.GentlemenDouble)
        {
            Console.WriteLine("debut d'un round simple");
            for (int i = 0; i < (64 / ((int)Math.Pow(2,(actualRound - 1)))); i++)
            {

                Opponent opponent1 = opponents.Dequeue();
                Opponent opponent2 = opponents.Dequeue();
                Referee referee = Referee.Available();
                Court court = Court.Available();
                Match match = new Match(actualRound, referee, court, opponent1, opponent2, this);
                match.Play();
                referee.Release();
                court.Release(match.Duration);
                opponents.Enqueue(match.Winner);
                opponentsStanding.Push(match.Loser);
            }
        }
        else
        {
            Console.WriteLine("debut d'un round double");               
            for (int i = 0; i < (32 / ((int)Math.Pow(2, (actualRound - 1)))); i++)
            {
                Opponent opponent1 = opponents.Dequeue();
                Opponent opponent2 = opponents.Dequeue();
                Referee referee = Referee.Available();
                Court court = Court.Available();
                Match match = new Match(actualRound, referee, court, opponent1, opponent2, this);
                match.Play();
                referee.Release();
                court.Release(match.Duration);
                opponents.Enqueue(match.Winner);
            }
        }
        
        Console.WriteLine($"fin du round : {actualRound}");
        
        actualRound++;
        

    }
   

    


    public Opponent GetWinner() {
        if(opponents.Count == 1)
        {
            this.winner= opponents.Dequeue();
        }
        return this.winner;
        
        
    }

}