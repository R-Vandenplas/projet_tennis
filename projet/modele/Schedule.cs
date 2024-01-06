
using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

public class Schedule
{

    private ScheduleType type;
    private int idSchedule;
    private int actualRound;
    private Tournament tournament;
    private Queue<Opponent> opponents;
    private Stack<Opponent> opponentsStanding = new Stack<Opponent>();

    private Opponent winner = null;

    DAO<Schedule> scheduleDAO = SQLFactory.GetScheduleDAO();

    //<------- getters and setters --------->
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

    //<------- constructors --------->
    public Schedule(ScheduleType type, Tournament tournament, Queue<Opponent> opponents)
    {
        this.type = type;
        this.actualRound = 1;
        this.tournament = tournament;
        this.opponents = opponents;
        bool creation_verifications = scheduleDAO.Create(this);
        if (!creation_verifications)
        {
            throw new Exception("Schedule creation failed");
        }
    }

    //<------- methods --------->

    public void PlayNextRound()
    {
        //seperate the double and single schedule
        if (type < ScheduleType.GentlemenDouble)
        {
            // Single schedule
            // start a number of matchs equal to 64/2^(actualRound-1) so each round has half the matchs of the previous one
            for (int i = 0; i < (64 / ((int)Math.Pow(2, (actualRound - 1)))); i++)
            {

                Opponent opponent1 = opponents.Dequeue();
                Opponent opponent2 = opponents.Dequeue();
                Referee referee = Referee.Available();
                Court court = Court.Available();
                Match match = new Match(actualRound, referee, court, opponent1, opponent2, this);
                match.Play();
                referee.Release();
                court.Release(match.Duration);
                opponents.Enqueue(match.Winner);// the winner of the match is added to the end of the queue to play the next round
                opponentsStanding.Push(match.Loser); // the loser of the match is added to the stack to set up the ranking
            }
        }
        else
        {
            // Double schedule
            // start a number of matchs equal to 32/2^(actualRound-1) so each round has half the matchs of the previous one          
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
                opponentsStanding.Push(match.Loser);
            }
        }
        actualRound++;
    }



    public Opponent GetWinner()
    {
        
        if (opponents.Count == 1)
        {
            this.winner = opponents.Dequeue();
            opponentsStanding.Push(winner);
        }
        return this.winner;


    }

    public List<string> GetPlayerRankings()
    {
        List<string> playerRankings = new List<string>();

        // Convert the stack to a list for easier processing
        List<Opponent> opponentsList = opponentsStanding.ToList();

        // Display player rankings
        for (int i = 0; i < opponentsList.Count; i++)
        {
            playerRankings.Add($"Rank {i + 1}: {opponentsList[i].ToString()}");
        }

        return playerRankings;
    }

}