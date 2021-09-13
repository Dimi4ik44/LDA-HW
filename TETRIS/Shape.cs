using System;
using System.Collections.Generic;
using System.Text;

namespace TETRIS
{
    class Shape : IShape
    {
        public string Name { get; set; }
        public int[,] Build { get; set; }
        public ShapeColor Color { get; set; }
        public Shape(string name, int[,] build)
        {
            Random rnd = new Random();
            Name = name;
            Build = build;
            Color = (ShapeColor)rnd.Next(5);
        }
        public bool Rotate()
        {
            int yLenth = Build.GetLength(0);
            int xLenth = Build.GetLength(1);
            int[,] result = new int[xLenth, yLenth];
            for (int i = 0; i < yLenth; i++)
            {
                for (int k = 0; k < xLenth; k++)
                {
                    result[k, i] = Build[yLenth-1-i, k];
                }
            }
            Build = result;
            return true;
        }
    }
}
