using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GroceryStore.Time;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace GroceryStore.Time.Tests
{
    [TestClass()]
    public class ClockTests
    {
        private IClock _clock;

        [TestInitialize]
        public void SetupTests()
        {
            _clock = new Clock();
        }

        [TestMethod]
        public void TickTest()
        {
            _clock.Tick();
            Assert.AreEqual(1,_clock.GetCurrentMinute());
        }

        [TestMethod]
        public void GetCurrentMinuteTest()
        {
            Assert.AreEqual(0,_clock.GetCurrentMinute());
        }
    }
}
