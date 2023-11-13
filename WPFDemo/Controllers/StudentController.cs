using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFDemo.Models;

namespace WPFDemo.Controllers
{
    public static class StudentController
    {
        private static string connectionString = "Data Source=(local);Initial Catalog=Studenti;Integrated Security=True;";




        public static Student generateRandom()
        {

            // apro la connessione
            


            using (SqlConnection connection = new SqlConnection(connectionString))

            {
                try
                {
                    connection.Open();
                    // comando per recuperare i dati dalla tabella Users
                    var command = new SqlCommand("select TOP 1 Students.*, Corsi.NOME as NomeCorso from Students join Corsi on Corsi.Id = Students.IdCorso order by NEWID()", connection);



                    // eseguo la query con l'execute più standard, per uqalsiasi query di select
                    var reader = command.ExecuteReader();

                    if (reader.Read()) // se la query ha restituito almeno una riga (quindi l'utente c'è)
                    {
                        //Login Corretto

                        // creo l'oggetto di classe User da passare
                        return new Student
                        {
                            Id = (int)reader["ID"],
                            Nome = (string)reader["Nome"],
                            Cognome = (string)reader["Cognome"],
                            DataNascita = (DateTime)reader["DataNascita"],
                            IdCorso = (int)reader["IdCorso"],
                            Corso = new Corso
                            {
                                Id = (int)reader["IdCorso"],
                                Nome = (string)reader["NomeCorso"]
                            }
                        };
                        // Corso = s.Corso;

                        // setto il valore della label per dare il benvenuto all'utente
                        // Result = $"{Nome} {Cognome}";

                    }
                    else
                    {
                        //Login errato
                        // Result = "Studenti Non Trovati bro";

                    }
                }
                catch (Exception ex)
                {
                    //connection.Close(); --> è commentato siccome è implicito nello using()
                    return null;
                }

            }

            return null;

        }



        public static List<Student> getStudents(string filter)
        {
            List<Student> results = new List<Student>();



            using(SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                var command = new SqlCommand($"select Students.*, Corsi.NOME as NomeCorso from Students join Corsi on Corsi.Id = Students.IdCorso where Students.Cognome like @Cognome order by Students.Id", connection);

                command.Parameters.AddWithValue("Cognome", '%' + filter + '%');

                var reader = command.ExecuteReader();

                while(reader.Read())
                {
                    results.Add(new Student
                    {
                        Id = (int)reader["ID"],
                        Nome = (string)reader["Nome"],
                        Cognome = (string)reader["Cognome"],
                        DataNascita = (DateTime)reader["DataNascita"],
                        IdCorso = (int)reader["IdCorso"],
                        Corso = new Corso
                        {
                            Id = (int)reader["IdCorso"],
                            Nome = (string)reader["NomeCorso"]
                        }
                    });
                    
                    
                    
                    
                    
                }
                connection.Close();
                return results;
            }
            
            


        }


        public static void deleteStudent(Student s)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                var command = new SqlCommand("delete from Students where Id like @Id", connection);

                command.Parameters.AddWithValue("@Id", s.Id);

                command.ExecuteReader();

                
            }
        }

        public static void updateStudent(Student s)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                var command = new SqlCommand("delete from Students where Id like @Id", connection);

                command.Parameters.AddWithValue("@Id", s.Id);

                command.ExecuteReader();


            }
        }

        internal static void add(Student student)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                var command = new SqlCommand($"insert into Students (Cognome, Nome, DataNascita, IdCorso) values(@Cognome, @Nome, @DataNascita, @IdCorso)", connection);

                command.Parameters.AddWithValue("@Cognome", student.Cognome);
                command.Parameters.AddWithValue("@Nome", student.Nome);
                command.Parameters.AddWithValue("@DataNascita", student.DataNascita);
                command.Parameters.AddWithValue("@IdCorso", student.IdCorso);

                command.ExecuteReader();


            }
        }


        internal static void update(Student student)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                var command = new SqlCommand($"update Students set Cognome = @Cognome, Nome = @Nome, DataNascita = @DataNascita, IdCorso = @IdCorso where Id = @Id", connection);

                command.Parameters.AddWithValue("@Cognome", student.Cognome);
                command.Parameters.AddWithValue("@Nome", student.Nome);
                command.Parameters.AddWithValue("@DataNascita", student.DataNascita);
                command.Parameters.AddWithValue("@IdCorso", student.IdCorso);
                command.Parameters.AddWithValue("@Id", student.Id);

                command.ExecuteReader();


            }
        }
    }
}
