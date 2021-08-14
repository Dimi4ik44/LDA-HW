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
        public static void DiseSort(this Dice[] Dice, Dice.DiceSides[] sortPattern)
        {
            Dice temp;
            int counter = 0;
            for (int i = 0; i < sortPattern.Length; i++)
            {
                for (int k = 0; k < Dice.Length; k++)
                {
                    if(Dice[k].UpSide.Sign == sortPattern[i])
                    {
                        temp = Dice[counter];
                        Dice[counter] = Dice[k];
                        Dice[k] = temp;
                        counter++;

                    }
                }
            }
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
