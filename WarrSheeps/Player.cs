using System;
using System.Collections.Generic;
using System.Text;
using System.Numerics;

namespace WarrShips
{
    class Player
    {
        public string Name { get; set; }
        public Controls ControlManager { get; set; }
        public Vector2 SelectedPoint { get; set; }
        public Vector2 PrevSelectedPoint { get; set; }
        public List<Ship> Ships { get; set; }
        public Field PField { get; set; }
        public Field? EField { get; set; }
        public Player()
        {
            PField = new Field();
            Ships = new List<Ship>();
            Ships.AddRange(
                new Ship[]
                {
                    new Ship(1),
                    new Ship(1),
                    new Ship(1),
                    new Ship(1),
                    new Ship(2),
                    new Ship(2),
                    new Ship(2),
                    new Ship(3),
                    new Ship(3),
                    new Ship(4),
                });
        }
        public Player(string name) : this()
        {
            Name = name;
            ControlManager = new Controls();
        }
        public bool SetEnemyField(Field efield)
        {
            if(EField == null)
            {
                EField = efield;
                return true;
            }
            return false;
        }
        public void ShowFields()
        {
            PField.ShowCells(RenderFieldType.Full);
            EField?.ShowCells(RenderFieldType.Partial);
        }

        public void SelectCell(Field field)
        {
            if(field.GetCellByCords(SelectedPoint) == null)
            {
                return;
            }
            if(PrevSelectedPoint == SelectedPoint)
            {
                field.GetCellByCords(SelectedPoint).ChangeSelectedState(CellSelectedState.Selected);
                PrevSelectedPoint = SelectedPoint;
                return;
            }
            field.GetCellByCords(SelectedPoint).ChangeSelectedState(CellSelectedState.Selected);
            field.GetCellByCords(PrevSelectedPoint).ChangeSelectedState(CellSelectedState.None);
            PrevSelectedPoint = SelectedPoint;
        }
        public void ResetSelection(Field field)
        {
            field.GetCellByCords(SelectedPoint).ChangeSelectedState(CellSelectedState.None);
            field.GetCellByCords(PrevSelectedPoint).ChangeSelectedState(CellSelectedState.None);
            SelectedPoint = Vector2.Zero;
            PrevSelectedPoint = Vector2.Zero;
        }

        public bool MoveSelector(Vector2 pos, Field field)
        {
            Vector2 prevP = SelectedPoint;
            SelectedPoint += pos;
            if (SelectedPoint.Y > field.Cells.GetLength(0) - 1 || SelectedPoint.Y < 0 || SelectedPoint.X > field.Cells.GetLength(1) - 1 || SelectedPoint.X < 0)
            {
                SelectedPoint = prevP;
                return false;
            }
            SelectCell(field);
            return true;
        }
        public ShootResult Shoot()
        {
            Cell cell = EField.GetCellByCords(SelectedPoint);
            if (cell == null || cell.State == CellState.MissedShot || cell.State == CellState.ShotShip)
            {
                return ShootResult.NotShoot;
            }
            if(cell.ShipHolder != null)
            {
                cell.State = CellState.ShotShip;
                cell.ShipHolder.TakeDamage();
                return ShootResult.Hit;
            }
            cell.State = CellState.MissedShot;
            return ShootResult.Miss;
        }
        public bool PlaceShip(int num)
        {
            Cell cell;
            for (int i = 0; i < Ships[num].Length; i++)
            {               
                if (Ships[num].PosState == ShipPosition.Horizontal)
                {
                    cell = PField.GetCellByCords(SelectedPoint + (Vector2.UnitX * i));
                    if (cell == null || cell.State == CellState.Ship || cell.State == CellState.NearShip)
                    {
                        return false;
                    }
                }
                else
                if (Ships[num].PosState == ShipPosition.Vertical)
                {
                    cell = PField.GetCellByCords(SelectedPoint + (Vector2.UnitY * i));
                    if (cell == null || cell.State == CellState.Ship || cell.State == CellState.NearShip)
                    {
                        return false;
                    }
                }                
            }
            //----
            for (int i = 0; i < Ships[num].Length; i++)
            {
                if (Ships[num].PosState == ShipPosition.Horizontal)
                {
                    cell = PField.GetCellByCords(SelectedPoint + (Vector2.UnitX * i));
                    Cell[] nearCells = new Cell[] {
                        PField.GetCellByCords((SelectedPoint + (Vector2.UnitX * i))+Vector2.UnitX),
                        PField.GetCellByCords((SelectedPoint + (Vector2.UnitX * i))-Vector2.UnitX),
                        PField.GetCellByCords((SelectedPoint + (Vector2.UnitX * i))+Vector2.UnitY),
                        PField.GetCellByCords((SelectedPoint + (Vector2.UnitX * i))-Vector2.UnitY),
                        PField.GetCellByCords((SelectedPoint + (Vector2.UnitX * i))+Vector2.One),
                        PField.GetCellByCords((SelectedPoint + (Vector2.UnitX * i))-Vector2.One),
                        PField.GetCellByCords((SelectedPoint + (Vector2.UnitX * i))+Vector2.UnitX-Vector2.UnitY),
                        PField.GetCellByCords((SelectedPoint + (Vector2.UnitX * i))-Vector2.UnitX+Vector2.UnitY),
                    };
                    foreach (Cell item in nearCells)
                    {
                        if(item != null && item.State != CellState.Ship)
                        {
                            item.ChangeState(CellState.NearShip);
                        }
                    }
                    cell.ShipHolder = Ships[num];
                    cell.ChangeState(CellState.Ship);
                }
                else
                if (Ships[num].PosState == ShipPosition.Vertical)
                {
                    cell = PField.GetCellByCords(SelectedPoint + (Vector2.UnitY * i));
                    Cell[] nearCells = new Cell[] {
                        PField.GetCellByCords((SelectedPoint + (Vector2.UnitY * i))+Vector2.UnitX),
                        PField.GetCellByCords((SelectedPoint + (Vector2.UnitY * i))-Vector2.UnitX),
                        PField.GetCellByCords((SelectedPoint + (Vector2.UnitY * i))+Vector2.UnitY),
                        PField.GetCellByCords((SelectedPoint + (Vector2.UnitY * i))-Vector2.UnitY),
                        PField.GetCellByCords((SelectedPoint + (Vector2.UnitY * i))+Vector2.One),
                        PField.GetCellByCords((SelectedPoint + (Vector2.UnitY * i))-Vector2.One),
                        PField.GetCellByCords((SelectedPoint + (Vector2.UnitY * i))+Vector2.UnitX-Vector2.UnitY),
                        PField.GetCellByCords((SelectedPoint + (Vector2.UnitY * i))-Vector2.UnitX+Vector2.UnitY),
                    };
                    foreach (Cell item in nearCells)
                    {
                        if (item != null && item.State != CellState.Ship)
                        {
                            item.ChangeState(CellState.NearShip);
                        }
                    }
                    cell.ShipHolder = Ships[num];
                    cell.ChangeState(CellState.Ship);
                }
            }            
            return true;
        }
        public void putShipsAction()
        {
            Console.Clear();
            Field seelectedField = PField;
            MoveSelector(Vector2.Zero, seelectedField);
            ShowFields();
            int placedShips = 0;
            while (Ships.Count > placedShips)
            {
                switch (ControlManager.GetInput())
                {
                    case ConsoleKey.UpArrow:
                        MoveSelector(-Vector2.UnitY, seelectedField);
                        break;
                    case ConsoleKey.DownArrow:
                        MoveSelector(Vector2.UnitY, seelectedField);
                        break;
                    case ConsoleKey.LeftArrow:
                        MoveSelector(-Vector2.UnitX, seelectedField);
                        break;
                    case ConsoleKey.RightArrow:
                        MoveSelector(Vector2.UnitX, seelectedField);
                        break;
                    case ConsoleKey.Enter:
                        if (PlaceShip(placedShips))
                        {
                            placedShips++;
                        }
                        break;
                    case ConsoleKey.Backspace:
                        Ships[placedShips].Rotate();
                        break;
                    case ConsoleKey.R:
                        ResetSelection(seelectedField);
                        PField = new Field();
                        seelectedField = PField;
                        MoveSelector(Vector2.Zero, seelectedField);
                        placedShips = 0;
                        break;
                }
                Console.Clear();
                ShowFields();
            }
            ResetSelection(seelectedField);
        }
        public void AtackAction()
        {
            Console.Clear();
            Field seelectedField = EField;
            MoveSelector(Vector2.Zero, seelectedField);
            ShowFields();
            bool miss = false;
            while (!miss)
            {
                switch (ControlManager.GetInput())
                {
                    case ConsoleKey.UpArrow:
                        MoveSelector(-Vector2.UnitY, seelectedField);
                        break;
                    case ConsoleKey.DownArrow:
                        MoveSelector(Vector2.UnitY, seelectedField);
                        break;
                    case ConsoleKey.LeftArrow:
                        MoveSelector(-Vector2.UnitX, seelectedField);
                        break;
                    case ConsoleKey.RightArrow:
                        MoveSelector(Vector2.UnitX, seelectedField);
                        break;
                    case ConsoleKey.Enter:
                        if(Shoot() == ShootResult.Miss)
                        {
                            miss = true;
                        }
                        break;
                }
                Console.Clear();
                ShowFields();
            }
            ResetSelection(seelectedField);
        }
        public bool CheckShips()
        {
            foreach (Ship item in Ships)
            {
                if (item.State != ShipState.Drowned) return true;
            }
            return false;
        }
    }
}
