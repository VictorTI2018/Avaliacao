<template>
  <div class="home">
    <header class="header"></header>
    <aside class="aside"></aside>
    <main class="content"></main>
    <footer class="footer"></footer>
  </div>
</template>

<script>
export default {
  name: "Home",
};
</script>

<style>
.home {
  height: 100vh;
  display: grid;
  grid-template-areas: "aside header" "aside content" "aside footer";
  grid-template-rows: 50px 1fr 60px;
  grid-template-columns: 230px 1fr ;
}

.header {
  grid-area: header;
  background-color: var(--primary-color);
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
