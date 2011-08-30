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
    public class when_a_player_places_a_token : with_a_presenter
    {
        Establish context = () =>
        {
            coordinate_text = "1,1";
            coordinate = Coordinate.parse(coordinate_text);

            game.Stub(x => x.can_place_token_for_current_player_at(Arg<Coordinate>.Matches(c => c.Equals(coordinate)))).Return(true);
        };

        private Because of = () =>
        {
            SUT.start();

            SUT.update_game_with_move(coordinate_text);
        };

        private It should_tell_the_game_to_place_a_token = () =>
        {
            game.AssertWasCalled(x => x.place_token_for_current_player_at(
                                 Arg<Coordinate>.Matches(c => c.Equals(coordinate))));
        };

        private It should_render_the_game = () =>
        {
            board_renderer.AssertWasCalled(x => x.render(game));
        };

        private It should_check_if_the_current_player_has_won_the_game = () =>
        {
            game.AssertWasCalled(x => x.the_current_player_has_won_the_game());
        };

        private static Coordinate coordinate;
        private static string coordinate_text;
    }
}

