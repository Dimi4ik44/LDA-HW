using System;

namespace Assasin_Screed_Minigame
{
    class Program
    {
        //orlog
        static void Main(string[] args)
        {
            Console.WriteLine("Controls:");
            Console.WriteLine(" 1: select cubes using 'Arrows'");
            Console.WriteLine(" 2: for conform select press 'ENTER'");
            Console.WriteLine(" 3: for select all cubes press 'ENTER' without selection");
            Console.WriteLine(" 4: 'BACKSPACE' reroll cubes");
            Console.WriteLine("Press ANY button to continue!");
            Console.ReadKey();
            Console.Clear();
            Player p = new Player();
            Enemy e = new Enemy();
            Table table = new Table(p,e);
            table.startGame();
            
        }
    }
}
