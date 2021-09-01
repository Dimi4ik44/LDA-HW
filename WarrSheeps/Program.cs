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
            //showRooles
            Console.WriteLine("Hello And Welcome\n" +
                "WarrSHIPS for 2 persons\n" +
                "Step1: Player1 put the ships on field\n" +
                "Step2: Player2 put the ships on field\n" +
                "Did it using arrow keys to select a cell\n" +
                "Use 'R' button for reset field\n" +
                "Use 'BackSpace' for rotate a ship\n" +               
                "Step3: Using arrow keys select a cell\n" +
                "Press 'Enter' for SHOOT\n\n\n\n" +
                "PRESS ANY KEY TO CONTINUE!"
                
                );
            Console.ReadKey();
            //----------
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
            while (p1.CheckShips() && p2.CheckShips())
            {
                p1.AtackAction();
                Console.WriteLine("Press Enter to end TURN");
                Console.ReadKey();
                p2.AtackAction();
                Console.WriteLine("Press Enter to end TURN");
                Console.ReadKey();
            }
            Console.Clear();
            if(p1.CheckShips())
            {
                Console.WriteLine("P1 WIN");
            }
            else
            {
                Console.WriteLine("P2 WIN");
            }

            //---------------

            //p1.ShowFields();

        }
    }
}
