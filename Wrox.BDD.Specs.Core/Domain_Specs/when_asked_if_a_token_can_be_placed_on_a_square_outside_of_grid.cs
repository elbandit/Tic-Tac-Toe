using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Machine.Specifications;
using Rhino.Mocks;
using NUnit.Framework;
using Wrox.BDD.Domain;

namespace Wrox.BDD.Specs.Core.Domain_Specs
{
    [Subject(typeof(TicTacToe))]
    public class when_asked_if_a_token_can_be_placed_on_a_square_outside_of_grid : with_a_tictactoe_game
    {
        Establish context = () =>
        {
            coordinate_text = "100,100";
            coordinate = Coordinate.parse(coordinate_text);
            
            tic_tac_toe_grid.Stub(x => x.is_square_at(Arg<Coordinate>.Matches(c => c.Equals(coordinate)))).Return(false);
        };

        private Because of = () =>
        {
            result = SUT.can_place_token_for_current_player_at(coordinate);
            reason = SUT.reason_why_the_current_player_cannot_place_token_at(coordinate);
        };

        private It should_ask_the_grid_if_there_is_a_square_at_this_coordinate = () =>
        {
            tic_tac_toe_grid.AssertWasCalled(x => x.is_square_at(Arg<Coordinate>.Matches(c => c.Equals(coordinate))), o => o.Repeat.Twice());            
        };

        private It should_return_false = () =>
        {
            Assert.That(result, Is.False);
        };

        private It should_have_an_invalid_reason_of_coordinate_outside_of_grid  = () =>
        {
            Assert.That(reason, Is.EqualTo(InvalidMoveReason.CoordinateOutsideOfGrid));
        };
        
        private static bool result;
        private static Coordinate coordinate;
        private static string coordinate_text;
        private static InvalidMoveReason reason;
    }
}
