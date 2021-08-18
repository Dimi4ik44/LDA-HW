using System;
using System.Collections.Generic;
using System.Text;

namespace test
{
    class Positions
    {
        object[,] posNameAndSallory = new object[5, 2]
        {
            { "PosName1",200 },
            { "PosName2",300 },
            { "PosName3",400 },
            { "PosName4",500 },
            { "PosName5",600 },
        };
        public void ShowPositions()
        {
            for (int i = 0; i < posNameAndSallory.GetLength(0); i++)
            {
                Console.Write(posNameAndSallory[i, 0] + ":" + posNameAndSallory[i, 1]);
            }
        }

    }
}

