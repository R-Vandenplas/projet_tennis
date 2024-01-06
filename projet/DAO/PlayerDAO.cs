using DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using projet.modele;

namespace projet.DAO
{
    internal class PlayerDAO : DAO<Player>
    {
        public override bool Create(Player obj)
        {
            throw new NotImplementedException();
        }

        public override bool Delete(Player obj)
        {
            throw new NotImplementedException();
        }

        public override Player Find(int id)
        {
            throw new NotImplementedException();
        }

        public override bool Update(Player obj)
        {
            throw new NotImplementedException();
        }
        public override List<Player> FindAll()
        {
            List<Player> players = new List<Player>();
            try { 
            using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string request = "SELECT * FROM Player ;";
                    SqlCommand command = new SqlCommand(request, connection);
                    connection.Open();
                    using(SqlDataReader reader = command.ExecuteReader())
                    {
                        
                        while (reader.Read())
                            {
                            
                                Player player = new Player(reader.GetInt32("idPlayer"),reader.GetString("firstname"), reader.GetString("lastname"), reader.GetString("nationality"), reader.GetInt32("rank"), reader.GetString("gender"));
                                players.Add(player);
                            }
                    }
                
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return players;
        }


    }
}
