using System;
using System.Collections.Generic;
using System.Text;

namespace Online_Store
{
    class Address
    {
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }

        #region Methods
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
        #endregion
    }
}

