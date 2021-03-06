﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wrox.BDD.Domain
{
    public class PlayingSquare : Square
    {
        private readonly Token _token;

        public PlayingSquare(Token token)
        {
            _token = token;
        }

        public bool contains_token_matching(Token token)
        {
            return _token.Equals(token);
        }

        public bool contains_token()
        {
            return true;
        }
    }
}
