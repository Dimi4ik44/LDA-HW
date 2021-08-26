using System;
using System.Collections.Generic;
using System.Text;

namespace WarrShips
{
    abstract class Field
    {
        public Cell[,] Cells { get; set; }

        public Field()
        {
            Cells = new Cell[10, 10];
        }
        public abstract void ShowCells();
    }
}
