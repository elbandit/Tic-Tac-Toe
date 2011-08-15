using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wrox.BDD.Domain
{
    public class TicTacToe : Game
    {
        private PlayerTracker _player_tracker;
        private Grid _grid;
        private readonly LineChecker _line_checker;

        public TicTacToe(PlayerTracker player_tracker, Grid grid, LineChecker line_checker)
        {
            _player_tracker = player_tracker;
            _grid = grid;
            _line_checker = line_checker;
        }

        public Token current_token()
        {
            return _player_tracker.current_player();
        }

        public void place_token_for_current_player_at(Coordinate coordinate)
        {
            _grid.place_token_at(coordinate, current_token());

            if (!the_current_player_has_won_the_game())
                _player_tracker.finish_players_move();                
        }

        public GridView get_game_view()
        {
            return _grid.generate_grid_view();
        }

        public bool the_current_player_has_won_the_game()
        {
            return _line_checker.contains_a_winning_line(_grid);
        }
    }
}
