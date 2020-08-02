using System.Collections.Generic;
using System.Data;
using backend.Models;

namespace backend.Repositories {
    public class ClientRepository {
        public List<Client> All () {
            List<Client> rows = new List<Client> ();
            Client client = new Client ();
            Client item;
            string sql = "SELECT * FROM clients order by id asc";
            DataTable data = client.GetDataTable (sql);
            for (int i = 0; i < data.Rows.Count; i++) {
                item = new Client () {
                    Id = int.Parse (data.Rows[i]["id"].ToString ()),
                    First_Name = data.Rows[i]["first_name"].ToString (),
                    Last_Name = data.Rows[i]["last_name"].ToString (),
                    Cpf_Cnpj = data.Rows[i]["cpf_cnpj"].ToString ()
                };
                rows.Add (item);
            }
            return rows;
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