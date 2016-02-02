using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JacobEbey.RobotCleaner.Math
{
    /// <summary>
    /// A simple 2D Vector
    /// </summary>
    public struct Vector2
    {
        /// <summary>
        /// Initialize an instance of <see cref="Vector2"/>.
        /// </summary>
        /// <param name="x">The x value of the vector.</param>
        /// <param name="y">The y value of the vector.</param>
        public Vector2(int x, int y)
        {
            X = x;
            Y = y;
        }

        /// <summary>
        /// Gets or sets the X value.
        /// </summary>
        public int X { get; set; }

        /// <summary>
        /// Gets or sets the Y value.
        /// </summary>
        public int Y { get; set; }

        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }

        public override string ToString()
        {
            return $"({X},{Y})";
        }

        /// <summary>
        /// Create a vector that represents a position provided to the application.
        /// </summary>
        /// <param name="s">A string in the format of "{XValue} {YValue}"./param>
        /// <returns>A new vector that reflects the given input value.</returns>
        public static Vector2 PositionFromString(string s)
        {
            var splitData = s.Split(' ');

            return new Vector2(int.Parse(splitData[0]), int.Parse(splitData[1]));
        }

        /// <summary>
        /// Create a vector that represents the direction to move based on the application input.
        /// </summary>
        /// <param name="s">A string in the format of "{Direction} {ValueToMove}" where Direction is N (north), S (south), E (east) or W (west).</param>
        /// <returns>A vector representing a direction to move based on the given input.</returns>
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
