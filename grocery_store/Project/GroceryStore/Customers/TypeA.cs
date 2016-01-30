using GroceryStore.Registers;

namespace GroceryStore.Customers
{
    //Represents a "Type A choice"
    public class TypeA : IRegisterPicker
    {
        public int PickRegister(IRegisters registers)
        {
            return registers.GetRegisterWithShortestLine();
        }
    }
}