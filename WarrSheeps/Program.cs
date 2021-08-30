using System;
using System.Numerics;

namespace WarrShips
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            Player p1 = new Player("Player1");
            Player p2 = new Player("Player2");

            //select
            //p1.SelectCell();
            //------------
            p1.putShipsAction();
            Console.WriteLine("Press Enter to continue");
            Console.ReadKey();
            p2.putShipsAction();
            Console.WriteLine("Press Enter to continue");
            Console.ReadKey();

            p1.SetEnemyField(p2.PField);
            p2.SetEnemyField(p1.PField);
            //---------------
            Console.Clear();
            //------------
            while(true)
            {
                p1.AtackAction();
                p2.AtackAction();
            }

            //---------------

            //p1.ShowFields();

        }
    }
}
