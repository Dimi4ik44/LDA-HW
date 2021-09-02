using System;

namespace Task2
{
    class Program
    {
        //Library
        //iterface 5 // Generic class 2 // Extention 1 linq style
        public static PhoneNumber pn = new PhoneNumber();
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            pn.CreateNumber("Ukraine",0672717399);
            Console.WriteLine(pn);
        }
    }
}
