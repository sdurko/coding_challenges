namespace GroceryStore.Time
{
    public class Clock : IClock
    {
        private int _counter = 0;

        public void Tick()
        {
            _counter++;
        }

        public int GetCurrentMinute()
        {
            return _counter;
        }
    }
}