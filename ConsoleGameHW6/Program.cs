using System;

namespace ConsoleGameHW6
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            Field.createNewField(10,10);
            Player p = new Player(0,2);
            Enemy[] enemys = new Enemy[] { new Enemy(), new Enemy(), new Enemy() };
            Field.render();
            while (true)
            {
                if (p.move(DirectionManager.selectDirection()))
                {
                    foreach (Enemy e in enemys)
                    {
                        e.move(rnd.Next(1, 5));
                    }
                }
                Console.Clear();
                Field.render();
            }
        }
    }
}
