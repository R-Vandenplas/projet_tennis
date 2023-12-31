using DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace projet.DAO
{
    internal class MatchDAO : DAO<Match>
    {
        public override bool Create(Match obj)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("INSERT INTO dbo.Match (idOpponent1, idOpponent2, idCourt, idSchedule, round, idReferee, date, duration) VALUES (@idOpponent1, @idOpponent2, @idCourt, @idSchedule, @round, @idReferee, @date, @duration);", connection);
                    cmd.Parameters.AddWithValue("@idOpponent1", obj.Team1.IdOpponent);
                    cmd.Parameters.AddWithValue("@idOpponent2", obj.Team2.IdOpponent);
                    cmd.Parameters.AddWithValue("@idCourt", obj.Court.IdCourt);
                    cmd.Parameters.AddWithValue("@idSchedule", obj.Schedule.IdSchedule);
                    cmd.Parameters.AddWithValue("@round", obj.Round);
                    cmd.Parameters.AddWithValue("@idReferee", obj.Referee.IdReferee);
                    cmd.Parameters.AddWithValue("@date", obj.Date);
                    cmd.Parameters.AddWithValue("@duration", obj.Duration);
                    connection.Open();
                    cmd.ExecuteNonQuery();
                
                    SqlCommand cmd2 = new SqlCommand("SELECT MAX(idMatch) FROM Match",connection);
                    using (SqlDataReader reader2 = cmd2.ExecuteReader())
                    {
                        if (reader2.Read())
                        {
                            obj.IdMatch = reader2.GetInt32(0);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            return true;
        }

        public override bool Delete(Match obj)
        {
            throw new NotImplementedException();
        }

        public override Match Find(int id)
        {
            Match match = null;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                   
                    SqlCommand cmd = new SqlCommand("SELECT * FROM Match WHERE id = @id;", connection);
                    cmd.Parameters.Add(new SqlParameter("@id", id));
                    connection.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            int idOpponent1 = reader.GetInt32("idOpponent1");
                            int idOpponent2 = reader.GetInt32("idOpponent2");
                            int idCourt = reader.GetInt32("idCourt");
                            int idSchedule = reader.GetInt32("idSchedule");
                            int round = reader.GetInt32("round");
                            int idReferee = reader.GetInt32("idReferee");
                            DateTime date = reader.GetDateTime("date");
                            TimeSpan duration = reader.GetTimeSpan(3);
                            DAO<Opponent> opponentDAO = new OpponentDAO();
                            Opponent opponent1 = opponentDAO.Find(idOpponent1);
                            Opponent opponent2 = opponentDAO.Find(idOpponent2);
                            DAO<Court> courtDAO = new CourtDAO();
                            Court court = courtDAO.Find(idCourt);
                            DAO<Schedule> scheduleDAO = new ScheduleDAO();
                            Schedule schedule = scheduleDAO.Find(idSchedule);
                            DAO<Referee> refereeDAO = new RefereeDAO();
                            Referee referee = refereeDAO.Find(idReferee);
                            match = new Match(round,referee,court,opponent1,opponent2,schedule);
                        }
                        
                    }

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
                Console.WriteLine(e.Source);
                Console.WriteLine(e.InnerException);
            }
            return match;
            
        }

        public override List<Match> FindAll()
        {
            throw new NotImplementedException();
        }

        public override bool Update(Match obj)
        {
            throw new NotImplementedException();
        }
    }
    
}
