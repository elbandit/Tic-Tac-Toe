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
    public class when_parsing_an_invalid_coordinate
    {
        private Because of =() =>
        {
           exception = Catch.Exception(() => { Coordinate.parse("ff,fff"); });
        };
        
        private It should_throw_an_exception = () =>
        {
            exception.ShouldNotBeNull();
        };

       private static Exception exception;

    }
}
