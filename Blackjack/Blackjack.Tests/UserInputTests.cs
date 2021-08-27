using System;
using System.Collections.Generic;
using Xunit;

namespace Blackjack.Tests
{
    public class UserInputTests
    {
        public List<Card> userHand = new List<Card>();
        public Deck deck = new Deck();
        public User user = new User();

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
    }
}
