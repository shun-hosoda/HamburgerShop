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
                                        <v-list-item-title v-text="order.orderNumber"></v-list-item-title>
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
    orderNumber: string,
    total: number
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
  export default class History extends Vue{
    orders: Order[] = []
    orderDetails: OrderDetail[] = []
    orderTotal = 0
    selectedItem = 0
    selectedOrderId = -1
    headers: DataTableHeader[] = [
      { text: '商品名', align: 'start', value: 'itemName', width: "50%" },
      { text: '個数', sortable: false, value: 'quantity', width: "25%" }, 
      { text: '価格', sortable: false, value: 'totalPrice', width: "25%" },
    ]
    
    mounted(){
        this.getOrder()
    }
    /**
     * オーダー取得
     */
    getOrder(){
        const url = "/hamburgershop/order"
        http.get(url)
        .then(response => {
            this.setOrderTable(response.data)
            // オーダー履歴がある場合は配列の0番目のオーダー詳細取得
            if(0 < this.orders.length){
                this.getOrderDetail(this.orders[0])
            }
        })
        .catch((e) => {
            console.log("error",e)
        })
    }
    /**
     * オーダーリスト配列に設定
     */
    setOrderTable(data: any){
        data.orderList.forEach(el => {
        let order: Order = {
          id: el.orderId,
          orderNumber: el.orderNumber,
          total: el.finalTotal
        }
        this.orders.push(order)
      });
    }
    /**
     * オーダー詳細取得
     */
    getOrderDetail(order: Order){
        // 初期化
        this.orderDetails = []
        this.orderTotal = 0
        // 選択→選択解除の場合はリターン
        if(this.selectedOrderId === order.id){
            this.selectedOrderId = 0
            return
        }
        this.selectedOrderId = order.id
        const url = "/hamburgershop/orderDetail"
        const params: any =
            {
                params:{
                    orderId: order.id
                }
            }
        console.log("param", params)
        http.get(url, params)
        .then(response => {
            console.log("response",response)
            // オーダー詳細取得
            this.setOrderDetailTable(response.data)
            // 合計金額設定
            this.orderTotal = order.total
        })
        .catch((e) => {
            console.log("error",e)
        })
    }

    /**
     * オーダー詳細リスト配列に設定
     */
    setOrderDetailTable(data: any){
        data.orderDetailList.forEach(el => {
            console.log("setOrderDetailTable el", el)
            let orderDetail: OrderDetail = {
            id: el.orderDetailId,
            itemName: el.itemName,
            quantity: el.quantity,
            totalPrice: el.total
        }
        this.orderDetails.push(orderDetail)
      });
    }
    /**
     * オーダー選択時の処理
     */
    selectOrder(order: Order){
        // オーダー詳細取得
        this.getOrderDetail(order)
    }
  }
</script>