<template>
  <div id="app">
    <div class="main-menu">
      <TheHeader />
      <div class="container">
        <TheNav />
        <TheContent />
      </div>
    </div>
  </div>
</template>

<script setup>
import TheHeader from "./components/layout/TheHeader.vue";
import TheNav from "./components/layout/TheNav.vue";
import TheContent from "./components/layout/TheContent.vue";
</script>

<style>
@import url(./css/main.css);
</style>
