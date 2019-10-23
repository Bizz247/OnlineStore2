using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Online_Store
{

    class InventoryItem
    {
        private static List<InventoryItem> inventoryDatabase = new List<InventoryItem>();

        public int ProductNumber { get; set; }
        public string ProductName { get; set; }
        public int InventoryQuanity { get; set; }
        public string Seller { get; set; }
        public decimal Price { get; set; }
        public DateTime CreatedDate { get; set; }

        public static void addInvetoryItem()
        {

        }
        public static void delInventoryItem()
        {

        }
        public static IEnumerable<InventoryItem>searchProductByName(string productname)
        {
            return inventoryDatabase.Where(a => a.ProductName.Contains(productname));
        }
    }
    
}
