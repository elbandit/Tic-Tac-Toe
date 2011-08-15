using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wrox.BDD.Ui.Console.Presentation
{
    public interface GameView
    {
        void WriteLine(string message);
        void Write(string message);
        void get_coordinates_for_next_move();  
    }
}
