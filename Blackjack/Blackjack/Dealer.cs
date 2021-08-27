using System;
using System.Collections.Generic;

namespace Blackjack
{
    public class Dealer
    {
        private Calculator calculator = new Calculator();
        private Output output = new Output();
       public List<Card> DealerAction(List<Card> dealerHand, Deck deck, int userScore)
        {
            while(IsDealerInPlay(dealerHand, userScore))
            {
                output.DisplayStatus(calculator.CalculateHand(dealerHand), dealerHand, 4);
                Card newCard = deck.dealCard();
                    dealerHand.Add(newCard);
                    output.DisplayNewCard(newCard, 4, 5);
            } 
            return dealerHand;
        }

        private bool IsDealerInPlay(List<Card> dealerHand, int userScore)
        {
            int dealerScore = calculator.CalculateHand(dealerHand);
            if(dealerScore == 0 || dealerScore >= 21 || (dealerScore > 17 && dealerScore > userScore))
            {
                return false;
            }
            return true;
        }
    }
}
