using System;
using System.Collections.Generic;
using System.Text;

namespace Assasin_Screed_Minigame
{
    public class DiceSide
    {
        public Dice.DiceSides Sign { get; private set; }
        public bool Border { get; private set; }
        public DiceSide(Dice.DiceSides side, bool border)
        {
            Sign = side;
            Border = border;
        }
    }
}
