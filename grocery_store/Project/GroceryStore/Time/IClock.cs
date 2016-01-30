namespace GroceryStore.Time
{
    public interface IClock
    {
        void Tick();
        int GetCurrentMinute();
    }
}