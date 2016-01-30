using GroceryStore.Customers;

namespace GroceryStore.Registers
{
    public interface IRegister
    {
        int RegisterId { get; }

        void Add(ICustomer newCustomer);

        int GetLastCustomerItemsRemaining();

        int GetCustomersInLine();

        bool ProcessItems();
    }
}