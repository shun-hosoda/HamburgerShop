using System;
using System.Collections.Generic;

namespace HamburgerShop.Infrastructure.Entities
{
    public partial class Orders
    {
        public int OrderId { get; set; }
        public int PaymentTypeId { get; set; }
        public int TaxTypeId { get; set; }
        public string OrderNumber { get; set; }
        public int FinalTotal { get; set; }
        public int Tax { get; set; }
        public int PaymentAmount { get; set; }
        public int PaymentRefund { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
