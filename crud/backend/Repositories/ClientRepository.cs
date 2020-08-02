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
                    Cpf_Cnpj = data.Rows[i]["cpf_cnpj"].ToString (),
                    Phone_Number = data.Rows[0]["phone_number"].ToString (),
                    Type_Number = data.Rows[0]["type_number"].ToString (),
                    Type_Address = data.Rows[0]["type_address"].ToString (),
                    Type_Person = data.Rows[0]["type_person"].ToString (),
                    Address = data.Rows[0]["address"].ToString (),
                    Zip_Code = data.Rows[0]["zip_code"].ToString (),
                    Number = data.Rows[0]["number"].ToString (),
                    Complement = data.Rows[0]["complement"].ToString (),
                    Neighborhood = data.Rows[0]["neighborhood"].ToString (),
                    City = data.Rows[0]["city"].ToString (),
                    UF = data.Rows[0]["uf"].ToString ()
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
                Id = int.Parse (data.Rows[0]["id"].ToString ()),
                First_Name = data.Rows[0]["first_name"].ToString (),
                Last_Name = data.Rows[0]["last_name"].ToString (),
                Cpf_Cnpj = data.Rows[0]["cpf_cnpj"].ToString (),
                Phone_Number = data.Rows[0]["phone_number"].ToString (),
                Type_Number = data.Rows[0]["type_number"].ToString (),
                Address = data.Rows[0]["address"].ToString (),
                Type_Address = data.Rows[0]["type_address"].ToString (),
                Type_Person = data.Rows[0]["type_person"].ToString (),
                Zip_Code = data.Rows[0]["zip_code"].ToString (),
                Number = data.Rows[0]["number"].ToString (),
                Complement = data.Rows[0]["complement"].ToString (),
                Neighborhood = data.Rows[0]["neighborhood"].ToString (),
                City = data.Rows[0]["city"].ToString (),
                UF = data.Rows[0]["uf"].ToString ()
            };
            return item;
        }

        public void save () {
            Client client = new Client ();
            string query = "INSERT INTO `clients`(first_name, last_name, cpf_cnpj, " +
                "type_person, phone_number, type_number, address, zip_code, neighborhood, complement, city, uf, number)" +
                $"VALUES('{client.First_Name}','{client.Last_Name}', '{client.Cpf_Cnpj}', " +
                $" '{client.Type_Person}', '{client.Phone_Number}', '{client.Type_Number}'," +
                $" '{client.Address}', '{client.Zip_Code}', '{client.Neighborhood}', " +
                $"'{client.Complement}', '{client.City}', '{client.UF}', '{client.Number}')";
            client.ExecuteSQL (query);
        }
    }
}