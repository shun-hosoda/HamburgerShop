<template>
  <v-container>
    <v-row justify="center" class="mt-2">
      <v-col cols="12" md="8">
        <!-- メニュー -->
        <v-card class="mb-10">
          <v-card-title 
          class="headline justify-center blue-grey lighten-1 white--text text-h4 font-weight-bold">
            MENU
          </v-card-title>
          <v-row class="ma-0 px-5">
            <v-col cols="12">
              <!-- オーダータイプ -->
              <v-radio-group v-model="orderTypeRadio" row mandatory>
                <v-radio
                  v-for="orderType in orderTypes"
                  :key="orderType.id"
                  :label="orderType.name"
                  :value="orderType.id"
                  @change="onChangeOrderType(orderType)"
                ></v-radio>
              </v-radio-group>
              <!-- /オーダータイプ -->
            </v-col>
          </v-row>
          <v-row class="ma-0 px-5">
            <!-- 商品 -->
            <v-col  cols="4" v-for="item in items" v-bind:key="item.id" class="mb-4">
              <v-card height="100%">
                <v-div class="pa-5 d-flex justify-center">
                  <v-img
                  max-height="auto"
                  :src=item.imgLink
                ></v-img>
                </v-div>
                
                <v-divider></v-divider>
                <v-card-title style="font-size: 1rem !important; font-weight: 600;">{{item.name}}</v-card-title>
                <v-card-text>
                  <v-row>
                    <v-col class="d-flex align-center">
                      {{item.taxIncludedPrice}}円(税込み)
                    </v-col>
                    <v-col class="d-flex align-center justify-end">
                      <v-btn
                      fab
                      dark
                      color="indigo"
                      small
                      @click="onClickAddItem(item)"
                      >
                        <v-icon dark>
                          mdi-plus
                        </v-icon>
                      </v-btn>
                    </v-col>
                  </v-row>
                </v-card-text>
              </v-card>
            </v-col>
            <!-- /商品 -->
          </v-row>
        </v-card>
        <!-- /メニュー -->
        <!-- オーダー -->
        <v-card>
          <v-card-title 
          class="headline justify-center grey white--text text-h4 font-weight-bold">
            ORDER
          </v-card-title>
          <v-row  class="ma-0">
            <v-col cols="12">
              <!-- 支払タイプ -->
              <v-radio-group v-model="paymentTypeRadio" row mandatory>
                <v-radio
                  v-for="paymentType in paymentTypes"
                  :key="paymentType.id"
                  :label="paymentType.name"
                  :value="paymentType.id"
                ></v-radio>
              </v-radio-group>
              <!-- /支払タイプ -->
            </v-col>
          </v-row>
          <v-row  class="ma-0">
            <v-col>
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
            </v-col>
          </v-row>
          <v-row  class="ma-0">
            <v-col>
              <v-btn color="primary" @click="purchase()">
                購入
              </v-btn>
            </v-col>
          </v-row>
        </v-card>
        <!-- /オーダー -->
      </v-col>
    </v-row>
  </v-container>
</template>

<script lang="ts">
  //import Vue from 'vue'
  import { Component, Prop, Vue } from "vue-property-decorator";
  import { DataTableHeader } from "vuetify";
  import http from "@/HttpTools/http-common";

  interface OrderType{
    id: number,
    name: string,
    taxId: number
  }

  interface PaymentType{
    id: number,
    name: string,
  }
  interface TaxType{
    id: number,
    rate: number
  }
  interface Item{
    id: number,
    name: string,
    unitPrice: number,
    taxIncludedPrice: number,
    imgLink: string
  }

  interface Order{
    id: number,
    itemName: string,
    quantity: number,
    unitPrice: number,
    totalPrice: number,
    tax: number
  }
  @Component({
    // conponentsは@Componentデコレータの引数に渡す
    components: {
    },
  })
  export default class HellowWorld extends Vue{
    orderTypeRadio = 1
    paymentTypeRadio = 1
    orderTypes: OrderType[] = []
    paymentTypes: PaymentType[] = []
    taxTypes: TaxType[] = []
    taxTypeId = 0
    taxRate = 0
    items: Item[] = []
    orders: Order[] = []
    orderTotal = 0
    orderTax = 0
    headers: DataTableHeader[] = [
      { text: '商品名', align: 'start', value: 'itemName', width: "40%" },
      { text: '個数', sortable: false, value: 'quantity', width: "10%" }, 
      { text: '', sortable: false, value: 'actions', width: "20%" }, 
      { text: '価格', sortable: false, value: 'totalPrice', width: "30%" },
    ]
    orderType1: OrderType = {
      id: 1,
      name: "店内",
      taxId: 2
    }
    orderType2: OrderType = {
      id: 2,
      name: "持ち帰り",
      taxId: 1
    }
    paymentType1: PaymentType = {
      id: 1,
      name: "現金"
    }
    paymentType2: PaymentType = {
      id: 2,
      name: "クレジット"
    }
    paymentType3: PaymentType = {
      id: 3,
      name: "QRコード"
    }
    taxType1: TaxType ={
      id: 1,
      rate: 0.08
    }
    taxType2: TaxType ={
      id: 2,
      rate: 0.1
    }
    item1: Item = {
      id: 1,
      name: "ハンバーガー",
      unitPrice: 100,
      taxIncludedPrice: 0,
      imgLink: "",
    }
    item2: Item = {
      id: 2,
      name: "チーズバーガー",
      unitPrice: 120,
      taxIncludedPrice: 0,
      imgLink: "",
    }
    item3: Item = {
      id: 3,
      name: "フィレオフィッシュ",
      unitPrice: 140,
      taxIncludedPrice: 0,
      imgLink: "",
    }
    item4: Item = {
      id: 4,
      name: "ダブルバーガー",
      unitPrice: 140,
      taxIncludedPrice: 0,
      imgLink: "",
    }
    created(){
      this.getMenuData()
    }
    async purchase(){
      console.log("RadioGroup", this.orderTypeRadio)
      console.log("SelectOrderType", this.orderTypes[this.orderTypeRadio - 1])
      const url = "/hamburgershop/order/register"
      let orderDetails: any = []
      this.orders.forEach((x) => {
        orderDetails.push({
          itemId: x.id, 
          quantity: x.quantity,
          total: x.totalPrice,
          tax: x.tax
          })
      })
      const param: any =
        {
          paymentTypeId: this.paymentTypeRadio,
          taxTipeId: this.taxTypeId,
          finalTotal: this.orderTotal,
          tax: this.orderTax,
          paymentAmount: this.orderTotal,
          paymentRefund: 0,
          OrderDetailDTOList: orderDetails
        }
      
      console.log("param", param)
      await http.post(url, param)
      .then(response => {
        console.log("getMenuDataResponse",response)
      })
      .catch((e) => {
        console.log("error",e)
      })
    }
    async getMenuData(){
      console.log("getMenuData")
      const url = "/hamburgershop/menu"
      await http.get(url)
      .then(response => {
        console.log("getMenuDataResponse",response)
        this.init(response.data)
      })
      .catch((e) => {
        console.log("error",e)
      })
    }
    // 初期画面設定
    init(menuData:any){
      let defaultOrderType: OrderType
      let taxType: TaxType
      // オーダータイプ設定
      menuData.orderTypeList.forEach(el => {
        let orderType: OrderType ={
          id: el.orderTypeId,
          name: el.orderTypeName,
          taxId: el.taxId
        }
        this.orderTypes.push(orderType)
        if(el.orderTypeId === this.orderTypeRadio){
          defaultOrderType = el
        }
      });
      // 支払タイプ設定
      menuData.paymentTypeList.forEach(el => {
        let paymentType: PaymentType ={
          id: el.paymentTypeId,
          name: el.paymentTypeName,
        }
        this.paymentTypes.push(paymentType)
      });
      // 消費税設定
      menuData.taxTypeList.forEach(el => {
        let taxType: TaxType ={
          id: el.taxId,
          rate: el.taxRate,
        }
        this.taxTypes.push(taxType)
        if(el.taxId === defaultOrderType.taxId){
          this.taxRate = el.taxRate
        }
      });
      // 商品設定
      menuData.itemList.forEach(el => {
        let item: Item ={
          id: el.itemId,
          name: el.itemName,
          unitPrice: el.itemPrice,
          taxIncludedPrice: this.calcTaxIncludedPrice(el.itemPrice),
          imgLink: el.imageLink
        }
        this.items.push(item)
      });
    }
    /**
     * オーダータイプ変更
     */
    onChangeOrderType(orderType:OrderType){
      // オーダータイプから消費税率取得
      const taxType = this.taxTypes.find((x) => x.id === orderType.taxId)
      // 消費税率設定
      this.taxRate = taxType === undefined ? 0 : taxType.rate
      this.taxTypeId = taxType === undefined ? 0 : taxType.id
      // メニューの消費税込み価格の変更
      this.items.forEach((x) => {
        x.taxIncludedPrice = this.calcTaxIncludedPrice(x.unitPrice)
      })
      // 注文の消費税込み価格の変更
      this.orders.forEach((x) => {
        // 税込み価格取得
        const taxIncludedPrice = this.calcTaxIncludedPrice(x.unitPrice)
        // 商品単位の合計設定 個数*税込み価格
        x.totalPrice = x.quantity * taxIncludedPrice
        // 消費税額
        x.tax = x.totalPrice - (x.quantity * x.unitPrice)
      })
      // 合計額計算
      this.calcTotalPrice()
    }
    /**
     * 注文追加
     */
    onClickAddItem(item:Item){
      // 注文一覧に対象商品があるか検索
      const targetItem = this.orders.find((x) => x.id === item.id)
      if(targetItem != undefined){
        // 注文一覧に対象商品がある場合

        // 個数プラス1
        targetItem.quantity++
        // 税込み価格取得
        const taxIncludedPrice = this.calcTaxIncludedPrice(targetItem.unitPrice)
        // 商品単位の合計設定 個数*税込み価格
        targetItem.totalPrice = targetItem.quantity * taxIncludedPrice
        // 消費税額
        targetItem.tax = targetItem.totalPrice - (targetItem.quantity * targetItem.unitPrice)
      }else{
        // 注文一覧に対象商品がない場合

        // 注文情報設定
        let order: Order = {
          id: item.id, 
          itemName: item.name, 
          quantity: 1, 
          unitPrice: item.unitPrice, 
          totalPrice: item.taxIncludedPrice, 
          tax: item.taxIncludedPrice - item.unitPrice
        }

        // 注文一覧に追加
        this.orders.push(order)
      }
      // 合計額計算
      this.calcTotalPrice()
    }
    /**
     * 個数追加
     */
    onClickPlus(order:Order){
      // 個数プラス1
      order.quantity++
      // 税込み価格取得
      const taxIncludedPrice = this.calcTaxIncludedPrice(order.unitPrice)
      // 商品単位の合計設定 個数*税込み価格
      order.totalPrice = order.quantity * taxIncludedPrice
      // 消費税額
      order.tax = order.totalPrice - (order.quantity * order.unitPrice)
      // 合計額計算
      this.calcTotalPrice()
    }
    /**
     * 個数減らす
     */
    onClickMinus(order:Order){
      // 個数マイナス1
      order.quantity--
      // 個数が0以下の場合は注文一覧から削除
      if(order.quantity <= 0){
        this.orders = this.orders.filter((x) => x.id !== order.id)
      }else{
        // 税込み価格取得
        const taxIncludedPrice = this.calcTaxIncludedPrice(order.unitPrice)
        // 商品単位の合計設定 個数*税込み価格
        order.totalPrice = order.quantity * taxIncludedPrice
        // 消費税額
        order.tax = order.totalPrice - (order.quantity * order.unitPrice)
      }
      // 合計額計算
      this.calcTotalPrice()
    }
    /**
     * 税込み価格計算
     */
    calcTaxIncludedPrice(price:number){
      // 税込み価格計算
      return  Math.floor(price + (price * this.taxRate))
    }
    /**
     * 注文合計計算
     */
    calcTotalPrice(){
      let total = 0
      let tax = 0
      this.orders.forEach((x) => {
        total = total + x.totalPrice
        tax = tax + x.tax
      })
      this.orderTotal = total
      this.orderTax = tax
    }
  }
</script>
