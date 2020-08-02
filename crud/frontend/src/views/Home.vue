<template>
  <div class="home" :class="{ hide__aside: !isToggle }">
    <header class="header">
      <div class="header__container-icon" @click="toggleMenu">
        <v-icon :icon="icon" />
      </div>
    </header>
    <aside class="aside"></aside>
    <main class="content"></main>
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
  },
  methods: {
    toggleMenu() {
      this.$store.commit("setToggle");
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

.content {
  grid-area: content;
  background-color: var(--bg-color);
}
.footer {
  grid-area: footer;
  background-color: var(--primary-color);
}
</style>
