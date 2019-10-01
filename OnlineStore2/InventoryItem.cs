using System;
using System.Collections.Generic;
using System.Text;

namespace Online_Store
{
    class InventoryItem
    {
        public int ProductNumber { get; set; }
        public string ProductName { get; set; }
        public int InventoryQuanity { get; set; }
        public string Seller { get; set; }
        public decimal Price { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
