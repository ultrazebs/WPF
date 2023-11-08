using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFDemo.Models;

namespace WPFDemo.viewModels
{

    /*string connectionString = "Data Source=DESKTOP-LHGOQ7M\Corso_2023;Initial Catalog=myDatabase;Integrated Security=True;";*/
    internal class LoginViewModel : BaseViewModel
    {


        private string _username;

        public string username
        {
            get { return _username; }
            set { _username = value; onPropChanged("username"); onPropChanged("canLogin"); }// onPropChanged mi serve per aggiornare l'enables del bottone
        }
        private string _password;

        public string password
        {
            get { return _password; }
            set { _password = value; onPropChanged("password"); onPropChanged("canLogin"); }// onPropChanged mi serve per aggiornare l'enables del bottone
        }



        //private bool _canLogin; troppo lento

        public bool canLogin
        {
            get { return !string.IsNullOrWhiteSpace(username) && !string.IsNullOrWhiteSpace(password); } // stra veloce e comodo
            //    return !(string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password)); } // stra veloce e comodo
            //set { _canLogin = value; onPropChanged("canLogin"); }
        }


        public string FullName { get; set; }

        private string _result;

        public string result
        {
            get { return _result; }
            set { _result = value; onPropChanged("result"); }
        }




        public void Login() {



            // apro la connessione
            string connectionString = "Data Source=(local);Initial Catalog=Studenti;Integrated Security=True;";

            
            using (SqlConnection connection = new SqlConnection(connectionString))

            {
                try
                {
                    // comando per recuperare i dati dalla tabella Users
                    SqlCommand command = new SqlCommand($"select * from Users where  Username = @username and Password = @password", connection);
                    command.Parameters.AddWithValue("username", username);
                    command.Parameters.AddWithValue("password", password);
                    connection.Open();

                    // eseguo la query con l'execute più standard, per uqalsiasi query di select
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read()) // se la query ha restituito almeno una riga (quindi l'utente c'è)
                    {
                        //Login Corretto

                        // creo l'oggetto di classe User da passare
                        User u = new User
                        {
                            Username = (string)reader["Username"],
                            Password = (string)reader["Password"],
                            Fullname = (string)reader["Fullname"]
                        };

                        // setto il valore della label per dare il benvenuto all'utente
                        result = $"Benvenuto {u.Fullname}";

                    }
                    else
                    {
                        //Login errato
                        result = "Login Errato";

                    }
                }
                catch
                {
                    //connection.Close(); --> è commentato siccome è implicito nello using()
                }
                    
            }

        }

        public LoginViewModel() { }

        public event NotifyCollectionChangedEventHandler CollectionChanged;
    }
}
