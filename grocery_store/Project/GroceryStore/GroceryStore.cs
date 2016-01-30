using System;
using System.Collections.Generic;
using System.Linq;
using GroceryStore.Customers;
using GroceryStore.Time;
using GroceryStore.Registers;
using GroceryStore.Utility;

namespace GroceryStore
{
    public class GroceryStore : IGroceryStore
    {
        private IRegisters _registers = null;

        private readonly IList<ICustomer> _customers = null;

        private readonly IClock _clock = null;

        public GroceryStore(IDataMapper dataMapper, IClock clock)
        {
            _registers = dataMapper.GetRegisters();

            _customers = dataMapper.GetCustomers();

            _clock = clock;
        }
        
        public void Start()
        {
            do
            {
                _clock.Tick();

                //see if there is a customer to add to the registers. if there is more then one... sort by number of items and if equal, b customer type A before B
                var customersArriving = _customers
                    .Where(c => c.ArrivalTime == _clock.GetCurrentMinute())
                    .OrderBy(c=>c.NumberOfItems)
                    .ThenBy(c => c.Picker.GetType() == typeof(TypeB));

                if (customersArriving.Any())
                    _registers.AddCustomers(customersArriving.ToList());

            } while (_registers.ProcessCurrentCustomersItems()); //process items first for customers in line. We do this so customers leaving in line won;t be counted and effect the results of new customers picking a register.

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(string.Format("Finished at: t={0} minutes.", _clock.GetCurrentMinute()));
        }
    }
}