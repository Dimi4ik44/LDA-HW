using System;

namespace Assasin_Screed_Minigame
{
    class Program
    {
        //orlog
        static void Main(string[] args)
        {
            Player p = new Player();
            Enemy e = new Enemy();
            Table table = new Table(e,p);
            table.startGame();
            
        }
    }
}
