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

        public BlackjackGameplay(IUserInput userInput)
        {
            this.userInput = userInput;
        }
            
      public string DecideWinner(int userScore, int dealerScore)
      {
          if(userScore <= 21 && userScore > dealerScore)
          {
              output.ResultMessage("win");
              return "You beat the dealer!";
          }
          else if(dealerScore <= 21 && dealerScore > userScore)
          {
              output.ResultMessage("lose");
              return "Dealer wins!";
          }
          else{
              output.ResultMessage("tie");
              return "Tied game!";
          }
      }
      
      public void StartGame()
      {
          Console.Clear();
          SetUpGame();
          userHand = user.UserAction(userHand, deck, userInput);
          userScore = calculator.CalculateHand(userHand);
          dealerHand = DealerAction(dealerHand, deck, userScore);
          dealerScore = calculator.CalculateHand(dealerHand);
          DecideWinner(userScore, dealerScore);
      }

      public void SetUpGame()
      {
          deck.CreateDeck();
          userHand.Add(deck.dealCard());
          userHand.Add(deck.dealCard());
          dealerHand.Add(deck.dealCard());
          dealerHand.Add(deck.dealCard());
      }

      public List<Card> DealerAction(List<Card> dealerHand, Deck deck, int userScore)
      {
          while(DealerInPlay(dealerHand, userScore))
          {
              output.DisplayStatus(calculator.CalculateHand(dealerHand), dealerHand, "Dealer is");
              Card newCard = deck.dealCard();
                dealerHand.Add(newCard);
                output.DisplayNewCard(newCard, "Dealer draws");
          } 
          return dealerHand;
      }

      public bool DealerInPlay(List<Card> dealerHand, int userScore)
      {
          dealerScore = calculator.CalculateHand(dealerHand);
          if(dealerScore == 0 || dealerScore > 21 || (dealerScore > 17 && dealerScore > userScore))
          {
              return false;
          }
          return true;
      }
    }
}
