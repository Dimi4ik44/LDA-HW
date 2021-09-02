using System;
using System.Collections.Generic;
using System.Text;

namespace Task2
{
    interface IBook
    {
        public string Name { get; set; }

        public string Desc { get; set; }

        public string Author { get; set; }
        public DateTime DateOfManufacture { get; set; }
    }
}
