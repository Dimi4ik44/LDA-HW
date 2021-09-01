using System;
using System.Collections.Generic;
using System.Text;

namespace WarrShips
{
    class Cell
    {
        public CellState State { get; set; }
        public CellSelectedState SelectedState { get; set; }
        public Ship? ShipHolder { get; set; }
        public Cell()
        {
            Reset();
        }
        public void Reset()
        {
            State = CellState.Empty;
            SelectedState = CellSelectedState.None;
            ShipHolder = null;
        }
        public void ChangeState(CellState state)
        {
            State = state;
        }
        public bool MarkShip(Ship ship)
        {
            if(ShipHolder == null)
            {
                ShipHolder = ship;
                ChangeState(CellState.Ship);
                return true;
            }
            return false;
        }
        public void ChangeSelectedState(CellSelectedState css)
        {
            SelectedState = css;
        }
        public bool IsSelected()
        {
            if (SelectedState == CellSelectedState.Selected) return true;
            return false;
        }
    }
}
