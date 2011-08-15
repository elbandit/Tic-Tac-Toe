using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wrox.BDD.Domain
{
    public interface PlayerTracker
    {
        Token current_player();
        void finish_players_move();
    }
}
