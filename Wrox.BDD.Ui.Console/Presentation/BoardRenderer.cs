using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wrox.BDD.Domain;

namespace Wrox.BDD.Ui.Console.Presentation
{
    public interface BoardRenderer
    {
        string render(Game game);
    }
}
