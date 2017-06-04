using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataLibrary;

namespace DataTest
{
    [TestClass]
    public class TestRecord
    {
        [TestMethod]
        public void TestToString()
        {
            NamedPoint p1 = new NamedPoint("p1", 1, 2, 3);
            Assert.AreEqual("p1,1,2,3", p1.ToCsv());
        }
        [TestMethod]
        public void TestGetXYZ()
        {
            NamedPoint p1 = new NamedPoint("p1", 10, 20, 30);
            Assert.AreEqual("p1", p1.GetName());
            Assert.AreEqual(10, p1.GetX());
            Assert.AreEqual(20, p1.GetY());
            Assert.AreEqual(30, p1.GetZ());
        }
        [TestMethod]
        public void TestMagnitude()
        {
            // we use a 5-12-13 triangle because that gives us a whole number answer
            NamedPoint p1 = new NamedPoint("p1", 5, 12, 0);
            Assert.AreEqual(13, p1.GetMagnitude());
        }
        [TestMethod]
        public void TestFromString()
        {
            NamedPoint c = NamedPoint.Parse("random, 10, 20, 30");
            Assert.AreEqual("random", c.GetName());
            Assert.AreEqual(10, c.GetX());
            Assert.AreEqual(20, c.GetY());
            Assert.AreEqual(30, c.GetZ());
        }
        [TestMethod]
        public void TestFromString_ExtraSpace()
        {
            NamedPoint c = NamedPoint.Parse("   random  , 10, 20, 30    ");
            Assert.AreEqual("random", c.GetName());
            Assert.AreEqual(10, c.GetX());
            Assert.AreEqual(20, c.GetY());
            Assert.AreEqual(30, c.GetZ());
        }
        /// <summary>
        /// Advanced testing of edge cases:
        /// ExpectedException verifies that this invocation throws an exception
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestFromString_BadRecord()
        {
            NamedPoint c = NamedPoint.Parse("// this is not a valid record");
        }
    }
}
