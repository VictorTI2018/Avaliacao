<template>
  <div class="input-group mb-3">
    <div class="input-group-prepend">
      <span class="input-group-text">
        <v-icon v-if="icon" :icon="icon" />
      </span>
    </div>
    <input
      :type="type"
      class="form-control"
      :placeholder="placeholder"
      v-model="v_value"
       v-on:blur="$emit('blur', $event.target.value)"
    />
  </div>
</template>

<script>
export default {
  name: "VTextField",
  props: {
    value: {
      type: [Number, String, Object, Array, null],
    },
    placeholder: String,
    type: String,
    icon: String,
    onBlur: Function
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
