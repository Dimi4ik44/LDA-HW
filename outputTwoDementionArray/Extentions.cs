using System;
using System.Collections.Generic;
using System.Text;

namespace outputTwoDementionArray
{
    static class Extentions
    {
        public static void arrayOutput3(this int[,] a)
        {
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int k = 0; k < a.GetLength(1); k++)
                {
                    Console.Write(" " + a[i, k]);
                }
                Console.WriteLine();
            }
        }
    }
}
