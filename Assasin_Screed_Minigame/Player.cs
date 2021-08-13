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
        public override void selectDice()
        {
            Dice[] sd = new Dice[SelectedDice.Length + 1];
            for (int i = 0; i < SelectedDice.Length; i++)
            {
                sd[i] = SelectedDice[i];
            }
            sd[sd.Length-1] = _Dice[Selector-1];
            SelectedDice = sd;

            Dice[] d = new Dice[_Dice.Length - 1];
            int counter = 0;
            for (int i = 0; i < _Dice.Length; i++)
            {
                if (i == Selector-1) continue;
                d[counter] = _Dice[i];
                counter++;
            }
            _Dice = d;
        }
    }
}
