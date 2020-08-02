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
            v-model="model.first_Name"
          />
        </div>
        <div class="col-md-4 col-lg-4 col-sm-12">
          <v-text-field
            icon="font"
            placeholder="Digite seu sobrenome..."
            title="Digite seu sobrenome"
            v-model="model.last_Name"
          />
        </div>
        <div class="col-md-3 col-lg-3 col-sm-12">
          <v-select-field
            icon="user"
            :options="type_person"
            v-model="model.type_Person"
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
            v-model="model.cpf_Cnpj"
            title="Digite seu documento"
          />
        </div>
        <div class="col-md-5 col-lg-4">
          <v-text-field
            type="tel"
            v-mask="['(##) ####-####', '(##) #####-####']"
            icon="phone"
            v-model="model.phone_Number"
            placeholder="(##) #####-####"
            title="Digite seu celular"
          />
        </div>
        <div class="col-md-3 col-lg-4 col-sm-12">
          <v-select-field
            icon="phone"
            :options="type_person"
            v-model="model.type_Number"
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
            v-model="model.zip_Code"
            title="CEP"
            @blur="getAddress"
          />
        </div>
        <div class="col-md-5 col-lg-7">
          <v-text-field
            placeholder="Logradouro"
            icon="map"
            v-model="model.address"
            title="Logradouro"
          />
        </div>
        <div class="col-md-3 col-lg-2 col-sm-12">
          <v-text-field
            placeholder="N°"
            icon="sort-numeric-up-alt"
            v-model="model.number"
            title="Número da residencia"
          />
        </div>
      </div>
      <div class="row">
        <div class="col-md-8 col-lg-8 col-sm-12">
          <v-text-field
            placeholder="Bairro..."
            icon="map"
            v-model="model.neighborhood"
            title="Bairro"
          />
        </div>
        <div class="col-md-4 col-lg-4 col-sm-12">
          <v-text-field
            placeholder="Complemento"
            icon="map-marked"
            v-model="model.complement"
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
            v-model="model.city"
          />
        </div>
        <div class="col-md-3 col-lg-2 col-sm-12">
          <v-text-field
            icon="city"
            placeholder="UF"
            title="Estado"
            v-model="model.uf"
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
            <v-icon :icon="model.id > 0 ? 'edit' : 'save'" />
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
        first_Name: "",
        last_Name: "",
        type_Person: "",
        cpf_Cnpj: "",
        phone_Number: "",
        type_Number: "",
        zip_Code: "",
        address: "",
        neighborhood: "",
        number: 0,
        complement: "",
        city: "",
        uf: "",
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
      if (this.model.first_Name && this.model.last_Name) {
        let res;
        if (this.model.id > 0) {
          res = this.$http.put(`/api/client/edit/${this.model.id}`, this.model);
        } else {
          res = this.$http.post("/api/client", this.model);
        }
        res
          .then((res) => {
            if (res.data.result) {
              alert(
                `${
                  this.model.id > 0
                    ? "Cliente atualizado com sucesso"
                    : "Cliente cadastrado com sucesso"
                }`
              );
              this.$router.back();
            } else {
              console.error(res.data.errorMessage);
            }
          })
          .catch((err) => console.error(err));
      } else {
        alert("Por favor Informe seu nome e sobrenome");
      }
    },
    getAddress() {
      if (this.model.zip_Code) {
        axios
          .get(`https://viacep.com.br/ws/${this.model.zip_Code}/json/`)
          .then((res) => {
            this.model.zip_Code = res.data.cep;
            this.model.city = res.data.localidade;
            this.model.uf = res.data.uf;
            this.model.neighborhood = res.data.bairro;
            this.model.address = res.data.logradouro;
          });
      }
    },
    setModel(data) {
      console.log(data);
      this.model.id = data.id;
      this.model.first_Name = data.first_Name;
      this.model.last_Name = data.last_Name;
      this.model.cpf_Cnpj = data.cpf_Cnpj;
      this.model.phone_Number = data.phone_Number;
      this.model.type_Person = data.type_Person;
      this.model.address = data.address;
      this.model.number = data.number;
      this.model.type_Number = data.type_Number;
      this.model.zip_Code = data.zip_Code;
      this.model.city = data.city;
      this.model.uf = data.uf;
      this.model.neighborhood = data.neighborhood;
    },
    clearModel() {
      if (confirm("Deseja realmente limpar o formulário?")) {
        this.model.first_Name = "";
        this.model.last_Name = "";
        this.model.cpf_Cnpj = "";
        this.model.phone_Number = "";
        this.model.type_Person = "";
        this.model.address = "";
        this.model.number = "";
        this.model.type_Number = "";
        this.model.zip_Code = "";
        this.model.city = "";
        this.model.uf = "";
        this.model.neighborhood = "";
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
