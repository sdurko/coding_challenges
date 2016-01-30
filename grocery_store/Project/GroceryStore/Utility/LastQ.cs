using System.Collections.Generic;

namespace GroceryStore.Utility
{
    //This class provides the ability to see the last item
    //added to a queue.  It is ultimately used to view the 
    //customer recently added to a register line.
    public class LastQ <T> : Queue<T>
    {
        public T Last { get; private set; }

        public new void Enqueue(T item)
        {
            Last = item;
            base.Enqueue(item);
        }
    }
}