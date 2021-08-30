using System;
using System.Collections.Generic;
using System.Text;
using System.Numerics;


namespace WarrShips
{
    class Field
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
        // ■
        public void ShowCells(RenderFieldType rt)
        {
            switch (rt)
            {
                case RenderFieldType.Full:
                    for (int i = 0; i < Cells.GetLength(0); i++)
                    {
                        for (int k = 0; k < Cells.GetLength(1); k++)
                        {
                            switch (Cells[i, k]?.State)
                            {
                                case CellState.Empty:
                                    if(Cells[i, k]?.SelectedState == CellSelectedState.Selected)
                                    {
                                        Console.BackgroundColor = ConsoleColor.Green;
                                    }
                                    Console.Write("E\t");
                                    break;
                                case CellState.MissedShot:
                                    if (Cells[i, k]?.SelectedState == CellSelectedState.Selected)
                                    {
                                        Console.BackgroundColor = ConsoleColor.Green;
                                    }
                                    Console.Write($"M\t");
                                    break;
                                case CellState.Ship:
                                    if (Cells[i, k]?.SelectedState == CellSelectedState.Selected)
                                    {
                                        Console.BackgroundColor = ConsoleColor.Green;
                                    }
                                    Console.Write($"S\t");
                                    break;
                                case CellState.ShotShip:
                                    if (Cells[i, k]?.SelectedState == CellSelectedState.Selected)
                                    {
                                        Console.BackgroundColor = ConsoleColor.Green;
                                    }
                                    if (Cells[i, k].ShipHolder.State == ShipState.Drowned)
                                    {
                                        Console.Write($"D\t");
                                        break;
                                    }
                                    Console.Write($"SS\t");
                                    break;
                                case CellState.NearShip:
                                    if (Cells[i, k]?.SelectedState == CellSelectedState.Selected)
                                    {
                                        Console.BackgroundColor = ConsoleColor.Green;
                                    }
                                    Console.Write($"E\t");
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
                            switch (Cells[i, k]?.State)
                            {
                                case CellState.Empty:
                                    if (Cells[i, k]?.SelectedState == CellSelectedState.Selected)
                                    {
                                        Console.BackgroundColor = ConsoleColor.Green;
                                    }
                                    Console.Write($"E\t");
                                    break;
                                case CellState.MissedShot:
                                    if (Cells[i, k]?.SelectedState == CellSelectedState.Selected)
                                    {
                                        Console.BackgroundColor = ConsoleColor.Green;
                                    }
                                    Console.Write($"M\t");
                                    break;
                                case CellState.Ship:
                                    if (Cells[i, k]?.SelectedState == CellSelectedState.Selected)
                                    {
                                        Console.BackgroundColor = ConsoleColor.Green;
                                    }
                                    Console.Write($"E\t");
                                    break;
                                case CellState.ShotShip:
                                    if (Cells[i, k]?.SelectedState == CellSelectedState.Selected)
                                    {
                                        Console.BackgroundColor = ConsoleColor.Green;
                                    }
                                    if (Cells[i, k].ShipHolder.State == ShipState.Drowned)
                                    {
                                        Console.Write($"D\t");
                                        break;
                                    }
                                    Console.Write($"SS\t");
                                    break;
                                case CellState.NearShip:
                                    if (Cells[i, k]?.SelectedState == CellSelectedState.Selected)
                                    {
                                        Console.BackgroundColor = ConsoleColor.Green;
                                    }
                                    Console.Write($"E\t");
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
    }
}
