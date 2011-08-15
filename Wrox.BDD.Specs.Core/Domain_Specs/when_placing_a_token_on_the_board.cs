using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Machine.Specifications;
using Rhino.Mocks;
using Wrox.BDD.Domain;

namespace Wrox.BDD.Specs.Core.Domain_Specs
{
    [Subject(typeof(TicTacToe))]
    public class when_placing_a_token_on_the_board : with_a_tictactoe_game
    {
        Establish context = () =>
        {
            coordinate_text = "1,1";
            coordinate = Coordinate.parse(coordinate_text);

            player_tracker.Stub(x => x.current_player()).Return(Tokens.x_token);
        };

        private Because of = () =>
        {
            SUT.place_token_for_current_player_at(coordinate);
        };

        private It should_place_a_token_on_the_grid = () =>
        {
            tic_tac_toe_grid.AssertWasCalled(x => x.place_token_at(
                Arg<Coordinate>.Matches(c => c.Equals(coordinate)),
                Arg<Token>.Matches(c => c.Equals(Tokens.x_token))));            
        };

        private It should_alternate_the_player = () =>
        {
            player_tracker.AssertWasCalled(x => x.finish_players_move());
        };        
  
        private static Coordinate coordinate;
        private static string coordinate_text;    
    }
}
