using System;
using System.Collections.Generic;
using System.Text;
using System.Numerics;

namespace WarrShips
{
    class Player : IControlable
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
                    new Ship(4,ShipPosition.Vertical),
                    new Ship(1),
                    new Ship(1),
                    new Ship(1),
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
            EField.ShowCells(RenderFieldType.Partial);
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
            SelectedPoint = default;
            PrevSelectedPoint = default;
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
        public bool Shoot()
        {
            Cell cell = EField.GetCellByCords(SelectedPoint);
            if (cell == null || cell.State == CellState.MissedShot || cell.State == CellState.ShotShip)
            {
                return false;
            }
            if(cell.ShipHolder != null)
            {
                cell.State = CellState.ShotShip;
                cell.ShipHolder.TakeDamage();
                return true;
            }
            cell.State = CellState.MissedShot;
            return true;
        }
        public bool PlaceShip(int num)
        {
            Cell cell;
            for (int i = 0; i < Ships[num].Length; i++)
            {               
                if (Ships[num].PosState == ShipPosition.Horizontal)
                {
                    cell = PField.GetCellByCords(SelectedPoint + (Vector2.UnitX * i));
                    if (cell == null || cell.State == CellState.Ship)
                    {
                        return false;
                    }
                }
                else
                if (Ships[num].PosState == ShipPosition.Vertical)
                {
                    cell = PField.GetCellByCords(SelectedPoint + (Vector2.UnitY * i));
                    if (cell == null || cell.State == CellState.Ship)
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
                    cell.ShipHolder = Ships[num];
                    cell.ChangeState(CellState.Ship);
                }
                else
                if (Ships[num].PosState == ShipPosition.Vertical)
                {
                    cell = PField.GetCellByCords(SelectedPoint + (Vector2.UnitY * i));
                    cell.ShipHolder = Ships[num];
                    cell.ChangeState(CellState.Ship);
                }
            }            
            return true;
        }
    }
}
