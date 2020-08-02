import Vue from "vue";
import VueRouter from "vue-router";

import Home from "../views/Home.vue";
import Clients from "../views/Client/Clients";
import NewClient from "../views/Client/NewClient";

Vue.use(VueRouter);

const routes = [
  {
    path: "/",
    name: "Home",
    component: Home,
    children: [
      {
        path: "/",
        redirect: "/clients",
      },
      {
        path: "/clients",
        name: "clients",
        component: Clients,
        meta: { title: "Clientes" },
      },
      {
        path: "/new-client",
        name: "new-client",
        component: Clients,
        meta: { title: "Novo Cliente" },
      },
    ],
  },
];

const router = new VueRouter({
  mode: "history",
  base: process.env.BASE_URL,
  routes,
});

export default router;
