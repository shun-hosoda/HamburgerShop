<template>
  <v-tabs centered class="mt-4">
    <v-tab href="#tab-1">メニュー</v-tab>
    <v-tab href="#tab-2">注文履歴</v-tab>
    <v-tab-item value="tab-1">
      <order-menu />
    </v-tab-item>
    <v-tab-item value="tab-2">
      <history />
    </v-tab-item>
  </v-tabs>
</template>

<script lang="ts">
  import Vue from 'vue'
  import OrderMenu from '../components/OrderMenu.vue'
  import History from '../components/History.vue'

  export default Vue.extend({
    name: 'Home',

    components: {
      OrderMenu,
      History
    },
  })
</script>
