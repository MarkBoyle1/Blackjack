using System;

namespace Blackjack
{
    public class Card
    {
        public int cardNumber;
        public string cardSuit;

        public Card(int cardNumber, string cardSuit)
        {
            this.cardNumber = cardNumber;
            this.cardSuit = cardSuit;
        }
    }
}