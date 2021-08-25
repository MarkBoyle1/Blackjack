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
               Console.Write("[{0} {1}]", card.cardNumber, card.cardSuit);
           }
           Console.WriteLine();
       }

       public void DisplayNewCard(Card newCard)
       {
           Console.WriteLine("You draw a [{0} {1}]", newCard.cardNumber, newCard.cardSuit);
       }
    }
}
