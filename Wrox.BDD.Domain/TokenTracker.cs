using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wrox.BDD.Domain
{
    public class TokenTracker : PlayerTracker
    {
        private Token _current_playing_token = Tokens.x_token;

        public Token current_player()
        {
            return _current_playing_token;
        }

        public void finish_players_move()
        {
            _current_playing_token = (_current_playing_token.Equals(Tokens.x_token)) ? Tokens.o_token : Tokens.x_token;
        }
    }
}
