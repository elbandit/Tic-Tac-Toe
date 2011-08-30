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
    public class when_trying_to_parse_an_invalid_coordinate
    {
        private Because of = () =>
        {            
            result = Coordinate.can_parse("rrr,fff");
        };

        private It should_be_able_to_correctly_parse_the_coordinate = () =>
        {
            Assert.That(result, Is.False);            
        };

        private static bool result;        
    }
}
