using JacobEbey.RobotCleaner.Math;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JacobEbey.RobotCleaner.Applicaton
{
    class Program
    {
        static void Main(string[] args)
        {
            // Read the count of the commands that will follow.
            int commandCount = int.Parse(Console.ReadLine());
            
            // Get the start position of the robot.
            Vector2 startPosition = Vector2.PositionFromString(Console.ReadLine());

            // Create the robot and the tracker.
            Robot robot = new Robot(startPosition);
            PositionTracker tracker = new PositionTracker(robot);

            // Loop until we have read all commands.
            for (int i = 0; i < commandCount; i++)
            {
                // Read the line and create a movement vector.
                var line = Console.ReadLine();
                Vector2 movement = Vector2.MoveDirectionFromString(line);

                // Move the robot.
                robot.Move(movement);
            }

            // Calculate and display the unique positions visited by the robot.
            Console.WriteLine($"=> Cleaned: {tracker.CalculatePositionsVisited()}");
        }
    }
}
