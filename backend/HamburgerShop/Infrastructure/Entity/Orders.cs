using System;
using System.Collections.Generic;

namespace HamburgerShop.Infrastructure.Entity
{
    public partial class Orders
    {
        public int OrderId { get; set; }
        public int PaymentTypeId { get; set; }
        public string OrderNumber { get; set; }
        public int FinalTotal { get; set; }
        public int Tax { get; set; }
    }
}
