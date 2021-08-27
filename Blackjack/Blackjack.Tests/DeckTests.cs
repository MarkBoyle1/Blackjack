using System;
using System.Collections.Generic;
using Xunit;

namespace Blackjack.Tests
{
    public class DeckTests
    {
        public List<Card> userHand = new List<Card>();
        public Deck deck = new Deck();
    
        [Fact]
        public void when_dealCard_then_userHandIncreasesBy1()
        {
            deck.CreateDeck();
            int expectedLength = (userHand.Count + 1);
            userHand.Add(deck.dealCard());
            int actualLength = userHand.Count;

            Assert.Equal(expectedLength, actualLength);
        }        

        [Fact]
        public void when_CreateDeck_then_deckOfCardsCountEquals52()
        {
            deck.CreateDeck();

            Assert.Equal(52, deck.deckOfCards.Count);
        }     

        [Fact]
        public void when_dealCard_then_deckOfCardsDecreasesBy1()
        {
            deck.CreateDeck();
            int expectedDeckCount = (deck.deckOfCards.Count - 1);
            deck.dealCard();
            int actualDeckCount = deck.deckOfCards.Count;

            Assert.Equal(expectedDeckCount, actualDeckCount);
        }  
    }
}
