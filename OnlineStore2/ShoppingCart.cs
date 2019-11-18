using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OnlineStore2;

namespace Online_Store
{
    
    class ShoppingCart : InventoryItem
    {
        #region properties
        private static int totalCartItems = 0;
        public int quantity { get; private set; }
        public int cartItemNumber { get; private set; }
        #endregion

        #region private objects    
        private static List<ShoppingCart> Cart = new List<ShoppingCart>();
        #endregion

        #region Methods

        //Private Methods
        private static int updateTotalItemsInCartNumber()
        {
            totalCartItems++;
            return totalCartItems;
        }

        //Private Void Methods
        private static void addItemToCart(InventoryItem item, int quantity)
        {
            //check cart first to see if an item already exists, if it does update the quanity, if it does not add it
            var checkCart = Cart.Where(i => i.ProductNumber == item.ProductNumber);
            if (checkCart.Count() == 0)
            {
                ShoppingCart cartItem = new ShoppingCart();
                cartItem.ProductName = item.ProductName;
                cartItem.ProductNumber = item.ProductNumber;
                cartItem.Price = item.Price;
                cartItem.Seller = item.Seller;
                cartItem.quantity = quantity;
                cartItem.cartItemNumber = updateTotalItemsInCartNumber();
                Cart.Add(cartItem);
            }

        }
        private static void removeItemFromCart(InventoryItem item, int quantity)
        {
            //Get current cart
            var currentCart = Cart;
            var itemToRemove = currentCart.Where(i => i.ProductNumber == item.ProductNumber);
            if (itemToRemove.Count() != 0)
            {
                foreach (ShoppingCart i in itemToRemove)
                {
                    if (i.quantity < quantity)
                    {
                        Cart.Remove(i);
                    }
                    else
                    {
                        //Remove old item first, update the quantity, add updated item
                        Cart.Remove(i);
                        i.quantity = i.quantity - quantity;
                        Cart.Add(i);
                    }
                }
            }
            else
            {
                Console.WriteLine("item not found in cart: " + item.ProductName);
            }
        }

        //Public Void Methods
        public static void ItemToCartPrompt()
        {
            Console.Clear();
            Console.WriteLine("Please provide the following product information");

            Console.Write("Product Number:");
            string productNumberInput = Console.ReadLine();
            int productNumber = Int32.Parse(productNumberInput);

            Console.Write("Quantity:");
            string productQuantityInput = Console.ReadLine();
            int productQuantity = Int32.Parse(productQuantityInput);

            var productToAdd = InventoryItem.getProductByNumber(productNumber);
            switch (productToAdd.Count())
            {
                case 0:
                    Console.WriteLine("Could not find product with the number " + productNumber.ToString());
                    break;

                case 1:
                    foreach (InventoryItem i in productToAdd)
                    {
                        addItemToCart(i, productQuantity);
                        Console.WriteLine(productQuantityInput + " " + i.ProductName + " succesfully added to cart");
                    }
                    break;

                default:
                    Console.WriteLine("Error: duplicate products with the same number found!");
                    break;
            }
            MenuActions.returnToMainMenu();
        }
        public static void removeItemFromCartPrompt()
        {
            Console.WriteLine("Please provide the product number of the item you would like to remove from your cart, along with the quantity.");
            var itemsInCart = getAllCartItems();
            if (itemsInCart.Count() > 0)
            {
                foreach (ShoppingCart cartItem in itemsInCart)
                {
                    Console.WriteLine("####################");
                    Console.WriteLine("Product Name: " + cartItem.ProductName);
                    Console.WriteLine("Product Number: " + cartItem.ProductNumber);
                    Console.WriteLine("Current Quantity: " + cartItem.quantity);
                    Console.WriteLine("####################");
                    Console.WriteLine();
                }
                Console.Write("Product Number:");
                string productNumberInput = Console.ReadLine();
                int productNumber = Int32.Parse(productNumberInput);

                Console.Write("Quantity:");
                string productQuantityInput = Console.ReadLine();
                int productQuantity = Int32.Parse(productQuantityInput);

            }

        }
        public static void purchaseItemsInCart()
        {
            foreach (ShoppingCart item in Cart)
            {
                //Check the inventory, confirm it's the corret item, and validate enough items are in stock to purchase
                //There cannot be duplicate items from sellers

                var searchItem = InventoryItem.searchProductByName(item.ProductName);

                //if multiple items found in inventory
                if (searchItem.Count() > 1)
                {
                    var specificItemFromSeller = searchItem.Where(i => i.ProductNumber == item.ProductNumber);
                    switch (specificItemFromSeller.Count())
                    {
                        case 1:
                            {
                                foreach (InventoryItem i in specificItemFromSeller)
                                {
                                    if (i.InventoryQuanity == 0)
                                    {
                                        Console.WriteLine("Error, purchase of item: " + i.ProductName + " not possilbe, currently out of stock");
                                    }
                                    else
                                    {
                                        InventoryItem.updateInventoryItem(i, item.quantity);
                                    }
                                }
                                return;
                            }
                        case 0:
                            {
                                Console.WriteLine("Error: item not found in store, item from seller may no longer be available");
                                return;
                            }

                        default:
                            {
                                Console.WriteLine("Error: duplicate items found from seller!");
                                return;
                            }
                    }
                }
                else
                {
                    foreach (InventoryItem i in searchItem)
                    {
                        if (i.InventoryQuanity == 0)
                        {
                            Console.WriteLine("Error, purchase of item: " + i.ProductName + " not possilbe, currently out of stock");
                        }
                        else
                        {

                        }
                    }
                }
                foreach (InventoryItem i in searchItem)
                {

                }
            }
        }

        //Public Methods
        public static IEnumerable<ShoppingCart> getAllCartItems()
        {
            return Cart;
        }
       
        
        #endregion
    }
}
