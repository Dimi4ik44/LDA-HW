using System;
using System.Collections.Generic;
using System.Text;

namespace Assasin_Screed_Minigame
{
    public class DeffaultDiceKit
    {
        public Dice[] diceCit { get; set; } = new Dice[]{
                (new Dice
                (new DiceSide[]{
                    new DiceSide(Assasin_Screed_Minigame.Dice.DiceSides.Arrow, true),
                    new DiceSide(Assasin_Screed_Minigame.Dice.DiceSides.Axe, false),
                    new DiceSide(Assasin_Screed_Minigame.Dice.DiceSides.Helmet, false),
                    new DiceSide(Assasin_Screed_Minigame.Dice.DiceSides.Hand, false),
                    new DiceSide(Assasin_Screed_Minigame.Dice.DiceSides.Shield, false),
                    new DiceSide(Assasin_Screed_Minigame.Dice.DiceSides.Empty, true)
                })),
                (new Dice
                (new DiceSide[]{
                    new DiceSide(Assasin_Screed_Minigame.Dice.DiceSides.Arrow, false),
                    new DiceSide(Assasin_Screed_Minigame.Dice.DiceSides.Axe, false),
                    new DiceSide(Assasin_Screed_Minigame.Dice.DiceSides.Helmet, false),
                    new DiceSide(Assasin_Screed_Minigame.Dice.DiceSides.Hand, false),
                    new DiceSide(Assasin_Screed_Minigame.Dice.DiceSides.Shield, true),
                    new DiceSide(Assasin_Screed_Minigame.Dice.DiceSides.Empty, true)
                })),
                (new Dice
                (new DiceSide[]{
                    new DiceSide(Assasin_Screed_Minigame.Dice.DiceSides.Arrow, true),
                    new DiceSide(Assasin_Screed_Minigame.Dice.DiceSides.Axe, true),
                    new DiceSide(Assasin_Screed_Minigame.Dice.DiceSides.Helmet, false),
                    new DiceSide(Assasin_Screed_Minigame.Dice.DiceSides.Hand, false),
                    new DiceSide(Assasin_Screed_Minigame.Dice.DiceSides.Shield, false),
                    new DiceSide(Assasin_Screed_Minigame.Dice.DiceSides.Empty, false)
                })),
                (new Dice
                (new DiceSide[]{
                    new DiceSide(Assasin_Screed_Minigame.Dice.DiceSides.Arrow, false),
                    new DiceSide(Assasin_Screed_Minigame.Dice.DiceSides.Axe, false),
                    new DiceSide(Assasin_Screed_Minigame.Dice.DiceSides.Helmet, true),
                    new DiceSide(Assasin_Screed_Minigame.Dice.DiceSides.Hand, true),
                    new DiceSide(Assasin_Screed_Minigame.Dice.DiceSides.Shield, false),
                    new DiceSide(Assasin_Screed_Minigame.Dice.DiceSides.Empty, false)
                })),
                (new Dice
                (new DiceSide[]{
                    new DiceSide(Assasin_Screed_Minigame.Dice.DiceSides.Arrow, false),
                    new DiceSide(Assasin_Screed_Minigame.Dice.DiceSides.Axe, true),
                    new DiceSide(Assasin_Screed_Minigame.Dice.DiceSides.Helmet, false),
                    new DiceSide(Assasin_Screed_Minigame.Dice.DiceSides.Hand, false),
                    new DiceSide(Assasin_Screed_Minigame.Dice.DiceSides.Shield, true),
                    new DiceSide(Assasin_Screed_Minigame.Dice.DiceSides.Empty, false)
                })),
                (new Dice
                (new DiceSide[]{
                    new DiceSide(Assasin_Screed_Minigame.Dice.DiceSides.Arrow, true),
                    new DiceSide(Assasin_Screed_Minigame.Dice.DiceSides.Axe, false),
                    new DiceSide(Assasin_Screed_Minigame.Dice.DiceSides.Helmet, false),
                    new DiceSide(Assasin_Screed_Minigame.Dice.DiceSides.Hand, false),
                    new DiceSide(Assasin_Screed_Minigame.Dice.DiceSides.Shield, true),
                    new DiceSide(Assasin_Screed_Minigame.Dice.DiceSides.Empty, false)
                })),
            };
    }
}
