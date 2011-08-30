using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Machine.Specifications;
using Wrox.BDD.Domain;
using NUnit.Framework;

namespace Wrox.BDD.Specs.Core.Domain_Specs
{
    [Subject(typeof(NineSquareGrid))]
    public class when_checking_for_a_token_on_the_grid
    {
        Establish context = () =>
        {
            coordinate_with_token = Coordinate.parse("1,1");
            coordinate_without_token = Coordinate.parse("2,2");
            SUT = new NineSquareGrid();
        };

        private Because of = () =>
        {
            SUT.place_token_at(coordinate_with_token, Tokens.x_token);
        };

        private It should_contain_a_token = () =>
        {
            Assert.That(SUT.contains_token_at(coordinate_with_token), Is.True);
        };

        private It should_not_contain_a_token = () =>
        {
            Assert.That(SUT.contains_token_at(coordinate_without_token), Is.False);
        };

        private It should_be_able_to_match_the_token = () =>
        {
            Assert.That(SUT.square_at(coordinate_with_token)
                           .contains_token_matching(Tokens.x_token), Is.True);
        };

        private It should_not_match_a_missing_token = () =>
        {
            Assert.That(SUT.square_at(coordinate_without_token)
                       .contains_token_matching(Tokens.o_token), Is.False);
        };

        private static NineSquareGrid SUT;
        private static Coordinate coordinate_with_token;
        private static Coordinate coordinate_without_token;
    }
}

