using System;
using System.Collections.Generic;
using System.Text;

namespace TETRIS
{
    class Game
    {
        public bool EndGame { get; set; }
        public Field GameField { get; set; }
        public Controls _Controls { get; set; }
        public List<Shape> Shapes { get; set; }
        public Shape NextShape { get; set; }
        public Game(List<Shape> allowShapes, int fieldHeight, int fieldLength)
        {
            GameField = new Field(fieldHeight,fieldLength);
            EndGame = false;
            Shapes = allowShapes;
            _Controls = new Controls();
        }
    }
}
