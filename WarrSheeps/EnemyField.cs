using System;
using System.Collections.Generic;
using System.Text;

namespace WarrShips
{
    class EnemyField : Field
    {
        public EnemyField() : base()
        {

        }
        public override void ShowCells()
        {
            for (int i = 0; i < Cells.GetLength(0); i++)
            {
                for (int k = 0; k < Cells.GetLength(1); k++)
                {
                    Console.Write($"E");
                }
                Console.WriteLine();
            }
        }
    }
}
