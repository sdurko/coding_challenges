using System.Collections.Generic;
using GroceryStore.Customers;
using GroceryStore.Registers;

namespace GroceryStore.Utility
{
    public interface IDataMapper
    {
        IRegisters GetRegisters();
        IList<ICustomer> GetCustomers();
    }
}