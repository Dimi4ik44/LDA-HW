using System;

namespace ConsoleGameHW6
{
    class Program
    {
        static bool gameStatus = true; // true - play | false - gameOver
        static void Main(string[] args)
        {         
            Random rnd = new Random();
            Field.createNewField(4,4);
            Player p = new Player(0,2);
            Enemy.enemys = new Enemy[] { new Enemy(), new Enemy(), new Enemy(), new Enemy(), new Enemy(), new Enemy(), new Enemy(), new Enemy() };
            Field.render();
            Console.Write($"Total Enemys: {Enemy.enemyCount}");
            while (gameStatus)
            {
                if (p.move(DirectionManager.selectDirection()))
                {
                    foreach (Enemy e in Enemy.enemys)
                    {
                        e.move(rnd.Next(1, 5));
                    }
                    Enemy.enemys = addEnemy();
                    Console.Clear();
                    Field.render();
                    Console.WriteLine($"Total Enemys: {Enemy.enemyCount}");
                }     
            }
            Console.WriteLine("Game Over");
        }
        public static Enemy[] addEnemy()
        {
            Enemy[] en = new Enemy[Enemy.enemys.Length + 1];
            for (int i = 0; i < Enemy.enemys.Length; i++)
            {
                en[i] = Enemy.enemys[i];
            }
            en[en.Length - 1] = new Enemy();
            return en;
        }
        public static void gameOver()
        {
            gameStatus = false;
        }
    }
}
