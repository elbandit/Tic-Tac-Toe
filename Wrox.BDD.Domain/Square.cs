using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wrox.BDD.Domain
{
    public interface Square
    {
        bool contains_token_matching(Token o_token);
    }
}
