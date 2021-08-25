using System;
using System.Collections.Generic;

namespace Blackjack
{
    public class Program
    {
        static void Main(string[] args)
        {
            BlackjackGameplay game = new BlackjackGameplay(new Input());
            game.StartGame();
        }
    }
}
