
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

    public void GetWinner() {
        // TODO implement here
    }

    public void Play() {
        // TODO implement here
    }

}