using Online_Store;
using System;
using System.Diagnostics;

namespace OnlineStore2
{
    class Program
    {
        #region Main
        static void Main(string[] args)
        {
            Console.WriteLine("###-Welcome to Online Store v1-###");

            var option = ShowMainMenu();
            while (option != "5")
            {
                switch (option)
                {
                    case "1":
                        generateNewUser();
                        option = ShowMainMenu();
                        break;
                    case "2":
                        Console.WriteLine("feature coming soon!");
                        option = ShowMainMenu();
                        break;
                    case "3":
                        Console.WriteLine("feature coming soon!");
                        option = ShowMainMenu();
                        break;
                    case "4":
                        Console.WriteLine("feature coming soon!");
                        option = ShowMainMenu();
                        break;
                }

            }

            if (option == "5")
            {
                Console.WriteLine("Thanks for checking out Online Store v1, Bye!");
                Stopwatch startSleep = new Stopwatch();
                startSleep.Start();
                while (startSleep.Elapsed.TotalSeconds < 5) { };
            }
            #endregion

        }

        #region MenuOption
        public static string ShowMainMenu()
        {
            Console.WriteLine("Please select and option of what you would like to do.");
            Console.WriteLine("1. Add a new user");
            Console.WriteLine("2. Add a new inventory item");
            Console.WriteLine("3. Search for an invetory item");
            Console.WriteLine("4. View Shopping Cart");
            Console.WriteLine("5. Exit");
            var option = Console.ReadLine();
            Console.Write("");
            return option;
        }
        #endregion

        #region User Creation functions

        public static UserAccount generateNewUser()
        {
            Console.WriteLine("##-New User-##");
            Console.WriteLine("");
            Console.Write("FirstName:");
            var firstName = Console.ReadLine();

            Console.Write("LastName:");
            var lastName = Console.ReadLine();

            //GetAddress
            var address = getNewAddress();

            Console.Write("Phone:"); var phone = Console.ReadLine();
            Console.Write("Email:");
            var email = Console.ReadLine();

            //getCardInfo
            var card = getCardInfo();

            UserAccount user = new UserAccount();
            user.FirstName = firstName;
            user.LastName = lastName;
            user.address = address;
            user.PhoneNumber = phone;
            user.PaymentCard = card;
            user.addCreationDate();
            user.updateLastUpdated();
            Console.WriteLine("");
            Console.WriteLine("New user successfully created!");
            Console.WriteLine("FirstName: " + user.FirstName + "\nLastName: " + user.LastName + "\nStreet Address: "+ user.address.Street + "\nCity:"+user.address.City+"\nState:"+user.address.State + "\nZipCode:" + user.address.ZipCode + "\nEmailAddress: "+user.EmailAddress+"\nPhoneNumber: "+user.PhoneNumber+"\nCreationDate: "+ user.CreationDate);

            return user;

        }

        public static Address getNewAddress()
        {
            Console.Write("StreetAddress:");
            var streetAdd = Console.ReadLine();
            Console.Write("City:");
            var city = Console.ReadLine();
            Console.Write("State:");
            var state = Console.ReadLine();
            Console.Write("ZipCode:");
            var zip = Console.ReadLine();
            Address address = new Address();
            address.Street = streetAdd;
            address.City = city;
            address.State = state;
            address.ZipCode = zip;

            return address;
        }

        public static CardInfo getCardInfo()
        {
            Console.Write("CardNumber:");
            var cardNumber = Console.ReadLine();
            Console.Write("ExpDate:");
            var expDate = Console.ReadLine();
            Console.Write("SecurityCode:");
            var securityCode = Console.ReadLine();
            CardInfo cardInfo = new CardInfo();
            cardInfo.CardNumber = cardNumber;
            cardInfo.ExpDate = expDate;
            cardInfo.SecurityCode = securityCode;

            return cardInfo;
        }

        #endregion
    }
}
