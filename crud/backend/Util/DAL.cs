using System;
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
            return $"Server={Server};Database={Database};Uid={User};Pwd={Password};Sslmode=none;Connection Timeout=4200";
        }

        public DAL () {
            Connection = new MySqlConnection (getConnectionString ());
            Connection.Open ();
        }

        /** Executar Querys **/
        public void ExecuteSQL (string query) {
            MySqlCommand Command = new MySqlCommand (query, Connection);
            Command.ExecuteNonQuery ();
        }

        //Retornar dados do banco
        public DataTable GetDataTable (string query, int currentIndex = 0, int pageSize = 5) {
            MySqlCommand Command = new MySqlCommand (query, Connection);
            MySqlDataAdapter DataAdapter = new MySqlDataAdapter (Command);
            DataTable data = new DataTable ();
            DataAdapter.Fill (data);
            return data;
        }
    }
}