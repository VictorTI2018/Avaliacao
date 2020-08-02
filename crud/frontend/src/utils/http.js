import Vue from "vue";
import VueAxios from "vue-axios";
import axios from "axios";
import axiosCancel from "axios-cancel";

const http = axios.create({
  baseURL: "https://localhost:5001",
});
axiosCancel(http);
Vue.use(VueAxios, http);

http.interceptors.request.use(
  (config) => {
    return config;
  },
  (error) => {
    return Promise.reject(error);
  }
);

export default http;
