<template>
  <v-container>
    <v-row justify="center" class="mt-2">
        <v-col cols="12">
           <v-row>
                <v-col cols="4">
                    <v-card class="px-3">
                        <v-subheader class="pa-0">注文ID</v-subheader>
                        <v-list>
                            <v-list-item-group
                                v-model="selectedItem"
                                color="primary"
                            >
                                <v-list-item
                                v-for="(order, i) in orders"
                                :key="i"
                                class="pa-0"
                                >
                                    <v-list-item-content>
                                        <v-list-item-title v-text="order.id"></v-list-item-title>
                                    </v-list-item-content>
                                </v-list-item>
                            </v-list-item-group>
                        </v-list>
                    </v-card>
                </v-col>
                <v-col  cols="8">
                    <v-card class="px-3 pb-3">
                        <v-subheader class="pa-0">注文ID</v-subheader>
                        <!-- オーダー一覧 -->
                        <v-data-table
                            dense
                            :headers="headers"
                            :items="orders"
                            item-key="name"
                            class="elevation-1"
                            :footer-props="{'items-per-page-text':'', 'items-per-page-options':[],'show-first-last-page':true}"
                        >
                        <template v-slot:[`item.actions`]="{ item }">
                            <v-btn x-small fab color="primary" class="mr-2 my-2" @click.stop="onClickPlus(item)"><v-icon>mdi-plus</v-icon></v-btn>
                            <v-btn x-small fab color="error" @click.stop="onClickMinus(item)"><v-icon>mdi-minus</v-icon></v-btn>
                        </template>
                        <template v-slot:[`item.totalPrice`]="{ item }">
                            {{ item.totalPrice }}円(税込み)
                        </template>
                        <template v-slot:footer>
                            <v-divider></v-divider>
                            <div class="text-center my-2">
                            合計:{{ orderTotal }}円
                            </div>
                        </template>
                        </v-data-table>
                        <!-- /オーダー一覧 -->
                    </v-card>
                </v-col>
            </v-row>
        </v-col>
    </v-row>
  </v-container>
</template>

<script lang="ts">
  //import Vue from 'vue'
  import { Component, Prop, Vue } from "vue-property-decorator";
  import { DataTableHeader } from "vuetify";
  import http from "@/HttpTools/http-common";

  interface Order{
    id: number,
    totalPrice: number,
    tax: number
  }
  @Component({
    // conponentsは@Componentデコレータの引数に渡す
    components: {
    },
  })
  export default class HellowWorld extends Vue{
    orders: Order[] = []
    orderTotal = 0
    orderTax = 0
    selectedItem = 0
    headers: DataTableHeader[] = [
      { text: '商品名', align: 'start', value: 'itemName', width: "40%" },
      { text: '個数', sortable: false, value: 'quantity', width: "10%" }, 
      { text: '', sortable: false, value: 'actions', width: "20%" }, 
      { text: '価格', sortable: false, value: 'totalPrice', width: "30%" },
    ]
    
    order1: Order = {id: 1, totalPrice: 110, tax: 10} 
    order2: Order = {id: 2, totalPrice: 220, tax: 20} 
    created(){
        this.orders.push(this.order1)
        this.orders.push(this.order2)
    }
    
  }
</script>