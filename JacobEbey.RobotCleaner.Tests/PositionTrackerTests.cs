using JacobEbey.RobotCleaner.Math;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JacobEbey.RobotCleaner.Tests
{
    [TestClass]
    public class PositionTrackerTests
    {
        [TestMethod]
        public void TestPositionTrackerCreation()
        {
            Robot robot = new Robot(new Vector2(10, 10));
            PositionTracker tracker = new PositionTracker(robot);
            
            Assert.AreEqual(1, tracker.CalculatePositionsVisited());
        }

        [TestMethod]
        public void TestPositionTrackerCalculationPositiveStart()
        {
            Robot robot = new Robot(new Vector2(10, 10));
            PositionTracker tracker = new PositionTracker(robot);

            robot.Move(new Vector2(2, 0));
            robot.Move(new Vector2(0, 2));
            robot.Move(new Vector2(-2, 0));
            robot.Move(new Vector2(0, -2));

            Assert.AreEqual(8, tracker.CalculatePositionsVisited());
        }

        [TestMethod]
        public void TestPositionTrackerCalculationNegativeStart()
        {
            Robot robot = new Robot(new Vector2(-10, -10));
            PositionTracker tracker = new PositionTracker(robot);

            robot.Move(new Vector2(2, 0));
            robot.Move(new Vector2(0, 2));
            robot.Move(new Vector2(-2, 0));
            robot.Move(new Vector2(0, -2));

            Assert.AreEqual(8, tracker.CalculatePositionsVisited());
        }

        [TestMethod]
        public void TestRetraceSteps()
        {
            Robot robot = new Robot(new Vector2(-10, -10));
            PositionTracker tracker = new PositionTracker(robot);

            robot.Move(new Vector2(10, 0));
            robot.Move(new Vector2(-11, 0));

            Assert.AreEqual(12, tracker.CalculatePositionsVisited());
        }
    }
}
