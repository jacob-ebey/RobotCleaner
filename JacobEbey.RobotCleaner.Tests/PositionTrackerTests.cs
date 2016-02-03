using Microsoft.VisualStudio.TestTools.UnitTesting;

using JacobEbey.RobotCleaner.Math;

namespace JacobEbey.RobotCleaner.Tests
{
    /// <summary>
    /// The test fixture for <see cref="JacobEbey.RobotCleaner.PositionTracker"/>.
    /// </summary>
    [TestClass]
    public class PositionTrackerTests
    {
        /// <summary>
        /// Verify that the position tracker's initial calculation works for
        /// <see cref="PositionTracker.CalculatePositionsVisited"/>.
        /// </summary>
        [TestMethod]
        public void TestPositionTrackerCreation()
        {
            Robot robot = new Robot(new Vector2(10, 10));
            PositionTracker tracker = new PositionTracker(robot);
            
            Assert.AreEqual(1, tracker.CalculatePositionsVisited());
        }

        /// <summary>
        /// Verify that starting in the positive grid works.
        /// </summary>
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

        /// <summary>
        /// Verify that starting in the negative grid works.
        /// </summary>
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

        /// <summary>
        /// Verify that retracing your steps calculates the correct value.
        /// </summary>
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
