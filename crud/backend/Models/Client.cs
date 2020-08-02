using backend.Util;

namespace backend.Models {
    public class Client : DAL {
        public int Id { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Cpf_Cnpj { get; set; }

        public string Type_Person { get; set; }

    }
}