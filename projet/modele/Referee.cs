
using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Referee : Person {
    private int idReferee;
    bool available;
    public static Queue<Referee> referees= new Queue<Referee>();
    


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
    
    

    public Referee(int idReferee,string firstname, string lastname, string nationality) : base(firstname, lastname, nationality)
    {
        this.idReferee = idReferee;
        this.available = true;
    }

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

    public void Release() {
       referees.Enqueue(this);
    }
    
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