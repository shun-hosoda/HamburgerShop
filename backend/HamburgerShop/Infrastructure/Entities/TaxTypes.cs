using System;
using System.Collections.Generic;

namespace HamburgerShop.Infrastructure.Entities
{
    public partial class TaxTypes
    {
        public int TaxId { get; set; }
        public double TaxRate { get; set; }
    }
}
