using System;
using System.Collections.Generic;
using System.Text;

namespace TETRIS
{
    interface IShape
    {
        public string Name { get; set; }
        public int[,] Build { get; set; }
    }
}
