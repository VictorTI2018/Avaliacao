<template>
  <div>
    <v-page-title title="Dados do Cliente" />
    <div class="form__client" role="form">
      <div class="row">
        <div class="col-md-5 col-lg-4 col-sm-12">
          <v-text-field
            icon="font"
            placeholder="Digite seu nome..."
            title="Digite seu nome"
            v-model="model.First_Name"
          />
        </div>
        <div class="col-md-4 col-lg-4 col-sm-12">
          <v-text-field
            icon="font"
            placeholder="Digite seu sobrenome..."
            title="Digite seu sobrenome"
            v-model="model.Last_Name"
          />
        </div>
        <div class="col-md-3 col-lg-3 col-sm-12">
          <v-select-field
            icon="user"
            :options="type_person"
            v-model="model.Type_Person"
            title="Pessoa Fisica ou Juridica"
          >
            <option
              v-for="(option, index) in type_person"
              :key="index"
              :value="option.value"
              >{{ option.label }}</option
            >
          </v-select-field>
        </div>
      </div>
      <div class="row">
        <div class="col-md-4 col-lg-4 col-sm-12">
          <v-text-field
            icon="id-card"
            placeholder="Cpf/Cnpj"
            v-mask="['###.###.###-##', '##.###.###/####-##']"
            v-model="model.Cpf_Cnpj"
            title="Digite seu documento"
          />
        </div>
        <div class="col-md-5 col-lg-4">
          <v-text-field
            type="tel"
            v-mask="['(##) ####-####', '(##) #####-####']"
            icon="phone"
            v-model="model.Phone_Number"
            placeholder="(##) #####-####"
            title="Digite seu celular"
          />
        </div>
        <div class="col-md-3 col-lg-4 col-sm-12">
          <v-select-field
            icon="phone"
            :options="type_person"
            v-model="model.Type_Number"
            title="Tipo de Telefone"
          >
            <option
              v-for="(option, index) in type_phone"
              :key="index"
              :value="option.value"
              >{{ option.label }}</option
            >
          </v-select-field>
        </div>
      </div>
      <v-page-title title="Dados do Endereço" />
      <div class="row">
        <div class="col-md-4 col-lg-3 col-sm-12">
          <v-text-field
            icon="shipping-fast"
            placeholder="#####-###"
            v-mask="'#####-###'"
            v-model="model.Zip_Code"
            title="CEP"
            @blur="getAddress"
          />
        </div>
        <div class="col-md-5 col-lg-7">
          <v-text-field
            placeholder="Logradouro"
            icon="map"
            v-model="model.Address"
            title="Logradouro"
          />
        </div>
        <div class="col-md-3 col-lg-2 col-sm-12">
          <v-text-field
            placeholder="N°"
            icon="sort-numeric-up-alt"
            v-model="model.Number"
            title="Número da residencia"
          />
        </div>
      </div>
      <div class="row">
        <div class="col-md-8 col-lg-8 col-sm-12">
          <v-text-field
            placeholder="Bairro..."
            icon="map"
            v-model="model.Neighborhood"
            title="Bairro"
          />
        </div>
        <div class="col-md-4 col-lg-4 col-sm-12">
          <v-text-field
            placeholder="Complemento"
            icon="map-marked"
            v-model="model.Complement"
            title="Complemento"
          />
        </div>
      </div>
      <div class="row">
        <div class="col-md-9 col-lg-10 col-sm-12">
          <v-text-field
            icon="city"
            placeholder="Cidade..."
            title="Cidade"
            v-model="model.City"
          />
        </div>
        <div class="col-md-3 col-lg-2 col-sm-12">
          <v-text-field
            icon="city"
            placeholder="UF"
            title="Estado"
            v-model="model.UF"
          />
        </div>
      </div>
      <div class="row">
        <div class="col-md-3 offset-md-6 col-sm-12 col-lg-3">
          <button
            class="btn btn-danger btn-block"
            title="Limpar Formulario"
            @click="clearModel"
          >
            <v-icon icon="ban" />
          </button>
        </div>
        <div class="col-md-3 col-lg-3 col-sm-12">
          <button
            class="btn btn-success btn-block"
            title="Salvar Dados"
            @click="handleSubmit"
          >
            <v-icon icon="save" />
          </button>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import axios from "axios";
export default {
  name: "NewClient",
  data() {
    return {
      model: {
        id: 0,
        First_Name: "",
        Last_Name: "",
        Type_Person: "",
        Cpf_Cnpj: "",
        Phone_Number: "",
        Type_Number: "",
        Zip_Code: "",
        Address: "",
        Neighborhood: "",
        Number: 0,
        Complement: "",
        City: "",
        UF: "",
      },
      type_person: [
        { label: "Fisica", value: "fisica" },
        { label: "Juridica", value: "juridica" },
      ],
      type_phone: [
        { label: "Celular", value: "celular" },
        { label: "Comercial", value: "comercial" },
        { label: "Residencial", value: "residencial" },
      ],
    };
  },
  methods: {
    getClient(id) {
      this.$http
        .get(`/api/client/${id}`)
        .then((res) => this.setModel(res.data))
        .catch((err) => console.error(err));
    },
    handleSubmit() {
      if (this.model.First_Name && this.model.Last_Name) {
        this.$http
          .post("/api/client", this.model)
          .then((res) => console.log(res.data))
          .catch((err) => console.error(err));
      } else {
        alert("Por favor Informe seu nome e sobrenome");
      }
    },
    getAddress() {
      axios.get(`https://viacep.com.br/ws/${this.model.Zip_Code}/json/`).then((res) => {
        this.model.Zip_Code = res.data.cep;
        this.model.City = res.data.localidade;
        this.model.UF = res.data.uf;
        this.model.Neighborhood = res.data.bairro;
        this.model.Address = res.data.logradouro
      });
    },
    setModel(data) {
      console.log(data);
      this.model.id = data.id;
      this.model.First_Name = data.first_Name;
      this.model.Last_Name = data.last_Name;
      this.model.Cpf_Cnpj = data.cpf_Cnpj;
      this.model.Phone_Number = data.phone_Number;
      this.model.Type_Person = data.type_Person;
      this.model.Address = data.address;
      this.model.Number = data.number;
      this.model.Type_Number = data.type_Number;
      this.model.Zip_Code = data.zip_Code;
      this.model.City = data.city;
      this.model.UF = data.uf;
      this.model.Neighborhood = data.neighborhood;
    },
    clearModel() {
      if (confirm("Deseja realmente limpar o formulário?")) {
        this.model.id = "";
        this.model.First_Name = "";
        this.model.Last_Name = "";
        this.model.Cpf_Cnpj = "";
        this.model.Phone_Number = "";
        this.model.Type_Person = "";
        this.model.Address = "";
        this.model.Number = "";
        this.model.Type_Number = "";
        this.model.Zip_Code = "";
        this.model.City = "";
        this.model.UF = "";
        this.model.Neighborhood = "";
      }
    },
  },
  mounted() {
    this.model.id = this.$route.params["id"];
    if (this.model.id > 0) {
      this.getClient(this.model.id);
    }
  },
};
</script>
