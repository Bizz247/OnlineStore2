using Online_Store;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace OnlineStore2
{
    class Program
    {
        #region Main
        static void Main(string[] args)
        {
            Console.WriteLine("###-Welcome to Online Store v1-###");
            InventoryItem.preloadInventoryOnStart();
            UserAccount.preloadUserOnStart();

            while (true)
            {
                var option = MenuActions.ShowMainMenu();
               
                switch (option)
                {
                    case "1":
                        var user = UserAccount.generateNewUser();
                        MenuActions.displayUser(user,false);
                        break;
                    case "2":
                        UserAccount.getAllUsers();
                        break;
                    case "3":
                        UserAccount.userSearchByEmail();
                        break;
                    case "4":
                        UserAccount.deleteUserFromDB();
                        break;
                    case "5":
                        MenuActions.displayInventory();
                        break;
                    case "6":
                        MenuActions.displayShoppingCart();
                        break;
                    case "7":
                        ShoppingCart.ItemToCartPrompt();
                        break;
                    case "8":
                        ShoppingCart.removeItemFromCartPrompt();
                        break;
                    case "9":
                        ShoppingCart.purchaseItemsInCart();
                        break;
                    case "10":
                        MenuActions.exit();
                        return;
                }
            }
        }
        #endregion
    }
}
