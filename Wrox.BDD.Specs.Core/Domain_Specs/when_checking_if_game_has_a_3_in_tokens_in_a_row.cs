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
    [Subject(typeof(RowWinningLineChecker))]
    public class when_checking_if_game_has_a_3_in_tokens_in_a_row
    {
        Establish context = () =>
        {
            grid = MockRepository.GenerateStub<Grid>();
            square = MockRepository.GenerateStub<Square>();
            empty_square = MockRepository.GenerateStub<Square>();

            coordinate_0_0 = new Coordinate(0, 0);
            coordinate_0_1 = new Coordinate(0, 1);
            coordinate_0_2 = new Coordinate(0, 2);

            square.Stub(x => x.contains_token_matching(
                Arg<Token>.Matches(c => c.Equals(Tokens.x_token)))).Return(true);

            empty_square.Stub(x => x.contains_token_matching(
                Arg<Token>.Is.Anything)).Return(false);

            grid.Stub(x => x.square_at(Arg<Coordinate>.Matches(c => !c.Equals(coordinate_0_0) &&
                                                                    !c.Equals(coordinate_0_1) && 
                                                                    !c.Equals(coordinate_0_2) ))).Return(empty_square);

            grid.Stub(x => x.square_at(Arg<Coordinate>.Matches(c => c.Equals(coordinate_0_0)))).Return(square);
            grid.Stub(x => x.square_at(Arg<Coordinate>.Matches(c => c.Equals(coordinate_0_1)))).Return(square);
            grid.Stub(x => x.square_at(Arg<Coordinate>.Matches(c => c.Equals(coordinate_0_2)))).Return(square);

            SUT = new RowWinningLineChecker();
        };

        private Because of = () =>
        {
            result = SUT.contains_a_winning_line(grid);
        };

        private It should_get_the_first_square_in_each_row_twice_for_X_and_O_tokens = () =>
        {
            for (int row = 0; row < 3; row++)
            {
                grid.AssertWasCalled(x => x.square_at(Arg<Coordinate>.Matches(c => c.Equals(new Coordinate(row, 0)))), o => o.Repeat.Twice());                
            }
        };

        private It should_check_the_winning_row_for_3_X_tokens = () =>
        {            
            square.AssertWasCalled(x => x.contains_token_matching(Arg<Token>.Matches(c => c.Equals(Tokens.x_token))), o => o.Repeat.Times(3));
        };

        private It should_check_the_first_square_in_each_row_for_an_X_token = () =>
        {
            empty_square.AssertWasCalled(x => x.contains_token_matching(Arg<Token>.Matches(c => c.Equals(Tokens.x_token))), o => o.Repeat.Times(2));

            square.AssertWasCalled(x => x.contains_token_matching(Arg<Token>.Matches(c => c.Equals(Tokens.x_token))), o => o.Repeat.AtLeastOnce());
        };

        private It should_check_the_first_square_in_each_row_for_an_O_token = () =>
        {
            empty_square.AssertWasCalled(x => x.contains_token_matching(Arg<Token>.Matches(c => c.Equals(Tokens.o_token))), o => o.Repeat.Times(2));

            square.AssertWasCalled(x => x.contains_token_matching(Arg<Token>.Matches(c => c.Equals(Tokens.o_token))), o => o.Repeat.Times(1));
        };
        
        private It should_find_a_winning_line = () =>
        {
            Assert.That(result, Is.True);
        };

        private static RowWinningLineChecker SUT;
        private static Grid grid;
        private static Square square;
        private static Square empty_square;
        private static bool result;
        private static Coordinate coordinate_0_0;
        private static Coordinate coordinate_0_1;
        private static Coordinate coordinate_0_2;
    }
}
