using System;
using System.Collections.Generic;
using System.Text;

namespace Task2
{
    class Emploee : IMember, IEmploee
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Position { get; set; }
        public int Sallary { get; set; }
    }
}
