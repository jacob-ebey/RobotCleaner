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
    public class RobotTests
    {
        [TestMethod]
        public void TestRobotCreation()
        {
            Robot robot = new Robot(new Vector2(10, 11));

            Assert.AreEqual(10, robot.Position.X);
            Assert.AreEqual(11, robot.Position.Y);
        }

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
