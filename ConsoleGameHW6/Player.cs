using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleGameHW6
{
    class Player
    {

        public int XPos { get; private set; } = 0;
        public int YPos { get; private set; } = 0;
        public static int ShieldCount { get; set; } = 2; // shield

        public Skins.SkinsList skin { get; set; } = Skins.SkinsList.DefaultPlayer;
        public Player()
        {
            spawn();
        }
        public Player(int XPos, int YPos)
        {
            this.XPos = XPos;
            this.YPos = YPos;
            spawn();
        }
        public Player(int XPos, int YPos, Skins.SkinsList skin)
        {
            this.XPos = XPos;
            this.YPos = YPos;
            this.skin = skin;
            spawn();
        }
        public void spawn()
        {
            if (!Field.placeObj(XPos, YPos, skin, true))
            {
                Random rnd = new Random();
                do
                {
                    XPos = rnd.Next(0, Field.XSize);
                    YPos = rnd.Next(0, Field.YSize);
                }
                while (!Field.placeObj(XPos, YPos, skin, true));
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Cant spawn at this pos, will be select random spawn pos");
                Console.ResetColor();
            }
        }
        public bool move(int direction)
        {
            switch (direction)
            {
                case 1:                  
                    if(Field.placeObj(XPos, YPos - 1, skin))
                    {
                        Field.clearObj(XPos, YPos, Skins.SkinsList.Empty);
                        YPos -= 1;
                        return true;
                    }
                    return false;                 
                case 2:
                    if (Field.placeObj(XPos, YPos + 1, skin))
                    {
                        Field.clearObj(XPos, YPos, Skins.SkinsList.Empty);
                        YPos += 1;
                        return true;
                    }
                    return false;
                case 3:
                    if (Field.placeObj(XPos - 1, YPos, skin))
                    {
                        Field.clearObj(XPos, YPos, Skins.SkinsList.Empty);
                        XPos -= 1;
                        return true;
                    }
                    return false;
                case 4:
                    if (Field.placeObj(XPos + 1, YPos, skin))
                    {
                        Field.clearObj(XPos, YPos, Skins.SkinsList.Empty);
                        XPos += 1;
                        return true;
                    }
                    return false;
            }
            return false;
        }
        public void addShield() // shield
        {
            ShieldCount ++;
        }
    }
}
