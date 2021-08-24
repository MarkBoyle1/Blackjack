using System;
using System.Collections.Generic;
using Xunit;

namespace Blackjack.Tests
{
    public class UnitTest1
    {
        public BlackJackGameplay game = new BlackJackGameplay();

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

        public void given_userHandContains10And8_when_CalculateHand_then_return_18()
        {
            
            List<Card> userHand = new List<Card>();
            userHand.Add(new Card(10, "Diamond"));
            userHand.Add(new Card(8, "Heart")); 
            int userScore = game.CalculateHand(userHand);

            Assert.Equal(18, userScore);
        }
    }
}
