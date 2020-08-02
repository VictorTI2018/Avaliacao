<template>
  <span>
    <v-data-table
      :headers="headers"
      url="/api/client"
      :filter="true"
      :action="true"
    >
      <template v-slot:item="{ item }">
        <v-icon icon="edit" class="text-primary" @click="editar(item)"
        style="cursor:pointer;"/>
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
      console.log(item);
    },
  },
};
</script>
