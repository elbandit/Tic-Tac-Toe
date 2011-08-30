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
    public class when_checking_for_a_square_on_the_grid_for_an_invalid_coordinate
    {
        Establish context = () =>
        {
            invalid_coordinate = Coordinate.parse("100,100");
            
            SUT = new NineSquareGrid();
        };

        private Because of = () =>
        {
            result = SUT.is_square_at(invalid_coordinate);
        };

        private It should_return_false = () =>
        {
            Assert.That(result, Is.False);
        };
       
        private static NineSquareGrid SUT;
        private static Coordinate invalid_coordinate;
        private static bool result;
    }
}

