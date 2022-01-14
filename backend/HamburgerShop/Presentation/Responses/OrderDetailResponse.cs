using System;
using System.Collections.Generic;
using HamburgerShop.Infrastructure.Entities;

namespace HamburgerShop.Presentation.Responses
{
    public class OrderDetailResponse
    {
        /// <summary>注文詳細リスト</summary>
        public List<OrderDetails> orderDetailList { get; set; } = new List<OrderDetails>();
    }
}
