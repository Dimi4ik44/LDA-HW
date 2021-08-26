using System;
using System.Collections.Generic;
using System.Text;

namespace WarrShips
{
    public enum ShipPosition
    {
        Vertical,
        Horizontal
    }
    public enum ShipState
    {
        Normal,
        Drowned,
    }
    class Ship
    {
        public ShipPosition PosState { get; set; }
        public ShipState State { get; set; }
        public int Length { get; set; }
        public int Health { get; set; }
        public Ship(int lenght)
        {
            Length = lenght;
            Health = lenght;
            PosState = ShipPosition.Horizontal;
        }
        public bool TakeDamage()
        {
            if (!DrovnedCheck() && Health - 1 >= 0 )
            {
                Health--;
                DrovnedCheck();
                return true;
            }
            return false;
        }
        private bool DrovnedCheck()
        {
            if (State = ShipState.Drowned)
            {
                return true;
            }else
            if (Health <= 0 && State = ShipState.Normal)
            {
                State = ShipState.Drowned;
                return true;
            }
            return false;
        }
    }
}
