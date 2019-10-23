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
    internal class CardInfo
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
    }

}
