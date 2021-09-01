using System;
using System.Collections.Generic;
using System.Text;
using System.Numerics;


namespace WarrShips
{
    class Field
    {
        public Cell[,] Cells { get; set; }
        public Player Owner { get; set; }

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
        // ■ ∙
        public void ShowCells(RenderFieldType rt)
        {
            switch (rt)
            {
                case RenderFieldType.Full:
                    for (int i = 0; i < Cells.GetLength(0); i++)
                    {
                        for (int k = 0; k < Cells.GetLength(1); k++)
                        {
                            if (Cells[i, k].IsSelected())
                            {
                                Console.BackgroundColor = ConsoleColor.Green;
                            }
                            switch (Cells[i, k]?.State)
                            {
                                case CellState.Empty:                                   
                                    Console.Write("~\t");
                                    break;
                                case CellState.MissedShot:
                                    Console.Write($"∙\t");
                                    break;
                                case CellState.Ship:

                                    Console.Write($"■\t");
                                    break;
                                case CellState.ShotShip:

                                    if (Cells[i, k].ShipHolder.DrovnedCheck())
                                    {
                                        Console.Write($"-\t");
                                        break;
                                    }
                                    Console.Write($"°\t");
                                    break;
                                case CellState.NearShip:
                                    Console.Write($"~\t");
                                    break;
                                default:
                                    Console.Write($"NULL\t");
                                    break;
                            }
                            Console.ResetColor();
                        }
                        Console.WriteLine();
                    }
                    Console.WriteLine();
                    break;
                case RenderFieldType.Partial:
                    for (int i = 0; i < Cells.GetLength(0); i++)
                    {
                        for (int k = 0; k < Cells.GetLength(1); k++)
                        {
                            if (Cells[i, k].IsSelected())
                            {
                                Console.BackgroundColor = ConsoleColor.Green;
                            }
                            switch (Cells[i, k]?.State)
                            {
                                case CellState.Empty:
                                    Console.Write($"~\t");
                                    break;
                                case CellState.MissedShot:
                                    Console.Write($"∙\t");
                                    break;
                                case CellState.Ship:
                                    Console.Write($"~\t");
                                    break;
                                case CellState.ShotShip:
                                    if (Cells[i, k].ShipHolder.DrovnedCheck())
                                    {
                                        Console.Write($"-\t");
                                        break;
                                    }
                                    Console.Write($"°\t");
                                    break;
                                case CellState.NearShip:
                                    Console.Write($"~\t");
                                    break;
                                default:
                                    Console.Write($"NULL\t");
                                    break;
                            }
                            Console.ResetColor();
                        }
                        Console.WriteLine();
                    }
                    Console.WriteLine();
                    break;
            }
        }
        public Cell GetCellByCords(Vector2 cords)
        {
            if(cords.Y < 0 || cords.Y > Cells.GetLength(0) - 1 || cords.X < 0 || cords.X > Cells.GetLength(1) - 1)
            {
                return null;
            }
            return Cells[(int)cords.Y, (int)cords.X];
        }
        public void Reset()
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
    }
}
