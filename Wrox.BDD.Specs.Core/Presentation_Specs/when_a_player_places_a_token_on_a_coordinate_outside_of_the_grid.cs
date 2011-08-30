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
    public class when_a_player_places_a_token_on_a_coordinate_outside_of_the_grid : with_a_presenter
    {
        Establish context = () =>
        {
            coordinate_text = "100,100";
            coordinate = Coordinate.parse(coordinate_text);

            game.Stub(x => x.reason_why_the_current_player_cannot_place_token_at(Arg<Coordinate>.Matches(c => c.Equals(coordinate)))).Return(InvalidMoveReason.CoordinateOutsideOfGrid);

            game.Stub(x => x.can_place_token_for_current_player_at(Arg<Coordinate>.Matches(c => c.Equals(coordinate)))).Return(false);            
        };

        private Because of = () =>
        {
            SUT.start();

            SUT.update_game_with_move(coordinate_text);            
        };

        private It should_ask_the_game_if_this_is_a_valid_move = () =>
        {
            game.AssertWasCalled(x => x.can_place_token_for_current_player_at(
                                 Arg<Coordinate>.Matches(c => c.Equals(coordinate))));
        };

        private It should_ask_the_game_why_the_move_is_not_valid = () =>
        {
            game.AssertWasCalled(x => x.reason_why_the_current_player_cannot_place_token_at(
                                 Arg<Coordinate>.Matches(c => c.Equals(coordinate))));
        };
        
        private It should_display_why_the_move_is_not_valid = () =>
        {
            game_view.AssertWasCalled(x => x.write_line("There is not a square at coordinate 100,100."));
        };

        private static Coordinate coordinate;
        private static string coordinate_text;
    }
}

