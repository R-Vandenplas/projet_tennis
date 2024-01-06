using DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projet.DAO
{
    internal class CourtDAO : DAO<Court>
    {
        
        public override bool Create(Court obj)
        {
            throw new NotImplementedException();
        }

        public override bool Delete(Court obj)
        {
            throw new NotImplementedException();
        }

        public override Court Find(int id)
        {
            throw new NotImplementedException();
        }

        public override List<Court> FindAll()
        {
            List<Court> courts = new List<Court>();
            DAO<Tournament> tournamentDAO = new TournamentDAO();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string request = "SELECT * FROM Court ;";
                    SqlCommand command = new SqlCommand(request, connection);
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            
                            int idTournament = reader.GetInt32("idTournament");
                            Tournament tournament = tournamentDAO.Find(idTournament);
                            Court court = new Court(reader.GetInt32("idCourt"),reader.GetInt32("nbSpectators") , reader.GetBoolean("covered"), tournament);
                            courts.Add(court);
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

            return courts;
        }

        public override bool Update(Court obj)
        {
            throw new NotImplementedException();
        }
        
    }
}
