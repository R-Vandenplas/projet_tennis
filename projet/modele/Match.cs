
using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Match {

    private int idMatch;
    private DateTime date;
    private TimeSpan duration;
    private int round;
    private Referee referee;
    private Court court;
    private Opponent team1;
    private Opponent team2;
    private Schedule schedule;
    private Opponent winner;

    public int IdMatch
    {
        get
        {
            return idMatch;
        }
        set
        {
            idMatch = value;
        }
    }
    public DateTime Date
    {
        get
        {
            return date;
        }
    }
    public TimeSpan Duration
    {
        get
        {
            return duration;
        }
        set
        {
            duration = value;
        
        }
    }
    public int Round
    {
        get
        {
            return round;
        }
    }
    public Referee Referee
    {
        get
        {
            return referee;
        }
    }
    public Court Court
    {
        get
        {
            return court;
        }
    }
    public Opponent Team1
    {
        get
        {
            return team1;
        }
    }
    public Opponent Team2
    {
        get
        {
            return team2;
        }
    }
    public Schedule Schedule
    {
        get
        {
            return schedule;
        }
    }
    public List<Set> Sets
    {
        get
        {
            return sets;
        }
    }
    public Opponent Winner
    {
        get
        {
            return winner;
        }
    }

    private List<Set> sets;

    DAO<Match> matchDAO = SQLFactory.GetMatchDAO();
    DAO<Set> setDAO = SQLFactory.GetSetDAO();

    

    public Match(int round, Referee referee, Court court, Opponent team1, Opponent team2, Schedule schedule)
    {
        this.round = round;
        this.referee = referee;
        this.court = court;
        this.team1 = team1;
        this.team2 = team2;
        this.schedule = schedule;
        this.date = DateTime.Now;
        this.duration = new TimeSpan(0,0,0);
        this.sets = new List<Set>();
        
    }

    public void Play() {
        int winner = 0;
        switch(schedule.Type)
        {
            
            case ScheduleType.LadiesDouble:
                winner = PlayDouble();
                break;
            case ScheduleType.LadiesSingle:
                winner =  PlayLadiesSingle();
                break;
            case ScheduleType.GentlemenDouble:
                winner =  PlayDouble();
                break;
            case ScheduleType.GentlemenSingle:
                winner =  PlayGentlemenSingle();
                break;
            case ScheduleType.MixedDouble:
                winner =PlayDouble();
                break;

        }
        if(winner == 1)
        {
            this.winner = team1;
        }
        else if(winner == 2)
        {
            this.winner = team2;
        }
        else
        {
            throw new Exception("Play error");
        }
        bool creation_verification = matchDAO.Create(this);
        
        
        if (!creation_verification)
        {
            throw new Exception("Match creation failed");
        }
        foreach (Set set in sets)
        {
            creation_verification = setDAO.Create(set);
            if (!creation_verification)
            {
                throw new Exception("Set creation failed");
            }
        }



    }

    private int PlayDouble()
    {
        int setWinTeam1 = 0;
        int setWinTeam2 = 0;
        for (int i = 0; i < 2; i++)
        {
            Set set = new Set(this);
            sets.Add(set);
            int winner = set.Play();
            sets.Add(set);
            if (winner == 1)
            {
                setWinTeam1++;
            }
            else
            {
                setWinTeam2++;
            }
        } 
        if (setWinTeam1 == setWinTeam2)
        {
            SuperTieBreak superTieBreak = new SuperTieBreak(this);
            sets.Add(superTieBreak);
            int winner = superTieBreak.Play();
            if (winner == 1)
            {
                setWinTeam1++;
               
            }
            else
            {
                setWinTeam2++;
            }
        }
        if(setWinTeam1 == 2)
        {
            return 1;
        }
        else if(setWinTeam2 == 2)
        {
            return 2;
        }
        else
        {
            throw new Exception("PlayDouble error");
        }
        
    }
    private int PlayLadiesSingle()
    {
        int setWinTeam1 = 0;
        int setWinTeam2 = 0;
        for (int i = 0; i < 2; i++)
        {
            
            Set set = new Set(this);
            sets.Add(set);
            int winner = set.Play();
            sets.Add(set);
            if (winner == 1)
            {
                setWinTeam1++;
            }
            else
            {
                setWinTeam2++;
            }
        }

        if (setWinTeam1 == setWinTeam2)
        {
            Set set = new Set(this,true);
            sets.Add(set);
            int winner = set.Play();
            if (winner == 1)
            {
                setWinTeam1++;

            }
            else
            {
                setWinTeam2++;
            }
        }
        if (setWinTeam1 == 2)
        {
            
            return 1;
        }
        else if (setWinTeam2 == 2)
        {
           
            return 2;
        }
        else
        {
            throw new Exception("PlayLadiesSingle error");
        }

    }
    private int PlayGentlemenSingle()
    {
        int setWinTeam1 = 0;
        int setWinTeam2 = 0;
        do
        {
           
            Set set = new Set(this);
            sets.Add(set);
            int winner = set.Play();
            sets.Add(set);
            if (winner == 1)
            {
                setWinTeam1++;
            }
            else
            {
                setWinTeam2++;
            }
        } while (!((setWinTeam1 == 3 && setWinTeam2 < 2) || (setWinTeam1 < 2 && setWinTeam2 == 3) || (setWinTeam1 == 2 && setWinTeam2 == 2)));
        if (setWinTeam1 == setWinTeam2)
        {
            Set set = new Set(this, true);
            sets.Add(set);
            int winner = set.Play();
            if (winner == 1)
            {
                setWinTeam1++;

            }
            else
            {
                setWinTeam2++;
            }
        }
        if (setWinTeam1 == 3)
        {
            return 1;
        }
        else if (setWinTeam2 == 3)
        {
            return 2;
        }
        else
        {
            throw new Exception("PlayGentlemenSingle error");
        }
        
    }

}