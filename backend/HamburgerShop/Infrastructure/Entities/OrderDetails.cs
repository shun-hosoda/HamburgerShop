using System;
using System.Collections.Generic;

namespace HamburgerShop.Infrastructure.Entities
{
    public partial class OrderDetails
    {
        public int OrderDetailId { get; set; }
        public int OrderId { get; set; }
        public int ItemId { get; set; }
        public int Quantity { get; set; }
        public int Total { get; set; }
        public int Tax { get; set; }
    }
}
