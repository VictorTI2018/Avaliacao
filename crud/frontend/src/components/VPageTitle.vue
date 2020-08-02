<template>
  <div class="page__title-container">
    <span class="page__title-title">{{ title }}</span>
  </div>
</template>

<script>
export default {
  name: "VPageTitle",
  props: {
    title: String,
  },
};
</script>

<style>
.page__title-container {
  height: 40px;
  display: flex;
  padding: 0 8px;
  border-bottom: 2px solid rgb(90, 89, 89);
  align-items: center;
  margin-bottom: 15px;
}

.page__title-title {
  font-size: 0.9rem;
  font-weight: bold;
  color: rgb(90, 89, 89);
}
</style>
