using System;
using System.Collections.Generic;
using System.Text;

namespace HW7_8
{
    class Positions
    {
        public enum PositionList
        {
            Manager = 0,
            Janitor,
            Сashier,
            Accountant,
            Supplier
        }
        public int[] Sallorys { get; set; } =
        {
            200,
            50,
            100,
            150,
            30
        };
        public int getSallory(PositionList p)
        {
            return Sallorys[(int)p];
        }
    }
}
