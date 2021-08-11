using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleGameHW6
{
    class Shield
    {
        public static Shield[] shields;
        public int XPos { get; private set; } = 0;
        public int YPos { get; private set; } = 0;
        public Skins.SkinsList skin { get; set; } = Skins.SkinsList.Stick;
        public Shield()
        {
            spawn();
        }
        public Shield(int XPos, int YPos)
        {
            this.XPos = XPos;
            this.YPos = YPos;
            spawn();
        }
        public Shield(int XPos, int YPos, Skins.SkinsList skin)
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
        public void reSpawn()
        {
            Field.placeObj(XPos, YPos, skin);

        }

    }
}
