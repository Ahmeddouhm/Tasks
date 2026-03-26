using System;
using System.Collections.Generic;
using System.Text;

namespace Snake_Game
{
    internal class Coordinates
    {
        private int _x;
        private int _y;

        public int X { get { return _x; } }
        public int Y { get { return _y; } }

        public Coordinates(int x , int y)
        {
            this._x = x;
            this._y = y;
        }
    }
}
