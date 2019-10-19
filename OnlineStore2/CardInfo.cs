using System;
using System.Collections.Generic;
using System.Text;

namespace Online_Store
{
    enum TypeOfCreditCard
    {
        Visa,
        MasterCard,
        Discover,
        Amex,
        Invalid
    }
    class CardInfo
    {
        public string CardNumber { get; set; }
        public string ExpDate { get; set; }
        public string SecurityCode { get; set; }
        public TypeOfCreditCard CardType { get; set; }
    }
}
