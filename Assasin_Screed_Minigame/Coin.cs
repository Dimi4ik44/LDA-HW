using System;
using System.Collections.Generic;
using System.Text;

namespace Assasin_Screed_Minigame
{
    class Coin
    {
        Random rnd = new Random();
        public int coinState { get; private set; }
        public Coin()
        {
            coinState = 0;
        }
        public void throwCoin()
        {
            coinState = rnd.Next(1, 3);
        }
    }
}
