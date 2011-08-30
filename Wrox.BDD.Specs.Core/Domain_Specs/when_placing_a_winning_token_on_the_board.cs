using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Machine.Specifications;
using Wrox.BDD.Domain;
using NUnit.Framework;
using Rhino.Mocks;

namespace Wrox.BDD.Specs.Core.Domain_Specs
{
    [Subject(typeof(TicTacToe))]
    public class when_placing_a_winning_token_on_the_board : with_a_tictactoe_game
    {
        Establish context = () =>
        {
            coordinate_text = "1,1";
            coordinate = Coordinate.parse(coordinate_text);

            line_checker.Stub(x =>
                              x.contains_a_winning_line(Arg<Grid>.Is.Anything)).Return(true);

            player_tracker.Stub(x => x.current_player()).Return(Tokens.x_token);
        };

        private Because of = () =>
        {
            SUT.place_token_for_current_player_at(coordinate);
        };

        private It should_not_alternate_the_player = () =>
        {
            player_tracker.AssertWasNotCalled(x => x.finish_players_move());
        };

        private static Coordinate coordinate;
        private static string coordinate_text;
    }
}