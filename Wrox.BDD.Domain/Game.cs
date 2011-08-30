using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wrox.BDD.Domain
{
    public interface Game
    {
        Token current_token();

        void place_token_for_current_player_at(Coordinate coordinate);
        bool can_place_token_for_current_player_at(Coordinate coordinate);
        InvalidMoveReason reason_why_the_current_player_cannot_place_token_at(Coordinate coordinate);

        GridView get_game_view();
        bool the_current_player_has_won_the_game();
    }
}
