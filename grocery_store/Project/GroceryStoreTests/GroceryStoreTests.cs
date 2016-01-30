using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GroceryStore;
using GroceryStore.Time;
using GroceryStore.Utility;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace GroceryStore.Tests
{
    [TestClass()]
    public class GroceryStoreTests
    {
        GroceryStore _groceryStore;

        [TestInitialize]
        public void TestSetup()
        {
            string[] data = new string[3];
            data[0] = "1";
            data[1] = "A 1 2";
            data[2] = "A 1 1";

            _groceryStore = new GroceryStore(new DataMapper(data), new Clock());
        }

        [TestMethod()]
        public void GroceryStoreTest()
        {
            Assert.Inconclusive();
        }

        [TestMethod()]
        public void StartTest()
        {
            Assert.Inconclusive();
        }
    }
}
