using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wrox.BDD.Domain
{
    public class NineSquareGrid : Grid
    {
        protected readonly Token[,] _squares;

        public NineSquareGrid()
        {           
            _squares = new Token[3, 3];            
        }

        public void place_token_at(Coordinate coordinate, Token token)
        {
            _squares[coordinate.X, coordinate.Y] = token;
        }

        public bool contains_token_at(Coordinate coordinate)
        {
            return _squares[coordinate.X, coordinate.Y] != null;
        }

        public GridView generate_grid_view()
        {
            var readonly_squares = new string[3, 3];

            for (int row = 0; row < 3; row++)
                for (int column = 0; column < 3; column++)
                    readonly_squares[row, column] =
                                   _squares[row, column] == null ?
                                   "" : _squares[row, column].value;

            return new GridView() { squares = readonly_squares };
        }

        public Square square_at(Coordinate coordinate)
        {
            return contains_token_at(coordinate) ? (Square) 
                new PlayingSquare(_squares[coordinate.X, coordinate.Y]) :
                new EmptyPlayingSquare();

        }

        public bool is_square_at(Coordinate coordinate)
        {
            if (coordinate.Y > 2 || coordinate.X > 2)
                return false;
            else
                return true;
        }
    }    
}
