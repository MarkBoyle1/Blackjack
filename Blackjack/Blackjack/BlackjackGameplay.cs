using System;
using System.Collections.Generic;

namespace Blackjack
{
    public class BlackjackGameplay
    {
        private int userScore;
        private int dealerScore;
        public List<Card> userHand = new List<Card>();
        public List<Card> dealerHand = new List<Card>();
        private IUserInput userInput;
        private Deck deck = new Deck();
        private Output output = new Output(); 
        private Calculator calculator = new Calculator();
        private User user = new User();
        private Dealer dealer = new Dealer();

        public BlackjackGameplay(IUserInput userInput)
        {
            this.userInput = userInput;
        }
        public void StartGame()
        {
            Console.Clear();
            SetUpGame();
            userHand = user.UserAction(userHand, deck, userInput);
            userScore = calculator.CalculateHand(userHand);
            if(userScore != 0) dealerHand = dealer.DealerAction(dealerHand, deck, userScore);
            dealerScore = calculator.CalculateHand(dealerHand);
            int result = calculator.CalculateWinner(userScore, dealerScore);
            output.ResultMessage(result);
        }

        public void SetUpGame()
        {
            deck.CreateDeck();
            userHand.Add(deck.dealCard());
            userHand.Add(deck.dealCard());
            dealerHand.Add(deck.dealCard());
            dealerHand.Add(deck.dealCard());
        }
    }
}
