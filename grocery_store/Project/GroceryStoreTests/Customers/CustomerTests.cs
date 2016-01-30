using System.Collections.Generic;
using GroceryStore.Registers;
using GroceryStore.Time;
using GroceryStore.Utility;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GroceryStore.Customers.Tests
{
    [TestClass]
    public class CustomerTests
    {
        private Customer _customer;

        [TestInitialize]
        public void TestSetup()
        {
            _customer = new Customer(2, 5, new TypeA());
        }

        [TestMethod()]
        public void Customer_TestForMatch_Success()
        {
            Assert.AreEqual(2,_customer.ArrivalTime);
            Assert.AreEqual(5, _customer.NumberOfItems);
            Assert.IsInstanceOfType(_customer.Picker,typeof(TypeA));
        }

        [TestMethod()]
        public void ChooseRegister_TestForValid_Success()
        {
            var registerList = new List<IRegister> {new Register(1, 2)};

            var result =  _customer.ChooseRegister(new GroupOfRegisters(registerList));

            Assert.AreEqual(1,result);
        }}
}
