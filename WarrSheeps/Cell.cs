using System;
using System.Collections.Generic;
using System.Text;

namespace WarrShips
{
    class Cell
    {
        public CellState State { get; set; }
        public Ship? ShipHolder { get; set; }
        public Cell()
        {
            Reset();
        }
        public void Reset()
        {
            State = CellState.Empty;
            ShipHolder = null;
        }
    }
}
