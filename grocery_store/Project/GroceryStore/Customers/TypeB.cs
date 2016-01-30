using GroceryStore.Customers;

namespace GroceryStore.Registers
{
    //Represents a "Type B choice"
    public class TypeB : IRegisterPicker
    {
        public int PickRegister(IRegisters registers)
        {
            int emptyRegister;

            //Is there an empty register?  
            if (registers.TryGetEmptyRegister(out emptyRegister))
                return emptyRegister;  //yes->return register index 
            else
            {
                //no->look at the last customer in each line for the the fewest items left
                return registers.GetRegisterByLastCustomerWithFewestItemsLeft();
            }
        }
    }
}