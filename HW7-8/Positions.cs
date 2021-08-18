using System;
using System.Collections.Generic;
using System.Text;

namespace HW7_8
{
    class Positions
    {
        Position[] positions = new Position[10];
        public Positions()
        {
            for (int i = 0; i < positions.Length; i++)
            {
                positions[i] = new Position();
            }
        }
        public Positions(Position[] positions)
        {
            this.positions = positions;
        }
        public Position GetPositionById(int id)
        {
            if(id < positions.Length && id >= 0)
            {
                for (int i = 0; i < positions.Length; i++)
                {
                    if (i == id - 1 && positions[i].Inited)
                    {
                        return positions[i];
                    }
                }
            }
            return new Position();
        }


    }
}
