
using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Referee : Person {
    private int idReferee;
    bool available;
    public static Queue<Referee> referees= new Queue<Referee>();
    

    // <------ getters and setters ------>
    public int IdReferee
    {
        get
        {
            return idReferee;
        }
        set
        {
            idReferee = value;
        }
    }
    
    // <------ constructors ------>
    public Referee(int idReferee,string firstname, string lastname, string nationality) : base(firstname, lastname, nationality)
    {
        this.idReferee = idReferee;
        this.available = true;
    }

    // <------ methods ------>
    // the function returns a referee if there is one available
    public static Referee Available() {
        if(referees.Count > 0)
        {
            return referees.Dequeue();
        }
        else
        {
            throw new Exception("No more referees available");
        }
       
    }

    // the method returns the referee to the queue of available referees
    public void Release() {
       referees.Enqueue(this);
    }
    // the method charges referees from the database
    public static void ChargeReferees()
    {
        DAO<Referee> dao = SQLFactory.GetRefereeDAO();
        List<Referee> refList = dao.FindAll();
        foreach (Referee r in refList)
        {
            referees.Enqueue(r);
        }
    }

}