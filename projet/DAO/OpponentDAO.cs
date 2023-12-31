using DAO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace projet.DAO
{
    internal class OpponentDAO : DAO<Opponent>
    {
        public override bool Create(Opponent obj)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(this.connectionString))
                {
                    SqlCommand cmd = new SqlCommand("INSERT INTO dbo.Opponent ( idPlayer1, idPlayer2) VALUES (@idPlayer1, @idPlayer2)", connection);
                    cmd.Parameters.AddWithValue("@idPlayer1", obj.Player1.IdPlayer);
                    if(obj.Player2 == null)
                    {
                        cmd.Parameters.AddWithValue("@idPlayer2", DBNull.Value);
                    }
                    else
                    { 
                        cmd.Parameters.AddWithValue("@idPlayer2", obj.Player2.IdPlayer);
                    }
                    
                    connection.Open();
                    cmd.ExecuteNonQuery();
                    SqlCommand cmd2 = new SqlCommand("SELECT MAX(idOpponent) from Opponent", connection);
                    using (SqlDataReader reader = cmd2.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            obj.IdOpponent = reader.GetInt32(0);
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

        public override bool Delete(Opponent obj)
        {
            throw new NotImplementedException();
        }

        public override Opponent Find(int id)
        {
            throw new NotImplementedException();
        }

        public override List<Opponent> FindAll()
        {
            throw new NotImplementedException();
        }

        public override bool Update(Opponent obj)
        {
            throw new NotImplementedException();
        }
    }
    
}
