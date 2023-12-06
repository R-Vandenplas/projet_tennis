
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Match {

    private DateTime date;
    private TimeSpan duration;
    private int round;
    private Referee referee;
    private Court court;
    private Opponent team1;
    private Opponent team2;
    private Schedule schedule;
    

    private List<Set> sets;

    public Match(DateTime date, TimeSpan duration, int round, Referee referee, Court court, Opponent team1, Opponent team2, Schedule schedule)
    {
        this.date = date;
        this.duration = duration;
        this.round = round;
        this.referee = referee;
        this.court = court;
        this.team1 = team1;
        this.team2 = team2;
        this.schedule = schedule;
        this.sets = new List<Set>();
    }

    public Opponent GetWinner() {

        
    }

    public void Play() {

        switch(schedule.GetScheduleType())
        {
            case ScheduleType.LadiesDouble:
                PlayDouble();
                break;
            case ScheduleType.LadiesSingle:
                PlayLadiesSingle();
                break;
            case ScheduleType.GentlemenDouble:
                PlayDouble();
                break;
            case ScheduleType.GentlemenSingle:
                PlayGentlemenSingle();
                break;
            case ScheduleType.MixedDouble:
                PlayDouble();
                break;

        }
    }

    private int PlayDouble()
    {
        int setWinTeam1 = 0;
        int setWinTeam2 = 0;
        do
        {
            Set set = new Set();
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
        } while ((setWinTeam1 == 2 || setWinTeam2 ==0) && (setWinTeam1 == 0 || setWinTeam2 == 2) && (setWinTeam1 == 1 || setWinTeam2 == 1));
        if (setWinTeam1 == setWinTeam2)
        {
            SuperTieBreak superTieBreak = new SuperTieBreak();
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
        do
        {
            Set set = new Set();
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
        }while ((setWinTeam1 == 2 || setWinTeam2 == 0) && (setWinTeam1 == 0 || setWinTeam2 == 2) && (setWinTeam1 == 1 || setWinTeam2 == 1));
        if (setWinTeam1 == setWinTeam2)
        {
            Set set = new Set(true);
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
            Set set = new Set();
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
        } while ((setWinTeam1 == 3 || setWinTeam2 < 2) && (setWinTeam1 < 2 || setWinTeam2 == 3) && (setWinTeam1 == 2 || setWinTeam2 == 2));
        if (setWinTeam1 == setWinTeam2)
        {
            Set set = new Set(true);
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