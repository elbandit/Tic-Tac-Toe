using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wrox.BDD.Domain
{
    public interface LineChecker
    {
        bool contains_a_winning_line(Grid tic_tac_toe_grid);
    }
}
