using System;

namespace Blackjack
{
    public class Deck
    {
       public Card dealCard()
       {
           return new Card(5, "Spade");
       }
    }
}