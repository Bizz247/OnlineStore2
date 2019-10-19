using System;
using System.Collections.Generic;
using System.Text;

namespace Online_Store
{
    
    class UserAccount
    {
        #region Properties

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Online_Store.Address address { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public Online_Store.CardInfo PaymentCard { get; set; }
        public DateTime CreationDate { get; private set; }
        public DateTime LastUpdated { get; private set; }

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
        #endregion
    }

}