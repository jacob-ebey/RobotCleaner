using Microsoft.VisualStudio.TestTools.UnitTesting;

using JacobEbey.RobotCleaner.Math;

namespace JacobEbey.RobotCleaner.Tests
{
    /// <summary>
    /// The test fixture for <see cref="JacobEbey.RobotCleaner.Robot"/>.
    /// </summary>
    [TestClass]
    public class RobotTests
    {
        /// <summary>
        /// Verify that the robot's initial position is correct.
        /// </summary>
        [TestMethod]
        public void TestRobotCreation()
        {
            Robot robot = new Robot(new Vector2(10, 11));

            Assert.AreEqual(10, robot.Position.X);
            Assert.AreEqual(11, robot.Position.Y);
        }

        /// <summary>
        /// Verify that the robot's move functionality works.
        /// </summary>
        [TestMethod]
        public void TestRobotMove()
        {
            Robot robot = new Robot(new Vector2(10, 11));

            robot.Move(new Vector2(10, 0));
            Assert.AreEqual(20, robot.Position.X);
            Assert.AreEqual(11, robot.Position.Y);

            robot.Move(new Vector2(0, 11));
            Assert.AreEqual(20, robot.Position.X);
            Assert.AreEqual(22, robot.Position.Y);

            robot.Move(new Vector2(-10, -11));
            Assert.AreEqual(10, robot.Position.X);
            Assert.AreEqual(11, robot.Position.Y);
        }
    }
}
