using System;
using System.Collections.Generic;

namespace Blackjack
{
    public class Calculator
    {
        public int CalculateHand(List<Card> hand)
        {
            int score = 0;
            bool containsAce = false;
            foreach(Card card in hand)
            {
                if(card.cardNumber == 1)
                {
                    containsAce = true;
                } 
                score += AdjustCardNumber(card.cardNumber);
            }

            if(containsAce)
            {
                score = DecideValueOfAce(score);
            }

            if(score > 21)
            {
                score = 0;
            }
            return score;
        }

        public int AdjustCardNumber(int cardNumber)
        {
            return cardNumber > 10 ? 10 : cardNumber;   //Ace equals 1
        }

        public int DecideValueOfAce(int score)
        {
            return score < 12 ? score += 10 : score;
        }
        }
}