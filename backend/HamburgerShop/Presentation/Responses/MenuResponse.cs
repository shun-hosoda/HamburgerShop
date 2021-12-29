using System;
using System.Collections.Generic;
using HamburgerShop.Infrastructure.Entities;

namespace HamburgerShop.Presentation.Responses
{
    public class MenuResponse
    {
        /// <summary>商品リスト</summary>
        public List<Items> itemList { get; set; }
        /// <summary>注文区分</summary>
        public List<OrderTypes> orderTypeList { get; set; }
        /// <summary>消費税区分</summary>
        public List<TaxTypes> taxTypeList { get; set; }
        /// <summary>支払タイプリスト</summary>
        public List<PaymentTypes> paymentTypeList { get; set; }
    }
}
