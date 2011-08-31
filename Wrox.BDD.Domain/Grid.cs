using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wrox.BDD.Domain
{
    public interface Grid
    {
        void place_token_at(Coordinate coordinate, Token token);        
        bool contains_token_at(Coordinate coordinate);
        bool is_square_at(Coordinate coordinate);
        bool is_full();
        GridView generate_grid_view();
        Square square_at(Coordinate coordinate);
    }
}
