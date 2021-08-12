using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleGameHW6
{
    public static class Skins
    {
       public enum SkinsList
        {
            Empty = 0,
            DefaultPlayer = 1,
            Enemy = 2,
            Stick = 3,
            Wall = 4,
            Tree = 5
        }
       public static char[] skinImage = new char[] { '0', '☺', '☻', '\\', 'W', 'T' };
    }

}
