using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wrox.BDD.Domain
{
    public class GameRuleException : ApplicationException 
    {
        public GameRuleException(string message) : base(message)
        {  }
    }
}
