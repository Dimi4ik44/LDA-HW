using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleGameHW6
{
    public static class Field
    {
        public static int XSize { get; private set; }
        public static int YSize { get; private set; }
        private static Cell[,] array;

        public static Cell[,] ChangeField { get { return array; } set { array = value; } }
        static Field()
        {

        }
        public static bool placeObj(int x, int y, Skins.SkinsList s, bool firstSpawn = false)
        {
            if(firstSpawn)
            {
                if (x >= 0 && x < XSize && y >= 0 && y < YSize && array[y, x].skin == (int)Skins.SkinsList.Empty)
                {
                    array[y, x].skin = (int)s;
                    return true;
                }
                
            }
            else
            {
                if (x >= 0 && x < XSize && y >= 0 && y < YSize && (array[y, x].skin == (int)Skins.SkinsList.Empty || array[y, x].skin == (int)Skins.SkinsList.DefaultPlayer || array[y, x].skin == (int)Skins.SkinsList.Stick))
                {
                    if(s == Skins.SkinsList.DefaultPlayer && array[y, x].skin == (int)Skins.SkinsList.Stick)
                    {
                        Player.ShieldCount++;
                        Shield[] tempShields = new Shield[Shield.shields.Length-1];
                        int counter = 0;
                        for (int i = 0; i < Shield.shields.Length; i++)
                        {
                            if(Shield.shields[i].XPos == x && Shield.shields[i].YPos == y)
                            {
                                continue;
                            }
                            tempShields[counter] = Shield.shields[i];
                            counter++;
                        }
                        Shield.shields = tempShields;
                    }
                    if(array[y, x].skin == (int)Skins.SkinsList.DefaultPlayer && Player.ShieldCount == 0)
                    {
                        Program.gameOver();
                    }
                    else if(array[y, x].skin == (int)Skins.SkinsList.DefaultPlayer && Player.ShieldCount > 0)
                    {
                        Player.ShieldCount--;
                        return false;
                    }
                    array[y, x].skin = (int)s;
                    return true;

                }
            }
            return false;
        }
        public static void clearObj(int x, int y, Skins.SkinsList s)
        {
            array[y, x].skin = (int)s;
        }
        public static void createNewField(int x,int y)
        {
            XSize = x;
            YSize = y;
            array = new Cell[YSize, XSize];
            Random rnd = new Random();
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int k = 0; k < array.GetLength(1); k++)
                {
                    array[i, k] = new Cell();
                    if(rnd.Next(0,100) >  90)
                    {
                        array[i, k].skin = (int)Skins.SkinsList.Tree;
                    }
                    else if(rnd.Next(0, 100) > 80)
                    array[i, k].skin = (int)Skins.SkinsList.Wall;
                }
            }
        }
        public static void render()
        {
                string sep = "";
                for (int i = 0; i < XSize * 6 + 1; i++)
                {
                    sep += "-";
                }
                for (int i = 0; i < YSize; i++)
                {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(sep);
                Console.ResetColor();
                    for (int k = 0; k < XSize; k++)
                    {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("|");
                    Console.ResetColor();

                    switch (array[i, k].skin)
                    {
                        case 0:
                            Console.ForegroundColor = ConsoleColor.Black;
                            break;
                        case 1:
                            Console.ForegroundColor = ConsoleColor.Blue;
                            break;
                        case 2:
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            break;
                        case 3:
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            break;
                        case 4:
                            Console.ForegroundColor = ConsoleColor.Gray;
                            break;
                        default:
                            break;
                    }
                    Console.Write($"  {Skins.skinImage[array[i, k].skin]}  ");
                    }
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("|\n");
                Console.ResetColor();
            }
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(sep);
                Console.ResetColor();

        }
        public static bool checkNear(int x, int y)
        {
            bool nearClear = false;
            int xCopy = x;
            int yCopy = y;

            x -= 1;
            if (x >= 0 && x < XSize && y >= 0 && y < YSize)
            {
                


                if (x >= 0 && x < XSize && y >= 0 && y < YSize && (array[y, x].skin == (int)Skins.SkinsList.Empty || array[y, x].skin == (int)Skins.SkinsList.Stick))
                {
                    nearClear = true;
                }
            }
            x = xCopy;
            y = yCopy;

            x += 1;
            if (x >= 0 && x < XSize && y >= 0 && y < YSize)
            {



                if (x >= 0 && x < XSize && y >= 0 && y < YSize && (array[y, x].skin == (int)Skins.SkinsList.Empty || array[y, x].skin == (int)Skins.SkinsList.Stick))
                {
                    nearClear = true;
                }
            }
            x = xCopy;
            y = yCopy;

            y -= 1;
            if (x >= 0 && x < XSize && y >= 0 && y < YSize)
            {


                if (x >= 0 && x < XSize && y >= 0 && y < YSize && (array[y, x].skin == (int)Skins.SkinsList.Empty || array[y, x].skin == (int)Skins.SkinsList.Stick))
                {
                    nearClear = true;
                }
            }
            x = xCopy;
            y = yCopy;

            y += 1;
            if (x >= 0 && x < XSize && y >= 0 && y < YSize)
            {


                if (x >= 0 && x < XSize && y >= 0 && y < YSize && (array[y, x].skin == (int)Skins.SkinsList.Empty || array[y, x].skin == (int)Skins.SkinsList.Stick))
                {
                    nearClear = true;
                }
            }
            x = xCopy;
            y = yCopy;


            return nearClear;
        }
    }
}
