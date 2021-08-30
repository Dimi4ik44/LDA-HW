using System;
using System.Collections.Generic;
using System.Text;

namespace WarrShips
{
    class Ship
    {
        public ShipPosition PosState { get; set; }
        public ShipState State { get; set; }
        public int Length { get; set; }
        public int Health { get; set; }
        public Ship(int lenght, ShipPosition shipPosition = ShipPosition.Horizontal)
        {
            Length = lenght;
            Health = lenght;
            PosState = shipPosition;
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
        public void Rotate()
        {
            if(PosState == ShipPosition.Horizontal)
            {
                PosState = ShipPosition.Vertical;
            }
            else
            {
                PosState = ShipPosition.Horizontal;
            }
        }
        private bool DrovnedCheck()
        {
            if (State == ShipState.Drowned)
            {
                return true;
            }else
            if (Health <= 0 && State == ShipState.Normal)
            {
                State = ShipState.Drowned;
                return true;
            }
            return false;
        }
    }
}
