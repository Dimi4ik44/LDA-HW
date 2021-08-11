using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleGameHW6
{
    public static class Field
    {
        public static int XSize { get; private set; }
        public static int YSize { get; private set; }
        private static int[,] array;

        public static int[,] ChangeField { get { return array; } set { array = value; } }
        static Field()
        {

        }
        public static bool placeObj(int x, int y, Skins.SkinsList s, bool firstSpawn = false)
        {
            if(firstSpawn)
            {
                if (x >= 0 && x < XSize && y >= 0 && y < YSize && array[y, x] == (int)Skins.SkinsList.Empty)
                {
                    array[y, x] = (int)s;
                    return true;
                }
                
            }
            else
            {
                if (x >= 0 && x < XSize && y >= 0 && y < YSize && (array[y, x] == (int)Skins.SkinsList.Empty || array[y, x] == (int)Skins.SkinsList.DefaultPlayer || array[y, x] == (int)Skins.SkinsList.Stick))
                {
                    if(s == Skins.SkinsList.DefaultPlayer && array[y, x] == (int)Skins.SkinsList.Stick)
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
                    if(array[y, x] == (int)Skins.SkinsList.DefaultPlayer && Player.ShieldCount == 0)
                    {
                        Program.gameOver();
                    }
                    else if(array[y, x] == (int)Skins.SkinsList.DefaultPlayer && Player.ShieldCount > 0)
                    {
                        Player.ShieldCount--;
                        return false;
                    }
                    array[y, x] = (int)s;
                    return true;

                }
            }
            return false;
        }
        public static void clearObj(int x, int y, Skins.SkinsList s)
        {
            array[y, x] = (int)s;
        }
        public static void createNewField(int x,int y)
        {
            XSize = x;
            YSize = y;
            array = new int[YSize, XSize];
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

                    switch (array[i, k])
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
                    Console.Write($"  {Skins.skinImage[array[i, k]]}  ");
                    }
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("|\n");
                Console.ResetColor();
            }
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(sep);
                Console.ResetColor();

        }
        public static void rerenderShields()
        {

        }
    }
}
