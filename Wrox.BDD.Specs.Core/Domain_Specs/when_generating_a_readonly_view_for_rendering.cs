using System;
using System.Collections.Generic;
using Machine.Specifications;
using Wrox.BDD.Domain;
using NUnit.Framework;

namespace Wrox.BDD.Specs.Core.Domain_Specs
{
    [Subject(typeof(NineSquareGrid))]
    public class when_generating_a_readonly_view_for_rendering
    {
        Establish context = () =>
        {
            coordinate_with_X_token = Coordinate.parse("1,1");
            coordinate_with_O_token = Coordinate.parse("2,2");
            SUT = new NineSquareGrid();
        };

        private Because of = () =>
        {
            SUT.place_token_at(coordinate_with_X_token, Tokens.x_token);
            SUT.place_token_at(coordinate_with_O_token, Tokens.o_token);

            result = SUT.generate_grid_view();
        };

        private It should_have_the_X_token_in_the_correct_position = () =>
        {
            Assert.That(result.squares[coordinate_with_X_token.X, coordinate_with_X_token.Y], Is.EqualTo(Tokens.x_token.value));
        };

        private It should_have_the_O_token_in_the_correct_position = () =>
        {
            Assert.That(result.squares[coordinate_with_O_token.X, coordinate_with_O_token.Y], Is.EqualTo(Tokens.o_token.value));
        };

        private static GridView result;
        private static NineSquareGrid SUT;
        private static Coordinate coordinate_with_X_token;
        private static Coordinate coordinate_with_O_token;
    }
}
