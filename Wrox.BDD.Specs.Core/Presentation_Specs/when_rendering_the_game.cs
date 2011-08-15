using System;
using Machine.Specifications;
using Wrox.BDD.Domain;
using Wrox.BDD.Ui.Console.Presentation;
using Rhino.Mocks;

namespace Wrox.BDD.Specs.Core.Presentation_Specs
{
    [Subject(typeof(PlainTextGameBoardRenderer))]
    public class when_rendering_the_game
    {
        Establish context = () =>
        {
            var square_array = new string[3, 3];
            game = MockRepository.GenerateStub<Game>();
            game.Stub(x => x.get_game_view()).Return(new GridView() { squares = square_array });
            SUT = new PlainTextGameBoardRenderer();
        };

        private Because of = () =>
        {
            SUT.render(game);
        };

        private It should_ask_the_game_for_a_readonly_view = () =>
        {
            game.AssertWasCalled(x => x.get_game_view());
        };

        private static PlainTextGameBoardRenderer SUT;
        private static Game game;
    }
}
