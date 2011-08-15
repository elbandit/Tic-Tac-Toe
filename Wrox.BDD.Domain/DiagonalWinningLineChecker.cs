namespace Wrox.BDD.Domain
{
    public class DiagonalWinningLineChecker : LineChecker
    {
        public bool contains_a_winning_line(Grid tic_tac_toe_grid)
        {
            var coordinate_0_0 = new Coordinate(0, 0);
            var coordinate_1_1 = new Coordinate(1, 1);
            var coordinate_2_2 = new Coordinate(2, 2);

            if (tic_tac_toe_grid.square_at(coordinate_0_0).contains_token_matching(Tokens.x_token) &&
                tic_tac_toe_grid.square_at(coordinate_1_1).contains_token_matching(Tokens.x_token) &&
                tic_tac_toe_grid.square_at(coordinate_2_2).contains_token_matching(Tokens.x_token))
                return true;

            return false;
        }
    }
}