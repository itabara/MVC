using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MVCGridPaging.Models;

namespace MVCGridPaging.Tests
{
    [TestClass]
    public class DatabaseUnitTest
    {
        [TestMethod]
        public void TestFillData()
        {
            var dbHelper = new DatabaseHelper();
            int rowsInserted = dbHelper.FillData();
            Assert.IsTrue(rowsInserted > 0, "Cannot fill database");
        }
    }
}
