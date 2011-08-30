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
    public class when_checking_for_a_square_on_the_grid_for_a_valid_coordinate
    {
        Establish context = () =>
        {
            valid_coordinate = Coordinate.parse("1,1");

            SUT = new NineSquareGrid();
        };

        private Because of = () =>
        {
            result = SUT.is_square_at(valid_coordinate);
        };

        private It should_return_true = () =>
        {
            Assert.That(result, Is.True);
        };

        private static NineSquareGrid SUT;
        private static Coordinate valid_coordinate;
        private static bool result;
    }
}

