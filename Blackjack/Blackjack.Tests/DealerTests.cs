using System;
using System.Collections.Generic;
using Xunit;

namespace Blackjack.Tests
{
    public class DealerTests
    {
        public List<Card> dealerHand = new List<Card>();
        public Deck deck = new Deck();
        public Dealer dealer = new Dealer(); 

        [Fact]
        public void given_dealerHandEquals6And7_when_DealerAction_then_dealerHandCountIncreases()
        {
            deck.CreateDeck();
            dealerHand.Add(new Card(6, (Deck.Suits)1));
            dealerHand.Add(new Card(7, (Deck.Suits)0));

            int userScore = 0;
            
            dealerHand = dealer.DealerAction(dealerHand, deck, userScore);
            
            Assert.True(dealerHand.Count > 2);
        }   

        [Fact]
        public void given_dealerHandScoreEquals20_and_userScoreEquals19_when_DealerAction_then_dealerHandCountRemainsTheSame()
        {
            deck.CreateDeck();
            dealerHand.Add(new Card(6, (Deck.Suits)3));
            dealerHand.Add(new Card(7, (Deck.Suits)1));
            dealerHand.Add(new Card(7, (Deck.Suits)0));
            int userScore = 19;

            dealerHand = dealer.DealerAction(dealerHand, deck, userScore);
            
            Assert.True(dealerHand.Count == 3);
        } 
    }
}
