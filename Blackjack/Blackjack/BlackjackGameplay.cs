using System;
using System.Collections.Generic;

namespace Blackjack
{
    public class BlackJackGameplay
    {
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
