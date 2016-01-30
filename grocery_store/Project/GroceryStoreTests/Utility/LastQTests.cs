using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GroceryStore.Utility;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace GroceryStore.Utility.Tests
{
    [TestClass()]
    public class LastQTests
    {
        private LastQ<int> _days = null;

        [TestInitialize]
        public void TestSetup()
        {
            _days = new LastQ<int>();
        }
            
        [TestMethod()]
        public void Enqueue_TestForMatch_Success()
        {
            _days.Enqueue(1);
            Assert.AreEqual(1, _days.Dequeue());
        }

        [TestMethod]
        public void Last_LastQueuedItemStoredCorrectly_Success()
        {
            _days.Enqueue(5);   
            Assert.AreEqual(5,_days.Last);
        }
    }
}
