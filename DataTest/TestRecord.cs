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
            NamedPoint p1 = new NamedPoint("p1", 1, 2);
            Assert.AreEqual("p1,1,2", p1.ToCsv());
        }
        [TestMethod]
        public void TestGetXYZ()
        {
            NamedPoint p1 = new NamedPoint("p1", 10, 20);
            Assert.AreEqual("p1", p1.GetName());
            Assert.AreEqual(10, p1.GetX());
            Assert.AreEqual(20, p1.GetY());
        }
        [TestMethod]
        public void TestMagnitude()
        {
            // we use a 5-12-13 triangle because that gives us a whole number answer
            NamedPoint p1 = new NamedPoint("p1", 5, 12);
            Assert.AreEqual(13, p1.GetMagnitude());
        }
        [TestMethod]
        public void TestFromString()
        {
            NamedPoint c = NamedPoint.Parse("random, 10, 20");
            Assert.AreEqual("random", c.GetName());
            Assert.AreEqual(10, c.GetX());
            Assert.AreEqual(20, c.GetY());
        }
        [TestMethod]
        public void TestFromString_ExtraSpace()
        {
            NamedPoint c = NamedPoint.Parse("   random  ,  10 ,  20    ");
            Assert.AreEqual("random", c.GetName());
            Assert.AreEqual(10, c.GetX());
            Assert.AreEqual(20, c.GetY());
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
