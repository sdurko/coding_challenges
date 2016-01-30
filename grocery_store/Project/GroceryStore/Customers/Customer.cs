using GroceryStore.Registers;

namespace GroceryStore.Customers
{
    public class Customer : ICustomer
    {
        public IRegisterPicker Picker { get; private set; }

        public int NumberOfItems { get; set; }

        public int ArrivalTime { get; private set; }

        public Customer(int arrivalTime, int numberOfItems, IRegisterPicker picker)
        {
            Picker = picker;
            ArrivalTime = arrivalTime;
            NumberOfItems = numberOfItems;
        }

        public int ChooseRegister(IRegisters registers)
        {
            return Picker.PickRegister(registers);
        }
    }
}