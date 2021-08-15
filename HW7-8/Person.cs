using System;
using System.Collections.Generic;
using System.Text;

namespace HW7_8
{
    class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public int MoveSpeed { get; set; }
        public string About { get; set; }
        public Person(string name, int age, int moveSpeed)
        {
            Name = name;
            Age = age;
            MoveSpeed = moveSpeed;

        }
        public Person(string name, int age, int moveSpeed, string about)
        {
            Name = name;
            Age = age;
            MoveSpeed = moveSpeed;
            About = about;

        }
    }
}
