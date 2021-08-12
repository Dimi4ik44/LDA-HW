using System;
using System.Collections.Generic;
using System.Text;

namespace Assasin_Screed_Minigame
{
    public class Entity
    {
        public int Health { get; set; }
        public int VictimToken { get; set; }
        public int DiceReroll { get; set; }
        public Dice Dice { get; set; }
        public Dice[] SelectedDice { get; set; }
        public Entity()
        {
            Health = 15;
            VictimToken = 0;
            DiceReroll = 3;
        }
    }
}
