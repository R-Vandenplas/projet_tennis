
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
    private Opponent loser;

    private List<Set> sets;

    DAO<Match> matchDAO = SQLFactory.GetMatchDAO();
    DAO<Set> setDAO = SQLFactory.GetSetDAO();

    //<------- getters and setters --------->
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
    public Opponent Loser
    {
        get
        {
            return loser;
        }
    }

    //<------- constructors --------->
    public Match(int round, Referee referee, Court court, Opponent team1, Opponent team2, Schedule schedule)
    {
        this.round = round;
        this.referee = referee;
        this.court = court;
        this.team1 = team1;
        this.team2 = team2;
        this.schedule = schedule;
        this.date = court.Date;
        this.duration = new TimeSpan(0,0,0);
        this.sets = new List<Set>();
        
    }

    public void Play() {
        int winner = 0;
        // launch the right play method depending on the schedule type
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
        // set winner and loser
        if(winner == 1)
        {
            this.winner = team1;
            this.loser = team2;
        }
        else if(winner == 2)
        {
            this.winner = team2;
            this.loser = team1;
        }
        else
        {
            throw new Exception("Play error");
        }
        // add match to database
        bool creation_verification = matchDAO.Create(this);
        if (!creation_verification)
        {
            throw new Exception("Match creation failed");
        }
        // add sets to database
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
        // play 2 sets
        for (int i = 0; i < 2; i++)
        {
            Set set = new Set(this);
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
        // play super tie break if 1 set each
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
        // return winner
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
        // play 2 sets
        for (int i = 0; i < 2; i++)
        {
            
            Set set = new Set(this);
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
        // if 1 set each play the last set where the tie break is a super tie break 
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
        // return winner
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
        // play sets until one team has 3 sets or 2 sets each
        do
        {
           
            Set set = new Set(this);
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
        } while (!((setWinTeam1 == 3 ) || (setWinTeam2 == 3) || (setWinTeam1 == 2 && setWinTeam2 == 2)));
        // if 2 sets each play the last set where the tie break is a super tie break
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
        // return winner
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