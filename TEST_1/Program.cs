using System;

namespace TEST_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Q1 q = new Q1(1,2,3);

            try
            {
                throw new CustomException("MyException");
            }
            catch (CustomException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("Another Ex");
            }
        }
    }
}
