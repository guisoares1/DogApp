<template>
    <v-container>
      <v-row>
        <v-col cols="12" md="4">
          <v-text-field
            v-model="search"
            label="Search by Name"
            prepend-icon="mdi-magnify"
            clearable
          />
        </v-col>
        <v-col cols="12" md="4">
          <v-btn color="primary" @click="fetchDogs">
            Refresh
          </v-btn>
        </v-col>
      </v-row>
  
      <v-row>
        <v-col
          v-for="(dog, index) in filteredDogs"
          :key="dog.dogId || index"
          cols="12"
          md="4"
        >
          <v-card>
            <v-card-title>{{ dog.name }}</v-card-title>
            <v-card-subtitle>
              {{ dog.minLife }} - {{ dog.maxLife }} years
            </v-card-subtitle>
            <v-card-text>{{ dog.description }}</v-card-text>
            <v-card-footer>
              <v-chip :color="dog.hypoallergenic ? 'green' : 'red'" dark>
                {{ dog.hypoallergenic ? 'Hypoallergenic' : 'Not Hypoallergenic' }}
              </v-chip>
            </v-card-footer>
          </v-card>
        </v-col>
      </v-row>
    </v-container>
  </template>
  
  <script lang="ts">
  import { defineComponent } from "vue";
  
  interface Dog {
    dogId: string;
    name: string;
    minLife: number;
    maxLife: number;
    description: string;
    hypoallergenic: boolean;
  }
  
  export default defineComponent({
    name: "DogList",
    data() {
      return {
        search: "",
        dogs: [] as Dog[], 
      };
    },
    computed: {
      filteredDogs(): Dog[] {
        return this.dogs.filter((dog: Dog) =>
          dog.name?.toLowerCase().includes(this.search.toLowerCase())
        );
      },
    },
    mounted() {
      this.fetchDogs();
    },
    methods: {
        fetchDogs(): void {
            fetch("https://localhost:7215/api/dog")
                .then((response) => {
                    if (!response.ok) {
                        throw new Error(`Error: ${response.status}`);
                    }
                    return response.json();
                    })
                .then((data) => {
                    if (data && Array.isArray(data.data)) {
                        this.dogs = data.data; 
                    } else {
                        this.dogs = []; 
                    }
                    })
                .catch((error) => console.error("Error", error));
        },
    },
  });
  </script>
  
  <style scoped>
  .v-container {
    margin-top: 20px;
  }
  
  .v-card {
    margin-bottom: 20px;
  }
  
  .v-btn {
    margin-top: 10px;
  }
  </style>
  