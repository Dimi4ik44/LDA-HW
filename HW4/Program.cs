using System;

namespace HW4
{
    class Program
    {
        static string[] errorMessageList = { "Incorect input", "Empty"};
        static void Main(string[] args)
        {
            int[,] matrix = inputMatrix(inputNumber("Input Lenght Matrix"), inputNumber("Input Height Matrix"));
            twoDementionArrayPrint(matrix);

        }
        static void selectOp()
        {
            Console.WriteLine("Select operation");
            Console.WriteLine("Operation list: \n   1: matrix + matrix\n   2: matrix * n\n  3: matrix * matrix\n   4: pow(matrix,n)\n   5: transpon(matrix)");
            switch (inputNumber())
            {
                case 1:

                default:
                    break;
            }
        }

        static int inputNumber(string message = "")
        {
            int number;
            if(message != "")
            {
                Console.WriteLine(message);
            }
            while (!(Int32.TryParse(Console.ReadLine(), out number)) || !(number > 0))
            {
                sendErrorMessage(errorMessageList[0]);
            }
            return number;
        }
        static int[,] inputMatrix(int sizeX,int sizeY)
        {
            int[,] matrix = new int[sizeY, sizeX];

            int lenghtDimen0, lenghtDimen1;
            lenghtDimen0 = matrix.GetLength(0);
            lenghtDimen1 = matrix.GetLength(1);

            for (int i = 0; i < lenghtDimen0; i++)
            {
                for (int k = 0; k < lenghtDimen1; k++)
                {
                    matrix[i, k] = inputNumber("Write next value:");
                }
            }

            return matrix;
        }
        static void twoDementionArrayPrint(int[,] array)
        {
            int lenghtDimen0, lenghtDimen1;
            lenghtDimen0 = array.GetLength(0);
            lenghtDimen1 = array.GetLength(1);
            string sep = "";
            for (int i = 0; i < lenghtDimen1 * 6 + 1; i++)
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


        static void sendErrorMessage(string error)
        {
            Console.WriteLine($"Error: {error}");
        }
    }
}
