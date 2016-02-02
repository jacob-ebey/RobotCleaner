using JacobEbey.RobotCleaner.Math;
using System;

namespace JacobEbey.RobotCleaner
{
    public class Robot
    {
        public Robot(Vector2 initialPosition)
        {
            Position = initialPosition;
        }

        public Vector2 Position { get; private set; }

        public void Move(Vector2 movementDirection)
        {
            Position += movementDirection;

            OnMoved(new RobotMovedEventArgs(movementDirection));
        }

        protected virtual void OnMoved(RobotMovedEventArgs e)
        {
            Moved?.Invoke(this, e);
        }

        public event EventHandler<RobotMovedEventArgs> Moved;
    }

    public class RobotMovedEventArgs : EventArgs
    {
        public RobotMovedEventArgs(Vector2 movementDirection)
        {
            MovementDirection = movementDirection;
        }

        public Vector2 MovementDirection { get; }
    }
}