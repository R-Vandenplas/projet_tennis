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
    internal class ScheduleDAO : DAO<Schedule>
    {
        public override bool Create(Schedule obj)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(this.connectionString))
                {
                    
                    SqlCommand cmd = new SqlCommand("INSERT INTO dbo.Schedule (type, idTournament) VALUES (@type, @idTournament)", connection);
                    cmd.Parameters.AddWithValue("@type", obj.Type);
                    cmd.Parameters.AddWithValue("@idTournament", obj.Tournament.IdTournament);
                    connection.Open();
                    cmd.ExecuteNonQuery();
                    SqlCommand cmd2 = new SqlCommand("SELECT MAX(idSchedule) FROM dbo.Schedule", connection);
                    using (SqlDataReader reader = cmd2.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            obj.IdSchedule= reader.GetInt32(0);
                            
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

        public override bool Delete(Schedule obj)
        {
            throw new NotImplementedException();
        }

        public override Schedule Find(int id)
        {
            throw new NotImplementedException();
        }

        public override List<Schedule> FindAll()
        {
            throw new NotImplementedException();
        }

        public override bool Update(Schedule obj)
        {
            throw new NotImplementedException();
        }
    }
    
}
