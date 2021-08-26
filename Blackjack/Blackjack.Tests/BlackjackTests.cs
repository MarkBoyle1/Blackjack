using System;
using System.Collections.Generic;
using Xunit;

namespace Blackjack.Tests
{
    public class UnitTest1
    {
        public BlackjackGameplay game = new BlackjackGameplay(new TestUserInput("0"));
        public List<Card> userHand = new List<Card>();
        public List<Card> dealerHand = new List<Card>();
        public Deck deck = new Deck();
        public Calculator calculator = new Calculator();
        public User user = new User();
        public Dealer dealer = new Dealer();

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

            int userScore = calculator.CalculateHand(userHand);
            int dealerScore = calculator.CalculateHand(dealerHand);

            string result = game.DecideWinner(userScore, dealerScore);
            string expectedResult = "Dealer wins!";

            Assert.Equal(expectedResult, result);
        }

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

        [Fact]
        public void when_SetUpGame_then_userAndDealerReceive2CardsEach()
        {
            game.SetUpGame();

            Assert.Equal(2, game.userHand.Count);
            Assert.Equal(2, game.dealerHand.Count);
        }  

        [Fact]
        public void given_userEnters1_when_DecideAction_then_userHandIncreases()
        {
            IUserInput userInput = new TestUserInput("1");
            BlackjackGameplay game = new BlackjackGameplay(userInput);

            deck.CreateDeck();
            int startLength = game.userHand.Count;
            userHand = user.UserAction(game.userHand, deck, userInput);
            int endLength = game.userHand.Count;

            Assert.True(startLength < endLength);
        }  

        [Fact]
        public void given_userEnters0_when_DecideAction_then_userHandRemainsTheSame()
        {
            IUserInput userInput = new TestUserInput("0");
            BlackjackGameplay game = new BlackjackGameplay(userInput);

            game.SetUpGame();
            int startLength = game.userHand.Count;
            userHand = user.UserAction(userHand, deck, userInput);
            int endLength = game.userHand.Count;

            Assert.Equal(endLength, startLength);
        }  

        [Fact]
        public void given_userHandScoreIsGreaterThan21_when_CalculateHand_then_return_0()
        {
            userHand.Add(new Card(7, "Club"));
            userHand.Add(new Card(8, "Heart"));
            userHand.Add(new Card(4, "Diamond"));
            userHand.Add(new Card(3, "Heart"));

            Assert.Equal(0, calculator.CalculateHand(userHand));
        }  

        [Fact]
        public void given_userHandEquals12And13_when_CalculateHand_then_return_20()
        {
            userHand.Add(new Card(12, "Club"));
            userHand.Add(new Card(13, "Heart"));
            
            Assert.Equal(20, calculator.CalculateHand(userHand));
        }      

        [Fact]
        public void given_userHandEquals1And7_when_CalculateHand_then_return_18()
        {
            userHand.Add(new Card(1, "Club"));
            userHand.Add(new Card(7, "Heart"));
            
            Assert.Equal(18, calculator.CalculateHand(userHand));
        }       

        [Fact]
        public void given_userHandEquals1And7And9_when_CalculateHand_then_return_17()
        {
            userHand.Add(new Card(1, "Club"));
            userHand.Add(new Card(7, "Heart"));
            userHand.Add(new Card(9, "Diamond"));
            
            Assert.Equal(17, calculator.CalculateHand(userHand));
        }   

        [Fact]
        public void given_dealerHandEquals6And7_when_DealerAction_then_dealerHandCountIncreases()
        {
            deck.CreateDeck();
            dealerHand.Add(new Card(6, "Club"));
            dealerHand.Add(new Card(7, "Heart"));

            int userScore = 0;
            
            dealerHand = dealer.DealerAction(dealerHand, deck, userScore);
            
            Assert.True(dealerHand.Count > 2);
        }   

        [Fact]
        public void given_dealerHandScoreEquals20_and_userScoreEquals19_when_DealerAction_then_dealerHandCountRemainsTheSame()
        {
            deck.CreateDeck();
            dealerHand.Add(new Card(6, "Club"));
            dealerHand.Add(new Card(7, "Heart"));
            dealerHand.Add(new Card(7, "Diamond"));
            int userScore = 19;

            dealerHand = dealer.DealerAction(dealerHand, deck, userScore);
            
            Assert.True(dealerHand.Count == 3);
        } 
    }
}
