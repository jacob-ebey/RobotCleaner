﻿using JacobEbey.RobotCleaner.Math;
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

        Vector2 boundsLow, boundsHigh;

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

            boundsLow = initialPosition;
            boundsHigh = initialPosition;

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
                if (moves.Count <= 0) return 1;

                Dictionary<int, bool> positionsVisitedCache = new Dictionary<int, bool>();

                int count = 0;

                Vector2 currentPosition = initialPosition;
                foreach (var move in moves)
                {
                    var lastPosition = currentPosition;
                    foreach (var position in PositionsAlongMove(currentPosition, move))
                    {
                        bool visited = false;
                        positionsVisitedCache.TryGetValue(position.GetHashCode(), out visited);
                        if (!visited)
                            count++;

                        positionsVisitedCache[position.GetHashCode()] = true;

                        lastPosition = position;
                    }
                    currentPosition = lastPosition;
                }

                return count;
            }
        }

        /// <summary>
        /// Get points along the move command.
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
