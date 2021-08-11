using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleGameHW6
{
    class DirectionManager
    {
        public static int selectDirection()
        {
            ConsoleKey key = Console.ReadKey(true).Key;
            bool correctInput = false;
            while (!correctInput)
            {
                switch (key)
                {
                    case ConsoleKey.UpArrow:
                        correctInput = true;
                        return 1;
                    case ConsoleKey.DownArrow:
                        correctInput = true;
                        return 2;
                    case ConsoleKey.LeftArrow:
                        correctInput = true;
                        return 3;
                    case ConsoleKey.RightArrow:
                        correctInput = true;
                        return 4;
                }
            }
            return 0;
        }
    }
}
