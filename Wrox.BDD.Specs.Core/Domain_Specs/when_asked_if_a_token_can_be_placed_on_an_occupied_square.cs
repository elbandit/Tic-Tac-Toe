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
    public class when_asked_if_a_token_can_be_placed_on_an_occupied_square : with_a_tictactoe_game
    {
        Establish context = () =>
        {
            coordinate_text = "1,1";
            coordinate = Coordinate.parse(coordinate_text);

            occupied_square = MockRepository.GenerateStub<Square>();
            occupied_square.Stub(x => x.contains_token()).Return(true);

            tic_tac_toe_grid.Stub(x => x.is_square_at(Arg<Coordinate>.Matches(c => c.Equals(coordinate)))).Return(true);
            tic_tac_toe_grid.Stub(x => x.square_at(Arg<Coordinate>.Matches(c => c.Equals(coordinate)))).Return(occupied_square);
        };

        private Because of = () =>
        {
            result = SUT.can_place_token_for_current_player_at(coordinate);

            reason = SUT.reason_why_the_current_player_cannot_place_token_at(coordinate);
        };

        private It should_ask_the_grid_if_the_square_is_occupied = () =>
        {
            occupied_square.AssertWasCalled(x => x.contains_token());            
        };

        private It should_return_false = () =>
        {
            Assert.That(result, Is.False);
        };

        private It should_have_an_invalid_reason_of_coordinate_outside_of_grid = () =>
        {
            Assert.That(reason, Is.EqualTo(InvalidMoveReason.SquareOccupied));
        };

        private static Square occupied_square;
        private static bool result;
        private static Coordinate coordinate;
        private static string coordinate_text;
        private static InvalidMoveReason reason;
    }
}
