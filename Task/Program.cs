using System;

namespace Task
{
    class Program
    {
        static void Main(string[] args)
        {
            Journal j = new Journal(new Course("Math"),"John",9,9,9,9,9);
            j.ShowJournal();
        }
    }
}
