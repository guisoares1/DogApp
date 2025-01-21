<template>
  <v-app>
    <v-container>
      <h1>Dogs app</h1>
      <data-grid />
    </v-container>
  </v-app>
</template>

<script lang="ts">
import { defineComponent } from "vue";
import DataGrid from "./components/DataGrid.vue"; 

export default defineComponent({
  name: "App",
  components: {
    DataGrid, 
  },
});
</script>

<style>

</style>
