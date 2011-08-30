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
    public class when_starting_a_new_game : with_a_presenter
    {
        Establish context = () =>
        {
            
        };

        private Because of = () =>
        {
            SUT.start();
        };

        private It should_send_a_welcome_message_to_the_view = () =>
        {
            game_view.AssertWasCalled(x => x.write_line(Arg<String>.Is.Anything),
                                      a => a.Repeat.AtLeastOnce());
        };

        private It should_prompt_for_a_move = () =>
        {
            game_view.AssertWasCalled(x => x.get_coordinates_for_next_move());
        };

        private It should_ask_the_game_for_the_next_player_to_move = () =>
        {
            game.AssertWasCalled(x => x.current_token());
        };
                
    }   

}
