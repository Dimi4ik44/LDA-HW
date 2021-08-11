using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleGameHW6
{
    class Player
    {
        static int playerCount;

        public int XPos { get; private set; } = 0;
        public int YPos { get; private set; } = 0;

        public Skins.SkinsList skin { get; set; } = Skins.SkinsList.DefaultPlayer;
        public Player()
        {
            playerCount++;
            spawn();
        }
        public Player(int XPos, int YPos)
        {
            playerCount++;
            this.XPos = XPos;
            this.YPos = YPos;
            spawn();
        }
        public Player(int XPos, int YPos, Skins.SkinsList skin)
        {
            playerCount++;
            this.XPos = XPos;
            this.YPos = YPos;
            this.skin = skin;
            spawn();
        }
        public void spawn()
        {
            if (!Field.placeObj(XPos, YPos, skin))
            {
                Random rnd = new Random();
                do
                {
                    XPos = rnd.Next(0, Field.XSize);
                    YPos = rnd.Next(0, Field.YSize);
                }
                while (!Field.placeObj(XPos, YPos, skin));
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
    }
}
