using System;
using System.Collections.Generic;

namespace Blackjack
{
    public class Deck
    {
        public List<Card> deckOfCards = new List<Card>();
        Random random = new Random();

        public enum Suits
        {
            Heart,
            Diamond,
            Club,
            Spade
        }

       
       public void CreateDeck()
       {
           foreach(Suits suit in Enum.GetValues(typeof(Suits)))
           {
               for(int i = 1; i <= 13; i++)
               {
                   deckOfCards.Add(new Card(i, suit));
               }
           }
       }
       public Card dealCard()
       {
           int index = random.Next(0, deckOfCards.Count - 1);
           Card card = deckOfCards[index];
           deckOfCards.RemoveAt(index);
           return card;
       }
    }
}