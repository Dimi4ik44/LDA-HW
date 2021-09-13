using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TETRIS
{
    class Controls
    {
        public Controls()
        {
        }
        public async Task GetInputAsync()
        {
            ConsoleKeyInfo k = default;
            do
            {
                if (Console.KeyAvailable)
                    k = Console.ReadKey();
            } while (k.Key != ConsoleKey.Q);                   
        }
    }
}
