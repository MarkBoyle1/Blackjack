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

       public void ResultMessage(int result)
       {
           switch(result)
           {
               case 1:
                    Console.WriteLine("You beat the dealer!");
                    break;
               case 2:
                    Console.WriteLine("Dealer Won!");
                    break;
                default:
                    Console.WriteLine("Tied Game!");
                    break;
           }
       }

       public void DisplayStatus(int userScore, List<Card> userHand, string player)
       {
           Console.WriteLine("{0} currently at {1}", player, userScore);
           Console.Write("with the hand ");
           foreach(Card card in userHand)
           {
               string cardType = AdjustToCorrectCardType(card.cardNumber);
               Console.Write("[{0} {1}] ", cardType, card.cardSuit);
           }
           Console.WriteLine("\n");
       }

       private string AdjustToCorrectCardType(int cardNumber)
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

       public void DisplayNewCard(Card newCard, string player)
       {
           string cardType = AdjustToCorrectCardType(newCard.cardNumber);
           Console.WriteLine("{0} a [{1} {2}]\n", player, cardType, newCard.cardSuit);
       }
    }
}
