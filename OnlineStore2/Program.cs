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
            
            //Only exit if option 5 is selected
            while (true)
            {
                var option = ShowMainMenu();
               
                switch (option)
                {
                    case "1":
                        var user = generateNewUser();
                        displayUser(user);
                        break;
                    case "2":
                        featureComingSoon();
                        break;
                    case "3":
                        featureComingSoon();
                        break;
                    case "4":
                        featureComingSoon();
                        break;
                    case "5":
                        exit();
                        return;
                }
            }
        }
        #endregion

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

        public static void exit()
        {
            Stopwatch startSleep = new Stopwatch();
            Console.Clear();        
            startSleep.Start();
            Console.WriteLine("Thanks for checking out Online Store v1, Bye!");
            while (startSleep.Elapsed.TotalSeconds < 3) { };
        }
        #endregion

        #region User Creation Functions
        public static UserAccount generateNewUser()
        {
            Console.WriteLine("##-New User-##");
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
            Console.Clear();
            return user;

        }
        public static void displayUser (UserAccount user)
        {
            Console.Clear();
            Console.WriteLine("##-" + user.FirstName + " " + user.LastName + "-##");
            Console.WriteLine("FirstName: " + user.FirstName + "\nLastName: " + user.LastName + "\nStreet Address: " + user.address.Street + "\nCity:" + user.address.City + "\nState:" + user.address.State + "\nZipCode:" + user.address.ZipCode + "\nEmailAddress: " + user.EmailAddress + "\nPhoneNumber: " + user.PhoneNumber + "\nCreationDate: " + user.CreationDate);
            Console.Write("Press Enter to return to main menu...");
            Console.ReadLine();
            Console.Clear();
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
            CardInfo cardInfo = new CardInfo();

            //Make sure the card number is a valid card number or try again
            while (true)
            {
                Console.Write("CardNumber:");
                var cardNumber = Console.ReadLine();
                cardInfo.getCreditCardType(cardNumber);
                if (cardInfo.CardType != TypeOfCreditCard.Invalid)
                {
                    cardInfo.CardNumber = cardNumber;
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid card number, please try again.");
                }
            }


            Console.Write("ExpDate:");
            var expDate = Console.ReadLine();
            Console.Write("SecurityCode:");
            var securityCode = Console.ReadLine();
            cardInfo.ExpDate = expDate;
            cardInfo.SecurityCode = securityCode;

            return cardInfo;
        }

        #endregion
    }
}
