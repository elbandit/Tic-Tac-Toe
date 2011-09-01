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
            _game_view.write_line("=========================");
            _game_view.write_line("Lets Play Tic-Tac-Toe!!!!");
            _game_view.write_line("=========================");
            _game_view.write_line("When prompted please input the");
            _game_view.write_line("coordinates of your move in the");
            _game_view.write_line("format row,col e.g. 0,1 for the");
            _game_view.write_line("first row and the second column");
            _game_view.write_line("");

            prompt_for_next_move();
        }

        private void prompt_for_next_move()
        {
            _game_view.write_line(String.Format(
                           "{0}, make your move.", _game.current_token()));
            _game_view.write_line("");
            _game_view.get_coordinates_for_next_move();
        }

        public void update_game_with_move(string move_coordinates)
        {
            place_token_for_players_input_of(move_coordinates);

            display_game();

            display_game_status();                          
        }

        private void display_game_status()
        {
            if (_game.the_current_player_has_won_the_game())
                announce_current_player_as_the_winner();
            else if (_game.has_ended_in_a_draw())
                announnce_that_the_game_has_ended_in_a_draw();
            else
                prompt_for_next_move();
        }

        private void place_token_for_players_input_of(string move_coordinates)
        {
            if (Coordinate.can_parse(move_coordinates))
            {
                var coordinate = Coordinate.parse(move_coordinates);

                if (_game.can_place_token_for_current_player_at(coordinate))
                    _game.place_token_for_current_player_at(coordinate);
                else
                    display_reason_for_not_being_able_to_place_token_at(coordinate);
            }
            else
            {
                _game_view.write_line(String.Format("{0} are invalid coordinates for a move, please use the format row,col.", move_coordinates));
                _game_view.write_line("");
            }
        }

        private void display_reason_for_not_being_able_to_place_token_at(Coordinate coordinate)
        {
            var reason = _game.reason_why_the_current_player_cannot_place_token_at(coordinate);

            if (reason == InvalidMoveReason.SquareOccupied)
                _game_view.write_line(String.Format("There is already a token in the square at coordinate {0}.", coordinate));
            if (reason == InvalidMoveReason.CoordinateOutsideOfGrid)
                _game_view.write_line(String.Format("There is not a square at coordinate {0}.", coordinate));

            _game_view.write_line("");
        }

        private void display_game()
        {
            _game_view.write(_board_renderer.render(_game));
            _game_view.write_line("");
        }

        private void announce_current_player_as_the_winner()
        {
            _game_view.write_line(string.Format("{0} has won the game!",
                                _game.current_token()));
        }

        private void announnce_that_the_game_has_ended_in_a_draw()
        { 
            _game_view.write_line("The game has ended in a draw!");            
        }
    }
}
