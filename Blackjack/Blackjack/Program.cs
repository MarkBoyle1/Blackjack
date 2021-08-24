using System;
using System.Collections.Generic;

namespace Blackjack
{
    public class Program
    {
        static void Main(string[] args)
        {
            BlackJackGameplay game = new BlackJackGameplay();
            game.DecideWinner(21, 19);
        }
    }
}
