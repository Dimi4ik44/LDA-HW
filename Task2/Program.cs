using System;
using System.Linq;

namespace Task2
{
    class Program
    {
        //Library
        //iterface 5 // Generic class 2 // Extention 1 linq style
        public static MobilePhoneNumber pn = new MobilePhoneNumber();
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            pn.CreateNumber("Ukraine",0672717399);

            pn.CountryList.Where(x => x.Length > 2).ToList().ForEach((x)=> Console.WriteLine(x));
        }
    }
}
