using System;
using System.Collections.Generic;
using System.Text;

namespace WarrShips
{
    class Controls
    {
        public ConsoleKey GetInput()
        {
            return Console.ReadKey().Key;
        }
    }
}
