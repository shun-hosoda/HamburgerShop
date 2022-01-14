using System;
namespace HamburgerShop.Application.DTO
{
    public class OrderDTO
    {
        public OrderDTO()
        {
        }
        // オーダーID
        public int OrderId { get; set; }
        // オーダー番号
        public string OrderNumber { get; set; }
    }
}
