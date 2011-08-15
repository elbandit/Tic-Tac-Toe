using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wrox.BDD.Domain;
using Rhino.Mocks;

namespace Wrox.BDD.Specs.Core.Domain_Specs
{
    public abstract class with_a_tictactoe_game
    {
        public with_a_tictactoe_game()
        {
            player_tracker = MockRepository.GenerateStub<PlayerTracker>();
            tic_tac_toe_grid = MockRepository.GenerateStub<Grid>();
            line_checker = MockRepository.GenerateStub<LineChecker>();

            SUT = new TicTacToe(player_tracker, tic_tac_toe_grid, line_checker);
        }

        protected static Game SUT;
        protected static PlayerTracker player_tracker;
        protected static Grid tic_tac_toe_grid;
        protected static LineChecker line_checker;
    }
}
