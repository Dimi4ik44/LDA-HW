using System;
using System.Collections.Generic;
using System.Text;
using System.Numerics;

namespace HW7_8
{
    abstract class Person : IMovable
    {
        public string Name { get; private set; }
        public int Age { get; private set; }
        public Vector3 MyProperty { get; set; }
        public int MoveSpeed { get; private set; }
        public int MaxMoveSpeed { get; private set; } = 10;
        public int MinMoveSpeed { get; private set; } = 0;
        public string About { get; private set; }
        public Person(string name, int age, int moveSpeed = 0)
        {
            Name = name;
            Age = age;
            MoveSpeed = moveSpeed;

        }
        public Person(string name, int age, string about, int moveSpeed = 0) : this(name,age,moveSpeed)
        {
            About = about;
        }
        public bool ChangeMoveSpeed(int speed)
        {
            if(speed >= MinMoveSpeed && speed <= MaxMoveSpeed)
            {
                MoveSpeed = speed;
                return true;
            }
            return false;
        }
        public bool Move()
        {
            return false;
        }
    }
}
