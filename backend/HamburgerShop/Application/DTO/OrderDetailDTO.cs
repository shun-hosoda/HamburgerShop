using System;
namespace HamburgerShop.Application.DTO
{
    public class OrderDetailDTO
    {
        /// <summary>商品ID</summary>
        public int ItemId { get; set; }
        /// <summary>商品名</summary>
        public string ItemName { get; set; }
        /// <summary>注文数</summary>
        public int Quantity { get; set; }
        /// <summary>合計</summary>
        public int Total { get; set; }
        /// <summary>消費税</summary>
        public int Tax { get; set; }
    }
}
