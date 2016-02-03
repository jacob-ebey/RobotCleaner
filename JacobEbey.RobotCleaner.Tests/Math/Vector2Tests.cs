using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using JacobEbey.RobotCleaner.Math;

namespace JacobEbey.RobotCleaner.Tests.Math
{
    /// <summary>
    /// The test fixture for <see cref="JacobEbey.RobotCleaner.Math.Vector2"/>.
    /// </summary>
    [TestClass]
    public class Vector2Tests
    {
        /// <summary>
        /// Verify that the vector is created correctly.
        /// </summary>
        [TestMethod]
        public void TestVector2Creation()
        {
            Vector2 vector = new Vector2(10, 11);
            Assert.AreEqual(10, vector.X);
            Assert.AreEqual(11, vector.Y);
        }

        /// <summary>
        /// Verify that vector addition works.
        /// </summary>
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
