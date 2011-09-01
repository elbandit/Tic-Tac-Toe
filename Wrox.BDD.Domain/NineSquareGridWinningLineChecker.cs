using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wrox.BDD.Domain
{
    public class NineSquareGridWinningLineChecker : LineChecker 
    {
        private LineChecker _diagonal_winning_line_checker;
        private LineChecker _column_winning_line_checker;
        private LineChecker _row_winning_line_checker;

        public NineSquareGridWinningLineChecker(LineChecker diagonal_winning_line_checker,
                                                LineChecker column_winning_line_checker,
                                                LineChecker row_winning_line_checker)
        {
            _diagonal_winning_line_checker = diagonal_winning_line_checker;
            _column_winning_line_checker = column_winning_line_checker;
            _row_winning_line_checker = row_winning_line_checker;
        }
        public bool contains_a_winning_line(Grid tic_tac_toe_grid)
        {
            return _diagonal_winning_line_checker.contains_a_winning_line(tic_tac_toe_grid) ||
                   _column_winning_line_checker.contains_a_winning_line(tic_tac_toe_grid) ||
                   _row_winning_line_checker.contains_a_winning_line(tic_tac_toe_grid);
        }
    }
}
