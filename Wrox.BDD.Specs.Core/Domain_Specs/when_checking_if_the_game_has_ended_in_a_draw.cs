using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Machine.Specifications;
using Wrox.BDD.Domain;
using Rhino.Mocks;

namespace Wrox.BDD.Specs.Core.Domain_Specs
{
    [Subject(typeof(TicTacToe))]
    public class when_checking_if_the_game_has_ended_in_a_draw : with_a_tictactoe_game
    {
        private Because of = () =>
        {
            SUT.has_ended_in_a_draw();
        };

        private It should_ask_the_grid_if_it_is_full = () =>
        {
            tic_tac_toe_grid.AssertWasCalled(x => x.is_full());
        };
    }
}
