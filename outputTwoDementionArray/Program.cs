using System;
using System.Collections.Generic;

namespace outputTwoDementionArray
{
    class Program
    {
        static public int[,] myarray = new int[10,10];
        static void Main(string[] args)
        {
            for (int i = 0; i < myarray.GetLength(0); i++)
            {
                for (int k = 0; k < myarray.GetLength(1); k++)
                {
                    myarray[i, k] = i + k;
                }
            }
            arrayOutput(myarray);
            arrayOutput2(myarray);
            myarray.arrayOutput3();
            Array.ForEach(myarray, new Action<int>(arrayOutput));
            Dictionary<string, int> paper = new Dictionary<string, int>();
        }
        static public void arrayOutput(int[,] a)
        {
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int k = 0; k < a.GetLength(1); k++)
                {
                    Console.Write(" "+a[i, k]);
                }
                Console.WriteLine();
            } 
        }
        static public void arrayOutput2(int[,] a)
        {
            foreach (int item in a)
            {
                Console.WriteLine(item);
            }
        }
        static public void ShowElement(int a)
        {
            Console.WriteLine(a);
        }

    }
}
