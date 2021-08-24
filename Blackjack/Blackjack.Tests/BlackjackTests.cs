using System;
using System.Collections.Generic;
using Xunit;

namespace Blackjack.Tests
{
    public class UnitTest1
    {
        public BlackjackGameplay game = new BlackjackGameplay();
        public List<Card> userHand = new List<Card>();
        public List<Card> dealerHand = new List<Card>();

        [Fact]
        public void given_userScoreEquals21_and_dealerScoreEquals19_when_DecideWinner_then_return_YouBeatTheDealer()
        {
            
            int userScore = 21;
            int dealerScore = 19;

            string result = game.DecideWinner(userScore, dealerScore);

            string expectedResult = "You beat the dealer!";

            Assert.Equal(expectedResult, result);
        }
    
        [Fact]
        public void given_userScoreEquals17_and_dealerScoreEquals19_when_DecideWinner_then_return_DealerWins()
        {
            int userScore = 17;
            int dealerScore = 19;

            string result = game.DecideWinner(userScore, dealerScore);

            string expectedResult = "Dealer wins!";

            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void given_userHandEquals9and8_and_dealerHandEquals10and9_when_DecideWinner_then_return_DealerWins()
        {
            
            userHand.Add(new Card(9, "Diamond"));
            userHand.Add(new Card(8, "Heart")); 
            
            dealerHand.Add(new Card(10, "Club"));
            dealerHand.Add(new Card(9, "Heart")); 

            int userScore = game.CalculateHand(userHand);
            int dealerScore = game.CalculateHand(dealerHand);

            string result = game.DecideWinner(userScore, dealerScore);

            string expectedResult = "Dealer wins!";

            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void when_dealCard_then_userHandIncreasesBy1()
        {
            Deck deck = new Deck();
            int expectedLength = (userHand.Count + 1);
            userHand.Add(deck.dealCard());
            int actualLength = userHand.Count;

            Assert.Equal(expectedLength, actualLength);
        }        
    }
}
