using System;

namespace ConsoleGameHW6
{
    class Program
    {
        static bool gameStatus = true; // true - play | false - gameOver
        static void Main(string[] args)
        {         
            Random rnd = new Random();
            Field.createNewField(6,6);
            Player p = new Player(0,2);
            Enemy.enemys = new Enemy[] { new Enemy(), new Enemy(), new Enemy(), new Enemy(), new Enemy(), new Enemy(), new Enemy(), new Enemy() };
            Shield.shields = new Shield[] { new Shield(), new Shield() };
            Field.render();
            Console.WriteLine($"Total Enemys: {Enemy.enemyCount}  Shields: {Player.ShieldCount}");
            while (gameStatus)
            {
                if (p.move(DirectionManager.selectDirection()))
                {
                    foreach (Enemy e in Enemy.enemys)
                    {
                        e.move(rnd.Next(1, 5));
                    }
                    Enemy.addEnemy();
                    Console.Clear();
                    foreach (Shield s in Shield.shields)
                    {
                        s.reSpawn();
                    }
                    Field.render();
                    Console.WriteLine($"Total Enemys: {Enemy.enemyCount}  Shields: {Player.ShieldCount}");

                }
                if (!Field.checkNear(p.XPos, p.YPos))
                {
                    //Console.WriteLine("lol");
                    gameOver();
                }
            }
            Console.WriteLine("Game Over");
        }
        public static void gameOver()
        {
            gameStatus = false;
        }
    }
}
