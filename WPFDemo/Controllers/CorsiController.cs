using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFDemo.Models;

namespace WPFDemo.Controllers
{
    internal static class CorsiController
    {
        private static string connectionString = "Data Source=(local);Initial Catalog=Studenti;Integrated Security=True;";

        public static List<Corso> getAll()
        {
            List<Corso> results = new List<Corso>();

            using(var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                var command = new SqlCommand("select * from Corsi", connection);
                var reader = command.ExecuteReader();

                while(reader.Read())
                {
                    Corso c = new Corso
                    {
                        Id = (int)reader["Id"],
                        Nome = (string)reader["Nome"]
                    };
                    results.Add(c);
                }

                return results;


            }
        }
    }
}
