using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Online_Store;

namespace OnlineStore2
{
    static class MenuActions
    {
        #region MenuOption
        public static string ShowMainMenu()
        {
            Console.Clear();
            Console.WriteLine("Please select and option of what you would like to do");
            Console.WriteLine("1. Add a new user");
            Console.WriteLine("2. Get all users");
            Console.WriteLine("3. Search for a user by email");
            Console.WriteLine("4. Delete user");
            Console.WriteLine("5. View store inventory");
            Console.WriteLine("6. View Shopping Cart");
            Console.WriteLine("7. Add item to shopping cart");
            Console.WriteLine("8. Remove item from shopping cart");
            Console.WriteLine("9. Purchase items in cart");
            Console.WriteLine("10. Exit");
            var option = Console.ReadLine();
            Console.WriteLine("");
            return option;
        }

        public static void featureComingSoon()
        {
            Stopwatch startSleep = new Stopwatch();
            Console.Clear();
            startSleep.Start();
            Console.WriteLine("feature coming soon!");
            while (startSleep.Elapsed.TotalSeconds < 3) { };
            startSleep.Stop();
            Console.Clear();
        }

        public static void displayUser(UserAccount user, bool dbquery)
        {
            if (!dbquery)
            {
                Console.Clear();
            }

            Console.WriteLine("##-" + user.FirstName + " " + user.LastName + "-##");
            Console.WriteLine("AccountNumber: " + user.accountNumber + "\nFirstName: " + user.FirstName + "\nLastName: " + user.LastName + "\nStreet Address: " + user.address.Street + "\nCity:" + user.address.City + "\nState:" + user.address.State + "\nZipCode:" + user.address.ZipCode + "\nEmailAddress: " + user.EmailAddress + "\nPhoneNumber: " + user.PhoneNumber + "\nCreationDate: " + user.CreationDate);
            if (!dbquery)
            {
                Console.Write("Press Enter to return to main menu...");
            }
            else
            {
                Console.Write("Press Enter to continue..");
            }
            Console.ReadLine();

            if (!dbquery)
            {
                Console.Clear();
            }

        }
        public static void displayInventory()
        {
            Console.Clear();
            var items = InventoryItem.getAllInventoryItems();
            foreach (InventoryItem item in items)
            {
                Console.WriteLine("-----------------------");
                Console.WriteLine("Product Number: " + item.ProductNumber);
                Console.WriteLine("Product Name: " + item.ProductName);
                Console.WriteLine("Price: " + item.Price);
                Console.WriteLine("Seller: " + item.Seller);
                Console.WriteLine("Inventory Quanity: " + item.InventoryQuanity);
                Console.WriteLine("-----------------------");
                Console.WriteLine();
            }
            Console.WriteLine("1. Add Item to Cart");
            Console.WriteLine("2. View shopping cart");
            Console.WriteLine("3. return to main menu");
            switch (Console.ReadLine())
            {
                case "1":
                    {
                        ShoppingCart.ItemToCartPrompt();
                        break;
                    }
                case "2":
                    {
                        displayShoppingCart();
                        break;
                    }
                case "3":
                    {
                        return;
                    }
                default:
                    {
                        return;
                    }
            }   
        }

        public static void displayShoppingCart()
        {
            Console.Clear();
            var shoppingCartItems = ShoppingCart.getAllCartItems();

            if(shoppingCartItems.Count() == 0)
            {
                Console.WriteLine("##Shopping Cart is Empty##");
                returnToMainMenu();
            }
            else
            {
                foreach (ShoppingCart item in shoppingCartItems)
                {
                    Console.WriteLine("-----------------------");
                    Console.WriteLine("Product Number: " + item.ProductName);
                    Console.WriteLine("Product Name: " + item.ProductName);
                    Console.WriteLine("Price: " + item.Price);
                    Console.WriteLine("Seller: " + item.Seller);
                    Console.WriteLine("Inventory Quanity: " + item.quantity);
                    Console.WriteLine("-----------------------");
                    Console.WriteLine();
                    Console.WriteLine("1. Remove Item from Cart");
                    Console.WriteLine("2. View Inventory");
                    Console.WriteLine("3. return to main menu");
                }

                switch (Console.ReadLine())
                {
                    case "1":
                        {
                            ShoppingCart.removeItemFromCartPrompt();
                            break;
                        }
                    case "2":
                        {
                            displayInventory();
                            break;
                        }
                    case "3":
                        {
                            return;
                        }
                    default:
                        {
                            return;
                        }
                }
            }
        }

        public static void returnToMainMenu()
        {
            Console.WriteLine("Press enter to return to the main menu");
            Console.ReadLine();
            return;
        }


        public static void exit()
        {
            Stopwatch startSleep = new Stopwatch();
            Console.Clear();
            startSleep.Start();
            Console.WriteLine("Thanks for checking out Online Store v1, Bye!");
            while (startSleep.Elapsed.TotalSeconds < 3) { };
        }
        #endregion
    }
}
