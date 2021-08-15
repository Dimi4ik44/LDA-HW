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
            while (!p1.IsDead && !p2.IsDead)
            {
                p1.reset();
                p2.reset();
                showTable();
                switch (_Coin.coinState)
                {
                    case 1:               
                        p1.rollDice();
                        showTable();
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
                                        //exitWhile = true;
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
                        p2.rollDice();
                        showTable();
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
                                        //exitWhile = true;
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
                        p2.rollDice();
                        showTable();
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
                                        //exitWhile = true;
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
                        p1.rollDice();
                        showTable();
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
                                        //exitWhile = true;
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
                p2.SelectedDice.DiceSort(new Dice.DiceSides[] { Dice.DiceSides.Axe, Dice.DiceSides.Arrow, Dice.DiceSides.Helmet, Dice.DiceSides.Shield, Dice.DiceSides.Hand, Dice.DiceSides.Empty });
                p1.SelectedDice.DiceSort(new Dice.DiceSides[] { Dice.DiceSides.Axe, Dice.DiceSides.Arrow, Dice.DiceSides.Helmet, Dice.DiceSides.Shield, Dice.DiceSides.Hand, Dice.DiceSides.Empty });
                foreach (Dice Dice in p1.SelectedDice)
                {
                    if (Dice.UpSide.Border) p1.getVictimTokens(1);
                }
                foreach (Dice Dice in p2.SelectedDice)
                {
                    if (Dice.UpSide.Border) p2.getVictimTokens(1);
                }
                showTable();
                Console.ReadKey(true);
                for (int i = 0; i < 6; i++)
                {
                    Action(p1, p2);
                }
                for (int i = 0; i < 6; i++)
                {
                    Action(p2, p1);
                }
                showTable();
                Console.ReadKey(true);
            }
            if(!p1.IsDead)
            {
                Console.WriteLine("Player 1 WIN");
            }
            if (!p2.IsDead)
            {
                Console.WriteLine("Player 2 WIN");
            }

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
            //Console.BackgroundColor = ConsoleColor.Magenta;
            showPlayerStatistic(p1, stringP1);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Dice:");
            Console.ResetColor();
            Console.Write("\t");
            renderDice(p1);
            //foreach (Dice item in p1._Dice)
            //{
            //    Console.Write(item.ToString()+"   ");
            //}
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Selected Dice:");
            Console.ResetColor();
            Console.Write("\t");
            RenderSelectedDice(p1.SelectedDice);

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            Console.Write("\t");
            RenderSelectedDice(p2.SelectedDice);
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Selected Dice:");
            Console.ResetColor();
            Console.Write("\t");

            renderDice(p2);
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Dice:");
            Console.ResetColor();
            showPlayerStatistic(p2,stringP2);
        }
        public void Action(Entity p1, Entity p2)
        {
            for (int i = 0; i < p1.SelectedDice.Length; i++)
            {
                if(p1.SelectedDice[i].UpSide.Sign != Dice.DiceSides.Axe && p1.SelectedDice.Length > 0)
                {
                    //continue;
                }
                else
                {
                    for (int k = 0; k < p2.SelectedDice.Length; k++)
                    {
                        if(p2.SelectedDice[k].UpSide.Sign == Dice.DiceSides.Helmet && p2.SelectedDice.Length > 0)
                        {
                            p2.SelectedDice = p2.SelectedDice.DiceRemoveByIndex(k);
                            p1.SelectedDice = p1.SelectedDice.DiceRemoveByIndex(i);
                            return;
                        }
                        
                    }
                    p1.SelectedDice = p1.SelectedDice.DiceRemoveByIndex(i);
                    p2.takeDamage(1);
                    return;
                }
                if (p1.SelectedDice[i].UpSide.Sign != Dice.DiceSides.Arrow && p1.SelectedDice.Length > 0)
                {
                    //continue;
                }
                else
                {
                    for (int k = 0; k < p2.SelectedDice.Length; k++)
                    {
                        if (p2.SelectedDice[k].UpSide.Sign == Dice.DiceSides.Shield && p2.SelectedDice.Length > 0)
                        {
                            p2.SelectedDice = p2.SelectedDice.DiceRemoveByIndex(k);
                            p1.SelectedDice = p1.SelectedDice.DiceRemoveByIndex(i);
                            return;
                        }

                    }
                    p1.SelectedDice = p1.SelectedDice.DiceRemoveByIndex(i);
                    p2.takeDamage(1);
                    return;
                }
                if (p1.SelectedDice[i].UpSide.Sign != Dice.DiceSides.Hand && p1.SelectedDice.Length > 0)
                {
                    //continue;
                }
                else
                {                    
                        if (p2.VictimToken > 0)
                        {
                            p1.getVictimTokens(1);
                            p2.loseVictimTokens(1);
                            p1.SelectedDice = p1.SelectedDice.DiceRemoveByIndex(i);
                            return;
                        }
                }
            }
        }
        private void showPlayerStatistic(Entity e,string name)
        {
            Console.ForegroundColor = ConsoleColor.Blue; Console.Write($"{name} | "); Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Red; Console.Write($"Health: {e.Health} | "); Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Yellow; Console.Write($"VictimTokens: {e.VictimToken} | "); Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Green; Console.Write($"RerollCount: {e.DiceReroll} |"); Console.ResetColor();
            Console.WriteLine();
        }
        private void RenderSelectedDice(Dice[] d)
        {
            if (d.Length > 0)
            {
                foreach (Dice item in d)
                {
                    switch (item.UpSide.Sign)
                    {
                        case Dice.DiceSides.Axe:
                            Console.ForegroundColor = ConsoleColor.Red;
                            break;
                        case Dice.DiceSides.Arrow:
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            break;
                        case Dice.DiceSides.Helmet:
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            break;
                        case Dice.DiceSides.Shield:
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            break;
                        case Dice.DiceSides.Hand:
                            Console.ForegroundColor = ConsoleColor.DarkCyan;
                            break;
                        case Dice.DiceSides.Empty:
                            Console.ForegroundColor = ConsoleColor.White;
                            break;
                        default:
                            break;
                    }
                    Console.Write(item.ToString() + "   ");
                    Console.ResetColor();
                }
            }
        }
        private void renderDice(Entity e)
        {
            for (int i = 0; i < e._Dice.Length; i++)
            {
                if (i + 1 == (e as Player)?.Selector)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.Write("-> ");
                    Console.ResetColor();
                    switch (e._Dice[i].UpSide.Sign)
                    {
                        case Dice.DiceSides.Axe:
                            Console.ForegroundColor = ConsoleColor.Red;
                            break;
                        case Dice.DiceSides.Arrow:
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            break;
                        case Dice.DiceSides.Helmet:
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            break;
                        case Dice.DiceSides.Shield:
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            break;
                        case Dice.DiceSides.Hand:
                            Console.ForegroundColor = ConsoleColor.DarkCyan;
                            break;
                        case Dice.DiceSides.Empty:
                            Console.ForegroundColor = ConsoleColor.White;
                            break;
                        default:
                            break;
                    }
                    Console.Write(e._Dice[i].ToString() + "   ");
                    Console.ResetColor();
                    continue;
                }
                switch (e._Dice[i].UpSide.Sign)
                {
                    case Dice.DiceSides.Axe:
                        Console.ForegroundColor = ConsoleColor.Red;
                        break;
                    case Dice.DiceSides.Arrow:
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        break;
                    case Dice.DiceSides.Helmet:
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        break;
                    case Dice.DiceSides.Shield:
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        break;
                    case Dice.DiceSides.Hand:
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        break;
                    case Dice.DiceSides.Empty:
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                    default:
                        break;
                }
                Console.Write(e._Dice[i].ToString() + "   ");
                Console.ResetColor();
            }
        }
    }
}
