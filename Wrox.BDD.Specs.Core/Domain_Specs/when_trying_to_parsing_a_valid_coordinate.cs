using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Machine.Specifications;
using Wrox.BDD.Domain;
using NUnit.Framework;

namespace Wrox.BDD.Specs.Core.Domain_Specs
{
    [Subject(typeof(Coordinate))]
    public class when_parsing_a_valid_coordinate
    {
        private Because of = () =>
        {
            x_coordinate = "2";
            y_coordinate = "1";
            coordinate = Coordinate.parse(String.Format("{0},{1}", x_coordinate, y_coordinate));
        };

        private It should_be_able_to_correctly_parse_the_coordinate = () =>
        {
            Assert.That(coordinate.X, Is.EqualTo(int.Parse(x_coordinate)));
            Assert.That(coordinate.Y, Is.EqualTo(int.Parse(y_coordinate)));
        };

        private static Coordinate coordinate;
        private static string x_coordinate;
        private static string y_coordinate;
    }
}
