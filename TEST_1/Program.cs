using System;

namespace TEST_1
{
    class Program
    {
        static void Main(string[] args)
        {
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
