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
            Console.WriteLine("Hello litle boyyyy))))");
            Console.WriteLine("Lets PLAYYY");
            Console.WriteLine("Throwing a Coin.......");
            _Coin.throwCoin();
            if(_Coin.coinState == 1)
            {
                Console.WriteLine("You turn first boyyyyyy");
                Console.WriteLine("Press 'ANY button' to roll your dice");
                Console.ReadKey();
                p1.rollDice();
                
            }

            showTable();
        }
        public void showTable()
        {
            string stringP1;
            string stringP2;
            if(p1 is Player)
            {
                stringP1 = "Player";
                stringP2 = "Enemy";
            }
            else
            {
                stringP1 = "Enemy";
                stringP2 = "Player";
            }
            Console.Clear();
            Console.WriteLine($"{stringP1} | Health: {p1.Health}  VictimTokens: {p1.VictimToken}");
            foreach (Dice item in p1._Dice)
            {
                Console.Write(item.ToString()+"   ");
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            foreach (Dice item in p2._Dice)
            {
                Console.Write(item.ToString() + "   ");
            }
            Console.WriteLine();
            Console.WriteLine($"{stringP2} | Health: {p2.Health}  VictimTokens: {p2.VictimToken}");
        }
    }
}
