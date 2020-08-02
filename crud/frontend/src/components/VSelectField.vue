<template>
  <div class="input-group mb-3">
    <div class="input-group-prepend">
      <span class="input-group-text">
        <v-icon :icon="icon" />
      </span>
    </div>
    <select class="form-control" v-model="v_value">
      <slot />
    </select>
  </div>
</template>

<script>
export default {
  name: "VSelectField",
  props: {
    value: {
      type: [Number, String, Object, Array, null],
    },
    options: [Array, Object, null],
    itemKey: String,
    itemValue: String,
    icon: String,
  },
  data() {
    return {
      v_value: "",
    };
  },
  watch: {
    value(val) {
      this.v_value = val;
    },
    v_value(val) {
      this.$emit("input", val);
    },
  },
  mounted() {
    this.v_value = this.value;
  },
};
</script>
