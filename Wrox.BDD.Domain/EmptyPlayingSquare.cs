using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wrox.BDD.Domain
{
    public class EmptyPlayingSquare : Square
    {
        public bool contains_token_matching(Token o_token)
        {
            return false;
        }

        public bool contains_token()
        {
            return false;
        }
    }
}
