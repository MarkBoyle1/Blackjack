using System;
using System.Collections.Generic;

namespace Blackjack
{
    public class Deck
    {
        public List<Card> deckOfCards = new List<Card>();
        public string[] suits = {"Heart", "Diamond", "Club", "Spade"};
       
       public void CreateDeck()
       {
           foreach(string suit in suits)
           {
               for(int i = 1; i <= 13; i++)
               {
                   deckOfCards.Add(new Card(i, suit));
               }
           }
       }
       public Card dealCard()
       {
           Random random = new Random();
           int index = random.Next(0, deckOfCards.Count - 1);
           Card card = deckOfCards[index];
           deckOfCards.RemoveAt(index);
           return card;
       }
    }
}