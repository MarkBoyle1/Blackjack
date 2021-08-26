using System;
using System.Collections.Generic;

namespace Blackjack
{
    public class User
    {
        public Calculator calculator = new Calculator();
        public Output output = new Output();
       public List<Card> UserAction(List<Card> userHand, Deck deck, IUserInput userInput)
      {
          bool inPlay = true;
           while(inPlay)
           {
               output.DisplayStatus(calculator.CalculateHand(userHand), userHand, "You are");
                string decision = userInput.DecideAction();
                if(decision == "1")
                {
                    Card newCard = deck.dealCard();
                    userHand.Add(newCard);
                    output.DisplayNewCard(newCard, "You draw");
                    
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
                    Console.WriteLine("Invaild response. Please enter 1 or 0");
                }
           }
           return userHand;
      }
    }
}
