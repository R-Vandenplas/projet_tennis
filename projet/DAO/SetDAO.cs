using DAO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projet.DAO
{
    internal class SetDAO : DAO<Set>
    {
        public override bool Create(Set obj)
        {
            try
            {
               using(SqlConnection connection = new SqlConnection(this.connectionString))
                {
                    SqlCommand cmd = new SqlCommand("INSERT INTO [Set] ([Set].scoreOP1,[Set].scoreOp2,[Set].idMatch)  VALUES (@scoreOP1,@scoreOp2,@idMatch) ", connection);
                    cmd.Parameters.AddWithValue("@idMatch", obj.Match.IdMatch);
                    cmd.Parameters.AddWithValue("@scoreOP1", obj.ScoreOp1);
                    cmd.Parameters.AddWithValue("@scoreOp2", obj.ScoreOp2);
                    connection.Open();
                    cmd.ExecuteNonQuery();
                    SqlCommand cmd2 = new SqlCommand("SELECT MAX([Set].idSet) FROM [Set]", connection);
                    using(SqlDataReader reader = cmd2.ExecuteReader())
                    {
                        if(reader.Read())
                        {
                            obj.IdSet = reader.GetInt32(0);
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            return true;
        }

        public override bool Delete(Set obj)
        {
            throw new NotImplementedException();
        }

        public override Set Find(int id)
        {
            throw new NotImplementedException();
        }

        public override List<Set> FindAll()
        {
            throw new NotImplementedException();
        }

        public override bool Update(Set obj)
        {
            throw new NotImplementedException();
        }
    }
}
