using System;
using System.Collections.Generic;
using System.Text;

namespace Task2
{
    class Client : IMember
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public Contacts<PhoneNumber> Contacts { get; set; }

        public Client(string name, int age, Contacts<PhoneNumber> con)
        {
            Name = name;
            Age = age;
            Contacts = con;
        }

    }
}
