using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JacobEbey.RobotCleaner.Math
{
    public struct Vector2
    {
        public Vector2(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; set; }

        public int Y { get; set; }

        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }

        public override string ToString()
        {
            return $"({X},{Y})";
        }

        public static Vector2 PositionFromString(string s)
        {
            var splitData = s.Split(' ');

            return new Vector2(int.Parse(splitData[0]), int.Parse(splitData[1]));
        }

        public static Vector2 MoveDirectionFromString(string s)
        {
            var splitData = s.Split(' ');
            int movement = int.Parse(splitData[1]);

            if (splitData[0][0] == 'N')
                return new Vector2(0, movement);
            if (splitData[0][0] == 'S')
                return new Vector2(0, -movement);
            if (splitData[0][0] == 'E')
                return new Vector2(movement, 0);
            if (splitData[0][0] == 'W')
                return new Vector2(-movement, 0);

            return new Vector2();
        }

        public static Vector2 operator +(Vector2 v1, Vector2 v2) => new Vector2(v1.X + v2.X, v1.Y + v2.Y);

        public static Vector2 operator +(Vector2 v1, int v2) => new Vector2(v1.X + v2, v1.Y + v2);

        public static Vector2 operator -(Vector2 v1, Vector2 v2) => new Vector2(v1.X - v2.X, v1.Y - v2.Y);

        public static Vector2 operator -(Vector2 v1, int v2) => new Vector2(v1.X - v2, v1.Y - v2);
    }
}
