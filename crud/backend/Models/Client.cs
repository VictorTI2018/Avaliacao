using backend.Util;

namespace backend.Models {
    public class Client : DAL {
        public int id { get; set; }
        public string first_Name { get; set; }
        public string last_Name { get; set; }
        public string cpf_Cnpj { get; set; }
        public string phone_Number { get; set; }
        public string type_Number { get; set; }
        public string address { get; set; }
        public string zip_Code { get; set; }
        public string number { get; set; }
        public string complement { get; set; }

        public string neighborhood { get; set; }
        public string city { get; set; }
        public string uf { get; set; }
        public string type_Address { get; set; }

        public string type_Person { get; set; }

    }
}