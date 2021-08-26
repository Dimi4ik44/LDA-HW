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
                    switch (Cells[i, k]?.State)
                    {
                        case CellState.Empty:
                            Console.Write($"E\t");
                            break;
                        case CellState.MissedShot:
                            Console.Write($"M\t");
                            break;
                        case CellState.ShotShip:
                            Console.Write($"SS\t");
                            break;
                        default:
                            Console.Write($"NULL\t");
                            break;
                    }
                    //Console.Write($"{i}:{k}E\t");
                }
                Console.WriteLine();
            }
        }
    }
}
