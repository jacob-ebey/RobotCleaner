using JacobEbey.RobotCleaner.Math;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JacobEbey.RobotCleaner
{
    /// <summary>
    /// This class is used to track the positions the robot has cleand within a room.
    /// </summary>
    public class PositionTracker
    {
        Robot robot;
        Vector2 initialPosition;

        Queue<Vector2> moves = new Queue<Vector2>();

        /// <summary>
        /// Initialize an instance of a <see cref="PositionTracker"/>.
        /// </summary>
        /// <param name="robot">The robot to track.</param>
        public PositionTracker(Robot robot)
        {
            if (robot == null) throw new ArgumentNullException(nameof(robot));

            this.robot = robot;

            initialPosition = this.robot.Position;

            this.robot.Moved += OnRobotMoved;
        }

        /// <summary>
        /// Calculate the number of positions the robot has visited.
        /// </summary>
        /// <returns>The number of unique positions visited.</returns>
        public int CalculatePositionsVisited()
        {
            lock (moves)
            {
                // If we have not moved then we have only visited one location i.e the initial position.
                if (moves.Count <= 0) return 1;

                // Create a cache to store the positions we've visited.
                // For a quick and dirty solution I've decided to go with
                // using the hash code of the positions formated as "({X},{Y})"
                // as the key in the dictionary and just doing a lookup along
                // the path the robot has moved.
                Dictionary<int, bool> positionsVisitedCache = new Dictionary<int, bool>();

                // This will be the resulting positions visited.
                int count = 0;

                // Start at the initial position and foreach move that was made,
                // check if each position along the move has been visited.
                Vector2 currentPosition = initialPosition;
                foreach (var move in moves)
                {
                    var lastPosition = currentPosition;
                    foreach (var position in PositionsAlongMove(currentPosition, move))
                    {
                        // Get if the current position has been visited.
                        bool visited = false;
                        positionsVisitedCache.TryGetValue(position.ToString().GetHashCode(), out visited);

                        // If this is the first time at this position, increment the count.
                        if (!visited)
                            count++;

                        // Store that we've visited this position as to not cound it again.
                        positionsVisitedCache[position.ToString().GetHashCode()] = true;

                        // Store the last position.
                        lastPosition = position;
                    }
                    // Store the current position after the moves.
                    currentPosition = lastPosition;
                }

                return count;
            }
        }

        /// <summary>
        /// Get points along the move command. (Quick and dirty)
        /// </summary>
        /// <param name="currentPosition">The current position to move from.</param>
        /// <param name="move">The direction to move.</param>
        /// <returns>Enumerable of positions between the current position and the resulting position of a move command.</returns>
        IEnumerable<Vector2> PositionsAlongMove(Vector2 currentPosition, Vector2 move)
        {
            if (move.X != 0 && move.Y != 0) throw new Exception("Must only move in one direction at a time.");

            if (move.X != 0)
            {
                if (move.X >= 0)
                {
                    for (int i = 0; i <= move.X; i++)
                        yield return new Vector2(currentPosition.X + i, currentPosition.Y);
                }
                else
                {
                    for (int i = 0; i >= move.X; i--)
                        yield return new Vector2(currentPosition.X + i, currentPosition.Y);
                }
            }
            else
            {
                if (move.Y >= 0)
                {
                    for (int i = 0; i <= move.Y; i++)
                        yield return new Vector2(currentPosition.X, currentPosition.Y + i);
                }
                else
                {
                    for (int i = 0; i >= move.Y; i--)
                        yield return new Vector2(currentPosition.X, currentPosition.Y + i);
                }
            }
        }

        /// <summary>
        /// Executed when the robot has been issued a move command.
        /// </summary>
        /// <param name="sender">The sending robot.</param>
        /// <param name="e">The event args of the robot move.</param>
        void OnRobotMoved(object sender, RobotMovedEventArgs e)
        {
            lock (moves)
            {
                moves.Enqueue(e.MovementDirection);
            }
        }
    }
}
