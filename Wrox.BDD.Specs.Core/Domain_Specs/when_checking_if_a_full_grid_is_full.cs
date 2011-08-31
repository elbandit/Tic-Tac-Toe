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
    [Subject(typeof(TicTacToe))]
    public class when_checking_if_a_full_grid_is_full
    {
        Establish context = () =>
        {            
            SUT = new NineSquareGrid();

            for (int row = 0; row < 3; row++)
                for (int column = 0; column < 3; column++)
                { 
                    SUT.place_token_at(Coordinate.parse(String.Format("{0},{1}", row, column)), Tokens.x_token);
                }
        };

        private Because of = () =>
        {
            result = SUT.is_full();
        };

        private It should_be_full = () =>
        {
            Assert.That(result, Is.True);
        };

        private static NineSquareGrid SUT;
        private static bool result;
    }
}
