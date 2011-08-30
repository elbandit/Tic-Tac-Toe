using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Machine.Specifications;
using Rhino.Mocks;
using Wrox.BDD.Ui.Console.Presentation;
using Wrox.BDD.Domain;

namespace Wrox.BDD.Specs.Core.Presentation_Specs
{
    [Subject(typeof(TicTacToeGamePresenter))]
    public class when_a_player_places_a_token_on_an_occupied_square : with_a_presenter
    {
        Establish context = () =>
        {
            coordinate_text = "1,1";
            coordinate = Coordinate.parse(coordinate_text);

            game.Stub(x => x.reason_why_the_current_player_cannot_place_token_at(Arg<Coordinate>.Matches(c => c.Equals(coordinate)))).Return(InvalidMoveReason.SquareOccupied);

            game.Stub(x => x.can_place_token_for_current_player_at(Arg<Coordinate>.Matches(c => c.Equals(coordinate)))).Return(true).Repeat.Once();
            game.Stub(x => x.can_place_token_for_current_player_at(coordinate)).Return(false);
        };

        private Because of = () =>
        {
            SUT.start();

            SUT.update_game_with_move(coordinate_text);
            SUT.update_game_with_move(coordinate_text);
        };

        private It should_ask_the_game_if_this_is_a_valid_move = () =>
        {
            game.AssertWasCalled(x => x.can_place_token_for_current_player_at(
                                 Arg<Coordinate>.Matches(c => c.Equals(coordinate))), o => o.Repeat.Twice());
        };

        private It should_ask_the_game_why_the_move_is_not_valid = () =>
        {
            game.AssertWasCalled(x => x.reason_why_the_current_player_cannot_place_token_at(
                                 Arg<Coordinate>.Matches(c => c.Equals(coordinate))));
        };

        private It should_display_why_the_move_is_not_valid = () =>
        {
            game_view.AssertWasCalled(x => x.write_line("There is already a token in the square at coordinate 1,1."));
        };

        private static Coordinate coordinate;
        private static string coordinate_text;
    }
}

