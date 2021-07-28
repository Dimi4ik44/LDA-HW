using System;

namespace HW3
{
    class Program
    {
         static string[] errorMessageList = new string[5];
        
        static void Main(string[] args)
        {
            errorMessageList[0] = "Incorect input";
            int arraySize = readNumber();
            Console.WriteLine(arraySize);
        }

        static int readNumber()
        {
            int number;
            while(!(Int32.TryParse(Console.ReadLine(), out number)))
            {
                errorMessageSender(errorMessageList[0]);
            }
            return number;
        }
        static void errorMessageSender(string error)
        {
            Console.WriteLine($"Error: {error}");
        }
    }
}
