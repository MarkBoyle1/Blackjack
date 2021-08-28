using System;
using System.Collections.Generic;
using Xunit;

namespace Blackjack.Tests
{
    public class BlackjackGameplayTests
    {
        public BlackjackGameplay game = new BlackjackGameplay(new TestUserInput("0"));
        public List<Card> userHand = new List<Card>();
        public List<Card> dealerHand = new List<Card>();
        public Calculator calculator = new Calculator();

        [Fact]
        public void given_userScoreEquals21_and_dealerScoreEquals19_when_CalculateWinner_then_return_YouBeatTheDealer()
        {
            int userScore = 21;
            int dealerScore = 19;
            int result = calculator.CalculateWinner(userScore, dealerScore);
            int expectedResult = 1;

            Assert.Equal(expectedResult, result);
        }
    
        [Fact]
        public void given_userScoreEquals17_and_dealerScoreEquals19_when_CalculateWinner_then_return_DealerWins()
        {
            int userScore = 17;
            int dealerScore = 19;
            int result = calculator.CalculateWinner(userScore, dealerScore);
            int expectedResult = 2;

            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void given_userHandEquals9and8_and_dealerHandEquals10and9_when_CalculateWinner_then_return_DealerWins()
        {
            
            userHand.Add(new Card(9, (Deck.Suits)1));
            userHand.Add(new Card(8, (Deck.Suits)3)); 
            
            dealerHand.Add(new Card(10, (Deck.Suits)1));
            dealerHand.Add(new Card(9, (Deck.Suits)0)); 

            int userScore = calculator.CalculateHand(userHand);
            int dealerScore = calculator.CalculateHand(dealerHand);

            int result = calculator.CalculateWinner(userScore, dealerScore);
            int expectedResult = 2;

            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void when_SetUpGame_then_userAndDealerReceive2CardsEach()
        {
            game.SetUpGame();

            Assert.Equal(2, game.userHand.Count);
            Assert.Equal(2, game.dealerHand.Count);
        }  
    }
}
