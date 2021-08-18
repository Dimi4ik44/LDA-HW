using System;
using System.Collections.Generic;
using System.Text;

namespace Task
{
    class Journal
    {
        public object[,] Data { get; set; }
        public Journal(Course course, string nameOfStudent, params int[] marks)
        {
            Data = new object[,] { { course.Name,new object[] {nameOfStudent,new object[] {marks} }  } };
        }

        public void ShowJournal()
        {
            for (int i = 0; i < Data.GetLength(0); i++)
            {
                Console.WriteLine(Data[i,1].);

            }
        }
    }
}
