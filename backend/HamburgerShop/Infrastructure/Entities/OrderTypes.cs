using System;
using System.Collections.Generic;

namespace HamburgerShop.Infrastructure.Entities
{
    public partial class OrderTypes
    {
        public int OrderTypeId { get; set; }
        public string OrderTypeName { get; set; }
        public int TaxId { get; set; }
        public int DisplayOrder { get; set; }
    }
}
