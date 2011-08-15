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
               
        public FakeGameView()
        {
            _presenter = new TicTacToeGamePresenter(this,
                                                    new TicTacToe(new TokenTracker(), new NineSquareGrid(), new DiagonalWinningLineChecker()),
                                                    new PlainTextGameBoardRenderer());


            GameStorage.presenter = _presenter;

            _presenter.start();
        }

        public string display()
        {
            return _display.ToString();
        }

        public void clean_display()
        {
            _display.Clear();
        }

        public void WriteLine(string message)
        {
            _display.AppendLine(message);
        }

        public void get_coordinates_for_next_move()
        {
            
        }

        public void Write(string message)
        {
            _display.Append(message);
        }
    }
}
