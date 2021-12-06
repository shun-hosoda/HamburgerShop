using System;
using System.Collections.Generic;

namespace HamburgerShop.Infrastructure.Entity
{
    public partial class OrderDetails
    {
        public int OrderDetailId { get; set; }
        public int OrderId { get; set; }
        public int OrderTypeId { get; set; }
        public int ItemId { get; set; }
        public int UnitPrice { get; set; }
        public int Quantity { get; set; }
        public int Discount { get; set; }
        public int Total { get; set; }
        public int Tax { get; set; }
        public int PaymentAmount { get; set; }
        public int PaymentRefund { get; set; }
    }
}
