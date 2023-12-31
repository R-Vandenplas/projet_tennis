using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using projet.DAO;

namespace DAO
{
    internal class SQLFactory 
    {
        public  static DAO<Player> GetPlayerDAO()
        {
            return new PlayerDAO();
        }
        public static DAO<Match> GetMatchDAO()
        {
            return new MatchDAO();
        }
        public static DAO<Set> GetSetDAO()
        {
            return new SetDAO();
        }
        public static DAO<Tournament> GetTournamentDAO()
        {
            return new TournamentDAO();
        }
        public static DAO<Court> GetCourtDAO() 
        { 
            return new CourtDAO();
        }
        public static DAO<Referee> GetRefereeDAO()
        {
            return new RefereeDAO();
        }
        public static DAO<Schedule> GetScheduleDAO()
        {
               return new ScheduleDAO();
        }
        public static DAO<Opponent> GetOpponentDAO()
        {
               return new OpponentDAO();
        }
        
        
    }

}
