using System;
using System.Collections.Generic;
using System.Text;

namespace WarrShips
{
    class Player : IControlable
    {
        public PlayerField PField { get; set; }
        public EnemyField EField { get; set; }
        public Player()
        {

        }
    }
}
