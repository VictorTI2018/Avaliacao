import Vue from "vue";
import Vuex from "vuex";

Vue.use(Vuex);

export default new Vuex.Store({
  state: {
    isToggle: false,
  },
  mutations: {
    setToggle(state, isToggle) {
      if (isToggle === undefined) {
        state.isToggle = !state.isToggle;
      } else {
        state.isToggle = isToggle;
      }
    },
  },
  actions: {},
  modules: {},
});
