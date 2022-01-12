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
                                @click="selectOrder(order)"
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
                        <v-subheader class="pa-0">注文詳細</v-subheader>
                        <!-- オーダー一覧 -->
                        <v-data-table
                            dense
                            :headers="headers"
                            :items="orderDetails"
                            item-key="name"
                            class="elevation-1"
                            :footer-props="{'items-per-page-text':'', 'items-per-page-options':[],'show-first-last-page':true}"
                        >
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
  import { Component, Prop, Vue } from "vue-property-decorator";
  import { DataTableHeader } from "vuetify";
  import http from "@/HttpTools/http-common";

  interface Order{
    id: number,
    totalPrice: number,
    tax: number
  }

  interface OrderDetail{
    id: number,
    itemName: string,
    quantity: number,
    totalPrice: number,
  }
  @Component({
    components: {
    },
  })
  export default class HellowWorld extends Vue{
    orders: Order[] = []
    orderDetails: OrderDetail[] = []
    orderTotal = 0
    selectedItem = 0
    headers: DataTableHeader[] = [
      { text: '商品名', align: 'start', value: 'itemName', width: "50%" },
      { text: '個数', sortable: false, value: 'quantity', width: "25%" }, 
      { text: '価格', sortable: false, value: 'totalPrice', width: "25%" },
    ]
    
    order1: Order = {id: 1, totalPrice: 110, tax: 10} 
    order2: Order = {id: 2, totalPrice: 220, tax: 20} 

    created(){
        this.orders.push(this.order1)
        this.orders.push(this.order2)
    }

    selectOrder(order:Order){
        let orderDetail: OrderDetail = { id: 1, itemName: "ハンバーガー", quantity :1, totalPrice: 100}
        this.orderDetails.push(orderDetail)
    }
    
  }
</script>