using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Rhino.Mocks;
using Wrox.BDD.Ui.Console.Presentation;
using Wrox.BDD.Domain;

namespace Wrox.BDD.Specs.Core.Presentation_Specs
{
    public abstract class with_a_presenter
    {
        public with_a_presenter()
        {
            game_view = MockRepository.GenerateStub<GameView>();
            game = MockRepository.GenerateStub<Game>();
            board_renderer = MockRepository.GenerateStub<BoardRenderer>();

            SUT = new TicTacToeGamePresenter(game_view, game, board_renderer);
        }

        protected static TicTacToeGamePresenter SUT;
        protected static Game game;
        protected static GameView game_view;
        protected static BoardRenderer board_renderer;
    }
}
