using System;
using System.Collections.Generic;
using System.Text;

namespace Online_Store
{
    class UserAccount
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Online_Store.Address MyProperty { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public Online_Store.CardInfo PaymentCard { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime LastUpdated { get; set; }

    }

}
