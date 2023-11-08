using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFDemo.Models;

namespace WPFDemo.viewModels
{
    internal class randomStudentViewModel : BaseViewModel
    {

        private Student _studente;
        public Student Studente
        {
            get { return _studente; }
            set { _studente = value; onPropChanged("Studente"); }
        }



        public void generateRandom()
		{

            // apro la connessione
            string connectionString = "Data Source=(local);Initial Catalog=Studenti;Integrated Security=True;";


            using (SqlConnection connection = new SqlConnection(connectionString))

            {
                try
                {
                    connection.Open();
                    // comando per recuperare i dati dalla tabella Users
                    SqlCommand command = new SqlCommand("select TOP 1* from Students order by NEWID()", connection);
                    
                    

                    // eseguo la query con l'execute più standard, per uqalsiasi query di select
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read()) // se la query ha restituito almeno una riga (quindi l'utente c'è)
                    {
                        //Login Corretto

                        // creo l'oggetto di classe User da passare
                        Studente = new Student
                        {
                            Id = (int)reader["ID"],
                            Nome = (string)reader["Nome"],
                            Cognome = (string)reader["Cognome"],
                            DataNascita = (DateTime)reader["DataNascita"],
                            IdCorso = (int)reader["IdCorso"]

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
                catch
                {
                    //connection.Close(); --> è commentato siccome è implicito nello using()
                }

            }
        }

        public randomStudentViewModel() { }

	}
}
