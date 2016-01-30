using System;
using GroceryStore.Customers;
using GroceryStore.Utility;

namespace GroceryStore.Registers
{
    public class Register : IRegister
    {
        readonly LastQ<ICustomer> _customers = new LastQ<ICustomer>();

        readonly int _itemMultiplier;

        public int RegisterId { get; private set; }

        public Register(int registerId, int itemMultiplier)
        {
            RegisterId = registerId;
            _itemMultiplier = itemMultiplier;
        }

        public bool ProcessItems()
        {
            if (_customers.Count <= 0)
                return false;

            var currentCustomer = _customers.Peek();

            if (currentCustomer.NumberOfItems > 0)
            {
                currentCustomer.NumberOfItems -= 1;

                if (currentCustomer.NumberOfItems <= 0)
                    _customers.Dequeue();
            }

            return true;
        }

        public void Add(ICustomer newCustomer)
        {
            newCustomer.NumberOfItems *= _itemMultiplier; //2 for TRAINING, 1 for REGULAR

            _customers.Enqueue(newCustomer);
        }

        public int GetCustomersInLine()
        {
            return _customers.Count;
        }

        public int GetLastCustomerItemsRemaining()
        {
            return _customers.Last.NumberOfItems;
        }
    }
}