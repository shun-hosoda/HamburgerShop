using System;
using System.Collections.Generic;

namespace HamburgerShop.Infrastructure.Entities
{
    public partial class PaymentTypes
    {
        public int PaymentTypeId { get; set; }
        public string PaymentTypeName { get; set; }
        public int DisplayOrder { get; set; }
    }
}
