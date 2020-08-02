using System.Data;
using MySql.Data.MySqlClient;
namespace backend.Util {
    public class DAL {
        private static string Server = "localhost";
        private static string Database = "crud";
        private static string User = "root";
        private static string Password = "";
        private MySqlConnection Connection;

        private static string getConnectionString () {
            return $"Server={Server};Database={Database};Uid={User};Pwd={Password};Sslmode=none";
        }

        public DAL () {
            Connection = new MySqlConnection (getConnectionString ());
            Connection.Open ();
        }

        /** Executar Querys **/
        public bool ExecuteSQL (string query) {
            MySqlCommand Command = new MySqlCommand (query, Connection);
            return Command.ExecuteNonQuery ()  > 0 ;
        }

        //Retornar dados do banco
        public DataTable GetDataTable (string query) {
            MySqlCommand Command = new MySqlCommand (query, Connection);
            MySqlDataAdapter DataAdapter = new MySqlDataAdapter (Command);
            DataTable data = new DataTable ();
            DataAdapter.Fill (data);
            return data;
        }
    }
}