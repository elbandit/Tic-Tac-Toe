using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wrox.BDD.Ui.Console.Presentation;
using Wrox.BDD.Domain;

namespace Wrox.BDD.Ui.Console
{
    public class ConsoleGameView : GameView
    {
        private TicTacToeGamePresenter _presenter;

        public ConsoleGameView()
        {
            _presenter = new TicTacToeGamePresenter(this, new TicTacToe(new TokenTracker(), new NineSquareGrid(), new DiagonalWinningLineChecker()), new PlainTextGameBoardRenderer());

            _presenter.start();
        }

        public void write_line(string message)
        {
            System.Console.WriteLine(message);
        }

        public void write(string message)
        {
            System.Console.Write(message);
        }                

        public void get_coordinates_for_next_move()
        {
            var coordinates = System.Console.ReadLine();

            _presenter.update_game_with_move(coordinates);    
        }
    }

}
