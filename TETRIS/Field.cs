using System;
using System.Collections.Generic;
using System.Text;

namespace TETRIS
{
    class Field
    {
        public int[,] _Field { get; set; }
        public Field(int x, int y)
        {
            _Field = new int[y, x];
        }
    }
}
