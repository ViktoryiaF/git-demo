using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using tpo_lab3_unitTest;

namespace TriangleUnitTest
{
    [TestClass]
    public class TriangleUnitTests
    {
        [TestMethod]
        public void IsTriangleRight()
        {
            Assert.IsTrue(Triangle.IsTriangle(9, 6, 4));
        }

        [TestMethod]
        public void IsTrianglePossible()
        {
            Assert.IsFalse(Triangle.IsTriangle(21, 7, 9));
        }

        [TestMethod]
        public void CheckAllZeroSides()
        {
            Assert.IsFalse(Triangle.IsTriangle(0, 0, 0));
        }

        [TestMethod]
        public void CheckAllNegativeSides()
        {
            Assert.IsFalse(Triangle.IsTriangle(-11, -2, -6));
        }


        [TestMethod]
        public void CheckOneZeroSide()
        {
            Assert.IsFalse(Triangle.IsTriangle(0, 12, 23));
        }

        [TestMethod]
        public void CheckOneNegativeSide()
        {
            Assert.IsFalse(Triangle.IsTriangle(3, -4, 5));
        }

        [TestMethod]
        public void IsTriangleIsoscelesTriangle()
        {
            Assert.IsTrue(Triangle.IsTriangle(6, 6, 8));
        }

        [TestMethod]
        public void IsTriangleEquilateralTriangle()
        {
            Assert.IsTrue(Triangle.IsTriangle(13, 13, 13));
        }

        [TestMethod]
        public void IsTriangleExsist()
        {
            Assert.IsTrue(Triangle.IsTriangle(4, 7, 10));
        }

        [TestMethod]
        public void IsTriangleAvailible()
        {
            Assert.IsTrue(Triangle.IsTriangle(3, 4, 7));
        }
    }
}
