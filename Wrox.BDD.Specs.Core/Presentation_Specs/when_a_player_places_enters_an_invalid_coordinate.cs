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
    public class when_a_player_places_enters_an_invalid_coordinate : with_a_presenter
    {
        Establish context = () =>
        {
            coordinate_text = "rrr,fff";                                    
        };

        private Because of = () =>
        {
            SUT.start();

            SUT.update_game_with_move(coordinate_text);            
        };
                       
        private It should_display_that_the_inputted_coordinate_is_not_valid = () =>
        {
            game_view.AssertWasCalled(x => x.write_line("rrr,fff are invalid coordinates for a move, please use the format row,col."));
        };

        private static Coordinate coordinate;
        private static string coordinate_text;
    }
}

