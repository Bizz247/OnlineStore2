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
            
            //Only exit if option 5 is selected
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
                        MenuActions.exit();
                        return;
                }
            }
        }
        #endregion
    }
}
