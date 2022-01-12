<template>
  <v-tabs>
    <v-tab href="#tab-1">One</v-tab>
    <v-tab href="#tab-2">Two</v-tab>

    <v-tab-item value="tab-1">
      <hello-world />
    </v-tab-item>
    <v-tab-item value="tab-2">
      <history />
    </v-tab-item>
  </v-tabs>
  
</template>

<script lang="ts">
  import Vue from 'vue'
  import HelloWorld from '../components/HelloWorld.vue'
  import History from '../components/History.vue'

  export default Vue.extend({
    name: 'Home',

    components: {
      HelloWorld,
      History
    },
  })
</script>
