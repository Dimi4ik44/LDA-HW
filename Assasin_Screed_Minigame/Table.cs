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
            Player player;
            Enemy enemy;
            if (p1.IsPlayer())
            {
                player = p1 as Player;
                enemy = p2 as Enemy;
            }else
            {
                player = p2 as Player;
                enemy = p1 as Enemy;
            }
            _Coin.throwCoin();
            switch (_Coin.coinState)
            {
                case 1:
                    showTable();
                    p1.rollDice();
                    if (p1.IsPlayer())
                    {
                        bool exitWhile = false;
                        while (!exitWhile)
                        {
                            if (p1._Dice.Length <= 0)
                            {
                                exitWhile = true;
                                continue;
                            }
                            switch (Console.ReadKey().Key)
                            {
                                case ConsoleKey.LeftArrow:
                                    (p1 as Player).moveSelector(Player.SelectorMove.Left);
                                    showTable();
                                    break;
                                case ConsoleKey.RightArrow:
                                    (p1 as Player).moveSelector(Player.SelectorMove.Right);
                                    showTable();
                                    break;
                                case ConsoleKey.Enter:
                                    p1.selectDice();
                                    p1.resetSelection();
                                    showTable();
                                    break;
                                case ConsoleKey.Backspace when p1.reRollDice():
                                    showTable();
                                    exitWhile = true;
                                    break;
                                case ConsoleKey.Escape:
                                    exitWhile = true;
                                    showTable();
                                    break;
                                default:
                                    continue;
                            }
                        }
                    }
                    else p1.selectAllDice();
                    showTable();
                    p2.rollDice();
                    if (p2.IsPlayer())
                    {
                        bool exitWhile = false;
                        while (!exitWhile)
                        {
                            if (p2._Dice.Length <= 0)
                            {
                                exitWhile = true;
                                continue;
                            }
                            switch (Console.ReadKey().Key)
                            {
                                case ConsoleKey.LeftArrow:
                                    (p2 as Player).moveSelector(Player.SelectorMove.Left);
                                    showTable();
                                    break;
                                case ConsoleKey.RightArrow:
                                    (p2 as Player).moveSelector(Player.SelectorMove.Right);
                                    showTable();
                                    break;
                                case ConsoleKey.Enter:
                                    p2.selectDice();
                                    p2.resetSelection();
                                    showTable();
                                    break;
                                case ConsoleKey.Backspace when p2.reRollDice():
                                    showTable();
                                    exitWhile = true;
                                    break;
                                case ConsoleKey.Escape:
                                    exitWhile = true;
                                    showTable();
                                    break;
                                default:
                                    continue;
                            }
                        }
                    }
                    else p2.selectAllDice();
                    showTable();
                    break;
                case 2:
                    showTable();
                    p2.rollDice();
                    if (p2.IsPlayer())
                    {
                        bool exitWhile = false;
                        while (!exitWhile)
                        {
                            if (p2._Dice.Length <= 0)
                            {
                                exitWhile = true;
                                continue;
                            }
                            switch (Console.ReadKey().Key)
                            {
                                case ConsoleKey.LeftArrow:
                                    (p2 as Player).moveSelector(Player.SelectorMove.Left);
                                    showTable();
                                    break;
                                case ConsoleKey.RightArrow:
                                    (p2 as Player).moveSelector(Player.SelectorMove.Right);
                                    showTable();
                                    break;
                                case ConsoleKey.Enter:
                                    p2.selectDice();
                                    p2.resetSelection();
                                    showTable();
                                    break;
                                case ConsoleKey.Backspace when p2.reRollDice():
                                    showTable();
                                    exitWhile = true;
                                    break;
                                case ConsoleKey.Escape:
                                    exitWhile = true;
                                    showTable();
                                    break;
                                default:
                                    continue;
                            }
                        }
                    }
                    else p2.selectAllDice();
                    showTable();
                    p1.rollDice();
                    if (p1.IsPlayer())
                    {
                        bool exitWhile = false;
                        while (!exitWhile)
                        {
                            if (p2._Dice.Length <= 0)
                            {
                                exitWhile = true;
                                continue;
                            }
                            switch (Console.ReadKey().Key)
                            {
                                case ConsoleKey.LeftArrow:
                                    (p2 as Player).moveSelector(Player.SelectorMove.Left);
                                    showTable();
                                    break;
                                case ConsoleKey.RightArrow:
                                    (p2 as Player).moveSelector(Player.SelectorMove.Right);
                                    showTable();
                                    break;
                                case ConsoleKey.Enter:
                                    p2.selectDice();
                                    p2.resetSelection();
                                    showTable();
                                    break;
                                case ConsoleKey.Backspace when p2.reRollDice():
                                    showTable();
                                    exitWhile = true;
                                    break;
                                case ConsoleKey.Escape:
                                    exitWhile = true;
                                    showTable();
                                    break;
                                default:
                                    continue;
                            }
                        }
                    }
                    else p1.selectAllDice();
                    showTable();
                    break;
                default:
                    break;
            }
            foreach (Dice Dice in p1.SelectedDice)
            {
                if (Dice.UpSide.Border) p1.getVictimTokens(1);
            }
            foreach (Dice Dice in p2.SelectedDice)
            {
                if (Dice.UpSide.Border) p2.getVictimTokens(1);
            }
            p2.SelectedDice.DiseSort(new Dice.DiceSides[] { Dice.DiceSides.Axe,Dice.DiceSides.Arrow, Dice.DiceSides.Helmet, Dice.DiceSides.Shield, Dice.DiceSides.Hand, Dice.DiceSides.Empty });
            p1.SelectedDice.DiseSort(new Dice.DiceSides[] { Dice.DiceSides.Axe, Dice.DiceSides.Arrow, Dice.DiceSides.Helmet, Dice.DiceSides.Shield, Dice.DiceSides.Hand, Dice.DiceSides.Empty });
            showTable();

        }
        public void showTable()
        {
            string stringP1;
            string stringP2;
            if(p1.IsPlayer())
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
            Console.WriteLine($"{stringP1} | Health: {p1.Health}  VictimTokens: {p1.VictimToken}  RerollCount: {p1.DiceReroll}");
            Console.WriteLine("Dice:");
            Console.Write("\t");
            for (int i = 0; i < p1._Dice.Length; i++)
            {
                if (i+1 == (p1 as Player)?.Selector)
                {
                    Console.Write("-> " + p1._Dice[i].ToString() + "   ");
                    continue;
                }
                Console.Write(p1._Dice[i].ToString() + "   ");
            }
            //foreach (Dice item in p1._Dice)
            //{
            //    Console.Write(item.ToString()+"   ");
            //}
            Console.WriteLine();
            Console.WriteLine("Selected dice:");
            Console.Write("\t");
            if (p1.SelectedDice.Length > 0)
            {
                foreach (Dice item in p1.SelectedDice)
                {
                    Console.Write(item.ToString() + "   ");
                }
            }

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            Console.Write("\t");
            if (p2.SelectedDice.Length > 0)
            {
                foreach (Dice item in p2.SelectedDice)
                {
                    Console.Write(item.ToString() + "   ");
                }
            }
            Console.WriteLine();
            Console.WriteLine("Selected dice:");
            Console.Write("\t");
            for (int i = 0; i < p2._Dice.Length; i++)
            {   if(i+1 == (p2 as Player)?.Selector)
                {
                    Console.Write("-> "+p2._Dice[i].ToString() + "   ");
                    continue;
                }
                Console.Write(p2._Dice[i].ToString() + "   ");
            }
            Console.WriteLine();
            Console.WriteLine("Dice:");
            Console.WriteLine($"{stringP2} | Health: {p2.Health}  VictimTokens: {p2.VictimToken}  RerollCount: {p1.DiceReroll}");
        }
    }
}
