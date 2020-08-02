using backend.Util;

namespace backend.Models {
    public class Client : DAL {
        public int Id { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Cpf_Cnpj { get; set; }
        public string Phone_Number { get; set; }
        public string Type_Number { get; set; }
        public string Address { get; set; }
        public string Zip_Code { get; set; }
        public string Number { get; set; }
        public string Complement { get; set; }

        public string Neighborhood { get; set; }
        public string City { get; set; }
        public string UF { get; set; }
        public string Type_Address { get; set; }

        public string Type_Person { get; set; }

    }
}