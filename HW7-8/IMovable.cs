using System;
using System.Collections.Generic;
using System.Text;
using System.Numerics;

namespace HW7_8
{
    interface IMovable
    {
        public int MoveSpeed { get; }
        public int MaxMoveSpeed { get; }
        public int MinMoveSpeed { get; }
        public Vector3 MyProperty { get; set; }
        public bool Move();
    }
}
