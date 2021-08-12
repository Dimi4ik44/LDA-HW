using System;
using System.Collections.Generic;
using System.Text;

namespace Assasin_Screed_Minigame
{
    class Table
    {
        public Coin _Coin { get; set; }
        public Entity p1 { get; set; }
        public Entity p2 { get; set; }
        public Entity Winer { get; private set; }
        public Table(Entity p1, Entity p2)
        {
            this.p1 = p1;
            this.p2 = p2;
            _Coin = new Coin();
        }
        public void startGame()
        {
            _Coin.throwCoin();
            if(_Coin.coinState == 1)
            {
                p1.rollDice();
            }
        }
    }
}
