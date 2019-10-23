using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Online_Store;

namespace OnlineStore2
{
    internal static class MenuActions
    {
        #region MenuOption
        public static string ShowMainMenu()
        {
            Console.WriteLine("Please select and option of what you would like to do.");
            Console.WriteLine("1. Add a new user");
            Console.WriteLine("2. Get all users");
            Console.WriteLine("3. Search for a user by email");
            Console.WriteLine("4. delete user");
            Console.WriteLine("5. Exit");
            var option = Console.ReadLine();
            Console.Write("");
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
