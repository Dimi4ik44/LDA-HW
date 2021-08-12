using System;
using System.Collections.Generic;
using System.Text;

namespace Assasin_Screed_Minigame
{
    public class Entity
    {
        public int Health { get; set; }
        public int VictimToken { get; set; }
        public int DiceReroll { get; private set; }
        public Dice[] _Dice { get; set; }
        public Dice[] SelectedDice { get; set; }
        public Entity()
        {
            Health = 15;
            VictimToken = 0;
            DiceReroll = 3;
            _Dice = new Dice[]{
                (new Dice
                (new DiceSide[]{
                    new DiceSide(Assasin_Screed_Minigame.Dice.DiceSides.Arrow, true),
                    new DiceSide(Assasin_Screed_Minigame.Dice.DiceSides.Axe, false),
                    new DiceSide(Assasin_Screed_Minigame.Dice.DiceSides.Helmet, true),
                    new DiceSide(Assasin_Screed_Minigame.Dice.DiceSides.Hand, true),
                    new DiceSide(Assasin_Screed_Minigame.Dice.DiceSides.Shield, false),
                    new DiceSide(Assasin_Screed_Minigame.Dice.DiceSides.Empty, true)
                })),
                (new Dice
                (new DiceSide[]{
                    new DiceSide(Assasin_Screed_Minigame.Dice.DiceSides.Arrow, false),
                    new DiceSide(Assasin_Screed_Minigame.Dice.DiceSides.Axe, true),
                    new DiceSide(Assasin_Screed_Minigame.Dice.DiceSides.Helmet, true),
                    new DiceSide(Assasin_Screed_Minigame.Dice.DiceSides.Hand, false),
                    new DiceSide(Assasin_Screed_Minigame.Dice.DiceSides.Shield, true),
                    new DiceSide(Assasin_Screed_Minigame.Dice.DiceSides.Empty, true)
                })),
                (new Dice
                (new DiceSide[]{
                    new DiceSide(Assasin_Screed_Minigame.Dice.DiceSides.Arrow, true),
                    new DiceSide(Assasin_Screed_Minigame.Dice.DiceSides.Axe, true),
                    new DiceSide(Assasin_Screed_Minigame.Dice.DiceSides.Helmet, false),
                    new DiceSide(Assasin_Screed_Minigame.Dice.DiceSides.Hand, true),
                    new DiceSide(Assasin_Screed_Minigame.Dice.DiceSides.Shield, true),
                    new DiceSide(Assasin_Screed_Minigame.Dice.DiceSides.Empty, false)
                })),
                (new Dice
                (new DiceSide[]{
                    new DiceSide(Assasin_Screed_Minigame.Dice.DiceSides.Arrow, true),
                    new DiceSide(Assasin_Screed_Minigame.Dice.DiceSides.Axe, false),
                    new DiceSide(Assasin_Screed_Minigame.Dice.DiceSides.Helmet, true),
                    new DiceSide(Assasin_Screed_Minigame.Dice.DiceSides.Hand, true),
                    new DiceSide(Assasin_Screed_Minigame.Dice.DiceSides.Shield, false),
                    new DiceSide(Assasin_Screed_Minigame.Dice.DiceSides.Empty, true)
                })),
                (new Dice
                (new DiceSide[]{
                    new DiceSide(Assasin_Screed_Minigame.Dice.DiceSides.Arrow, false),
                    new DiceSide(Assasin_Screed_Minigame.Dice.DiceSides.Axe, true),
                    new DiceSide(Assasin_Screed_Minigame.Dice.DiceSides.Helmet, true),
                    new DiceSide(Assasin_Screed_Minigame.Dice.DiceSides.Hand, false),
                    new DiceSide(Assasin_Screed_Minigame.Dice.DiceSides.Shield, true),
                    new DiceSide(Assasin_Screed_Minigame.Dice.DiceSides.Empty, true)
                })),
                (new Dice
                (new DiceSide[]{
                    new DiceSide(Assasin_Screed_Minigame.Dice.DiceSides.Arrow, true),
                    new DiceSide(Assasin_Screed_Minigame.Dice.DiceSides.Axe, true),
                    new DiceSide(Assasin_Screed_Minigame.Dice.DiceSides.Helmet, false),
                    new DiceSide(Assasin_Screed_Minigame.Dice.DiceSides.Hand, true),
                    new DiceSide(Assasin_Screed_Minigame.Dice.DiceSides.Shield, true),
                    new DiceSide(Assasin_Screed_Minigame.Dice.DiceSides.Empty, false)
                })),
            };
        }
        public bool rollDice()
        {
            foreach (Dice item in _Dice)
            {
                item.Roll();
            }
            return true;
        }
    }
}
