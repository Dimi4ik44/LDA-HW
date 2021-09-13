using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TETRIS
{
    class Program
    {
        static async Task Main(string[] args)
        {
            List<Shape> baseShapes = new List<Shape>() {
                new Shape("O",new int[2,2]{ 
                    {1,1},
                    {1,0}
                }),
                new Shape("I",new int[1,4]{
                    {1,1,1,1},
                }),
                new Shape("S",new int[2,3]{
                    {0,1,1},
                    {1,1,0}
                }),
                new Shape("Z",new int[2,3]{
                    {1,1,0},
                    {0,1,1}
                }),
                new Shape("T",new int[2,3]{
                    {0,1,0},
                    {1,1,1}
                }),
                new Shape("J",new int[2,3]{
                    {1,1,1},
                    {0,0,1}
                }),
                new Shape("L",new int[2,3]{
                    {1,1,1},
                    {1,0,0}
                })



            };

            Game game = new Game(new List<Shape>() { },20,10);
            for (int i = 0; i < 3; i++)
            {
                ShowFigure(baseShapes[0].Build);
                Console.WriteLine();
                ShowFigure(baseShapes[1].Build);
                Console.WriteLine();
                ShowFigure(baseShapes[2].Build);
                Console.WriteLine();
                ShowFigure(baseShapes[3].Build);
                Console.WriteLine();
                ShowFigure(baseShapes[4].Build);
                Console.WriteLine();
                ShowFigure(baseShapes[5].Build);
                Console.WriteLine();
                ShowFigure(baseShapes[6].Build);
                Console.WriteLine();
                baseShapes[0].Rotate();
                baseShapes[1].Rotate();
                baseShapes[2].Rotate();
                baseShapes[3].Rotate();
                baseShapes[4].Rotate();
                baseShapes[5].Rotate();
                baseShapes[6].Rotate();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("-------------------");
                Console.ResetColor();

            }
        }
        public static void ShowFigure(int[,] a)
        {
            int f = a.GetLength(0);
            int g = a.GetLength(1);
            for (int i = 0; i < f; i++)
            {
                for (int k = 0; k < g; k++)
                {
                    if (a[i,k] == 1)
                    {
                        Console.Write("#");
                    }
                    else
                    { 
                        Console.Write("-"); 
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
