<template>
  <div>
    <div class="row" v-if="filter">
      <div class="col-md-12">
        <v-text-field
          icon="search"
          placeholder="Digite para buscar"
          v-model="search"
        />
      </div>
    </div>
    <table class="table table-striped table-hover">
      <thead>
        <tr>
          <th v-for="(header, index) in headers" :key="index">
            {{ header.label }}
          </th>
          <th v-if="action">Ações</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="(item, index) in filtered" :key="index">
          <td v-for="(h, key) in headers" :key="key">{{ item[h.value] }}</td>
          <td v-if="action">
            <slot name="item" v-bind:item="{ item }" />
          </td>
        </tr>
      </tbody>
    </table>
  </div>
</template>

<script>
import { debounce } from "lodash";
export default {
  name: "VDataTable",
  props: {
    url: {
      type: String,
    },
    headers: {
      type: Array,
    },
    action: {
      type: Boolean,
    },
    filter: {
      type: Boolean,
    },
  },
  data() {
    return {
      items: [],
      search: "",
    };
  },
  computed: {
    filtered() {
      if (this.search) {
        return this.items.filter((res) => {
          res = Object.values(res);
          for (let i = 0; i < res.length; i++) {
            if ((res[i] + "").toLowerCase().indexOf(this.search) >= 0) {
              return true;
            }
          }
          return false;
        });
      }
      return this.items;
    },
  },
  methods: {
    reload: debounce(function() {
      this.$http
        .get(this.url)
        .then((res) => {
          console.log(res)
          this.items = res.data;
        })
        .catch((err) => {
          console.error(Object.values(err));
        });
    }, 10),
  },
  mounted() {
    if (!this.url && !this.headers) {
      console.error(
        "Props url and headers is required in component VDataTable"
      );
    } else {
      this.reload();
    }
  },
};
</script>

<style>
.table tr,
th {
  text-align: center;
}
</style>
