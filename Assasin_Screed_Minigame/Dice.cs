using System;
using System.Collections.Generic;
using System.Text;

namespace Assasin_Screed_Minigame
{
    public class Dice
    {
        Random rnd = new Random();
        public enum DiceSides
        {
            Axe = 1,
            Arrow,
            Helmet,
            Shield,
            Hand,
            Empty
        }
        public DiceSide[] Sides { get; private set; }
        public DiceSide UpSide { get; private set; }
        public Dice(DiceSide[] sideSign)
        {
            Sides = sideSign;
        }
        public void Roll()
        {
            UpSide = Sides[rnd.Next(0, Sides.Length)];
        }

    }
}
