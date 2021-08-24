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
        public Input userInput = new Input();
        public Deck deck = new Deck();
            
      public string DecideWinner(int userScore, int dealerScore)
      {
          if(userScore <= 21 && userScore > dealerScore)
          {
              return "You beat the dealer!";
          }
          else if(dealerScore <= 21 && dealerScore > userScore)
          {
              return "Dealer wins!";
          }
          else{
              return "Tied game!";
          }
      }
      

      public void StartGame()
      {
          deck.CreateDeck();
          userHand.Add(deck.dealCard());
          userHand.Add(deck.dealCard());
          dealerHand.Add(deck.dealCard());
          dealerHand.Add(deck.dealCard());
          userHand = userInput.DecideAction(userHand, deck);
          userScore = CalculateHand(userHand);

          
          dealerScore = CalculateHand(dealerHand);
          Console.WriteLine(DecideWinner(userScore, dealerScore));
      }

      public int CalculateHand(List<Card> hand)
      {
          int score = 0;
          foreach(Card card in hand)
          {
            score += card.cardNumber;
          }
          return score;
      }
    }
}
