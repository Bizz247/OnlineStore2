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

        private static DateTime generateDateCreated()
        {
            DateTime date = DateTime.Now;
            return date;
        }
        public static void addInvetoryItem(int productNumber = 0,string productName = null,int quanity = 0, string seller = null, double price = 0, bool fromConsole = false)
        {
            InventoryItem item = new InventoryItem();
            if (!fromConsole)
            {
                item.CreatedDate = InventoryItem.generateDateCreated();
                item.InventoryQuanity = quanity;
                item.Price = price;
                item.ProductName = productName;
                item.ProductNumber = productNumber;
                item.Seller = seller;
                inventoryDatabase.Add(item);
            }
        }
        public static void delInventoryItem(InventoryItem Item)
        {
           var itemsToDelete = inventoryDatabase.Where(a => a.ProductName.Contains(Item.ProductName));
            if (itemsToDelete.Count() != 0)
            {
                foreach (InventoryItem item in itemsToDelete)
                {
                    inventoryDatabase.Remove(item);
                }
            }
            else
            {
                Console.Write("No items named " + Item.ProductName + " found.");
            }
            
        }
        public static void updateInventoryItem(InventoryItem productnumber, int quanity) 
        {
            var itemToUpdate = inventoryDatabase.Where(i => i.ProductNumber == productnumber.ProductNumber);
            foreach (InventoryItem i in itemToUpdate)
            {
                if (i.InventoryQuanity == 0)
                {
                    Console.WriteLine("Item: " + i.ProductNumber + ":" + i.ProductName + " out of stock.");
                    return;
                }
                if (i.InventoryQuanity < quanity)
                {
                    Console.WriteLine("Unable to proceess transaction for item: " + i.ProductName + " purchase quanity: " + quanity + " inventory quanity: " + i.InventoryQuanity);
                    Console.WriteLine("Please reduce quanity to " + quanity + " or less");
                    return;
                }
                if (i.InventoryQuanity > quanity)
                {
                    InventoryItem updatedItem = new InventoryItem();
                    updatedItem.InventoryQuanity = i.InventoryQuanity - quanity;
                    updatedItem.Price = i.Price;
                    updatedItem.ProductName = i.ProductName;
                    updatedItem.ProductNumber = i.ProductNumber;
                    updatedItem.Seller = i.Seller;
                    updatedItem.CreatedDate = i.CreatedDate;
                    InventoryItem.delInventoryItem(i);
                    InventoryItem.addInvetoryItem(updatedItem.ProductNumber, updatedItem.ProductName, updatedItem.InventoryQuanity, updatedItem.Seller, updatedItem.Price);
                }
            }
        }
        public static IEnumerable<InventoryItem> getAllInventoryItems()
        {
            return inventoryDatabase;
        }
        public static IEnumerable<InventoryItem>searchProductByName(string productname)
        {
            return inventoryDatabase.Where(a => a.ProductName.Contains(productname));
        }
        public static IEnumerable<InventoryItem>getProductByNumber(int productNumber)
        {
            return inventoryDatabase.Where(i => i.ProductNumber == productNumber);
        }
        public static void preloadInventoryOnStart()
        { 
            addInvetoryItem(1, "Red Apple", 20, "Apple an Apple Inc.", 0.50);
            addInvetoryItem(2, "Oranges", 5, "Californiaproduce.com", 1.00);
            addInvetoryItem(3, "0day RCE against azure", 1, "Microstux", 1000000.00);
        }
    }
    
}
