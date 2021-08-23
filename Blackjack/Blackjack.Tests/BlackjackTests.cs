using System;
using Xunit;

namespace Blackjack.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void given_userScoreEquals21_and_dealerScoreEquals19_when_DecideWinner_then_return_YouBeatTheDealer()
        {
            BlackJackGameplay game = new BlackJackGameplay();
            int userScore = 21;
            int dealerScore = 19;

            string result = game.DecideWinner(userScore, dealerScore);

            string expectedResult = "You beat the dealer!";

            Assert.Equal(expectedResult, result);
        }
    }
}
