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
        public double Price { get; set; }
        public DateTime CreatedDate { get; private set; }

        public static void addInvetoryItem(int productNumber,string productName,int quanity, string seller, double price)
        {
            InventoryItem item = new InventoryItem();
            item.CreatedDate = InventoryItem.generateDateCreated();
            item.InventoryQuanity = quanity;
            item.Price = price;
            item.ProductName = productName;
            item.ProductNumber = productNumber;
            item.Seller = seller;
            inventoryDatabase.Add(item);
        }
        public static void delInventoryItem(string productname)
        {
           var itemsToDelete = inventoryDatabase.Where(a => a.ProductName.Contains(productname));
            if (itemsToDelete.Count() != 0)
            foreach (InventoryItem item in itemsToDelete){
                inventoryDatabase.Remove(item);
            }
            else
            {
                Console.Write("No items named " + productname + " found.");
            }
            
        }
        public static DateTime generateDateCreated()
        {
            DateTime date = DateTime.Now;
            return date;
        }
        public static IEnumerable<InventoryItem>searchProductByName(string productname)
        {
            return inventoryDatabase.Where(a => a.ProductName.Contains(productname));
        }
        public static void preloadInventoryOnStart()
        { 
            addInvetoryItem(1, "Red Apple", 20, "Apple an Apple Inc.", 0.50);
            addInvetoryItem(2, "Oranges", 5, "Californiaproduce.com", 1.00);
            addInvetoryItem(3, "0day RCE against azure", 1, "wouldn't you like to know", 1000000.00);
        }
    }
    
}
