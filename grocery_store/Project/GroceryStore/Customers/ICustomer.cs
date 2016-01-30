using GroceryStore.Registers;

namespace GroceryStore.Customers
{
    public interface ICustomer
    {
        IRegisterPicker Picker { get; }

        int NumberOfItems { get; set; }

        int ArrivalTime { get; }

        int ChooseRegister(IRegisters registers);
    }
}