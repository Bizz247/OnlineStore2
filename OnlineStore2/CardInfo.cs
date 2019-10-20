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
        public TypeOfCreditCard CardType { get; private set; }

        public void getCreditCardType(string cardnumber)
        {
            switch (cardnumber[0].ToString())
            {
                case "3":
                    CardType = TypeOfCreditCard.Amex;
                    break;
                case "4":
                    CardType = TypeOfCreditCard.Visa;
                    break;
                case "5":
                    CardType = TypeOfCreditCard.MasterCard;
                    break;
                case "6":
                    CardType = TypeOfCreditCard.Discover;
                    break;
                default:
                    CardType = TypeOfCreditCard.Invalid;
                    break;
            }
        }
    }

}
