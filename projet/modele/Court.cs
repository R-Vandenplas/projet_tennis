
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

    private static Queue<Court> courts= new Queue<Court>();

    public int IdCourt 
    {
        get { return idCourt; }
        set { idCourt = value; } 
    }

    public Court(int idCourt,int nbSpectators, bool covered, Tournament tournament)
    {
        this.idCourt = idCourt;
        this.nbSpectators = nbSpectators;
        this.covered = covered;
        this.tournament = tournament;
    }

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
    public void Release() {
        courts.Enqueue(this);
    }
    public string ToString()
    {
        return "Court " + nbSpectators + " " + covered + " " + tournament;
    }
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