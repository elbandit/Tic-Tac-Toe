using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wrox.BDD.Domain
{
    public enum InvalidMoveReason
    {
        SquareOccupied,
        CoordinateOutsideOfGrid
    }
}
