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
    internal class TournamentDAO : DAO<Tournament>
    {
        public override bool Create(Tournament obj)
        {
            throw new NotImplementedException();
        }

        public override bool Delete(Tournament obj)
        {
            throw new NotImplementedException();
            
        }

        public override Tournament Find(int id)
        {
            Tournament tournament = null;
            try
            {
                using (SqlConnection connection = new SqlConnection(this.connectionString))
                {
                    SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.Tournament WHERE idTournament = @id", connection);
                    cmd.Parameters.AddWithValue("id", id);
                    connection.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            tournament = new Tournament(reader.GetInt32("idTournament"),reader.GetString("name"));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
           return tournament;
        }

        public override List<Tournament> FindAll()
        {
            throw new NotImplementedException();
        }

        public override bool Update(Tournament obj)
        {
            throw new NotImplementedException();
        }
    }
    
    
}
