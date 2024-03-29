﻿using System;
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
        public static CardInfo getCardInfo(string CardNumber = null, string CardExp = null, string SecurityCode = null)
        {
            CardInfo cardInfo = new CardInfo();

            //If values passed to method directly, generate CardInfo, if not prompt user for input
            if (CardNumber != null && CardExp != null && SecurityCode != null)
            {
                cardInfo.CardNumber = CardNumber;
                cardInfo.ExpDate = CardExp;
                cardInfo.SecurityCode = SecurityCode;
                cardInfo.getCreditCardType(CardNumber);
            }
            else
            {
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
            }

            return cardInfo;
        }
    }

}
