using System;
using System.Collections.Generic;
using System.Linq;
using GroceryStore.Customers;

namespace GroceryStore.Registers
{
    public class GroupOfRegisters : IRegisters
    {
        private IList<IRegister> _registers;

        public GroupOfRegisters(IList<IRegister> registers)
        {
            _registers = registers;
        }

        public bool ProcessCurrentCustomersItems()
        {
            var result = false;

            foreach (var register in _registers.Where(register => register.ProcessItems()))
                result = true;

            return result;
        }

        public int GetRegisterWithShortestLine()
        {
            return _registers.OrderBy(r => r.GetCustomersInLine()).ThenBy(r => r.RegisterId).First().RegisterId;
        }

        public bool TryGetEmptyRegister(out int emptyRegister)
        {
            emptyRegister = -1;

            var emptyRegisters = _registers.Where(r => r.GetCustomersInLine() == 0).OrderBy(r => r.RegisterId);

            if (emptyRegisters.Any())
            {
                emptyRegister = emptyRegisters.First().RegisterId;
               
                return true;
            }

            return false;
        }

        public int GetRegisterByLastCustomerWithFewestItemsLeft()
        {
            return _registers.OrderBy(r => r.GetLastCustomerItemsRemaining()).First().RegisterId;
        }

        public void AddCustomers(IList<ICustomer> customers)
        {
            foreach (var customer in customers)
            {
                try
                {
                    var registerChosen = customer.ChooseRegister(this);
                    _registers[registerChosen].Add(customer);   
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    throw;
                }
            }
        }   
    }
}