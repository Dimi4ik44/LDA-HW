using System;

namespace ConsoleGameHW6
{
    class Program
    {
        static Enemy[] enemys;
        static void Main(string[] args)
        {
            //Console.OutputEncoding = System.Text.Encoding.Unicode;
            Random rnd = new Random();
            Field.createNewField(10,10);
            Player p = new Player(0,2);
            enemys = new Enemy[] { new Enemy(), new Enemy(), new Enemy(), new Enemy(), new Enemy(), new Enemy(), new Enemy(), new Enemy() };
            Field.render();
            while (true)
            {
                if (p.move(DirectionManager.selectDirection()))
                {
                    foreach (Enemy e in enemys)
                    {
                        e.move(rnd.Next(1, 5));
                    }
                    addEnemy();
                    Console.Clear();
                    Field.render();
                }     
            }
        }
        public static Enemy[] addEnemy()
        {
            Enemy[] en = new Enemy[enemys.Length + 1];
            for (int i = 0; i < enemys.Length; i++)
            {
                en[i] = enemys[i];
            }
            en[en.Length - 1] = new Enemy();
            return en;
        }
    }
}
