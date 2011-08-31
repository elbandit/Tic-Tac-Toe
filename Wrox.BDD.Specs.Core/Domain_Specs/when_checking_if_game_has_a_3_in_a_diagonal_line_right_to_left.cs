using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Machine.Specifications;
using Wrox.BDD.Domain;
using Rhino.Mocks;
using NUnit.Framework;

namespace Wrox.BDD.Specs.Core.Domain_Specs
{
    [Subject(typeof(DiagonalWinningLineChecker))]
    public class when_checking_if_game_has_a_3_in_a_diagonal_line_right_to_left
    {
        Establish context = () =>
        {
            grid = MockRepository.GenerateStub<Grid>();
            square = MockRepository.GenerateStub<Square>();
            empty_square = MockRepository.GenerateStub<Square>();

            coordinate_0_2 = new Coordinate(0, 2);
            coordinate_1_1 = new Coordinate(1, 1);
            coordinate_2_0 = new Coordinate(2, 0);

            square.Stub(x => x.contains_token_matching(
                Arg<Token>.Matches(c => c.Equals(Tokens.x_token)))).Return(true);

            square.Stub(x => x.contains_token_matching(Arg<Token>.Is.Anything)).Return(false);

            grid.Stub(x => x.square_at(Arg<Coordinate>.Matches(c => !c.Equals(coordinate_0_2) && !c.Equals(coordinate_1_1) && !c.Equals(coordinate_2_0)))).Return(empty_square);

            grid.Stub(x => x.square_at(Arg<Coordinate>.Matches(c => c.Equals(coordinate_0_2)))).Return(square);
            grid.Stub(x => x.square_at(Arg<Coordinate>.Matches(c => c.Equals(coordinate_1_1)))).Return(square);
            grid.Stub(x => x.square_at(Arg<Coordinate>.Matches(c => c.Equals(coordinate_2_0)))).Return(square);

            SUT = new DiagonalWinningLineChecker();
        };

        private Because of = () =>
        {
            result = SUT.contains_a_winning_line(grid);
        };

        private It should_check_for_3_X_tokens_from_right_to_left_diagonally = () =>
        {
            grid.AssertWasCalled(x => x.square_at(
                   Arg<Coordinate>.Matches(c => c.Equals(coordinate_0_2))));
            grid.AssertWasCalled(x => x.square_at(
                   Arg<Coordinate>.Matches(c => c.Equals(coordinate_1_1))));
            grid.AssertWasCalled(x => x.square_at(
                   Arg<Coordinate>.Matches(c => c.Equals(coordinate_2_0))));

            square.AssertWasCalled(x => x.contains_token_matching(
                   Arg<Token>.Matches(c => c.Equals(Tokens.x_token))),
                                      o => o.Repeat.Times(3));
        };

        private It should_find_a_winning_line = () =>
        {
            Assert.That(result, Is.True);
        };

        private static DiagonalWinningLineChecker SUT;
        private static Grid grid;
        private static Square square;
        private static Square empty_square;
        private static bool result;
        private static Coordinate coordinate_0_2;
        private static Coordinate coordinate_1_1;
        private static Coordinate coordinate_2_0;
    }
}
