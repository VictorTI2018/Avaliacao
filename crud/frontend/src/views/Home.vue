<template>
  <div class="home" :class="{ hide__aside: !isToggle }">
    <header class="header">
      <div class="header__container-icon" @click="toggleMenu">
        <v-icon :icon="icon" />
      </div>
    </header>
    <aside class="aside" v-show="isToggle">
      <div class="aside__top">
        Bebidas Express
      </div>
      <div class="aside__topnav">
        <router-link
          class="link"
          v-for="(item, index) in menu"
          :key="index"
          :to="item.to"
        >
          <v-icon :icon="item.icon" />
          {{ item.text }}
        </router-link>
      </div>
    </aside>
    <main class="content">
      <router-view></router-view>
    </main>
    <footer class="footer"></footer>
  </div>
</template>

<script>
import { mapState } from "vuex";
export default {
  name: "Home",
  computed: {
    ...mapState(["isToggle"]),
    icon() {
      return !this.isToggle ? "bars" : "angle-left";
    },
    menu() {
      return [{ icon: "user", ...this.menuName("clients") }];
    },
  },
  methods: {
    toggleMenu() {
      this.$store.commit("setToggle");
    },
    menuName(name) {
      const route = this.$router.resolve({ name }).route;
      return { to: route.path, text: route.meta.title };
    },
  },
};
</script>

<style>
.home {
  height: 100vh;
  display: grid;
  grid-template-areas: "aside header" "aside content" "aside footer";
  grid-template-rows: 50px 1fr 60px;
  grid-template-columns: 230px 1fr;
}

.home.hide__aside {
  grid-template-areas: "header header" "content content" "footer footer";
}

.header {
  grid-area: header;
  background-color: var(--primary-color);
  display: flex;
  padding: 0 20px;
  align-items: center;
}

.header__container-icon {
  height: 35px;
  width: 35px;
  display: flex;
  justify-content: center;
  align-items: center;
  color: var(--white-color);
  cursor: pointer;
}

.aside {
  grid-area: aside;
  background-color: var(--dark-color);
}

.aside__top {
  height: 50px;
  border-bottom: 1px solid var(--bg-color);
  display: flex;
  align-items: center;
  justify-content: center;
  color: var(--white-color);
  font-weight: bold;
}

.aside__topnav {
  overflow: hidden;
  background-color: #333;
  display: flex;
  justify-content: center;
}

.aside__topnav .link {
  color: #f2f2f2;
  text-align: center;
  padding: 14px 16px;
  text-decoration: none;
  font-size: 17px;
  width: 100%;
}

.aside__topnav .link:hover {
  border-left: 6px solid var(--primary-color);
  border-right: 6px solid var(--primary-color);
}

.content {
  grid-area: content;
  height: calc(100vh - 110px);
  padding: 25px;
  background-color: var(--bg-color);
  overflow-y: scroll;
}
.footer {
  grid-area: footer;
  background-color: var(--primary-color);
}
</style>
