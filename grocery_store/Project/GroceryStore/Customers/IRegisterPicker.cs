using GroceryStore.Registers;

namespace GroceryStore.Customers
{
    //This is used to encapsulate the customer's
    //decision when picking a register
    public interface IRegisterPicker
    {
        int PickRegister(IRegisters registers);
    }
}