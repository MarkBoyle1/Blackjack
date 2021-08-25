using System;
using System.Collections.Generic;

namespace Blackjack
{
    public class Input : IUserInput
    {
       public string DecideAction()
       {
            Console.WriteLine("Would you like to Stay or Hit? (Hit = 1, Stay = 0)");
            string response = Console.ReadLine();
            return response;     
       }
    }
}
