using System;
using System.Collections.Generic;

namespace Blackjack
{
    public class User
    {
        private Calculator calculator = new Calculator();
        private Output output = new Output();
       public List<Card> UserAction(List<Card> userHand, Deck deck, IUserInput userInput)
      {
          bool inPlay = true;
           while(inPlay)
           {
               output.DisplayStatus(calculator.CalculateHand(userHand), userHand, 2);
                string decision = userInput.DecideAction();
                if(decision == "1")
                {
                    Card newCard = deck.dealCard();
                    userHand.Add(newCard);
                    output.DisplayNewCard(newCard, 1,3);
                    
                    if(calculator.CalculateHand(userHand) == 0)
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
                    output.InvalidInputMessage();
                }
           }
           return userHand;
      }
    }
}
