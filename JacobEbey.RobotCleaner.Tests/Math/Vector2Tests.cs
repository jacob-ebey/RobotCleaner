using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using JacobEbey.RobotCleaner.Math;

namespace JacobEbey.RobotCleaner.Tests.Math
{
    [TestClass]
    public class Vector2Tests
    {
        [TestMethod]
        public void TestVector2Creation()
        {
            Vector2 vector = new Vector2(10, 11);
            Assert.AreEqual(10, vector.X);
            Assert.AreEqual(11, vector.Y);
        }

        [TestMethod]
        public void TestVectorAddition()
        {
            Vector2 vector = new Vector2(10, 11);

            vector += new Vector2(10, 11);
            Assert.AreEqual(20, vector.X);
            Assert.AreEqual(22, vector.Y);

            vector += new Vector2(-10, -11);
            Assert.AreEqual(10, vector.X);
            Assert.AreEqual(11, vector.Y);
        }
    }
}
