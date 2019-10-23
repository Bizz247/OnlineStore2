using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Online_Store;
using OnlineStore2;

namespace Online_Store
{
    
    class UserAccount
    {
        #region private objects
        private static List<UserAccount> Users = new List<UserAccount>();
        private static int totalAccounts = 0;
        #endregion

        #region Properties

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Online_Store.Address address { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public Online_Store.CardInfo PaymentCard { get; set; }
        public DateTime CreationDate { get; private set; }
        public DateTime LastUpdated { get; private set; }
        public int accountNumber { get; private set; }

        #endregion

        #region Methods
        public void addCreationDate()
        {
            DateTime date = DateTime.Now;
            CreationDate = date;
        }
        
        public void updateLastUpdated()
        {
            DateTime date = DateTime.Now;
            LastUpdated = date;
        }

        public void updateAccountNumber()
        {
            totalAccounts++;
            accountNumber = totalAccounts;
        }

        public static UserAccount generateNewUser()
        {
            Console.WriteLine("##-New User-##");
            Console.Write("FirstName:");
            var firstName = Console.ReadLine();

            Console.Write("LastName:");
            var lastName = Console.ReadLine();

            //GetAddress
            var address = Address.getNewAddress();

            Console.Write("Phone:"); var phone = Console.ReadLine();
            Console.Write("Email:");
            var email = Console.ReadLine();

            //getCardInfo
            var card = CardInfo.getCardInfo();

            UserAccount user = new UserAccount();
            user.FirstName = firstName;
            user.LastName = lastName;
            user.address = address;
            user.EmailAddress = email;
            user.PhoneNumber = phone;
            user.PaymentCard = card;
            user.addCreationDate();
            user.updateLastUpdated();
            user.updateAccountNumber();
            Users.Add(user);
            Console.Clear();
            return user;

        }

        public static void deleteUserFromDB()
        {
            List<UserAccount> userSearchResults = new List<UserAccount>();

            Console.Clear();
            Console.Write("Email to search user by: ");
            var emailAddress = Console.ReadLine();

            foreach (UserAccount user in Users)
            {
                if (user.EmailAddress == emailAddress)
                {
                    userSearchResults.Add(user);
                }
            }
            if (userSearchResults.Count == 0)
            {
                Console.WriteLine("No users found with email address - " + emailAddress);
            }
            else
            {
                Console.WriteLine("Total Users Found: " + userSearchResults.Count);
                foreach (UserAccount user in userSearchResults)
                {
                    Console.WriteLine("You are about to remove user the following user");
                    MenuActions.displayUser(user, true);
                    Console.Write("Are you sure you want to remove this user? (y/n)");
                    var action = Console.ReadLine();
                    if (action.StartsWith("y"))
                    {
                        Users.Remove(user);
                        getAllUsers();
                    }
                }
            }
        }

        public static void getAllUsers()
        {
            foreach (UserAccount user in Users)
            {
                MenuActions.displayUser(user, true);
            }
        }

        public static void userSearchByEmail()
        {
            Console.Clear();
            Console.Write("Email to search: ");
            var emailAddress = Console.ReadLine();

            var accounts = getUserByEmail(emailAddress);
            int totalAccounts = accounts.Count();
            if (totalAccounts == 0)
            {
                Console.WriteLine("No users found with email address - " + emailAddress);
            }
            else
            {
                Console.WriteLine("Total Users Found: " + totalAccounts);
                foreach (var user in accounts)
                {
                    MenuActions.displayUser(user, true);
                }
            }
        }

        public static IEnumerable<UserAccount> getUserByEmail(string emailAddress)
        {
            return Users.Where(a => a.EmailAddress == emailAddress);
        }

        #endregion
    }

}