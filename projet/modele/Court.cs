
using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Court {

    
    private int idCourt;
    private int nbSpectators;
    private bool covered;
    private Tournament tournament;
    DateTime date ;

    private static Queue<Court> courts= new Queue<Court>();

    // <------ getters and setters ------>
    public int IdCourt 
    {
        get { return idCourt; }
        set { idCourt = value; } 
    }
    public DateTime Date
    {
        get
        {
            return date;
        }
    }

    // <------ constructors ------>
    public Court(int idCourt,int nbSpectators, bool covered, Tournament tournament)
    {
        this.idCourt = idCourt;
        this.nbSpectators = nbSpectators;
        this.covered = covered;
        this.tournament = tournament;
        this.date = tournament.Date;
    }

    // <------ methods ------>

    // the function returns a court if there is one available
    public static Court Available() {
        if(courts.Count > 0)
        {
            return courts.Dequeue();
        }
        else
        {
            throw new Exception("No more courts available");
            
        }


    }
    // the function returns the date of end of the last match of the round
    public static DateTime GetDateEndRound()
    {
        
        DateTime maxDate = DateTime.MinValue;
        foreach (Court c in courts)
        {
            if (c.date > maxDate)
            {
                maxDate = c.date;
            }
        }
        foreach (Court c in courts)
        {
           c.date = maxDate;
        }
        return maxDate;

    }
    // the function release the court after a match and add the duration of the match to the date of the court
    // if the match ends after 19h the date is set to 8h30 the next day because we don't start match after 19h
    public void Release(TimeSpan duration_match) {
        
        this.date = date.Add(duration_match);
        if (date.Hour > 19)
        {
            date = date.AddDays(1);
            date = new DateTime(date.Year,date.Month,date.Day,8,30,0);
        }
        courts.Enqueue(this);
    }

    // the function charges the courts from the database
    public static void ChargeCourts()
    {
        DAO<Court> dao = SQLFactory.GetCourtDAO();
        List<Court> courtList = dao.FindAll();
        foreach (Court c in courtList)
        {
            courts.Enqueue(c);
        }
    }   
}