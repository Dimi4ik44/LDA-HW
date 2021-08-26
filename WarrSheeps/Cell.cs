using System;
using System.Collections.Generic;
using System.Text;

namespace WarrShips
{
    class Cell
    {
        public CellState State { get; set; }
        public Ship ShipHolder { get; set; }
    }
}
