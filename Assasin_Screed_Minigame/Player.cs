using System;
using System.Collections.Generic;
using System.Text;

namespace Assasin_Screed_Minigame
{
    class Player : Entity
    {
        public enum SelectorMove
        {
            Left = 1,
            Right
        }
        public Player() : base()
        {

        }
        public void moveSelector(SelectorMove sm)
        {
            switch (sm)
            {
                case SelectorMove.Left when Selector > 1:
                    Selector--;
                    break;
                case SelectorMove.Right when Selector <= _Dice.Length-1:
                    Selector++;
                    break;
                default:
                    break;
            }
        }
    }
}
