using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Machine.Specifications;
using Wrox.BDD.Domain;
using Wrox.BDD.Ui.Console.Presentation;
using Rhino.Mocks;

namespace Wrox.BDD.Specs.Core.Presentation_Specs
{
    [Subject(typeof(TicTacToeGamePresenter))]
    public class when_a_player_gets_3_tokens_in_a_row : with_a_presenter
    {
        Establish context = () =>
        {
            coordinate_text = "1,1";
            coordinate = Coordinate.parse(coordinate_text);

            game.Stub(x => x.current_token()).Return(Tokens.x_token);
            game.Stub(x => x.the_current_player_has_won_the_game()).Return(true);
        };

        private Because of = () =>
        {
            SUT.start();

            SUT.update_game_with_move(coordinate_text);
        };

        private It should_announce_that_he_has_won_the_game = () =>
        {
            game_view.AssertWasCalled(x => x.write_line("X has won the game!"));
        };


        private static Coordinate coordinate;
        private static string coordinate_text;
    }
}
