using System;
using System.Collections.Generic;
using System.Linq;
using GroceryStore.Customers;
using GroceryStore.Registers;

namespace GroceryStore.Utility
{
    public class DataMapper : IDataMapper
    {
        string[] _inputData;

        const int TRAINING = 2;

        const int REGULAR = 1;

        public DataMapper(string[] inputData)
        {
            _inputData = inputData;
        }

        public IRegisters GetRegisters()
        {
            var numberOfRegisters = Convert.ToInt32(_inputData[0]);

            var registers = new List<IRegister>(numberOfRegisters);

            for (int x = 0; x < numberOfRegisters; x++)
                registers.Add(x.Equals(numberOfRegisters - 1) ? (IRegister)new Register(x, TRAINING) : new Register(x, REGULAR));

            return new GroupOfRegisters(registers);
        }

        public IList<ICustomer> GetCustomers()
        {
            var results = new List<ICustomer>();

            for (int x = 1; x < _inputData.Count(); x++)
                results.Add(CreateCustomer(_inputData[x]));

            return results;
        }

        ICustomer CreateCustomer(string input)
        {
            var inputs = input.Split(' ');

            var timeOffset = Convert.ToInt32(inputs[1]);

            var numberOfItems = Convert.ToInt32(inputs[2]);

            switch (inputs[0])
            {
                case "A": return new Customer(timeOffset, numberOfItems, new TypeA());
                case "B": return new Customer(timeOffset, numberOfItems, new TypeB());
                default: throw new Exception("Unknown Customer Type received.");
            }
        }
    }
}