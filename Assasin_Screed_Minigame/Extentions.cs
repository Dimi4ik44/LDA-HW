using System;
using System.Collections.Generic;
using System.Text;

namespace Assasin_Screed_Minigame
{
    public static class Extentions
    {
        public static bool IsPlayer(this Entity e)
        {
            return e is Player;
        }
        public static bool IsEnemy(this Entity e)
        {
            return e is Enemy;
        }
        public static void DiceSort(this Dice[] _Dice, Dice.DiceSides[] sortPattern)
        {
            Dice temp;
            int counter = 0;
            for (int i = 0; i < sortPattern.Length; i++)
            {
                for (int k = 0; k < _Dice.Length; k++)
                {
                    if(_Dice[k].UpSide.Sign == sortPattern[i])
                    {
                        temp = _Dice[counter];
                        _Dice[counter] = _Dice[k];
                        _Dice[k] = temp;
                        counter++;

                    }
                }
            }
        }
        public static Dice[] DiceRemoveByIndex(this Dice[] _Dice, int index) //????? cant use just _Dice = d; Why must use return??????
        {
            Dice[] d = new Dice[_Dice.Length - 1];
            int counter = 0;
            for (int i = 0; i < _Dice.Length; i++)
            {
                if (i == index) continue;
                d[counter] = _Dice[i];
                counter++;
            }
            return d;
            
        }
        public static void DiseSort (this Dice[] _Dice, Dice[] second, Dice.DiceSides[] sortPattern) // soon
        {
            Dice temp;
            int counter = 0;
            for (int i = 0; i < second.Length; i++)
            {
                
            }
        }
    }
}
