using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wrox.BDD.Domain;

namespace Wrox.BDD.Ui.Console.Presentation
{
    public class PlainTextGameBoardRenderer : BoardRenderer 
    {
        public string render(Game game)
        {
            var squares = game.get_game_view().squares;
            
            var grid_display = new StringBuilder();
            var row_seperator = "";

            for (int row = 0; row <= 2; row++)
            {
                if (!String.IsNullOrEmpty(row_seperator))
                    grid_display.AppendLine(row_seperator);

                var pipe = "";
                var row_display = new StringBuilder();

                for (int column = 0; column <= 2; column++)
                {
                    row_display.Append(string.Format("{0} {1} ", pipe, pad_if_square_empty(squares[row, column])));
                    pipe = "|";
                }

                grid_display.AppendLine(row_display.ToString());
                row_seperator = "-----------";
            }

            return grid_display.ToString();
        }

        private string pad_if_square_empty(string value)
        {
            return String.IsNullOrEmpty(value) ? " " : value;
        }
    }
}
