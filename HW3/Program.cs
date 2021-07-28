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

            static int readNumber()
            {
                int number;
                Console.WriteLine("Set array size!");
                while (!(Int32.TryParse(Console.ReadLine(), out number)))
                {
                    sendErrorMessage(errorMessageList[0]);
                }
                return number;
            }

            static void arrayFillSquareOutline(int[,] array)
            {

            }
            static void arrayFillPiramid(int[,] array)
            {

            }
            static void arrayFillTypeX(int[,] array)
            {

            }
            static void sendErrorMessage(string error)
            {
                Console.WriteLine($"Error: {error}");
            }
        }
    }
}
