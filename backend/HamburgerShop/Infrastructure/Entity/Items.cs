using System;
using System.Collections.Generic;

namespace HamburgerShop.Infrastructure.Entity
{
    public partial class Items
    {
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public int ItemPrice { get; set; }
        public string ImageLink { get; set; }
        public int DisplayOrder { get; set; }
    }
}
