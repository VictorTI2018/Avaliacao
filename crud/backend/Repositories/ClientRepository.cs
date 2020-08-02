using System.Collections.Generic;
using System.Data;
using backend.Models;

namespace backend.Repositories {
    public class ClientRepository {
        public DataTable All () {
            Client client = new Client ();
            string sql = "SELECT * FROM clients";
            DataTable data = client.GetDataTable (sql);
            return data;
        }

        public DataTable find (int id) {
            Client client = new Client ();
            string sql = "SELECT * FROM clients WHERE id = " + id;
            DataTable data = client.GetDataTable (sql);
            return data;
        }

        public bool save () {
            Client client = new Client ();
            string query = "INSERT INTO clients(first_name, last_name, cpf_cnpj, type_person) " +
                $"VALUES({client.First_Name}, {client.Last_Name}, {client.Cpf_Cnpj}, {client.Type_Person})";
            return client.ExecuteSQL (query);
        }
    }
}