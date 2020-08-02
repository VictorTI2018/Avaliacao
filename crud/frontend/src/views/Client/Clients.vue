<template>
  <span>
    <v-page-title title="Lista de Clientes" />
    <div class="row mb-3">
      <div class="col-md-3 col-sm-3 col-lg-2">
        <button class="btn btn-success btn-block" @click="create">
          <v-icon icon="plus" />
        </button>
      </div>
    </div>
    <v-data-table
      :headers="headers"
      url="/api/client"
      :filter="true"
      :action="true"
    >
      <template v-slot:item="{ item }">
        <v-icon
          icon="edit"
          class="text-primary mr-2"
          @click="editar(item)"
          style="cursor:pointer;"
        />
        <v-icon
          icon="trash"
          class="text-danger ml-1"
          @click="remove(item)"
          style="cursor:pointer;"
        />
      </template>
    </v-data-table>
  </span>
</template>

<script>
export default {
  name: "Clients",
  data() {
    return {
      headers: [
        { label: "#", value: "id" },
        { label: "Nome", value: "first_Name" },
      ],
    };
  },
  methods: {
    editar({ item }) {
      this.$router.push({ name: "new-client", params: { id: item.id } });
    },
    remove({ item }) {
      if (confirm("Deseja excluir esse cliente ?")) {
        this.$http
          .delete(`/api/client/${item.id}`)
          .then((res) => {
            if (res.data.result) {
              alert("Cliente excluido com sucesso");
              window.location.reload();
            }
          })
          .catch((err) => console.error(err));
      }
    },
    create() {
      this.$router.push("/new-client");
    },
  },
};
</script>
