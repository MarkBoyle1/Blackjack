using System;
using System.Collections.Generic;

namespace Blackjack
{
    public class TestUserInput : IUserInput
    {
        private string testInput;
        public TestUserInput(string testInput)
        {
            this.testInput = testInput;
        }
       public string DecideAction()
       {
            return testInput;     
       }
    }
}