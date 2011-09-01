using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wrox.BDD.Domain
{
    public class RowWinningLineChecker : LineChecker
    {
        public bool contains_a_winning_line(Grid tic_tac_toe_grid)
        {
           var found_winning_row = false;

           for (int row = 0; row < 3; row++)
           {
               if (found_3_tokens_in_a_row_for(row, Tokens.x_token, tic_tac_toe_grid))
                   found_winning_row = true;

               if (found_3_tokens_in_a_row_for(row, Tokens.o_token, tic_tac_toe_grid))
                   found_winning_row = true;
           }

           return found_winning_row;
        }

        private bool found_3_tokens_in_a_row_for(int row, Token token, Grid tic_tac_toe_grid)
        {         
            return  tic_tac_toe_grid.square_at(new Coordinate(row,0)).contains_token_matching(token) &&
                    tic_tac_toe_grid.square_at(new Coordinate(row,1)).contains_token_matching(token) &&
                    tic_tac_toe_grid.square_at(new Coordinate(row,2)).contains_token_matching(token);                
        }
    }
}
