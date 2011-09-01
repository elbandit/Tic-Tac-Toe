using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wrox.BDD.Domain
{
    public class ColumnWinningLineChecker : LineChecker
    {
        public bool contains_a_winning_line(Grid tic_tac_toe_grid)
        {
           var found_winning_column = false;

           for (int column = 0; column < 3; column++)
           {
               if (found_3_tokens_in_a_column_for(column, Tokens.x_token, tic_tac_toe_grid))
                   found_winning_column = true;

               if (found_3_tokens_in_a_column_for(column, Tokens.o_token, tic_tac_toe_grid))
                   found_winning_column = true;
           }

           return found_winning_column;
        }

        private bool found_3_tokens_in_a_column_for(int column, Token token, Grid tic_tac_toe_grid)
        {         
            return  tic_tac_toe_grid.square_at(new Coordinate(0,column)).contains_token_matching(token) &&
                    tic_tac_toe_grid.square_at(new Coordinate(1,column)).contains_token_matching(token) &&
                    tic_tac_toe_grid.square_at(new Coordinate(2,column)).contains_token_matching(token);                
        }
    }
}
