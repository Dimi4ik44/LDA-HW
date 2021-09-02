using System;
using System.Collections.Generic;

namespace validators
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            ValidatorList<string> vl = new ValidatorList<string>();
            IValidator<string> p = new StringStartWithUpperCase();
            vl.vlist = new List<Validator<string>> {
                new StringLengthLessThanFive(),
                new StringStartWithUpperCase()
            };
            Console.WriteLine(CheckStringValide("Kdy",vl));
        }
        public static bool CheckStringValide(string text, ValidatorList<string> a)
        {
            if(a.vlist.Count > 0)
            {
                foreach (Validator<string> item in a.vlist)
                {
                    if (!item.IsValueValid(text)) return false;
                }
            }
            else
            {
                return false;
            }

            return true;
        }
    }
}
