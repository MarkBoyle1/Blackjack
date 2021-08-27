using System;

namespace Blackjack
{
    public class Card
    {
        public int cardNumber;
        public Deck.Suits cardSuit;
        public Card(int cardNumber, Deck.Suits cardSuit)
        {
            this.cardNumber = cardNumber;
            this.cardSuit = cardSuit;
        }
    }
}