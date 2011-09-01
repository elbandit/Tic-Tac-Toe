using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wrox.BDD.Ui.Console.Presentation;
using Wrox.BDD.Domain;
using Wrox.BDD.Specs.UAT.StepHelpers;

namespace Wrox.BDD.Specs.UAT
{
    public class FakeGameView : GameView
    {
        private TicTacToeGamePresenter _presenter;
        private StringBuilder _display = new StringBuilder();

        public string display()
        {
            return _display.ToString();
        }

        public FakeGameView()
        {
            var _presenter = new TicTacToeGamePresenter(this, new TicTacToe(new TokenTracker(), new NineSquareGrid(), new NineSquareGridWinningLineChecker(new DiagonalWinningLineChecker(), new ColumnWinningLineChecker(), new RowWinningLineChecker())), new PlainTextGameBoardRenderer());

            GameStorage.presenter = _presenter;
            _presenter.start();
        }

        public void write_line(string message)
        {
            _display.AppendLine(message);
        }

        public void write(string message)
        {
            _display.Append(message);
        }

        public void get_coordinates_for_next_move()
        {

        }

        public void clean_display()
        {
            _display.Clear();
        }
    }
}
