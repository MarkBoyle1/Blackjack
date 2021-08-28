using System;
using System.Collections.Generic;

namespace Blackjack
{
    public class Calculator
    {

        public int blackjackValue = 21;
        public int CalculateHand(List<Card> hand)
        {
            int score = 0;
            bool containsAce = false;
            foreach(Card card in hand)
            {
                if(card.cardNumber == 1) containsAce = true;
                score += AdjustCardNumber(card.cardNumber);
            }
            if(containsAce) score = DecideValueOfAce(score);
            if(score > blackjackValue) score = 0;
            return score;
        }

        private int AdjustCardNumber(int cardNumber)
        {
            return cardNumber > 10 ? 10 : cardNumber;   //Ace equals 1
        }

        private int DecideValueOfAce(int score)
        {
            return score < (blackjackValue - 9) ? score += 10 : score;
        }

        public bool CheckForBust(List<Card> userHand)
        {
            return CalculateHand(userHand) == 0;
        }

        public int CalculateWinner(int userScore, int dealerScore)
        {
            if(CheckForWin(userScore, dealerScore))
            {
                return 1;
            }
            else if(CheckForWin(dealerScore, userScore))
            {
                return 2;
            }
            else
            {
                return 3;
            }
        }
        private bool CheckForWin(int playerScore, int opponentScore)
        {
            return (playerScore <= blackjackValue && playerScore > opponentScore);
        }
    }
}