using System;
using System.Collections.Generic;

namespace Blackjack
{
    public class BlackjackGameplay
    {
        public int userScore;
        public int dealerScore;
        public List<Card> userHand = new List<Card>();
        public List<Card> dealerHand = new List<Card>();
        public IUserInput userInput;
        public Deck deck = new Deck();
        public Output output = new Output(); 
        public Calculator calculator = new Calculator();
        public User user = new User();
        public Dealer dealer = new Dealer();

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
