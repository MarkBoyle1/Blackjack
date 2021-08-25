using System;
using System.Collections.Generic;

namespace Blackjack
{
    public class Output
    {
       public void BustedMessage()
       {
           Console.WriteLine("Busted!");
       }

       public void WinMessage()
       {
           Console.WriteLine("You beat the dealer!");
       }

       public void LoseMessage()
       {
           Console.WriteLine("Dealer Won!");
       }

       public void TieMessage()
       {
           Console.WriteLine("Tied Game!");
       }

       public void DisplayStatus(int userScore, List<Card> userHand)
       {
           Console.WriteLine("You are currently at {0}", userScore);
           Console.Write("with the hand");
           foreach(Card card in userHand)
           {
               string cardType = AdjustToCorrectCardType(card.cardNumber);
               Console.Write("[{0} {1}]", cardType, card.cardSuit);
           }
           Console.WriteLine();
       }

       public string AdjustToCorrectCardType(int cardNumber)
       {
           switch(cardNumber)
           {
               case 1:
                    return "Ace";
               case 13:
                    return "King";
                case 12:
                    return "Queen";
                case 11:
                    return "Jack";
                default:
                    return cardNumber.ToString();
           }
       }

       public void DisplayNewCard(Card newCard)
       {
           string cardType = AdjustToCorrectCardType(newCard.cardNumber);
           Console.WriteLine("You draw a [{0} {1}]", cardType, newCard.cardSuit);
       }
    }
}
