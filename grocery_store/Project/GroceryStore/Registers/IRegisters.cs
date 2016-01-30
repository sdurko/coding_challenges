using System.Collections.Generic;
using GroceryStore.Customers;

namespace GroceryStore.Registers
{
    public interface IRegisters
    {        
        bool ProcessCurrentCustomersItems();

        int GetRegisterWithShortestLine();
        
        bool TryGetEmptyRegister(out int emptyRegister);
        
        int GetRegisterByLastCustomerWithFewestItemsLeft();
        
        void AddCustomers(IList<ICustomer> customers);
    }
}