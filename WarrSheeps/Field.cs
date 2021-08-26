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
            for (int i = 0; i < Cells.GetLength(0); i++)
            {
                for (int k = 0; k < Cells.GetLength(1); k++)
                {
                    Cells[i, k] = new Cell();
                }
            }
        }
        public abstract void ShowCells();
    }
}
