using System;

namespace HW3
{
    class Program
    {
        static string[] errorMessageList = new string[5];

        static void Main(string[] args)
        {
            //init error messages
            errorMessageList[0] = "Incorect input";
            errorMessageList[1] = "Empty";
            errorMessageList[2] = "Empty";
            errorMessageList[3] = "Empty";
            errorMessageList[4] = "Empty";
            //code
            int arraySize = readNumber();
            int[,] myArray = new int[arraySize, arraySize];
            arrayPrint(arrayFillRandom(myArray));
            myArray = new int[arraySize, arraySize];
            arrayPrint(arrayFillSquareOutline(myArray));
            myArray = new int[arraySize, arraySize];
            arrayPrint(arrayFillTypeX(myArray));
            myArray = new int[arraySize, arraySize];
            arrayPrint(arrayFillPiramid(myArray));

            static int readNumber()
            {
                int number;
                Console.WriteLine("Set array size!");
                while (!(Int32.TryParse(Console.ReadLine(), out number)) || !(number > 0))
                {
                    sendErrorMessage(errorMessageList[0]);
                }
                return number;
            }
            static int[,] arrayFillRandom(int[,] array)
            {
                int lenghtDimen0, lenghtDimen1, max=int.MinValue, min=int.MaxValue, holder;
                double middle , sum = 0;
                lenghtDimen0 = array.GetLength(0);
                lenghtDimen1 = array.GetLength(1);
                Random rnd = new Random();
                for (int i = 0; i < lenghtDimen0; i++)
                {
                    for (int k = 0; k < lenghtDimen1; k++)
                    {
                        holder = rnd.Next(0, 10);
                        if (holder < min) min = holder;
                        if (holder > max) max = holder;
                        sum += holder;
                        array[i, k] = holder;
                    }
                }
                middle = sum / array.Length;
                Console.WriteLine($"Min: {min}, Max: {max}, Middle: {middle}");
                return array;
            }
            static int[,] arrayFillSquareOutline(int[,] array)
            {
                int lenghtDimen0, lenghtDimen1;
                lenghtDimen0 = array.GetLength(0);
                lenghtDimen1 = array.GetLength(1);
                for (int i = 0; i < lenghtDimen0; i++)
                {
                    for (int k = 0; k < lenghtDimen1; k++)
                    {
                        if((i == 0 || k == 0) || (i == lenghtDimen0 - 1 || k == lenghtDimen1 - 1))
                        {
                            array[i, k] = 1;
                        }
                        else
                        {
                            array[i, k] = 0;
                        }
                    }
                }
                return array;
            }
            static int[,] arrayFillPiramid(int[,] array)
            {
                int lenghtDimen0, lenghtDimen1;
                lenghtDimen0 = array.GetLength(0);
                lenghtDimen1 = array.GetLength(1);
                int counter = 1;
                for (int i = 0; i < lenghtDimen1; i++)
                {
                    for (int k = 0 + i; k < lenghtDimen0 - i; k++)
                    {
                        array[i, k] = counter++;
                    }
                    counter = 1;
                    for (int k = lenghtDimen0 - i-1; k <= 0 + i; k++)
                    {
                        array[i, k] = counter++;
                    }
                    counter = 1;
                }
                return array;
            }
            static int[,] arrayFillTypeX(int[,] array)
            {
                int lenghtDimen0, lenghtDimen1;
                lenghtDimen0 = array.GetLength(0);
                lenghtDimen1 = array.GetLength(1);
                for (int i = 0; i < lenghtDimen0; i++)
                {
                    array[i, 0+i] = 1;
                    array[i, (lenghtDimen1-1)-i] = 1;
                }
                return array;
            }
            static void arrayPrint(int[,] array)
            {
                int lenghtDimen0, lenghtDimen1;
                lenghtDimen0 = array.GetLength(0);
                lenghtDimen1 = array.GetLength(1);
                string sep = "";
                for (int i = 0; i < lenghtDimen1*6+1; i++)
                {
                    sep += "-";
                }
                for (int i = 0; i < lenghtDimen0; i++)
                {
                    Console.WriteLine(sep);
                    for (int k = 0; k < lenghtDimen1; k++)
                    {
                        Console.Write($"|  {array[i, k]}  ");
                    }
                    Console.Write("|\n");
                }
                Console.WriteLine(sep);
            }
            //error sender
            static void sendErrorMessage(string error)
            {
                Console.WriteLine($"Error: {error}");
            }
        }
    }
}
