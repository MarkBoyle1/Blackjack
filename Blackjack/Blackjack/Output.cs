using System;
using System.Collections.Generic;

namespace Blackjack
{
    public class Output
    {
        enum CardName
        {
            Ace = 1, Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Jack, Queen, King
        }

        enum ConsoleOutput
        {
            You = 1,
            Your,
            draw,
            Dealer,
            draws
        }

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

       public void DisplayStatus(int userScore, List<Card> userHand, int player)
       {
           Console.WriteLine("{0} score is currently at {1}", (ConsoleOutput)player, userScore);
           Console.Write("with the hand ");
           foreach(Card card in userHand)
           {
               Console.Write("[{0} {1}] ", (CardName)card.cardNumber, card.cardSuit);
           }
           Console.WriteLine("\n");
       }

       public void DisplayNewCard(Card newCard, int player, int verb)
       {
           Console.WriteLine("{0} {1} a [{2} {3}]\n", (ConsoleOutput)player, (ConsoleOutput)verb, (CardName)newCard.cardNumber, newCard.cardSuit);
       }

       public void InvalidInputMessage()
       {
           Console.WriteLine("Invaild response. Please enter 1 or 0");
       }
    }
}
