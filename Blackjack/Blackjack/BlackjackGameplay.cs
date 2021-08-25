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

        public BlackjackGameplay(IUserInput userInput)
        {
            this.userInput = userInput;
        }
            
      public string DecideWinner(int userScore, int dealerScore)
      {
          if(userScore <= 21 && userScore > dealerScore)
          {
              output.WinMessage();
              return "You beat the dealer!";
          }
          else if(dealerScore <= 21 && dealerScore > userScore)
          {
              output.LoseMessage();
              return "Dealer wins!";
          }
          else{
              output.TieMessage();
              return "Tied game!";
          }
      }
      
      public void StartGame()
      {
          SetUpGame();
          userHand = UserAction();
          userScore = CalculateHand(userHand);
          dealerScore = CalculateHand(dealerHand);
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

      public int CalculateHand(List<Card> hand)
      {
          int score = 0;
          foreach(Card card in hand)
          {
            score += card.cardNumber;
          }
          if(score > 21)
          {
              score = 0;
          }
          return score;
      }

      public List<Card> UserAction()
      {
          bool inPlay = true;
           while(inPlay)
           {
                string decision = userInput.DecideAction();
                if(decision == "1")
                {
                    userHand.Add(deck.dealCard());
                    
                    if(CalculateHand(userHand) == 0)
                    {
                        output.BustedMessage();
                        inPlay = false;
                    }
                } 
                else if(decision == "0")
                {
                    inPlay = false;
                }
                else
                {
                    Console.WriteLine("Invaild response. Please enter 1 or 0");
                }
           }
           return userHand;
      }
    }
}
