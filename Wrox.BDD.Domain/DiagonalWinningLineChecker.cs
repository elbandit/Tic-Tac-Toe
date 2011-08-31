using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wrox.BDD.Domain
{
    public class DiagonalWinningLineChecker : LineChecker
    {            
        public bool contains_a_winning_line(Grid tic_tac_toe_grid)
        {
            if (found_diagonal_winning_line_for(Tokens.x_token, tic_tac_toe_grid) ||
                found_diagonal_winning_line_for(Tokens.o_token, tic_tac_toe_grid))
                return true;
            else
                return false;
        }

        private static bool found_diagonal_winning_line_for(Token token, Grid tic_tac_toe_grid)
        {
            bool found_winning_line = false;
            var coordinate_0_0 = new Coordinate(0, 0);
            var coordinate_1_1 = new Coordinate(1, 1);
            var coordinate_2_2 = new Coordinate(2, 2);

            var coordinate_0_2 = new Coordinate(0, 2);
            var coordinate_2_0 = new Coordinate(2, 0);

            if (tic_tac_toe_grid.square_at(coordinate_0_0)
                         .contains_token_matching(token) &&
                tic_tac_toe_grid.square_at(coordinate_1_1)
                         .contains_token_matching(token) &&
                tic_tac_toe_grid.square_at(coordinate_2_2)
                         .contains_token_matching(token))
                found_winning_line = true;

            else if (tic_tac_toe_grid.square_at(coordinate_0_2)
                        .contains_token_matching(token) &&
               tic_tac_toe_grid.square_at(coordinate_1_1)
                        .contains_token_matching(token) &&
               tic_tac_toe_grid.square_at(coordinate_2_0)
                        .contains_token_matching(token))
                found_winning_line = true;

            return found_winning_line;
        }
    }
}
