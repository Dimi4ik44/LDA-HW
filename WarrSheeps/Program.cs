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
            p1.SetEnemyField(p2.PField);
            p2.SetEnemyField(p1.PField);

            //select
            //p1.SelectCell();
            //------------
            Field seelectedField = p1.PField;
            p1.MoveSelector(Vector2.Zero, seelectedField);
            p1.ShowFields();
            int placedShips = 0;
            while (p1.Ships.Count > placedShips)
            {
                switch (p1.ControlManager.GetInput())
                {
                    case ConsoleKey.UpArrow:
                        p1.MoveSelector(-Vector2.UnitY, seelectedField);
                        break;
                    case ConsoleKey.DownArrow:
                        p1.MoveSelector(Vector2.UnitY, seelectedField);
                        break;
                    case ConsoleKey.LeftArrow:
                        p1.MoveSelector(-Vector2.UnitX, seelectedField);
                        break;
                    case ConsoleKey.RightArrow:
                        p1.MoveSelector(Vector2.UnitX, seelectedField);
                        break;
                    case ConsoleKey.Enter:
                        if(p1.PlaceShip(placedShips))
                        {
                            placedShips++;
                        }                       
                        break;
                    case ConsoleKey.Backspace:
                        p1.Ships[placedShips].Rotate();                    
                        break;
                }
                Console.Clear();
                p1.ShowFields();
            }
            p1.ResetSelection(seelectedField);
            //---------------
            Console.Clear();
            //------------
            seelectedField = p1.EField;
            p1.MoveSelector(Vector2.Zero, seelectedField);
            p1.ShowFields();
            while (true)
            {                         
                switch (p1.ControlManager.GetInput())
                {
                    case ConsoleKey.UpArrow:
                        p1.MoveSelector(-Vector2.UnitY, seelectedField);                    
                        break;
                    case ConsoleKey.DownArrow:
                        p1.MoveSelector(Vector2.UnitY, seelectedField);
                        break;
                    case ConsoleKey.LeftArrow:
                        p1.MoveSelector(-Vector2.UnitX, seelectedField);
                        break;
                    case ConsoleKey.RightArrow:
                        p1.MoveSelector(Vector2.UnitX, seelectedField);
                        break;
                    case ConsoleKey.Enter:
                        p1.Shoot();
                        break;
                }
                Console.Clear();
                p1.ShowFields();
            }
            //---------------

            //p1.ShowFields();

        }
    }
}
