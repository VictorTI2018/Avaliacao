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
                    id = int.Parse (data.Rows[i]["id"].ToString ()),
                    first_Name = data.Rows[i]["first_name"].ToString (),
                    last_Name = data.Rows[i]["last_name"].ToString (),
                    cpf_Cnpj = data.Rows[i]["cpf_cnpj"].ToString (),
                    phone_Number = data.Rows[0]["phone_number"].ToString (),
                    type_Number = data.Rows[0]["type_number"].ToString (),
                    type_Address = data.Rows[0]["type_address"].ToString (),
                    type_Person = data.Rows[0]["type_person"].ToString (),
                    address = data.Rows[0]["address"].ToString (),
                    zip_Code = data.Rows[0]["zip_code"].ToString (),
                    number = data.Rows[0]["number"].ToString (),
                    complement = data.Rows[0]["complement"].ToString (),
                    neighborhood = data.Rows[0]["neighborhood"].ToString (),
                    city = data.Rows[0]["city"].ToString (),
                    uf = data.Rows[0]["uf"].ToString ()
                };
                rows.Add (item);
            }
            return rows;
        }

        public Client find (int id) {
            Client client = new Client ();
            Client item;
            string sql = "SELECT * FROM clients WHERE id = " + id + " order by id asc";
            DataTable data = client.GetDataTable (sql);
            item = new Client () {
                id = int.Parse (data.Rows[0]["id"].ToString ()),
                first_Name = data.Rows[0]["first_name"].ToString (),
                last_Name = data.Rows[0]["last_name"].ToString (),
                cpf_Cnpj = data.Rows[0]["cpf_cnpj"].ToString (),
                phone_Number = data.Rows[0]["phone_number"].ToString (),
                type_Number = data.Rows[0]["type_number"].ToString (),
                address = data.Rows[0]["address"].ToString (),
                type_Address = data.Rows[0]["type_address"].ToString (),
                type_Person = data.Rows[0]["type_person"].ToString (),
                zip_Code = data.Rows[0]["zip_code"].ToString (),
                number = data.Rows[0]["number"].ToString (),
                complement = data.Rows[0]["complement"].ToString (),
                neighborhood = data.Rows[0]["neighborhood"].ToString (),
                city = data.Rows[0]["city"].ToString (),
                uf = data.Rows[0]["uf"].ToString ()
            };
            return item;
        }

        public void save (Client client) {
            string query = "INSERT INTO `clients`(first_name, last_name, cpf_cnpj, " +
                "type_person, phone_number, type_number, address, zip_code, neighborhood, complement, city, uf, number)" +
                $"VALUES('{client.first_Name}','{client.last_Name}', '{client.cpf_Cnpj}', " +
                $" '{client.type_Person}', '{client.phone_Number}', '{client.type_Number}'," +
                $" '{client.address}', '{client.zip_Code}', '{client.neighborhood}', " +
                $"'{client.complement}', '{client.city}', '{client.uf}', '{client.number}')";
            client.ExecuteSQL (query);
        }

        public void edit (int id, Client client) {
            string query = "UPDATE `clients` SET " +
                $"first_name = '{client.first_Name}', last_name = '{client.last_Name}', " +
                $"cpf_cnpj = '{client.cpf_Cnpj}', type_person = '{client.type_Person}', " +
                $"phone_number = '{client.phone_Number}', type_number = '{client.type_Number}', " +
                $"address = '{client.address}', zip_code = '{client.zip_Code}', " +
                $"neighborhood = '{client.neighborhood}', complement = '{client.complement}', " +
                $"city = '{client.city}', uf = '{client.uf}', number= '{client.number}' " +
                $" WHERE id = '{id}'";

            client.ExecuteSQL (query);
        }

        public void remove (int id) {
            Client client = new Client ();
            string query = "DELETE FROM clients WHERE id = " + id;
            client.ExecuteSQL (query);
        }
    }
}