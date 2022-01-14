using System;
using System.Collections.Generic;
using HamburgerShop.Infrastructure.Entities;

namespace HamburgerShop.Presentation.Responses
{
    public class OrderResponse
    {
        /// <summary>注文リスト</summary>
        public List<Orders> orderList { get; set; } = new List<Orders>();
    }
}
