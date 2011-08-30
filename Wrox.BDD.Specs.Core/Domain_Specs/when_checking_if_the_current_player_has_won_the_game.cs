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
    public class when_checking_if_the_current_player_has_won_the_game :
                                                           with_a_tictactoe_game
    {
        private Because of = () =>
        {
            SUT.the_current_player_has_won_the_game();
        };

        private It should_tell_the_game_to_place_a_token = () =>
        {
            line_checker.AssertWasCalled(x =>
                       x.contains_a_winning_line(tic_tac_toe_grid));
        };
    }
}
