using System;
using System.Collections.Generic;
using Xunit;

namespace Blackjack.Tests
{
    public class CalculatorTests
    {
        public List<Card> userHand = new List<Card>();
        public Calculator calculator = new Calculator(); 

        [Fact]
        public void given_userHandScoreIsGreaterThan21_when_CalculateHand_then_return_0()
        {
            userHand.Add(new Card(7, (Deck.Suits)3));
            userHand.Add(new Card(8, (Deck.Suits)1));
            userHand.Add(new Card(4, (Deck.Suits)0));
            userHand.Add(new Card(3, (Deck.Suits)2));

            Assert.Equal(0, calculator.CalculateHand(userHand));
        }  

        [Fact]
        public void given_userHandEquals12And13_when_CalculateHand_then_return_20()
        {
            userHand.Add(new Card(12, (Deck.Suits)3));
            userHand.Add(new Card(13, (Deck.Suits)2));
            
            Assert.Equal(20, calculator.CalculateHand(userHand));
        }      

        [Fact]
        public void given_userHandEquals1And7_when_CalculateHand_then_return_18()
        {
            userHand.Add(new Card(1, (Deck.Suits)0));
            userHand.Add(new Card(7, (Deck.Suits)2));
            
            Assert.Equal(18, calculator.CalculateHand(userHand));
        }       

        [Fact]
        public void given_userHandEquals1And7And9_when_CalculateHand_then_return_17()
        {
            userHand.Add(new Card(1, (Deck.Suits)1));
            userHand.Add(new Card(7, (Deck.Suits)3));
            userHand.Add(new Card(9, (Deck.Suits)0));
            
            Assert.Equal(17, calculator.CalculateHand(userHand));
        }   
    }
}
