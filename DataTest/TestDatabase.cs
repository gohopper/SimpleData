using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataLibrary;
using System.Collections.Generic;

namespace DataTest
{
    [TestClass]
    public class TestDatabase
    {
        private const string DB_DATA =
            "red,255,0,0\n" +
            "green,0,0,255\n" +
            "blue,0,0,255\n";

        [TestMethod]
        public void TestConstructData()
        {
            DataManager db = new DataManager();
        }
        [TestMethod]
        public void TestLoadFromString()
        {
            StringReader reader = new StringReader(DB_DATA);
            DataManager db = new DataManager(reader);
            Assert.AreEqual(3, db.GetSize());
        }
    }
}
