using System;
using System.Collections.Generic;
using System.Text;

namespace WarrShips
{
        public enum CellState
        {
            Empty,
            MissedShot,
            Ship,
            ShotShip,
            NearShip
        }
        public enum CellSelectedState
        {
            None,
            Selected
        }
}
