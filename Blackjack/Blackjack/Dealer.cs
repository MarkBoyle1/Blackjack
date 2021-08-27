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
            while(DealerInPlay(dealerHand, userScore))
            {
                output.DisplayStatus(calculator.CalculateHand(dealerHand), dealerHand, "Dealer is");
                Card newCard = deck.dealCard();
                    dealerHand.Add(newCard);
                    output.DisplayNewCard(newCard, "Dealer draws");
            } 
            return dealerHand;
        }

        private bool DealerInPlay(List<Card> dealerHand, int userScore)
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
