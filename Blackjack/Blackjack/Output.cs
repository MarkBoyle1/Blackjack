using System;
using System.Collections.Generic;

namespace Blackjack
{
    public class Output
    {
       public void BustedMessage()
       {
           Console.WriteLine("Busted!");
       }

       public void WinMessage()
       {
           Console.WriteLine("You beat the dealer!");
       }

       public void LoseMessage()
       {
           Console.WriteLine("Dealer Won!");
       }

       public void TieMessage()
       {
           Console.WriteLine("Tied Game!");
       }
    }
}
