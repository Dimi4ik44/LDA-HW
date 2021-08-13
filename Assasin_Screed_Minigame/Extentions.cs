using System;
using System.Collections.Generic;
using System.Text;

namespace Assasin_Screed_Minigame
{
    public static class Extentions
    {
        public static bool IsPlayer(this Entity e)
        {
            return e is Player;
        }
        public static bool IsEnemy(this Entity e)
        {
            return e is Enemy;
        }
    }
}
