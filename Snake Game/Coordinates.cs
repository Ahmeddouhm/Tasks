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

        public override bool Equals(object? obj)
        {
            if (obj == null || !GetType().Equals(obj.GetType()))
            {
                return false;
            }

            Coordinates coord = (Coordinates)obj;
            return _x == coord._x && _y == coord._y;
        }

        public void ApplyMove(Directions direction) 
        {
            switch (direction)
            {
                case Directions.Up:
                    _y--;
                    break;
                case Directions.Left:
                    _x--;
                    break;
                case Directions.Down:
                    _y++;
                    break;
                case Directions.Right:
                    _x++;
                    break;
            }
        }
    }
}
