using JacobEbey.RobotCleaner.Math;
using System;

namespace JacobEbey.RobotCleaner
{
    /// <summary>
    /// Represents a robot that is capable of moving around a 2D plane.
    /// </summary>
    public class Robot
    {
        /// <summary>
        /// Initialize an instance of <see cref="Robot"/>.
        /// </summary>
        /// <param name="initialPosition"></param>
        public Robot(Vector2 initialPosition)
        {
            Position = initialPosition;
        }

        /// <summary>
        /// The current position of the robot.
        /// </summary>
        public Vector2 Position { get; private set; }

        /// <summary>
        /// Move the robot in the given direction.
        /// </summary>
        /// <param name="movementDirection">The direction to move.</param>
        public void Move(Vector2 movementDirection)
        {
            Position += movementDirection;

            OnMoved(new RobotMovedEventArgs(movementDirection));
        }

        /// <summary>
        /// Raises the <see cref="Moved"/> event.
        /// </summary>
        /// <param name="e">The event args to pass to the event handler.</param>
        protected virtual void OnMoved(RobotMovedEventArgs e)
        {
            Moved?.Invoke(this, e);
        }

        /// <summary>
        /// Raised when the robot has moved.
        /// </summary>
        public event EventHandler<RobotMovedEventArgs> Moved;
    }

    /// <summary>
    /// Event args that contain information about the latest move the robot has performed.
    /// </summary>
    public class RobotMovedEventArgs : EventArgs
    {
        /// <summary>
        /// Initialize an instance of <see cref="RobotMovedEventArgs"/>.
        /// </summary>
        /// <param name="movementDirection"></param>
        public RobotMovedEventArgs(Vector2 movementDirection)
        {
            MovementDirection = movementDirection;
        }

        /// <summary>
        /// The direction that the robot has moved.
        /// </summary>
        public Vector2 MovementDirection { get; }
    }
}