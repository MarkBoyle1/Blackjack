using System;
using System.Collections.Generic;

namespace Blackjack
{
    public class Input
    {
       public List<Card> DecideAction(List<Card> userHand, Deck deck)
       {
           bool inPlay = true;
           while(inPlay)
           {
                Console.WriteLine("Would you like to Stay or Hit? (Hit = 1, Stay = 0)");
                string response = Console.ReadLine();
                if(response == "1")
                {
                    userHand.Add(deck.dealCard());
                } 
                else if(response == "0")
                {
                    inPlay = false;
                }
                else
                {
                    Console.WriteLine("Invaild response. Please enter 1 or 0");
                }
           }
           return userHand;
       }
    }
}
