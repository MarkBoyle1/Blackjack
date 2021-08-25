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
          SetUpGame();
          userHand = UserAction();
          userScore = CalculateHand(userHand);
          dealerHand = DealerAction(dealerHand, deck, userScore);
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

      public List<Card> UserAction()
      {
          bool inPlay = true;
           while(inPlay)
           {
               output.DisplayStatus(CalculateHand(userHand), userHand, "You are");
                string decision = userInput.DecideAction();
                if(decision == "1")
                {
                    Card newCard = deck.dealCard();
                    userHand.Add(newCard);
                    output.DisplayNewCard(newCard, "You draw");
                    
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

      public List<Card> DealerAction(List<Card> dealerHand, Deck deck, int userScore)
      {
          while(DealerInPlay(dealerHand, userScore))
          {
              output.DisplayStatus(CalculateHand(dealerHand), dealerHand, "Dealer is");
              Card newCard = deck.dealCard();
                dealerHand.Add(newCard);
                output.DisplayNewCard(newCard, "Dealer draws");
          } 
          return dealerHand;
      }

      public bool DealerInPlay(List<Card> dealerHand, int userScore)
      {
          dealerScore = CalculateHand(dealerHand);
          if(dealerScore == 0 || dealerScore > 21 || (dealerScore > 17 && dealerScore > userScore))
          {
              return false;
          }
          return true;
      }
    }
}
