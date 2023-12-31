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
    internal class RefereeDAO : DAO<Referee>
    {
        public override bool Create(Referee obj)
        {
            throw new NotImplementedException();
        }

        public override bool Delete(Referee obj)
        {
            throw new NotImplementedException();
        }

        public override Referee Find(int id)
        {
            throw new NotImplementedException();
        }

        public override List<Referee> FindAll()
        {
            List<Referee> refs = new List<Referee>();
            try
            {
                using(SqlConnection connection = new SqlConnection(this.connectionString))
                {
                    SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.Referee", connection);
                    connection.Open();
                    using(SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while(reader.Read())
                        {
                            Referee referee = new Referee(reader.GetInt32("idReferee"),reader.GetString("firstname"), reader.GetString("lastname"), reader.GetString("nationality"));
                            refs.Add(referee);
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return refs;
        }

        public override bool Update(Referee obj)
        {
            throw new NotImplementedException();
        }
    }
    
}
