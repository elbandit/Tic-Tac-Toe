using Machine.Specifications;
using Rhino.Mocks;
using Wrox.BDD.Domain;
using NUnit.Framework;

namespace Wrox.BDD.Specs.Core.Domain_Specs
{
    [Subject(typeof(DiagonalWinningLineChecker))]
    public class when_checking_if_game_has_a_3_in_a_diagonal_line
    {
        Establish context = () =>
        {
            grid = MockRepository.GenerateStub<Grid>();
            square = MockRepository.GenerateStub<Square>();

            coordinate_0_0 = new Coordinate(0, 0);
            coordinate_1_1 = new Coordinate(1, 1);
            coordinate_2_2 = new Coordinate(2, 2);

            square.Stub(x => x.contains_token_matching(
                Arg<Token>.Matches(c => c.Equals(Tokens.x_token)))).Return(true);

            grid.Stub(x => x.square_at(Arg<Coordinate>.Matches(c => c.Equals(coordinate_0_0)))).Return(square);
            grid.Stub(x => x.square_at(Arg<Coordinate>.Matches(c => c.Equals(coordinate_1_1)))).Return(square);
            grid.Stub(x => x.square_at(Arg<Coordinate>.Matches(c => c.Equals(coordinate_2_2)))).Return(square);

            SUT = new DiagonalWinningLineChecker();
        };

        private Because of = () =>
        {
            result = SUT.contains_a_winning_line(grid);
        };

        private It should_check_for_3_X_tokens_from_left_to_right_diagonally = () =>
        {
            grid.AssertWasCalled(x => x.square_at(
                   Arg<Coordinate>.Matches(c => c.Equals(coordinate_0_0))));
            grid.AssertWasCalled(x => x.square_at(
                   Arg<Coordinate>.Matches(c => c.Equals(coordinate_1_1))));
            grid.AssertWasCalled(x => x.square_at(
                   Arg<Coordinate>.Matches(c => c.Equals(coordinate_2_2))));

            square.AssertWasCalled(x => x.contains_token_matching(
                   Arg<Token>.Matches(c => c.Equals(Tokens.x_token))), o => o.Repeat.Times(3));
        };

        private It should_find_a_winning_line = () =>
        {
            Assert.That(result, Is.True);
        }; 

        private static DiagonalWinningLineChecker SUT;
        private static Grid grid;
        private static Square square;
        private static bool result;
        private static Coordinate coordinate_0_0;
        private static Coordinate coordinate_1_1;
        private static Coordinate coordinate_2_2;
    }
}