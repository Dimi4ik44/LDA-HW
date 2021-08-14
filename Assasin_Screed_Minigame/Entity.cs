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
        public int Selector { get; set; } = 0;
        public bool Turn { get; set; } = false;
        public Dice[] _Dice { get; set; }
        public Dice[] SelectedDice { get { return selectedDice; } set { selectedDice = value; } }
        private Dice[] selectedDice;
        public Entity()
        {
            Health = 15;
            VictimToken = 0;
            DiceReroll = 3;
            SelectedDice = new Dice[0];
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
        public bool reRollDice()
        {
            if(DiceReroll > 0)
            {
                foreach (Dice item in _Dice)
                {
                    item.Roll();
                }
                DiceReroll--;
                if(DiceReroll == 0)
                {
                    selectAllDice();
                    Turn = false;
                }
                return true;
            }
            return false;
            
        }
        public void resetSelection()
        {
            Selector = 0;
        }
        public virtual void selectDice()
        {
            if(Selector == 0)
            {
                selectAllDice();
                resetSelection();
                return;
            }
            Dice[] sd = new Dice[SelectedDice.Length + 1];
            for (int i = 0; i < SelectedDice.Length; i++)
            {
                sd[i] = SelectedDice[i];
            }
            sd[sd.Length - 1] = _Dice[Selector - 1];
            SelectedDice = sd;

            Dice[] d = new Dice[_Dice.Length - 1];
            int counter = 0;
            for (int i = 0; i < _Dice.Length; i++)
            {
                if (i == Selector - 1) continue;
                d[counter] = _Dice[i];
                counter++;
            }
            _Dice = d;
            resetSelection();
        }
        public void selectAllDice()
        {
            int startIndexSelectedDice = SelectedDice.Length;
            Array.Resize(ref selectedDice, SelectedDice.Length + _Dice.Length);
            for (int i = 0; i < _Dice.Length; i++)
            {
                SelectedDice[startIndexSelectedDice++] = _Dice[i];
            }
            _Dice = new Dice[0];
            Turn = false;
        }

        public bool takeDamage(int damage)
        {
            if(Health > 0)
            {
                if (Health - damage >= 0)
                {
                    Health -= damage;
                }
                else Health = 0;
                return true;
            }
            return false;
        }
        public void getVictimTokens(int count)
        {
            VictimToken += count;
        }
        public void loseVictimTokens(int count)
        {
            if (VictimToken - count <= 0)
            {
                VictimToken = 0;
            }
            else VictimToken -= count;
        }
    }
}
