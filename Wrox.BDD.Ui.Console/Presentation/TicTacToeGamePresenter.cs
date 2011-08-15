using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wrox.BDD.Domain;

namespace Wrox.BDD.Ui.Console.Presentation
{
    public class TicTacToeGamePresenter
    {
        private readonly GameView _game_view;
        private readonly Game _game;
        private readonly BoardRenderer _board_renderer;

        public TicTacToeGamePresenter(GameView game_view, Game game, BoardRenderer board_renderer)
        {
            _game_view = game_view;
            _game = game;
            _board_renderer = board_renderer;
        }

        public void start()
        {
            _game_view.WriteLine("=========================");
            _game_view.WriteLine("Lets Play Tic-Tac-Toe!!!!");
            _game_view.WriteLine("=========================");
            _game_view.WriteLine("When prompted please input the");
            _game_view.WriteLine("coordinates of your move in the");
            _game_view.WriteLine("format row,col e.g. 0,1 for the");
            _game_view.WriteLine("first row and the second column");
            _game_view.WriteLine("");

            prompt_for_next_move();      
        }

        private void prompt_for_next_move()
        {
            _game_view.WriteLine(String.Format("{0}, make your move.", _game.current_token()));
            _game_view.WriteLine("");
            _game_view.get_coordinates_for_next_move();
        }

        public void update_game_with_move(string move_coordinates)
        {
            var coordinate = Coordinate.parse(move_coordinates);

            _game.place_token_for_current_player_at(coordinate);

            display_game();
            
            if (_game.the_current_player_has_won_the_game())
                announce_current_player_as_the_winner();
            else
                prompt_for_next_move();                            
        }

        private void announce_current_player_as_the_winner()
        {
            _game_view.WriteLine(string.Format("{0} has won the game!", _game.current_token()));
        }

        private void display_game()
        {
            _game_view.Write(_board_renderer.render(_game));
            _game_view.WriteLine("");
        }
    }
}
