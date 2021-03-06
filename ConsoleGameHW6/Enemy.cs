using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleGameHW6
{
    class Enemy
    {
        public static int enemyCount;
        public static Enemy[] enemys;

        public int XPos { get; private set; } = 0;
        public int YPos { get; private set; } = 0;

        public Skins.SkinsList skin { get; set; } = Skins.SkinsList.Enemy;
        public Enemy()
        {
            enemyCount++;
            spawn();
        }
        public Enemy(int XPos, int YPos)
        {
            enemyCount++;
            this.XPos = XPos;
            this.YPos = YPos;
            spawn();
        }
        public Enemy(int XPos, int YPos, Skins.SkinsList skin)
        {
            enemyCount++;
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

        public void move(int direction)
        {
            switch (direction)
            {
                case 1:
                    if (Field.placeObj(XPos, YPos - 1, skin))
                    {
                        Field.clearObj(XPos, YPos, Skins.SkinsList.Empty);
                        YPos -= 1;
                    }
                    break;
                case 2:
                    if (Field.placeObj(XPos, YPos + 1, skin))
                    {
                        Field.clearObj(XPos, YPos, Skins.SkinsList.Empty);
                        YPos += 1;
                    }
                    break;
                case 3:
                    if (Field.placeObj(XPos - 1, YPos, skin))
                    {
                        Field.clearObj(XPos, YPos, Skins.SkinsList.Empty);
                        XPos -= 1;
                    }
                    break;
                case 4:
                    if (Field.placeObj(XPos + 1, YPos, skin))
                    {
                        Field.clearObj(XPos, YPos, Skins.SkinsList.Empty);
                        XPos += 1;
                    }
                    break;
            }
        }
        public static void addEnemy()
        {
            Enemy[] en = new Enemy[enemys.Length + 1];
            for (int i = 0; i < enemys.Length; i++)
            {
                en[i] = enemys[i];
            }
            en[en.Length - 1] = new Enemy();
            enemys = en;
        }
    }
}
